﻿using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinjaUnit._8.TestingHouseKeeper
{
    [TestFixture]
    public class Another_Interaction_Test
    {
        private RefacHouseKeeperHelper _service;
        private Mock<IStatementGenerator> _statementGenerator;
        private Mock<IEmailSender> _emailSender;
        private Mock<IXtraMessageBox> _messageBox;
        private DateTime _statementDate = new DateTime(2017, 1, 1);
        private Housekeeper _houseKeeper;
        private readonly string _statementFileName = "fileName";

        [SetUp]
        public void SetUp()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            _houseKeeper = new Housekeeper
            {
                Email = "a",
                FullName = "b",
                Oid = 1,
                StatementEmailBody = "c"
            };
            unitOfWork.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                _houseKeeper
            }.AsQueryable());

            _statementGenerator = new Mock<IStatementGenerator>();
            _emailSender = new Mock<IEmailSender>();
            _messageBox = new Mock<IXtraMessageBox>();

            _service = new RefacHouseKeeperHelper(unitOfWork.Object
                , _statementGenerator.Object,
                _emailSender.Object,
                _messageBox.Object);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatement()
        {
            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg => sg.SaveStatement(_houseKeeper.Oid,
                _houseKeeper.FullName,
                (_statementDate)));
        }
        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsNull_ShouldNotGenerateStatement()
        {
            _houseKeeper.Email = null;

            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg => sg.SaveStatement(_houseKeeper.Oid,
                _houseKeeper.FullName,
                (_statementDate)),
                Times.Never);
        }
        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsWhitespace_ShouldNotGenerateStatement()
        {
            _houseKeeper.Email = " ";

            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg => sg.SaveStatement(_houseKeeper.Oid,
                _houseKeeper.FullName,
                (_statementDate)),
                Times.Never);
        }
        [Test]
        public void SendStatementEmails_HouseKeepersEmailIsEmpty_ShouldNotGenerateStatement()
        {
            _houseKeeper.Email = "";

            _service.SendStatementEmails(_statementDate);

            _statementGenerator.Verify(sg => sg.SaveStatement(_houseKeeper.Oid,
                _houseKeeper.FullName,
                (_statementDate)),
                Times.Never);
        }
        [Test]
        public void SendStatementEmails_WhenCalled_EmailTheStatement()
        {
            _statementGenerator.Setup(sg => sg.SaveStatement(_houseKeeper.Oid,
                _houseKeeper.FullName,
                (_statementDate))
                ).Returns(() => null);

            _service.SendStatementEmails(_statementDate);

            _emailSender.Verify(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Times.Never);

        }
        [Test]
        public void SendStatementEmails_StatementFileNameIsEmptyString_ShouldNotEmailTheStatement()
        {
            _statementGenerator.Setup(sg => sg.SaveStatement(_houseKeeper.Oid,
                _houseKeeper.FullName,
                (_statementDate))
                ).Returns("");

            _service.SendStatementEmails(_statementDate);

            _emailSender.Verify(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Times.Never);

        }
        [Test]
        public void SendStatementEmails_StatementFileNameIsWhitespace_ShouldNotEmailTheStatement()
        {
            _statementGenerator.Setup(sg => sg.SaveStatement(_houseKeeper.Oid,
                _houseKeeper.FullName,
                (_statementDate))
                ).Returns(" ");

            _service.SendStatementEmails(_statementDate);

            _emailSender.Verify(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()),
                Times.Never);
        }
    }
}

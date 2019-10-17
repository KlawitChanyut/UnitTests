using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaUnit._3.Core_Unit_Testing_Techingues
{
    [TestFixture]
    class Testing_the_Return_Type_of_Method
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

            var result = controller.GetCustomer(0);

            // NotFound 
            Assert.That(result, Is.TypeOf<NotFound>());

            //NotFound or one of its derivatives 
            //Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
        }
    }
}

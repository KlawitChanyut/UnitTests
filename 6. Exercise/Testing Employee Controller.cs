using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinjaUnit._6.Exercise
{
    [TestFixture]
    class Testing_Employee_Controller
    {
        [Test]
        public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
        {
            var storage = new Mock<IEmployee_Storage>();
            var controller = new Employee_Controller(storage.Object);

            controller.DeleteEmployee(1);

            storage.Verify(s => s.DeleteEmployee(1));
        }
    }
}

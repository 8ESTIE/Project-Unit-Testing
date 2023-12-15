using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    internal class EmployeeControllerTests
    {
        EmployeeController _employeeController;
        Mock<IEmployeeStorage> _employeeStorage;
        [SetUp]
        public void SetUp()
        {
            _employeeStorage = new Mock<IEmployeeStorage>();
            _employeeController = new EmployeeController(_employeeStorage.Object);
        }
        [Test]
        public void DeleteEmployee_WhenCalled_DeletesEmployee()
        {
            int id = 0;

            _employeeController.DeleteEmployee(id);

            _employeeStorage.Verify(es => es.DeleteEmployeeStorage(id));
            Assert.That(_employeeController.DeleteEmployee(id), Is.TypeOf<RedirectResult>());
        }
    }
}

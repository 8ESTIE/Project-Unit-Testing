using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja
{
    public interface IEmployeeStorage
    {
        void DeleteEmployeeStorage(int id);
    }

    public class EmployeeStorage : IEmployeeStorage
    {
        private EmployeeContext _employeeContext;
        public EmployeeStorage(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext ?? new EmployeeContext();
        }

        public void DeleteEmployeeStorage(int id)
        {
            Employee employee = _employeeContext.Employees.Find(id);
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }
    }
}

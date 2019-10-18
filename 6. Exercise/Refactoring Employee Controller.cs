using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class Refactoring_Employee_Controller
    {
        private readonly IEmployee_Storage _storage;

        public Refactoring_Employee_Controller(IEmployee_Storage storage)
        {
            _storage = storage;
        }

        public ActionResult DeleteEmployee(int id)
        {
            _storage.DeleteEmployee(id);

            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResultX { }

    public class RedirectResultX : ActionResult { }

    public class EmployeeContextX
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class EmployeeX
    {
    }
}

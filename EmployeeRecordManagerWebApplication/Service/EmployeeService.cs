using EmployeeRecordManagerWebApplication.Models;
using EmployeeRecordManagerWebApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecordManagerWebApplication.Service
{
    public class EmployeeService : IEmployee
    {
        private EmployeeContext _employeeContext;

        public EmployeeService(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        //private List<Employee> employees = new List<Employee>()
        //{
        //    new Employee()
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Musanna",
        //        MiddleName = "Bin",
        //        LastName = "Tauhid"
        //    },
        //    new Employee()
        //    {
        //        Id = Guid.NewGuid(),
        //        FirstName = "Muhammad",
        //        MiddleName = "Bin",
        //        LastName = "Tauhid"
        //    }
        //};
        public Employee CreateEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Guid employeeId)
        {
            _employeeContext.Employees.Remove(GetEmployee(employeeId));
            _employeeContext.SaveChanges();
        }

        public Employee GetEmployee(Guid id)
        {
            return _employeeContext.Employees.Find(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeContext.Employees;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            Employee oldEmployee = GetEmployee(employee.Id);
            oldEmployee.FirstName = employee.FirstName;
            oldEmployee.MiddleName = employee.MiddleName;
            oldEmployee.LastName = employee.LastName;
            return oldEmployee;
        }
    }
}

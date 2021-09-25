using EmployeeRecordManagerWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecordManagerWebApplication.Service.Interface
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetEmployees();

        Employee GetEmployee(Guid id);

        Employee CreateEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);

        void DeleteEmployee(Guid employeeId);
    }
}

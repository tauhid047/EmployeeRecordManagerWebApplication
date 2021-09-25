using EmployeeRecordManagerWebApplication.Models;
using EmployeeRecordManagerWebApplication.Service;
using EmployeeRecordManagerWebApplication.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecordManagerWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeService;

        public EmployeeController(IEmployee employee)
        {
            _employeeService = employee;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeeService.GetEmployees());
        }

        //[HttpGet]
        //public IEnumerable<Employee> Get()
        //{
        //    return _employeeService.GetEmployees();
        //}


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Employee employee = _employeeService.GetEmployee(id);

            if(employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with id: {id} was not found.");
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            _employeeService.CreateEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Employee employee)
        {
            Employee oldEmployee = _employeeService.GetEmployee(id);
            if(oldEmployee != null)
            {
                employee.Id = oldEmployee.Id;
                _employeeService.UpdateEmployee(employee);
                return Ok(employee);
            }
            return NotFound($"Employee with id: {id} couldn't be updated!");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Employee employee = _employeeService.GetEmployee(id);
            if(employee != null)
            {
                _employeeService.DeleteEmployee(id);
                return Ok();
            }
            return NotFound($"Empoyee with id: {id} was not found!");
        }
    }
}
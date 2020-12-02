using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AugmentoEmployee.Database.Models;
using AugmentoEmployee.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace AugmentoEmployee.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _EmployeeService = employeeService;
        }
        [ProducesResponseType(200, Type = typeof(Employee[]))]
        [HttpGet("RecentEmployee")]
        public async Task<IActionResult> RecentlyJoinedEmployee()
        {
            try
            {
                Employee recentlyJoinedEmployee = await _EmployeeService.GetRecentEmployee();
                return Ok(recentlyJoinedEmployee);
            }
            catch (Exception ex)
            {
                Log.Error($"exception {ex}");
                return StatusCode(500, new { Status = "Error", Message = "Failed in fetching recent timestamp for Employee details" });
            }
        }
        [ProducesResponseType(200, Type = typeof(Employee[]))]
        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee([FromQuery] int Id)
        {
            try
            {
                Employee employeeDetails = await _EmployeeService.GetEmployee(Id);

                return Ok(employeeDetails);
            }
            catch (Exception ex)
            {
                Log.Error($"exception {ex}");
                return StatusCode(500, new { Status = "Error", Message = "Failed in fetching Employee for Employee details" });
            }
        }
        [ProducesResponseType(200, Type = typeof(Employee[]))]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                IEnumerable<Employee> employeeDetails = await _EmployeeService.GetAllEmployees();

                return Ok(employeeDetails);
            }
            catch (Exception ex)
            {
                Log.Error($"exception {ex}");
                return StatusCode(500, new { Status = "Error", Message = "Failed in fetching  Employee details" });
            }
        }
        [ProducesResponseType(200, Type = typeof(Employee[]))]
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEmployee([FromQuery] int Id)
        {
            try
            {
                var result = await _EmployeeService.Delete(Id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error($"exception {ex}");
                return StatusCode(500, new { Status = "Error", Message = "Failed in Deleting Employee details" });
            }
        }
        [ProducesResponseType(200, Type = typeof(Employee[]))]
        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            try
            {
                IEnumerable<Employee> employeeDetails = await _EmployeeService.Add(employee);

                return Ok(employeeDetails);
            }
            catch (Exception ex)
            {
                Log.Error($"exception {ex}");
                return StatusCode(500, new { Status = "Error", Message = "Failed in Adding New Employee to Employee details" });
            }
        }
        [ProducesResponseType(200, Type = typeof(Employee[]))]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            try
            {
                Employee employeeDetails = await _EmployeeService.Update(employee);

                return Ok(employeeDetails);
            }
            catch (Exception ex)
            {
                Log.Error($"exception {ex}");
                return StatusCode(500, new { Status = "Error", Message = "Failed in Updating Employee details" });
            }
        }
    }
}

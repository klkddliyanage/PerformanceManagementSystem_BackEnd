using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Data;
using PerformanceManagementSystem.PerformanceManagementSystem.Models;
using PerformanceManagementSystem.Services;


namespace PerformanceManagementSystem.controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {

        private readonly EmployeesService _employeesService;

        public EmployeesController(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }


        [HttpGet("employees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeesService.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("employees/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeesService.GetEmployee(id);
            return Ok(employee);
        }

        [HttpPost("employees")]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            var createdEmployee = await _employeesService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, createdEmployee);
        }

        [HttpDelete("employees/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var success = await _employeesService.DeleteEmployee(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Data;
using PerformanceManagementSystem.PerformanceManagementSystem.Models;

namespace PerformanceManagementSystem.Services
{
    
    public class EmployeesService
    {

        private readonly AppDbContext _context;
        public EmployeesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {

            //return await _context.Employees.Include(e => e.PerformanceGoals).ToListAsync();
            return await _context.Employees.IgnoreAutoIncludes().ToListAsync();
        }
        public async Task<Employee?> GetEmployee(int id)
        {
            return await _context.Employees.IgnoreAutoIncludes().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}

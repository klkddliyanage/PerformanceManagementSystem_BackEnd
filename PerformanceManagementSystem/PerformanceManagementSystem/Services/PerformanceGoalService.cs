using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.Data;
using PerformanceManagementSystem.PerformanceManagementSystem.Models;

namespace PerformanceManagementSystem.PerformanceManagementSystem.Services
{

    
    public class PerformanceGoalService
    {
        private readonly AppDbContext _context;
        public PerformanceGoalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<PerformanceGoal>>> GetGoals(int employeeId)
        {
            var goals = await _context.Goals
                .Where(g => g.EmployeeId == employeeId)
                .ToListAsync();
            return goals;
        }
        public async Task<PerformanceGoal> AddGoal(int employeeId, PerformanceGoal goal)
        {
            goal.EmployeeId = employeeId;
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
            return goal;
        }


        public async Task<PerformanceGoal> UpdateGoal(int employeeId, int goalId, PerformanceGoal goal)
        {
            var existingGoal = await _context.Goals
                .FirstOrDefaultAsync(g => g.Id == goalId && g.EmployeeId == employeeId);

            if (existingGoal == null)
                return null;

            existingGoal.GoalTitle = goal.GoalTitle;
            existingGoal.Description = goal.Description;
            existingGoal.DueDate = goal.DueDate;
            existingGoal.Status = goal.Status;

            await _context.SaveChangesAsync();
            return existingGoal;
        }


        public async Task<bool> DeleteGoal(int employeeId, int goalId)
        {
            var goal = await _context.Goals
                .FirstOrDefaultAsync(g => g.Id == goalId && g.EmployeeId == employeeId);

            if (goal == null)
                return false;

            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}

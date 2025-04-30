using Microsoft.AspNetCore.Mvc;
using PerformanceManagementSystem.PerformanceManagementSystem.Models;
using PerformanceManagementSystem.PerformanceManagementSystem.Services;
using PerformanceManagementSystem.Services;

namespace PerformanceManagementSystem.PerformanceManagementSystem.controllers
{
    [ApiController]
    [Route("api/[controller]/employees/{employeeId}")]
    public class PerfromanceGoalController : Controller
    {
        private readonly PerformanceGoalService _performanceGoalService;

        public PerfromanceGoalController(PerformanceGoalService performanceGoalService)
        {
            _performanceGoalService = performanceGoalService;
        }


        [HttpGet("goals")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetGoals(int employeeId)
        {
            var goals = await _performanceGoalService.GetGoals(employeeId);
            return Ok(goals);
        }

        [HttpPost("goals")]
        public async Task<ActionResult<PerformanceGoal>> AddGoal(int employeeId, PerformanceGoal goal)
        {
            var createdGoal = await _performanceGoalService.AddGoal(employeeId, goal);
            return CreatedAtAction(nameof(GetGoals), new { employeeId = employeeId }, createdGoal);
        }


        [HttpPut("goals/{goalId}")]
        public async Task<IActionResult> UpdateGoal([FromRoute] int employeeId, [FromRoute] int goalId, PerformanceGoal goal)
        {
            var updatedGoal = await _performanceGoalService.UpdateGoal(employeeId, goalId, goal);
            return Ok(updatedGoal);
        }

        [HttpDelete("goals/{goalId}")]
        public async Task<IActionResult> DeleteGoal([FromRoute] int employeeId,[FromRoute] int goalId)
        {
            var success = await _performanceGoalService.DeleteGoal(employeeId, goalId);

            if (!success)
                return NotFound(new { message = $"Goal with ID {goalId} for Employee {employeeId} not found." });

            return NoContent();
        }

    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PerformanceManagementSystem.PerformanceManagementSystem.Models
{
    public enum GoalStatus
    {
        NotStarted,
        InProgress,
        Completed,
        Cancelled
    }

    public class PerformanceGoal
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string GoalTitle { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }

        public GoalStatus Status { get; set; }

        [ValidateNever]
        public Employee Employee { get; set; } = null!;
    }

}

using System.Text.Json.Serialization;
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
        public int? Id { get; set; }

        
        public int? EmployeeId { get; set; }

        [JsonRequired]
        public string GoalTitle { get; set; } = string.Empty;

        [JsonRequired]
        public string Description { get; set; } = string.Empty;
        
        [JsonRequired]
        public DateTime DueDate { get; set; }

        [JsonRequired]
        public GoalStatus Status { get; set; }

        [ValidateNever]
        public Employee Employee { get; set; } = null!;
    }

}

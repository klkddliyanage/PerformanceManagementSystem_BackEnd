using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace PerformanceManagementSystem.PerformanceManagementSystem.Models
{
    public class Employee
    {
        public int? Id { get; set; }

        [JsonRequired]
        public string FullName { get; set; } = string.Empty;

        [JsonRequired]
        public string Department { get; set; } = string.Empty;

        public ICollection<PerformanceGoal>? PerformanceGoals { get; set; }
    }
}

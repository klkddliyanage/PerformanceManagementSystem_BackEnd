using Microsoft.EntityFrameworkCore;
using PerformanceManagementSystem.PerformanceManagementSystem.Models;

namespace PerformanceManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<PerformanceGoal> Goals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 25, FullName = "Alice Johnson", Department = "HR" },
                new Employee { Id = 26, FullName = "Bob Smith", Department = "IT" }
            );

            modelBuilder.Entity<PerformanceGoal>().HasData(
                new PerformanceGoal
                {
                    Id = 25,
                    EmployeeId = 25,
                    GoalTitle = "Improve Onboarding",
                    Description = "Refine onboarding process for new hires.",
                    DueDate = new DateTime(2025, 12, 31, 0, 0, 0, DateTimeKind.Utc),
                    Status = GoalStatus.NotStarted
                },
                new PerformanceGoal
                {
                    Id = 26,
                    EmployeeId = 26,
                    GoalTitle = "Upgrade Infrastructure",
                    Description = "Replace old servers with cloud instances.",
                    DueDate = new DateTime(2025, 10, 01, 0, 0, 0, DateTimeKind.Utc),
                    Status = GoalStatus.InProgress
                }
            );
        }

    }

}

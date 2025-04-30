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
            // Seeding Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FullName = "Alice Johnson", Department = "HR" },
                new Employee { Id = 2, FullName = "Bob Smith", Department = "IT" }
            );

            // Seeding Performance Goals
            modelBuilder.Entity<PerformanceGoal>().HasData(
                new PerformanceGoal
                {
                    Id = 1,
                    EmployeeId = 1,
                    GoalTitle = "Improve Onboarding",
                    Description = "Refine onboarding process for new hires.",
                    DueDate = new DateTime(2025, 12, 31),
                    Status = GoalStatus.NotStarted
                },
                new PerformanceGoal
                {
                    Id = 2,
                    EmployeeId = 2,
                    GoalTitle = "Upgrade Infrastructure",
                    Description = "Replace old servers with cloud instances.",
                    DueDate = new DateTime(2025, 10, 01),
                    Status = GoalStatus.InProgress
                }
            );
        }
    }

}

using System.Security.Cryptography;

namespace PerformanceManagementSystem.PerformanceManagementSystem.Models
{
    public class Employee
    {
        private int _id;
        private string _fullName;
        private string _department;
        private ICollection<PerformanceGoal>? _performanceGoals;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public ICollection<PerformanceGoal>? PerformanceGoals
        {
            get { return _performanceGoals; }
            set { _performanceGoals = value; }
        }

    }
}

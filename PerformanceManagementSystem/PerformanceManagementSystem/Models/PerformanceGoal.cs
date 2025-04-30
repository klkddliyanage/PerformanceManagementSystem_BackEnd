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
        private int _id;
        private int _employeeId;
        private string _goalTitle;
        private string _description;
        private DateTime _dueDate;
        private GoalStatus _status;


        [ValidateNever]
        public Employee Employee { get; set; }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        public string GoalTitle
        {
            get { return _goalTitle; }
            set { _goalTitle = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime DueDate
        {
            get { return _dueDate; }
            set { _dueDate = value; }
        }

        public GoalStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }


    }

}

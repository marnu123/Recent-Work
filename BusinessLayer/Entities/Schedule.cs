using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;
using BusinessLayer.Validators;

namespace BusinessLayer.Classes
{ 
    [Serializable]
    [Table("tblschedule")]
    public class Schedule : DataObject, IValidatable<Schedule>
    {
        private string id;
        private DateTime timeStart;
        private double price;
        private TimeSpan duration;
        private string fK_TaskId;
        private string fK_EmployeeId;
        private Task task;
        private Employee employee;


        public Schedule(DataRow dataRow)
        {
            Id = dataRow["PK_ScheduleID"].ToString();
            TimeStart = (DateTime)dataRow["TimeStart"];
            Price = Convert.ToDouble(dataRow["SchedulePrice"]);
            Duration = (TimeSpan) dataRow["Duration"];
            FK_TaskId = dataRow["FK_TaskID"].ToString();
            FK_EmployeeId = dataRow["FK_EmployeeID"].ToString();

            try
            {
                task = new Task(dataRow);
            }
            catch (Exception e) { }
        }

        public Schedule(string id, DateTime timeStart, float price, TimeSpan duration, string fK_TaskId, string fK_EmployeeId)
        {
            Id = id;
            TimeStart = timeStart;
            Price = price;
            Duration = duration;
            FK_TaskId = fK_TaskId;
            FK_EmployeeId = fK_EmployeeId;
        }

        [Key]
        [Column("PK_ScheduleID")]
        public string Id { get => id; set => id = value; }
        [Column("TimeStart")]
        public DateTime TimeStart { get => timeStart; set => timeStart = value; }
        [Column("SchedulePrice")]
        public double Price { get => price; set => price = value; }
        [Column("Duration")]
        public TimeSpan Duration { get => duration; set => duration = value; }
        [ForeignKey(typeof(Task))]
        [Column("FK_TaskID")]
        public string FK_TaskId { get => fK_TaskId; set => fK_TaskId = value; }
        [ForeignKey(typeof(Employee))]
        [Column("FK_EmployeeID")]
        public string FK_EmployeeId { get => fK_EmployeeId; set => fK_EmployeeId = value; }
        public Task Task
        {
            get
            {
                if (task == null)
                {
                    string matchId = fK_TaskId;
                    List<Task> temp = Task.Select(p => p.Id == matchId);
                    task = temp.Count > 0 ? temp[0] : null;
                }

                return task;
            }
            set => task = value;
        }
        public Employee Employee
        {
            get
            {
                if (employee == null)
                {
                    string matchId = fK_EmployeeId;
                    List<Employee> temp = Employee.Select(p => p.EmployeeId == matchId);
                    employee = temp.Count > 0 ? temp[0] : null;
                }

                return employee;
            }
            set => employee = value; }

        public static List<Schedule> Select(params Expression<Func<Schedule, object>>[] expression)
        {
            return DataObjectFactory.Select<Schedule>(expression);
        }

        public override string ToString()
        {
            return "ID: " + Id + " TimeStart: " + TimeStart.ToShortDateString() + " Price: " + Price;
        }

        public bool Validate(IValidator<Schedule> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}

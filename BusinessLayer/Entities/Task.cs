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
    [Table("tbltask")]
    public class Task : DataObject, IValidatable<Task>
    {
        private string id;
        private string oldKey;
        private int fK_LocationId;
        private int fK_TaskTypeId;
        private string taskDescription;
        private int fK_TaskStatusId;
        private string fK_ClientId;
        private DateTime dateAdded;
        private Location location;
        private TaskType taskType;
        private TaskStatus taskStatus;
        private Client client;

        public Task(string id, int fK_LocationId, int fK_TaskTypeId, string taskDescription, int fK_TaskStatusId)
        {
            Id = id;
            OldKey = id;
            FK_LocationId = fK_LocationId;
            FK_TaskTypeId = fK_TaskTypeId;
            TaskDescription = taskDescription;
            FK_TaskStatusId = fK_TaskStatusId;
        }

        public Task(DataRow dataRow)
        {
            Id = dataRow["PK_TaskID"].ToString();
            FK_LocationId = Convert.ToInt32(dataRow["FK_LocationID"]);
            FK_TaskTypeId = Convert.ToInt32(dataRow["FK_TaskTypeID"]);
            TaskDescription = dataRow["TaskDescription"].ToString();
            FK_TaskStatusId = Convert.ToInt32(dataRow["FK_TaskStatusID"]);
            FK_ClientId = dataRow["FK_ClientID"].ToString();
            DateAdded = (DateTime)dataRow["TaskDateAdded"];
            OldKey = id;

            try
            {
                Location = new Location(dataRow);
                TaskType = new TaskType(dataRow);
                TaskStatus = new TaskStatus(dataRow);
                Client = new Client(dataRow);
            }
            catch (Exception e) { }
        }

        [Key]
        [Column("PK_TaskID")]
        public string Id { get => id; set => id = value; }
        [KeyStorage("Id")]
        public string OldKey { get => oldKey; set => oldKey = value; }
        [ForeignKey(typeof(Location))]
        [Column("FK_LocationID")]
        public int FK_LocationId { get => fK_LocationId; set => fK_LocationId = value; }
        [ForeignKey(typeof(TaskType))]
        [Column("FK_TaskTypeID")]
        public int FK_TaskTypeId { get => fK_TaskTypeId; set => fK_TaskTypeId = value; }
        [Column("TaskDescription")]
        public string TaskDescription { get => taskDescription; set => taskDescription = value; }
        [ForeignKey(typeof(TaskStatus))]
        [Column("FK_TaskStatusID")]
        public int FK_TaskStatusId { get => fK_TaskStatusId; set => fK_TaskStatusId = value; }
        [Column("TaskDateAdded")]
        public DateTime DateAdded { get => dateAdded == null ? DateTime.Now : dateAdded; set => dateAdded = value; }
        [ForeignKey(typeof(Client))]
        [Column("FK_ClientID")]
        public string FK_ClientId { get => fK_ClientId; set => fK_ClientId = value; }
        public Location Location
        {
            get
            {
                if (location == null && fK_LocationId != 0)
                {
                    int matchId = fK_LocationId;
                    List<Location> temp = Location.Select(p => p.Id == matchId);
                    location = temp.Count > 0 ? temp[0] : null;
                }

                return location;
            }
            set => location = value;
        }
        public TaskType TaskType
        {
            get
            {
                if (taskType == null)
                {
                    int matchId = fK_TaskTypeId;
                    List<TaskType> temp = TaskType.Select(p => p.Id == matchId);
                    taskType = temp.Count > 0 ? temp[0] : null;
                }

                return taskType;
            }
            set => taskType = value;
        }
        public TaskStatus TaskStatus
        {
            get
            {
                if (taskStatus == null)
                {
                    int matchId = FK_TaskStatusId;
                    List<TaskStatus> temp = TaskStatus.Select(p => p.Id == matchId);
                    taskStatus = temp.Count > 0 ? temp[0] : null;
                }

                return taskStatus;
            }
            set => taskStatus = value;
        }

        public Client Client
        {
            get
            {
                if (client == null)
                {
                    string clientId = fK_ClientId;
                    List<Client> result = Client.Select(c => c.ClientId == clientId);
                    client = result.Count == 1 ? result[0] : null;
                }
                return client;
            }
            set => client = value;
        }

        public static List<Task> Select(params Expression<Func<Task, object>>[] expression)
        {
            return DataObjectFactory.Select<Task>(expression);
        }

        public bool Validate(IValidator<Task> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tbltask")]
    class Task : DataObject
    {
        private string id;
        private int fK_LocationId;
        private int fK_TaskTypeId;
        private string taskDescription;
        private int fK_TaskStatusId;
        private Location location;
        private TaskType taskType;
        private TaskStatus taskStatus;

        public Task(string id, int fK_LocationId, int fK_TaskTypeId, string taskDescription, int fK_TaskStatusId)
        {
            Id = id;
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
        }

        [Key]
        [Column("PK_TaskID")]
        public string Id { get => id; set => id = value; }
        [Column("FK_LocationID")]
        public int FK_LocationId { get => fK_LocationId; set => fK_LocationId = value; }
        [Column("FK_TaskTypeID")]
        public int FK_TaskTypeId { get => fK_TaskTypeId; set => fK_TaskTypeId = value; }
        [Column("TaskDescription")]
        public string TaskDescription { get => taskDescription; set => taskDescription = value; }
        [Column("FK_TaskStatusID")]
        public int FK_TaskStatusId { get => fK_TaskStatusId; set => fK_TaskStatusId = value; }
        public Location Location
        {
            get
            {
                if (location == null)
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
                    int matchId = fK_TaskTypeId;
                    List<TaskStatus> temp = TaskStatus.Select(p => p.Id == matchId);
                    taskStatus = temp.Count > 0 ? temp[0] : null;
                }

                return taskStatus;
            }
            set => taskStatus = value;
        }

        public static List<Task> Select(params Expression<Func<Task, object>>[] expression)
        {
            return DataObjectFactory.Select<Task>(expression);
        }
    }
}

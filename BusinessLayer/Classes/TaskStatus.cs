using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tbltaskstatus")]
    public class TaskStatus : DataObject
    {
        private int id;
        private string title;

        public TaskStatus(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public TaskStatus(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["PK_TaskStatusID"]);
            Title = dataRow["TaskStatusTitle"].ToString();
        }

        [Key]
        [Column("PK_TaskStatusID")]
        public int Id { get => id; set => id = value; }
        [Column("TaskStatusTitle")]
        public string Title { get => title; set => title = value; }

        public static List<TaskStatus> Select(params Expression<Func<TaskStatus, object>>[] expression)
        {
            return DataObjectFactory.Select<TaskStatus>(expression);
        }

        public override string ToString()
        {
            return Id + " " + Title;
        }
    }
}

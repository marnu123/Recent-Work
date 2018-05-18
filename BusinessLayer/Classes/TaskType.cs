using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tbltasktype")]
    public class TaskType : DataObject
    {
        private int id;
        private string title;

        public TaskType(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public TaskType(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["PK_TaskTypeID"]);
            Title = dataRow["TaskTypeTitle"].ToString();
        }

        [Key]
        [Column("PK_TaskTypeID")]
        public int Id { get => id; set => id = value; }
        [Column("TaskTypeTitle")]
        public string Title { get => title; set => title = value; }

        public static List<TaskType> Select(params Expression<Func<TaskType, object>>[] expression)
        {
            return DataObjectFactory.Select<TaskType>(expression);
        }

        public override string ToString()
        {
            return Id + " " + Title;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tblnotificationtype")]
    public class NotificationType : DataObject
    {
        private int id;
        private string title;

        public NotificationType(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public NotificationType(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["PK_NotificationTypeID"]);
            Title = dataRow["NotificationTypeTitle"].ToString();
        }

        [Key]
        [Column("PK_NotificationTypeID")]
        public int Id { get => id; set => id = value; }
        [Column("NotificationTypeTitle")]
        public string Title { get => title; set => title = value; }

        public override string ToString()
        {
            return "ID: " + Id + " Title: " + Title;
        }
    }
}

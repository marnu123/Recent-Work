using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tblemployeetype")]
    public class EmployeeType : DataObject
    {
        private int id;
        private string title;

        public EmployeeType(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public EmployeeType(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["PK_EmployeeTypeID"]);
            Title = dataRow["EmployeeTypeTitle"].ToString();
        }

        [Key]
        [Column("PK_EmployeeTypeID")]
        public int Id { get => id; set => id = value; }
        [Column("EmployeeTypeTitle")]
        public string Title { get => title; set => title = value; }

        public override string ToString()
        {
            return "ID: " + Id + " Title: " + Title;
        }
    }
}

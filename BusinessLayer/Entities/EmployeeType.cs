using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;
using BusinessLayer.Validators;

namespace BusinessLayer.Classes
{
    [Table("tblemployeetype")]
    public class EmployeeType : DataObject, IValidatable<EmployeeType>
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

        [Key(true)]
        [Column("PK_EmployeeTypeID")]
        public int Id { get => id; set => id = value; }
        [Column("EmployeeTypeTitle")]
        public string Title { get => title; set => title = value; }

        public static List<EmployeeType> Select(params Expression<Func<EmployeeType, object>>[] expression)
        {
            return DataObjectFactory.Select<EmployeeType>(expression);
        }

        public override string ToString()
        {
            return "ID: " + Id + " Title: " + Title;
        }

        public bool Validate(IValidator<EmployeeType> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;
using BusinessLayer.Validators;

namespace BusinessLayer.Classes
{
    [Table("tblmanufacturer")]
    public class Manufacturer : DataObject, IValidatable<Manufacturer>
    {
        private int id;
        private string name;

        public Manufacturer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Manufacturer(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["PK_ManufacturerID"]);
            Name = dataRow["ManufacturerName"].ToString();
        }

        [Key(true)]
        [Column("PK_ManufacturerID")]
        public int Id { get => id; set => id = value; }
        [Column("ManufacturerName")]
        public string Name { get => name; set => name = value; }

        public static List<Manufacturer> Select(params Expression<Func<Manufacturer, object>>[] expression)
        {
            return DataObjectFactory.Select<Manufacturer>(expression);
        }

        public override string ToString()
        {
            return Id + " " + Name;
        }

        public bool Validate(IValidator<Manufacturer> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}

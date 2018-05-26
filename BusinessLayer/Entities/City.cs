using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;
using DataLayer.Attributes;
using BusinessLayer.Validators;

namespace BusinessLayer.Classes
{
    [Serializable]
    [Table("tblcity")]
    public class City: DataObject, IValidatable<City>
    {
        private int id = 0;
        private string name = "";

        public City(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public City() { }

        public City(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["PK_CityID"]);
            Name = dataRow["CityName"].ToString();
        }

        [Key(true)]
        [Column("PK_CityID")]
        public int Id { get => id; set => id = value; }
        [Column("CityName")]
        public string Name { get => name; set => name = value; }

        public static List<City> Select(params Expression<Func<City, object>>[] expression)
        {
            return DataObjectFactory.Select<City>(expression);
        }

        public override string ToString()
        {
            return Name;
        }

        public bool Validate(IValidator<City> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}

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
    [Table("tblstreet")]
    public class Street: DataObject, IValidatable<Street>
    {
        private int id;
        private string name;
        private string areaCode;
        private int fK_CityID;
        private City city;

        public Street(int id, string name, string areaCode, City city)
        {
            Id = id;
            Name = name;
            AreaCode = areaCode;
            City = city;
        }

        public Street(DataRow dataRow)
        {
            Id = Convert.ToInt32(dataRow["PK_StreetID"]);
            Name = dataRow["StreetName"].ToString();
            AreaCode = dataRow["AreaCode"].ToString();
            FK_CityID = Convert.ToInt32(dataRow["FK_CityID"]);

            try
            {
                city = new City(dataRow);
            }
            catch (Exception e) { }
        }

        [Key(true)]
        [Column("PK_StreetID")]
        public int Id { get => id; set => id = value; }
        [Column("StreetName")]
        public string Name { get => name; set => name = value; }
        [Column("AreaCode")]
        public string AreaCode { get => areaCode; set => areaCode = value; }
        public City City
        {
            get
            { 
                if (city == null)
                {
                    return City.Select(c => c.Id == fK_CityID)[0];
                }
                else
                {
                    return city;
                }
            }
            set => city = value;
        }

        [ForeignKey(typeof(City))]
        [Column("FK_CityID")]
        public int FK_CityID { get => fK_CityID; set => fK_CityID = value; }

        public static List<Street> Select(params Expression<Func<Street, object>>[] expression)
        {
            return DataObjectFactory.Select<Street>(expression);
        }

        public override string ToString()
        {
            return Name + ", " + AreaCode + ", " + City.ToString();
        }

        public bool Validate(IValidator<Street> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}

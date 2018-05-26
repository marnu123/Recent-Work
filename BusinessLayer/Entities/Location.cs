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
    [Table("tbllocation")]
    public class Location : DataObject, IValidatable<Location>
    {
        private int id = 0;
        private int oldId = 0;
        private string houseNumber = "";
        private int fK_StreetID = 0;
        private Street street;
        //private City city;
        private List<Product> products;

        public Location() { }

        public Location(DataRow dataRow)
        {
            this.Id = Convert.ToInt32(dataRow["PK_LocationID"]);
            this.HouseNumber = dataRow["HouseNumber"].ToString();
            this.FK_StreetID = Convert.ToInt32(dataRow["FK_StreetID"]);
            OldId = Id;

            try
            {
                street = new Street(dataRow);
            }
            catch (Exception e) { }
            //Console.WriteLine("Location {0} created", street.ToString());
            //this.FK_CityID = Convert.ToInt32(dataRow["FK_CityID"]);
        }

        public Location(int id, string houseNumber, int fK_StreetID, int fK_CityID, List<Product> products)
        {
            this.Id = id;
            OldId = id;
            this.HouseNumber = houseNumber;
            this.FK_StreetID = fK_StreetID;
            //this.FK_CityID = fK_CityID;
            this.Products = products;
        }

        public List<Product> Products { get => products; set => products = value; }
        [Key(true)]
        [Column("PK_LocationID")]
        public int Id { get => id; set => id = value; }
        [KeyStorage("Id")]
        public int OldId { get => oldId; set => oldId = value; }
        [Column("HouseNumber")]
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }
        [ForeignKey(typeof(Street))]
        [Column("FK_StreetID")]
        public int FK_StreetID { get => fK_StreetID; set => fK_StreetID = value; }
        public Street Street
        {
            get
            {
                if (street is null)
                {
                    if (fK_StreetID == 0) street = new Street();
                    else
                    {
                        int id = fK_StreetID;
                        street = Street.Select(s => s.Id == id)[0];
                    }
                }

                return street;
            }
            set => street = value; }

        //public City City { get => city; set => city = value; }

        public static List<Location> Select(params Expression<Func<Location, object>>[] expression)
        {
            //Add inner join relationships
            Expression<Func<Location, Street, object>> ex1 = (l, s) => l.FK_StreetID == s.Id;
            Expression<Func<Street, City, object>> ex2 = (s, c) => s.FK_CityID == c.Id;

            Expression[] expList = new Expression[]
            {
                       ex1, ex2
            };

            return DataObjectFactory.Select<Location>(Utils.JoinArrays<Expression>(expList, expression));
        }

        public override string ToString()
        {
            return HouseNumber + Street.ToString();
        }

        public bool Validate(IValidator<Location> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }

        public override bool Equals(object obj)
        {
            Location temp = obj as Location;
            if (temp == null) return false;

            return temp.Id == Id && temp.HouseNumber == HouseNumber && temp.FK_StreetID == FK_StreetID;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ HouseNumber.GetHashCode() ^ FK_StreetID.GetHashCode();
        }
    }
}

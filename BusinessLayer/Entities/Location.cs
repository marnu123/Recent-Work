using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{ 
    [Table("tbllocation")]
    public class Location : DataObject
    {
        private int id;
        private string houseNumber;
        private int fK_StreetID;
        private Street street;
        //private City city;
        private List<Product> products;

        public Location() { }

        public Location(DataRow dataRow)
        {
            this.Id = Convert.ToInt32(dataRow["PK_LocationID"]);
            this.HouseNumber = dataRow["HouseNumber"].ToString();
            this.FK_StreetID = Convert.ToInt32(dataRow["FK_StreetID"]);

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
            this.HouseNumber = houseNumber;
            this.FK_StreetID = fK_StreetID;
            //this.FK_CityID = fK_CityID;
            this.Products = products;
        }

        public List<Product> Products { get => products; set => products = value; }
        [Key]
        [Column("PK_LocationID")]
        public int Id { get => id; set => id = value; }
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
                    return Street.Select(s => s.Id == FK_StreetID)[0];
                }
                else
                {
                    return street;
                }
            }
            set => street = value; }
        //public City City { get => city; set => city = value; }

        public static List<Location> Select(params Expression<Func<Location, object>>[] expression)
        {
            //Add inner join relationships
            Expression<Func<Person_Location, Location, object>> ex = (pl, l) => l.Id == pl.LocationId;
            Expression<Func<Location, Street, object>> ex1 = (l, s) => l.FK_StreetID == s.Id;
            Expression<Func<Street, City, object>> ex2 = (s, c) => s.FK_CityID == c.Id;

            Expression[] expList = new Expression[]
            {
                       ex, ex1, ex2
            };

            return DataObjectFactory.Select<Location>(Utils.JoinArrays<Expression>(expList, expression));
        }

        public override string ToString()
        {
            return HouseNumber + Street.ToString();
        }
    }
}

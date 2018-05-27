using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;
using System.Data;
using System.ComponentModel;
using System.Reflection;
using DataLayer.Attributes;
using DataLayer;
using BusinessLayer.Validators;

namespace BusinessLayer.Classes
{
    [Serializable]
    [Table("tblperson")]
    public class Person : DataObject, IValidatable<Person>
    {
        private int id;
        private string name;
        private string surname;
        private string email;
        private string oldEmail;
        private string cellNumber;
        private List<Location> locations;

        public Person(DataRow dr)
        {
            id = Convert.ToInt32(dr["PK_PersonID"]);
            name = dr["FirstName"].ToString();
            surname = dr["Surname"].ToString();
            email = dr["Email"].ToString();
            cellNumber = dr["CellNumber"].ToString();
            locations = null;
            oldEmail = email;
        }

        public Person() { }

        public Person(int id, string name, string surname, string email, string cellNumber)
        {
            this.id = id;
            this.Name = name;
            this.Surname = surname;
            this.Email = email;
            oldEmail = email;
            this.CellNumber = cellNumber;
            Locations = null;
        }

        [Column("PK_PersonID", true)]
        public int Id { get => id; set => id = value; }
        [Column("FirstName")]
        public string Name { get => name; set => name = value; }
        [Column("Surname")]
        public string Surname { get => surname; set => surname = value; }
        [Key]
        [Column("Email")]
        public string Email { get => email; set => email = value; }
        //Cache old primary key values for update statements
        [KeyStorage("Email")]
        public string OldEmail { get => oldEmail; private set => oldEmail = value; }
        [Column("CellNumber")]
        public string CellNumber { get => cellNumber; set => cellNumber = value; }
        //Lazy load locations
        public List<Location> Locations
        {
            get
            {
                if (locations == null)
                {
                    RefreshLocations();
                }
                return locations;
            }
            set => locations = value;
        }

        public override string ToString()
        {
            return "ID:" + id + " Name:" + name + " Surname:" + surname;
        }

        public void RefreshLocations()
        {
            string matchEmail = Email;
            //Retrieve all records for this person with relationships
            Expression<Func<Person_Location, Location, object>> ex = (pl, l) => (pl.PersonEmail == matchEmail && l.Id == pl.LocationId);
            Expression<Func<Location, Street, object>> ex1 = (l, s) => l.FK_StreetID == s.Id;
            Expression<Func<Street, City, object>> ex2 = (s, c) => s.FK_CityID == c.Id;

            Expression[] expList = new Expression[]
            {
                        ex, ex1, ex2
            };
            //Use the DataOjbectFactory to retrive the correct relationships
            locations = DataObjectFactory.Select<Location>(expList);
        }

        public static List<Person> Select(params Expression<Func<Person, object>>[] expression)
        {
            return DataObjectFactory.Select<Person>(expression);
        }

        public bool Validate(IValidator<Person> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tblperson_location")]
    public class Person_Location : DataObject
    {
        private string personEmail;
        private int locationId;

        public Person_Location(string personEmail, int locationId)
        {
            PersonEmail = personEmail;
            LocationId = locationId;
        }

        public Person_Location(DataRow dataRow)
        {
            PersonEmail = dataRow["FK_PersonEmail"].ToString();
            LocationId = Convert.ToInt32(dataRow["FK_LocationID"]);
        }

        [Key]
        [ForeignKey(typeof(Person))]
        [Column("FK_PersonEmail")]
        public string PersonEmail { get => personEmail; set => personEmail = value; }

        [Key]
        [ForeignKey(typeof(Location))]
        [Column("FK_LocationID")]
        public int LocationId { get => locationId; set => locationId = value; }

        public override string ToString()
        {
            return base.ToString() + " FK_LocationID: " + locationId;
        }
    }
}

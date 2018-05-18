using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSManagement.business_logic
{
    class Location
    {
        private int id;
        private int houseNumber;
        private string city;
        private string areaCode;
        private List<Product> products;

        public Location(int id, int houseNumber, string city, string areaCode)
        {
            this.id = id;
            this.houseNumber = houseNumber;
            this.city = city;
            this.areaCode = areaCode;
        }

        public int ID { get; }
        public int HouseNumber { get; set; }
        public string City
        {
            get { return city; }
            set
            {
                if (value == String.Empty || value == null)
                {
                    new ArgumentNullException("City", "City may not be empty");
                }
            }
        }
        public string AreaCode { get; set; }
        public List<Product> Products { get; set; }
    }
}

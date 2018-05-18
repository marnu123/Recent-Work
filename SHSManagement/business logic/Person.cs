using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSManagement.business_logic
{
    class Person
    {
        private int id;
        private string name;
        private string surname;
        private string email;
        private string cellNumber;
        private List<Location> locations;

        public Person(string name, string surname, string email, string cellNumber) { }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        public List<Location> Locations { get; set; }
    }
}

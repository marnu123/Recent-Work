using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSManagement.business_logic
{
    class Client:Person
    {
        private int clientID;
        public int ClientID { get; set; }

        public Client(Person person, int clientID) : base(person.Name, person.Surname, person.Email, person.CellNumber) { }
        public Client(int personID, string name, string surname, string email, string cellNumber, int clientID) : base(name, surname, email, cellNumber) { }
    }
}

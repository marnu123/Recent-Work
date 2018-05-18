using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSManagement.business_logic
{
    class Employee: Person
    {
        private int employeeID;
        private string employeeType;
        public string EmployeeType { get; set; }
        public int EmployeeID { get; set; }

        public Employee(Person person, int employeeID, string employeeType) :base(person.Name, person.Surname, person.Email, person.CellNumber){ }
        public Employee(int personID, string name, string surname, string email, string cellNumber, int employeeID, string employeeType) : base(name, surname, email, cellNumber) { }
    }
}

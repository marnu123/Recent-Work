using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{ 
    [Table("tblemployee")]
    class Employee: Person
    {
        private string employeeId;
        private string fK_PersonEmail;
        private int fK_EmployeeTypeId;

        public Employee(Person person, string employeeId, int fK_EmployeeTypeId) 
            :base(person.Id, person.Name, person.Surname, person.Email, person.CellNumber)
        {
            EmployeeId = employeeId;
            fK_PersonEmail = Email;
            FK_EmployeeTypeId = fK_EmployeeTypeId;
        }
        public Employee(int personID, string name, string surname, string email, string cellNumber, string employeeId, int fK_EmployeeTypeId) 
            :base(personID, name, surname, email, cellNumber)
        {
            EmployeeId = employeeId;
            FK_PersonEmail = email;
            FK_EmployeeTypeId = fK_EmployeeTypeId;
        }

        public Employee(DataRow dataRow)
            :base (dataRow)
        {
            EmployeeId = dataRow["PK_EmployeeID"].ToString();
            FK_PersonEmail = dataRow["FK_PersonEmail"].ToString();
            FK_EmployeeTypeId = Convert.ToInt32(dataRow["FK_EmployeeTypeID"]);
        }

        [Key]
        [Column("PK_EmployeeID")]
        public string EmployeeId { get => employeeId; set => employeeId = value; }
        [ForeignKey(typeof(Person))]
        [Column("FK_PersonEmail")]
        public string FK_PersonEmail { get => fK_PersonEmail; set => fK_PersonEmail = value; }
        [ForeignKey(typeof(EmployeeType))]
        [Column("FK_EmployeeTypeID")]
        public int FK_EmployeeTypeId { get => fK_EmployeeTypeId; set => fK_EmployeeTypeId = value; }

        public static List<Employee> Select(params Expression<Func<Employee, object>>[] expression)
        {
            return DataObjectFactory.Select<Employee>(expression);
        }
    }
}

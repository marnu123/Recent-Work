using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;
using System.Text;
using BusinessLayer.Validators;

namespace BusinessLayer.Classes
{ 
    [Serializable]
    [Table("tblemployee")]
    public class Employee: Person, IValidatable<Employee>
    {
        private string employeeId;
        private string oldEmployeeId;
        private string fK_PersonEmail;
        private int fK_EmployeeTypeId;
        private string password;
        private EmployeeType employeeType;

        public Employee(Person person, string employeeId, int fK_EmployeeTypeId, string password) 
            :base(person.Id, person.Name, person.Surname, person.Email, person.CellNumber)
        {
            EmployeeId = employeeId;
            FK_PersonEmail = Email;
            FK_EmployeeTypeId = fK_EmployeeTypeId;
            Password = password;
            oldEmployeeId = employeeId;
        }

        public Employee() : base() { }

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
            oldEmployeeId = employeeId;
            try
            {
                employeeType = new EmployeeType(dataRow);
            }
            catch (Exception e) { }
        }

        [Key]
        [Column("PK_EmployeeID")]
        public string EmployeeId { get => employeeId; set => employeeId = value; }
        [KeyStorage("EmployeeId")]
        public string OldEmployeeId { get => oldEmployeeId; set => oldEmployeeId = value; }
        [ForeignKey(typeof(Person))]
        [Column("FK_PersonEmail")]
        public string FK_PersonEmail
        {
            get
            {
                fK_PersonEmail = fK_PersonEmail == null ? Email : fK_PersonEmail;
                return fK_PersonEmail
            ;
            }
            set => fK_PersonEmail = value; }
        [ForeignKey(typeof(EmployeeType))]
        [Column("FK_EmployeeTypeID")]
        public int FK_EmployeeTypeId { get => fK_EmployeeTypeId; set => fK_EmployeeTypeId = value; }
        [Column("Password")]
        public string Password {
            get => password;
            set
            {
                password = Utils.GetSHA256String(value);
            }
        }

        public EmployeeType EmployeeType
        {
            get
            {
                if (employeeType == null)
                {
                    int id = FK_EmployeeTypeId;
                    List<EmployeeType> temp = EmployeeType.Select(et => et.Id == id);
                    employeeType = temp.Count > 0 ? temp[0] : null;
                }

                return employeeType;
            }
            set => employeeType = value;
        }

        public bool ComparePassword(string password)
        {
            return this.password == password;
        }

        public static List<Employee> Select(params Expression<Func<Employee, object>>[] expression)
        {
            Expression<Func<Person, Employee, object>> ex = (p, c) => p.Email == c.FK_PersonEmail;
            Expression[] exList = { ex };
            return DataObjectFactory.Select<Employee>(Utils.JoinArrays(exList, expression));
        }

        public bool Validate(IValidator<Employee> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}

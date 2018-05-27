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
    [Table("tblclient")]
    public class Client : Person, IValidatable<Client>
    {

        private string clientId;
        private int fK_NotificationTypeId;
        private string fK_PersonEmail;
        private string oldClientId;
        private List<Contract> contracts;

        public Client(Person person, string clientID, int fK_NotificationID) 
            :base(person.Id, person.Name, person.Surname, person.Email, person.CellNumber)
        {}

        public Client() { }

        public Client(int personId, string name, string surname, string email, string cellNumber, string clientId,
            int fK_NotificationID) 
            :base(personId, name, surname, email, cellNumber)
        {
            ClientId = clientId;
        }
        
        public Client(DataRow dataRow)
            :base(dataRow)
        {
            ClientId = dataRow["PK_ClientID"].ToString();
            FK_PersonEmail = dataRow["FK_PersonEmail"].ToString();
            FK_NotificationTypeId = Convert.ToInt32(dataRow["FK_NotificationTypeID"]);
            OldClientId = ClientId;
        }

        [Key]
        [Column("PK_ClientID")]
        public string ClientId { get => clientId; set => clientId = value; }
        [KeyStorage("ClientId")]
        public string OldClientId { get => oldClientId; set => oldClientId = value; }
        [ForeignKey(typeof(NotificationType))]
        [Column("FK_NotificationTypeID")]
        public int FK_NotificationTypeId { get => fK_NotificationTypeId; set => fK_NotificationTypeId = value; }
        [ForeignKey(typeof(Person))]
        [Column("FK_PersonEmail")]
        public string FK_PersonEmail
        {
            get => Email;
            set => Email = fK_PersonEmail = value;
        }

        public List<Contract> Contracts
        {
            get
            {
                if (contracts == null)
                {
                    string personEmail = Email;
                    contracts = Contract.Select(c => c.FK_ClientId == personEmail);
                }

                return contracts;
            }
            set => contracts = value;
        }

        public static List<Client> Select(params Expression<Func<Client, object>>[] expression)
        {
            Expression<Func<Person, Client, object>> ex = (p, c) => p.Email == c.FK_PersonEmail;
            Expression[] exList = { ex };
            return DataObjectFactory.Select<Client>(Utils.JoinArrays(expression, exList));
        }

        public bool Validate(IValidator<Client> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}

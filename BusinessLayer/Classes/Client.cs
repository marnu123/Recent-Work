using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tblclient")]
    class Client : Person
    {

        private string clientId;
        private int fK_NotificationTypeId;
        private int fK_PersonId;

        public Client(Person person, string clientID, int fK_NotificationID) 
            :base(person.Id, person.Name, person.Surname, person.Email, person.CellNumber)
        {

        }
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
            FK_NotificationTypeId = Convert.ToInt32(dataRow["FK_NotificationTypeID"]);
        }

        [Key]
        [Column("PK_ClientID")]
        public string ClientId { get => clientId; set => clientId = value; }
        [Column("FK_NotificationTypeID")]
        public int FK_NotificationTypeId { get => fK_NotificationTypeId; set => fK_NotificationTypeId = value; }
        [Column("FK_PersonID")]
        public int FK_PersonId { get => fK_PersonId; set => fK_PersonId = value; }

        public static List<Client> Select(params Expression<Func<Client, object>>[] expression)
        {
            return DataObjectFactory.Select<Client>(expression);
        }
    }
}

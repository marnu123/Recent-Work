using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tblcontract")]
    public class Contract : DataObject
    {
        private string id;
        private string fK_ClientId;
        private DateTime startDate;
        private DateTime endDate;
        private char fK_ContractTypeId;
        private Client client;
        private ContractType contractType;

        public Contract(string id, string fK_ClientId, DateTime startDate, DateTime endDate, char contractTypeId)
        {
            Id = id;
            FK_ClientId = fK_ClientId;
            StartDate = startDate;
            EndDate = endDate;
            FK_ContractTypeId = contractTypeId;
        }

        public Contract(DataRow dataRow)
        {
            Id = dataRow["PK_ContractID"].ToString();
            FK_ClientId = dataRow["FK_ClientID"].ToString();
            StartDate = (DateTime) dataRow["StartDate"];
            EndDate = (DateTime) dataRow["EndDate"];
            FK_ContractTypeId = (char) dataRow["ContractTypeID"];
        }

        [Key]
        [Column("PK_ContractTypeID")]
        public string Id { get => id; set => id = value; }
        [ForeignKey(typeof(Client))]
        [Column("FK_ClientID")]
        public string FK_ClientId { get => fK_ClientId; set => fK_ClientId = value; }
        [Column("StartDate")]
        public DateTime StartDate { get => startDate; set => startDate = value; }
        [Column("EndDate")]
        public DateTime EndDate { get => endDate; set => endDate = value; }
        [Column("FK_ContractTypeID")]
        public char FK_ContractTypeId { get => fK_ContractTypeId; set => fK_ContractTypeId = value; }
        public ContractType ContractType
        {
            get
            {
                if (contractType == null)
                {
                    int matchId = fK_ContractTypeId;
                    List<ContractType> temp = ContractType.Select(p => p.Id == matchId);
                    contractType = temp.Count > 0 ? temp[0] : null;
                }

                return contractType;

            }
            set => contractType = value;
        }

        private Client Client
        {
            get
            {
                if (client == null)
                {
                    string matchId = fK_ClientId;
                    List<Client> temp = Client.Select(p => p.ClientId == matchId);
                    client = temp.Count > 0 ? temp[0] : null;
                }

                return client;

            }
            set => client = value;
        }

        public static List<Contract> Select(params Expression<Func<Contract, object>>[] expression)
        {
            return DataObjectFactory.Select<Contract>(expression);
        }
    }
}

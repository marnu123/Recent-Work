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
    [Table("tblcontract")]
    public class Contract : DataObject, IValidatable<Contract>
    {
        private string id;
        private string oldKey;
        private string fK_ClientId;
        private DateTime startDate;
        private DateTime endDate;
        private char fK_ContractTypeId;
        private char fK_ServiceLevelId;
        private ServiceLevel serviceLevel;
        private Client client;
        private ContractType contractType;


        public Contract(string id, string fK_ClientId, DateTime startDate, DateTime endDate, char contractTypeId, ContractType contractType)
        {
            Id = id;
            OldKey = id;
            FK_ClientId = fK_ClientId;
            StartDate = startDate;
            EndDate = endDate;
            FK_ContractTypeId = contractTypeId;
            ContractType = contractType;
        }

        public Contract(DataRow dataRow)
        {
            Id = dataRow["PK_ContractID"].ToString();
            OldKey = Id;
            FK_ClientId = dataRow["FK_ClientID"].ToString();
            StartDate = (DateTime) dataRow["StartDate"];
            EndDate = (DateTime) dataRow["EndDate"];
            FK_ContractTypeId = Convert.ToChar(dataRow["FK_ContractTypeID"].ToString().Substring(0,1));
            contractType = new ContractType(dataRow);
            ServiceLevel = new ServiceLevel(dataRow);
            FK_ServiceLevelId = Convert.ToChar(dataRow["FK_ServiceLevelID"].ToString().Substring(0, 1));
        }

        [Key]
        [Column("PK_ContractID")]
        public string Id { get => id; set => id = value; }
        [KeyStorage("Id")]
        public string OldKey { get => oldKey; set => oldKey = value; }
        [ForeignKey(typeof(Client))]
        [Column("FK_ClientID")]
        public string FK_ClientId { get => fK_ClientId; set => fK_ClientId = value; }
        [Column("StartDate")]
        public DateTime StartDate { get => startDate; set => startDate = value; }
        [Column("EndDate")]
        public DateTime EndDate { get => endDate; set => endDate = value; }
        [ForeignKey(typeof(ServiceLevel))]
        [Column("FK_ServiceLevelID")]
        public char FK_ServiceLevelId { get => fK_ServiceLevelId; set => fK_ServiceLevelId = value; }
        public ServiceLevel ServiceLevel
        {
            get
            {
                if (serviceLevel == null)
                {
                    int matchId = fK_ServiceLevelId;
                    List<ServiceLevel> serviceLevels = ServiceLevel.Select(s => s.Id == matchId);
                    if (serviceLevels.Count > 0)
                    {
                        serviceLevel = serviceLevels[0];
                    }
                }

                return serviceLevel;
            }
            set => serviceLevel = value;
        }
        [ForeignKey(typeof(ContractType))]
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
            Expression<Func<Contract, ContractType, ServiceLevel, object>> ex =
                (c, ct, s) => c.FK_ContractTypeId == ct.Id && s.Id == c.FK_ServiceLevelId;
            Expression[] list = { ex };
            return DataObjectFactory.Select<Contract>(Utils.JoinArrays(expression, list));
        }

        public bool Validate(IValidator<Contract> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}

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
    [Table("tblcontracttype")]
    public class ContractType : DataObject, IValidatable<ContractType>
    {
        private char id;
        private char oldKey;
        private string title;
        private char fK_ServiceLevelId;
        private ServiceLevel serviceLevel;
        private List<ProductCategory> productCategories;

        public ContractType(char id, string title, char fK_ServiceLevelId, ServiceLevel serviceLevel)
        {
            Id = id;
            Title = title;
            FK_ServiceLevelId = fK_ServiceLevelId;
            ServiceLevel = serviceLevel;
            oldKey = id;
        }

        public ContractType(DataRow dataRow)
        {
            Id = Convert.ToChar(dataRow["PK_ContractTypeID"].ToString().Substring(0, 1));
            Title = dataRow["ContractTypeTitle"].ToString();
            FK_ServiceLevelId = Convert.ToChar(dataRow["FK_ServiceLevelID"].ToString().Substring(0, 1));
            ServiceLevel = new ServiceLevel(dataRow);
            oldKey = Id;
        }

        [Key]
        [Column("PK_ContractTypeID")]
        public char Id { get => id; set => id = value; }
        [KeyStorage("Id")]
        public char OldKey { get => oldKey; set => oldKey = value; }
        [Column("ContractTypeTitle")]
        public string Title { get => title; set => title = value; }
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
            set => serviceLevel = value; }
        public List<ProductCategory> ProductCategories
        {
            get
            {
                if (productCategories == null)
                {
                    char matchId = Id;
                    Expression<Func<ProductCategory, ProductCategory_ContractType, object>> ex =
                        (pc, pcct) => pc.Title == pcct.FK_ProductCategoryTitle && pcct.FK_ContractTypeID == matchId;
                    productCategories = DatabaseHelper.Select<ProductCategory>(ex);
                }

                return productCategories;
            }
            set => productCategories = value;
        }

        public static List<ContractType> Select(params Expression<Func<ContractType, object>>[] expression)
        {
            Expression<Func<ContractType, ServiceLevel, object>> ex = (c, s) => c.FK_ServiceLevelId == s.Id;
            Expression[] list = { ex };
            return DataObjectFactory.Select<ContractType>(Utils.JoinArrays(expression, list));
        }

        public override string ToString()
        {
            return Id + " " + Title + " " + FK_ServiceLevelId;
        }

        public bool Validate(IValidator<ContractType> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}

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
        private List<ProductCategory> productCategories;

        public ContractType(char id, string title)
        {
            Id = id;
            Title = title;
            oldKey = id;
        }

        public ContractType(DataRow dataRow)
        {
            Id = Convert.ToChar(dataRow["PK_ContractTypeID"].ToString().Substring(0, 1));
            Title = dataRow["ContractTypeTitle"].ToString();
            oldKey = Id;
        }

        [Key]
        [Column("PK_ContractTypeID")]
        public char Id { get => id; set => id = value; }
        [KeyStorage("Id")]
        public char OldKey { get => oldKey; set => oldKey = value; }
        [Column("ContractTypeTitle")]
        public string Title { get => title; set => title = value; }
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
            return DataObjectFactory.Select<ContractType>(expression);
        }

        public override string ToString()
        {
            return Id + " " + Title;
        }

        public bool Validate(IValidator<ContractType> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}

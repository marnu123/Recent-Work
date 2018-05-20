using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;


namespace BusinessLayer.Classes
{
    [Table("tblcontracttype")]
    public class ContractType : DataObject
    {
        private char id;
        private string title;
        private int fK_ServiceLevelId;
        private string fK_ProductCategoryTitle;
        private ServiceLevel serviceLevel;
        private ProductCategory productCategory;

        public ContractType(char id, string title, int fK_ServiceLevelId, string fK_ProductCategoryTitle)
        {
            Id = id;
            Title = title;
            FK_ServiceLevelId = fK_ServiceLevelId;
            FK_ProductCategoryTitle = fK_ProductCategoryTitle;
        }

        public ContractType(DataRow dataRow)
        {
            Id = (char)dataRow["PK_ContractTypeID"];
            Title = dataRow["ContractTypeTitle"].ToString();
            FK_ServiceLevelId = (char) dataRow["FK_ServiceLevelID"];
            FK_ProductCategoryTitle = dataRow["FK_ProductCategoryTitle"].ToString();
        }

        [Key]
        [Column("PK_ContractTypeID")]
        public char Id { get => id; set => id = value; }
        [Column("ContractTypeTitle")]
        public string Title { get => title; set => title = value; }
        [ForeignKey(typeof(ServiceLevel))]
        [Column("FK_ServiceLevelID")]
        public int FK_ServiceLevelId { get => fK_ServiceLevelId; set => fK_ServiceLevelId = value; }
        [ForeignKey(typeof(ProductCategory))]
        [Column("FK_ProductCategoryTitle")]
        public string FK_ProductCategoryTitle { get => fK_ProductCategoryTitle; set => fK_ProductCategoryTitle = value; }
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
        public ProductCategory ProductCategory
        {
            get
            {
                if (productCategory == null)
                {
                    string matchId = fK_ProductCategoryTitle;
                    List<ProductCategory> temp = ProductCategory.Select(p => p.Title == matchId);
                    productCategory = temp.Count > 0 ? temp[0] : null;
                }

                return productCategory;
            }
            set => productCategory = value;
        }

        public static List<ContractType> Select(params Expression<Func<ContractType, object>>[] expression)
        {
            return DataObjectFactory.Select<ContractType>(expression);
        }

        public override string ToString()
        {
            return Id + " " + Title + " " + FK_ServiceLevelId + " " + FK_ProductCategoryTitle;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;
using DataLayer;
using DataLayer.Attributes;

namespace BusinessLayer.Classes
{
    [Table("tblproductcategory_contracttype")]
    public class ProductCategory_ContractType : DataObject
    {
        private string fK_ProductCategoryTitle;
        private char fK_ContractTypeID;

        public ProductCategory_ContractType(string fK_ProductCategoryTitle, char fK_ContractTypeID)
        {
            this.FK_ProductCategoryTitle = fK_ProductCategoryTitle;
            this.FK_ContractTypeID = fK_ContractTypeID;
        }

        [Key]
        [ForeignKey(typeof(ProductCategory))]
        [Column("FK_ProductCategoryTitle")]
        public string FK_ProductCategoryTitle { get => fK_ProductCategoryTitle; set => fK_ProductCategoryTitle = value; }
        [Key]
        [ForeignKey(typeof(ContractType))]
        [Column("FK_ContractTypeID")]
        public char FK_ContractTypeID { get => fK_ContractTypeID; set => fK_ContractTypeID = value; }

        public override string ToString()
        {
            return FK_ProductCategoryTitle + " " + FK_ContractTypeID;
        }

        public override bool Equals(object obj)
        {
            ProductCategory_ContractType temp = obj as ProductCategory_ContractType;
            if (temp == null) return false;
            return temp.fK_ContractTypeID == fK_ContractTypeID && temp.fK_ProductCategoryTitle == fK_ProductCategoryTitle;
        }

        public override int GetHashCode()
        {
            return fK_ProductCategoryTitle.GetHashCode() ^ fK_ContractTypeID.GetHashCode();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data;
using DataLayer;
using DataLayer.Attributes;
using BusinessLayer.Validators;

namespace BusinessLayer.Classes
{
    [Table("tblproductcategory")]
    public class ProductCategory : DataObject, IValidatable<ProductCategory>
    {
        private string title;
        private string description;

        public ProductCategory(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public ProductCategory() { }

        public ProductCategory(DataRow dataRow)
        {
            Title = dataRow["ProductCategoryTitle"].ToString();
            Description = dataRow["ProductCategoryDescription"].ToString();
        }

        [Key]
        [Column("ProductCategoryTitle")]
        public string Title { get => title; set => title = value; }
        [Column("ProductCategoryDescription")]
        public string Description { get => description; set => description = value; }

        public static List<ProductCategory> Select(params Expression<Func<ProductCategory, object>>[] expression)
        {
            return DataObjectFactory.Select<ProductCategory>(expression);
        }

        public override string ToString()
        {
            return "Title: " + Title + " Description: " + Description;
        }

        public bool Validate(IValidator<ProductCategory> validator, out IEnumerable<string> brokenRules)
        {
            return validator.IsValid(this, out brokenRules);
        }
    }
}

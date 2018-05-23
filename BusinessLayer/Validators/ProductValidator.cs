using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;
using static BusinessLayer.Utils;

namespace BusinessLayer.Validators
{
    public class ProductValidator : IValidator<Product>
    {
        public IEnumerable<string> BrokenRules(Product entity)
        {
            if (IsEmpty(entity.Name)) yield return "Product name may not be empty";
            if (IsZeroOrEmpty(entity.FK_ManufacturerId)) yield return "A manufacturer has to be chosen for this product";
            if (IsEmpty(entity.FK_ProductCategoryTitle)) yield return "A product category has to be chosen for this product";
            if (IsEmpty(entity.Model)) yield return "Product model must be specified";
        }

        public bool IsValid(Product entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}

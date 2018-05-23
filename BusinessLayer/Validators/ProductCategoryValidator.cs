using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.Validators
{
    public class ProductCategoryValidator : IValidator<ProductCategory>
    {
        public IEnumerable<string> BrokenRules(ProductCategory entity)
        {
            if (Utils.IsEmpty(entity.Title)) yield return "Product Category title may not be empty";
        }

        public bool IsValid(ProductCategory entity, out IEnumerable<string> brokenRules)
        {
            brokenRules = BrokenRules(entity);
            return brokenRules.Count() == 0;
        }
    }
}

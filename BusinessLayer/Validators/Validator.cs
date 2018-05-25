using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;
using BusinessLayer;

namespace BusinessLayer.Validators
{
    public static class Validator
    {
        public static bool Validate<T>(this T entity, out IEnumerable<string> brokenRules)
            where T : IValidatable<T>
        {
            return entity.Validate(ValidatorFactory.GetValidator<T>(), out brokenRules);
        }

        public static bool IsUnique<T>(this T entity)
            where T : DataObject
        {
            if (typeof(T) == typeof(City)) return City.Select(c => c.Name == (entity as City).Name).Count == 0;
            if (typeof(T) == typeof(Street))
            {
                Street street = entity as Street;
                return Street.Select(s => s.AreaCode == street.AreaCode && s.FK_CityID == street.FK_CityID
                && s.Name == street.Name).Count == 0;
            }
            if (typeof(T) == typeof(Manufacturer)) return Manufacturer.Select(m => m.Name == (entity as Manufacturer).Name).Count == 0;
            if (typeof(T) == typeof(ProductCategory)) return ProductCategory.Select(p => p.Title == (entity as ProductCategory).Title).Count == 0;
            if (typeof(T) == typeof(Product)) return Product.Select(p => p.Id == (entity as Product).Id).Count == 0;

            return true;
        }
    }
}

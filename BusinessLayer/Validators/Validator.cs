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
            if (typeof(T) == typeof(City))
            {
                City city = entity as City;
                return City.Select(c => c.Name == city.Name).Count == 0;
            }

            if (typeof(T) == typeof(Street))
            {
                Street street = entity as Street;
                return Street.Select(s => s.AreaCode == street.AreaCode && s.FK_CityID == street.FK_CityID
                && s.Name == street.Name).Count == 0;
            }

            if (typeof(T) == typeof(Manufacturer))
            {
                Manufacturer man = entity as Manufacturer;
                return Manufacturer.Select(m => m.Name == man.Name).Count == 0;
            }

            if (typeof(T) == typeof(ProductCategory))
            {
                ProductCategory cat = entity as ProductCategory;
                return ProductCategory.Select(p => p.Title == cat.Title).Count == 0;
            }

            if (typeof(T) == typeof(Product))
            {
                Product product = entity as Product;
                return Product.Select(p => p.Id == product.Id).Count == 0;
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;
using BusinessLayer;

namespace BusinessLayer.Helpers
{
    /// <summary>
    /// Class used to help simplify calls to complex queries.
    /// </summary>
    public static class ComplexQueryHelper
    {
        public static void InsertLocationForPerson(ref Person person, Location location)
        {
            location.Insert();
            Person_Location pl = new Person_Location(person.Email, location.Id);
            pl.Insert();
            person.Locations.Add(location);
        }

        public static List<Product> GetProductsForLocation(Location location)
        {
            Expression<Func<Product_Location, Product, Manufacturer, ProductCategory, object>> ex = 
                (pl, p, m, pc) => pl.FK_LocationId == location.Id && p.Id == pl.FK_ProductId && m.Id == p.FK_ManufacturerId
                && pc.Title == p.FK_ProductCategoryTitle;
            return DataObjectFactory.Select<Product>(ex);
        }
    }
}

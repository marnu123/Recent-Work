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

        public static void AddConfigurationsForComponent(Component component, List<Configuration> itemsToAdd)
        {
            //List<Component_Configuration> itemsToSave = new List<Component_Configuration>();
            //Insert all items into the database
            itemsToAdd.ForEach(item => new Component_Configuration(component.Id, item.PK_ConfigurationID).Insert());
        }

        public static List<Component> GetComponentsForProduct(Product product)
        {
            string id = product.Id;
            Expression<Func<Option, Component, object>> ex = (o, c) => o.FK_ProductID == id && c.Id == o.FK_ComponentID;
            return DatabaseHelper.Select<Component>(ex);
        }
    }
}

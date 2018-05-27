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

        public static void AddComponentsForProduct(Product product, List<Component> itemsToAdd)
        {
            itemsToAdd.ForEach(item => new Option(product.Id, item.Id).Insert());
        }

        public static void AddLocationsForPerson(Person person, List<Location> itemsToAdd)
        {
            itemsToAdd.ForEach(item => new Person_Location(person.Email, item.Id).Insert());
        }

        public static void AddProductsForLocation(Location location, List<Product> itemsToAdd)
        {
            itemsToAdd.ForEach(item => new Product_Location(0, item.Id, location.Id).Insert());
        }

        public static void UpdateProductCategoriesForContractType(ContractType contractType, List<ProductCategory> itemsToAdd, List<ProductCategory>itemsToDelete)
        {
            itemsToAdd.ForEach(item => new ProductCategory_ContractType(item.Title, contractType.Id).Insert());
            itemsToDelete.ForEach(item => new ProductCategory_ContractType(item.Title, contractType.Id).Delete());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
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

        public static void UpdateComponentsForProduct(Product product, List<Component> itemsToAdd, List<Component> itemsToDelete)
        {
            itemsToAdd.ForEach(item => new Option(product.Id, item.Id).Insert());
            itemsToDelete.ForEach(item => new Option(product.Id, item.Id).Delete());
        }

        public static void UpdateLocationsForPerson(Person person, List<Location> itemsToAdd, List<Location> itemsToDelete)
        {
            itemsToAdd.ForEach(item => new Person_Location(person.Email, item.Id).Insert());
            itemsToDelete.ForEach(item => new Person_Location(person.Email, item.Id).Delete());
        }

        public static void UpdateProductsForLocation(Location location, List<Product> itemsToAdd, List<Product> itemsToDelete)
        {
            itemsToAdd.ForEach(item => new Product_Location(0, item.Id, location.Id).Insert());
            itemsToDelete.ForEach(item => new Product_Location(0, item.Id, location.Id).Delete());
        }

        public static void UpdateProductCategoriesForContractType(ContractType contractType, List<ProductCategory> itemsToAdd, List<ProductCategory>itemsToDelete)
        {
            itemsToAdd.ForEach(item => new ProductCategory_ContractType(item.Title, contractType.Id).Insert());
            itemsToDelete.ForEach(item => new ProductCategory_ContractType(item.Title, contractType.Id).Delete());
        }

        public static List<Task> GetCompleteTaskDetails(params Expression[] expression)
        {
            Expression<Func<Task, Location, Street, City, TaskStatus, TaskType, object>> ex =
                (t, l, s, c, ts, tt) => t.FK_LocationId == l.Id && l.FK_StreetID == s.Id && s.FK_CityID == c.Id
                && ts.Id == t.FK_TaskStatusId && tt.Id == t.FK_TaskTypeId;
            Expression[] list = { ex };
            return DatabaseHelper.Select<Task>(Utils.JoinArrays(expression, list));
        }

        public static List<Location> GetLocationsForPerson(string personEmail)
        {
            Expression<Func<Location, Person_Location, Street, City, object>> ex =
                (l, pl, s, c) => pl.LocationId == l.Id && pl.PersonEmail == personEmail && s.Id == l.FK_StreetID
                && s.FK_CityID == c.Id;
            return DatabaseHelper.Select<Location>(ex);
        }

        public static List<Employee> GetAllTechnicians()
        {
            Expression<Func<Person, Employee, EmployeeType, object>> ex =
                (p, e, et) => p.Email == e.FK_PersonEmail && e.FK_EmployeeTypeId == et.Id && et.Title == "Technician";
            return DatabaseHelper.Select<Employee>(ex);
        }

        public static Employee ValidLogin(string email, string password)
        {
            string encodedPassword = Utils.GetSHA256String(password);
            Expression<Func<Employee, object>> ex =
                e => e.FK_PersonEmail == email && e.Password == encodedPassword;
            List<Employee> result = Employee.Select(ex);
            return result.Count == 1 ? result[0] : null;
        }
    }
}

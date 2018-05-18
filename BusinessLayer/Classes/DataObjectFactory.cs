using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;

namespace BusinessLayer.Classes
{
    public static class DataObjectFactory
    {
        /// <summary>
        /// Select a list of records from the database and return a list of that object
        /// </summary>
        /// <typeparam name="T">A child of DataObject</typeparam>
        /// <param name="expression">Parameters to supply to the database</param>
        /// <returns>List of DataObjects</returns>
        public static List<T> Select<T>(params Expression[] expression)
            where T : DataObject
        {
            DataTable dt = DataHandler.GetInstance().Select<T>(expression);
            List<T> result = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                result.Add((T)Activator.CreateInstance(typeof(T), dr));
            }

            return result;
        }

        /// <summary>
        /// Return the correct object based on the type of the object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        public static DataObject DataObjectCreatorFactory<T>(DataRow dataRow)
            where T : DataObject
        {

            //return (DataObject) ;
            if (typeof(T) == typeof(Person))
            {
                return new Person(dataRow);
            }

            if (typeof(T) == typeof(Street))
            {
                return new Street(dataRow);
            }

            if (typeof(T) == typeof(Location))
            {
                return new Location(dataRow);
            }

            if (typeof(T) == typeof(City))
            {
                return new City(dataRow);
            }

            if (typeof(T) == typeof(Product))
            {
                return new Product(dataRow);
            }

            if (typeof(T) == typeof(OperationType))
            {
                return new OperationType(dataRow);
            }

            if (typeof(T) == typeof(Schedule))
            {
                return new Schedule(dataRow);
            }

            if (typeof(T) == typeof(Employee_Schedule))
            {
                return new Employee_Schedule(dataRow);
            }

            if (typeof(T) == typeof(Person_Location))
            {
                return new Person_Location(dataRow);
            }

            if (typeof(T) == typeof(ProductCategory))
            {
                return new ProductCategory(dataRow);
            }

            if (typeof(T) == typeof(Employee))
            {
                return new Employee(dataRow);
            }

            if (typeof(T) == typeof(EmployeeType))
            {
                return new EmployeeType(dataRow);
            }

            if (typeof(T) == typeof(Client))
            {
                return new Client(dataRow);
            }

            if (typeof(T) == typeof(NotificationType))
            {
                return new NotificationType(dataRow);
            }

            if (typeof(T) == typeof(ContractType))
            {
                return new ContractType(dataRow);
            }

            if (typeof(T) == typeof(Contract))
            {
                return new Contract(dataRow);
            }

            if (typeof(T) == typeof(ServiceLevel))
            {
                return new ServiceLevel(dataRow);
            }

            if (typeof(T) == typeof(Manufacturer))
            {
                return new Manufacturer(dataRow);
            }

            if (typeof(T) == typeof(TaskStatus))
            {
                return new TaskStatus(dataRow);
            }

            throw new TypeLoadException("Object type has not been implemented in DataOjbectCreatorFactory");
        }
    }
}

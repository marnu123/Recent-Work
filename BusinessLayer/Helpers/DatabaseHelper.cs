using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Attributes;
using System.Reflection;

namespace BusinessLayer.Classes
{
    public static class DatabaseHelper
    {
        public static void Insert<T>(this T instance)
            where T : DataObject
        {
            DataHandler dh = DataHandler.GetInstance();
            object val = dh.Insert(instance);
            if (val != null)
            {
                TableColumn cl = dh.Cache[typeof(T)].FindPrimaryKey();
                instance.GetType().GetProperty(cl.PropertyName).SetValue(instance, val);
            }
        }

        public static void Delete<T>(this T instance)
            where T : DataObject
        {
            DataHandler.GetInstance().Delete(instance);
        }
        public static void Update<T>(this T instance)
            where T : DataObject
        {
            DataHandler.GetInstance().Update(instance);
        }

        public static List<T> Select<T>(params Expression[] expression)
            where T : DataObject
        {
            return DataObjectFactory.Select<T>(expression);
        }

        
    }
}

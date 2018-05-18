using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BusinessLayer
{
    //Convert properties of classes to their correct types
    public class DataConverter
    {
        public static void SetPropertyValue(object obj, string propertyName, object propertyValue)
        {
            PropertyInfo pi = obj.GetType().GetProperty(propertyName);

            //Determine whether the property is indeed writeable
            if (pi != null && pi.CanWrite)
            {
                Type propType = Nullable.GetUnderlyingType(pi.PropertyType);
                //Check for null types
                if (propType != null && propType.IsGenericType &&
                    propType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    pi.SetValue(obj, null, null);
                }
                else
                {
                    pi.SetValue(obj, Convert.ChangeType(propertyValue, pi.PropertyType), null);
                }
            }
        }
    }
}

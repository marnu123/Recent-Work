using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PresentationLayer
{
    /// <summary>
    /// This class serves as a method to retrieve nested properties inside classes for access in a bindingsource.
    /// Originally developed by Bradley Smith
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AggregatedPropertyBindingList<T> : List<T>, ITypedList
    {
        public AggregatedPropertyBindingList(IEnumerable<T> range) : base(range) { }

        const int MAX_DEPTH = 5;
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            PropertyDescriptorCollection col = new PropertyDescriptorCollection(null);
            Attribute[] attrs = new Attribute[] { new BrowsableAttribute(true) };

            foreach (PropertyDescriptor prop in GetPropertiesRecursive(typeof(T), null, attrs, 1))
            {
                col.Add(prop);
            }

            return col;
        }

        IEnumerable<PropertyDescriptor> GetPropertiesRecursive(Type t, PropertyDescriptor parent, Attribute[] attributes, int depth)
        {
            if (depth >= MAX_DEPTH)
            {
                yield break;
            }

            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(t, attributes))
            {
                if (parent == null) yield return prop;
                else
                {
                    yield return new AggregatedPropertyDescriptor(parent, prop, attributes);
                }

                foreach (PropertyDescriptor aggregated in GetPropertiesRecursive(prop.PropertyType, parent, attributes, depth + 1))
                {
                    yield return new AggregatedPropertyDescriptor(prop, aggregated, attributes);
                }
            }
        }



        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return GetType().Name;
        }
    }
}

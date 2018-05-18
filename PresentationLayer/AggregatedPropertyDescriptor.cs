using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PresentationLayer
{
    /// <summary>
    /// This class acts as a wrapper to facilitate the retrieving of information in nested classes.
    /// Originally developed by Bradley Smith
    /// </summary>
    public class AggregatedPropertyDescriptor : PropertyDescriptor
    {
        public PropertyDescriptor AggregatedProperty { get; private set; }
        public override Type ComponentType { get { return AggregatedProperty.ComponentType; } }

        public override bool IsReadOnly { get { return AggregatedProperty.IsReadOnly; } }
        public PropertyDescriptor OwningProperty { get; private set; }

        public override Type PropertyType { get { return AggregatedProperty.PropertyType; } }

        public AggregatedPropertyDescriptor(PropertyDescriptor owner, PropertyDescriptor aggregated, Attribute[] attributes)
            :base(owner.Name + "->" + aggregated.Name, attributes)
        {
            OwningProperty = owner;
            AggregatedProperty = aggregated;
        }

        public override bool CanResetValue(object component)
        {
            return AggregatedProperty.CanResetValue(component);
        }

        public override object GetValue(object component)
        {
            return AggregatedProperty.GetValue(OwningProperty.GetValue(component));
        }

        public override void ResetValue(object component)
        {
            AggregatedProperty.ResetValue(component);
        }

        public override void SetValue(object component, object value)
        {
            AggregatedProperty.SetValue(component, value);
        }

        public override bool ShouldSerializeValue(object component)
        {
            return AggregatedProperty.ShouldSerializeValue(component);
        }
    }
}

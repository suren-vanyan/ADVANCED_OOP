using System;
using System.Collections.Generic;
using System.Text;


namespace Obsolete
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct,Inherited = false)]
    public sealed class VehicleDescriptionAttribute : System.Attribute
    {
        public string Description { get; set; }
        public VehicleDescriptionAttribute(string vehicalDescription)
        {
            Description = vehicalDescription;
        }
        public VehicleDescriptionAttribute() { }
    }
}

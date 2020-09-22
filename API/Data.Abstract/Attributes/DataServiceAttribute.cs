using System;

namespace ZFramework.Data.Abstract.Attributes
{
    public class DataServiceAttribute : Attribute
    {
        public Type ServiceType { get; }

        public DataServiceAttribute(Type serviceType)
        {
            ServiceType = serviceType;
        }
    }
}
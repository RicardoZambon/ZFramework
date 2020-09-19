using System;

namespace ZFramework.Data.Abstract.Attributes
{
    public class ServiceAttribute : Attribute
    {
        public Type ServiceType { get; }

        public ServiceAttribute(Type serviceType)
        {
            ServiceType = serviceType;
        }
    }
}
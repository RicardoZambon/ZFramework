using System;

namespace ZFramework.Data.Abstract.Attributes
{
    public sealed class RepositoryAttribute : Attribute
    {
        public Type ServiceType { get; }

        public RepositoryAttribute(Type serviceType)
        {
            ServiceType = serviceType;
        }
    }
}
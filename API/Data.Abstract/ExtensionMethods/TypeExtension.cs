using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ZFramework.Data.Abstract.ExtensionMethods
{
    /// <summary>
    /// Helper methods to use when having Castle.Proxies entities.
    /// </summary>
    public static class TypeExtension
    {
        /// <summary>
        /// Check if a type implements any interface
        /// </summary>
        /// <param name="type">The type to search for the interface.</param>
        /// <param name="interfaceType">The interface type that should search.</param>
        /// <returns>If the type implements the interface, returns true.</returns>
        public static bool ImplementsInterface(this Type type, Type interfaceType)
            => type.GetTypeInfo().ImplementedInterfaces.Contains(interfaceType);

        public static IEnumerable<TypeInfo> GetReferencedTypes<TAttribute>() where TAttribute : Attribute
            => AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.DefinedTypes)
                .Where(x => !x.IsAbstract && !x.IsGenericTypeDefinition && x.GetCustomAttribute<TAttribute>() != null)
                .Distinct();
    }
}
using System;
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

        //public static void GetReferencedAssemblies<TType>()
        //    => GetReferencedAssemblies(typeof(TType));

        //public static IEnumerable<string> GetReferencedAssemblies(this Type interfaceType)
        //    => AppDomain.CurrentDomain.GetAssemblies()
        //        .Where(a => a.DefinedTypes.Any(x => !x.IsAbstract && !x.IsGenericTypeDefinition && x.GetTypeInfo().ImplementedInterfaces.Contains(interfaceType)))
        //        .Select(a => a.GetName().Name)
        //        .Distinct();
    }
}
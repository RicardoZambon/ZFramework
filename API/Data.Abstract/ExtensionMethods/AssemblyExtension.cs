using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ZFramework.Data.Abstract.ExtensionMethods
{
    /// <summary>
    /// Extension methods to get and instantiate the objects when calling OnConfigureMethod in CoreDbContext.
    /// </summary>
    public static class AssemblyExtension
    {
        /// <summary>
        /// Search in the assembly and referenced assemblies for a specific type.
        /// </summary>
        /// <param name="rootAssembly">Parent assembly to search.</param>
        /// <param name="searchedType">Type to search.</param>
        /// <returns>Returns a list of instanced objects.</returns>
        public static IEnumerable<TypeInfo> GetReferencedConstructibleTypes(this Assembly rootAssembly, Type searchedType)
        {
            var list = new List<TypeInfo>();
            list.AddRange(rootAssembly.GetConstructibleTypes(searchedType));
            foreach (var assembly in rootAssembly.GetReferencedAssemblies())
            {
                list.AddRange(Assembly.Load(assembly).GetConstructibleTypes(searchedType));
            }
            return list;
        }

        /// <summary>
        /// Get all types from the assembly that are not abstract and have no generic type definition.
        /// </summary>
        /// <param name="assembly">The assembly to search.</param>
        /// <param name="searchedType">The type searched.</param>
        /// <returns>Returns an IEnumerable of TypeInfo.</returns>
        public static IEnumerable<TypeInfo> GetConstructibleTypes(this Assembly assembly, Type searchedType)
            => assembly.GetLoadableDefinedTypes().Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition && t.ImplementsInterface(searchedType));

        /// <summary>
        /// Get all defined types from the assembly.
        /// </summary>
        /// <param name="assembly">The assembly to search.</param>
        /// <returns>Returns an IEnumerable of TypeInfo.</returns>
        public static IEnumerable<TypeInfo> GetLoadableDefinedTypes(this Assembly assembly)
        {
            try
            {
                return assembly.DefinedTypes;
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(t => t != null).Select(IntrospectionExtensions.GetTypeInfo);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZFramework.Data.Abstract.Helper
{
    public static class DependencyInjectionHelper
    {
        //private static IEnumerable ListServiceClasses<TAttribute>() where TAttribute : Attribute
        //    => from a in AppDomain.CurrentDomain.GetAssemblies().ToList()
        //        from t in a.GetTypes()
        //        let attributes = t.GetCustomAttributes(typeof(TAttribute), true)
        //        where attributes != null && attributes.Length > 0
        //        select new { Attribute = attributes.Cast<TAttribute>().FirstOrDefault(), Type = t };

        //public static IEnumerable<Type[]> List
    }
}

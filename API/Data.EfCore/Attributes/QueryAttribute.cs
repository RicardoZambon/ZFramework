using System;

namespace ZFramework.Data.EfCore.Attributes
{
    public class QueryAttribute : Attribute
    {
        public string ViewName { get; set; }

        public QueryAttribute(string viewName)
        {
            ViewName = viewName;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Linq.Dynamic.Core;
using System.Reflection;
using ZFramework.Data.Abstract.ExtensionMethods;
using ZFramework.Data.Abstract.Interfaces;
using ZFramework.Data.EfCore.Attributes;

namespace ZFramework.Data.EfCore.ExtensionMethods
{
    public static class ModelBuilderExtensions
    {
        public static void CreateEntitiesModel(this ModelBuilder modelBuilder, Assembly migrationsAssembly)
        {
            foreach (var entityType in migrationsAssembly.GetReferencedConstructibleTypes(typeof(IEntity)))
            {
                if (entityType.GetConstructor(Type.EmptyTypes) == null)
                {
                    continue;
                }

                var entityTypeBuilder = modelBuilder.Entity(entityType);

                if (entityType.GetCustomAttribute<QueryAttribute>() is QueryAttribute queryAttribute)
                {
                    entityTypeBuilder.HasNoKey();
                    entityTypeBuilder.ToView(queryAttribute.ViewName);
                }
                else
                {
                    if (entityType.ImplementsInterface(typeof(ISoftDelete)))
                    {
                        entityTypeBuilder.HasQueryFilter(DynamicExpressionParser.ParseLambda(entityType, typeof(bool), "!IsDeleted", Activator.CreateInstance(entityType)));

                        entityTypeBuilder.Property(nameof(ISoftDelete.IsDeleted)).HasDefaultValueSql("0");
                        entityTypeBuilder.Property(nameof(ISoftDelete.IsDeleted)).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    }

                    if (entityType.ImplementsInterface(typeof(IKeyed<>)))
                    {
                        entityTypeBuilder.Property(nameof(IKeyed<object>.ID)).UseIdentityColumn();
                        entityTypeBuilder.Property(nameof(IKeyed<object>.ID)).ValueGeneratedOnAdd();
                        entityTypeBuilder.Property(nameof(IKeyed<object>.ID)).Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                    }
                }
            }
        }
    }
}
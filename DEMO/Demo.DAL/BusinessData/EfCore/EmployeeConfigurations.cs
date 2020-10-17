using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZFramework.Demo.DAL.BusinessData.EfCore
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.Property(x => x.IsActive).HasDefaultValueSql("1");

            builder.Property(x => x.Username).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}
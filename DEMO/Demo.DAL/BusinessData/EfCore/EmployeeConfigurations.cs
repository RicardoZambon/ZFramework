using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;
using ZFramework.Modules.API.Security;

namespace ZFramework.Demo.DAL.BusinessData.EfCore
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.Property(x => x.IsActive).HasDefaultValueSql("1");
            builder.Property(x => x.Username).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.HasIndex(x => x.Username).IsUnique().IncludeProperties(x => new { x.ID, x.PasswordHash});

            builder.HasData(new Employees[] {
                new Employees() { ID = 1, FullName = "Demo user", Username = "demo", PasswordHash = PasswordHash.Create(1, "demo") }
            });
        }
    }
}
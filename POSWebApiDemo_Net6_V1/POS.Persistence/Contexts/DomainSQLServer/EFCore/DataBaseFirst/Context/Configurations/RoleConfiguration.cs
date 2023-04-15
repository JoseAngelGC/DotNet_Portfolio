using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;

namespace POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);
        }
    }
}

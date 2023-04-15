using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.DomainSqlServer.EFCore.DatabaseFirst.Entities;


namespace POS.Persistence.Contexts.DomainSQLServer.EFCore.DataBaseFirst.Context.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("CategoryId");
            builder.HasKey(e => e.Id).HasName("PK__Categori__19093A0BB1FEC823");
            builder.Property(e => e.Name).HasMaxLength(100);
        }
    }
}

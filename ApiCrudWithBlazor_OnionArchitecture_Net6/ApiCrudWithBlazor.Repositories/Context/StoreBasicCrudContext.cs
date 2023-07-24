using ApiCrudWithBlazor.Entities.ApiCrud.EFCore;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudWithBlazor.Repositories.Context
{
    public partial class StoreBasicCrudContext : DbContext
    {
        public StoreBasicCrudContext()
        {
        }

        public StoreBasicCrudContext(DbContextOptions<StoreBasicCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Category__79D361B67CA3F35D");

                entity.ToTable("Category");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Products__5EEC79D1F0D332E6");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(14, 2)")
                    .HasColumnName("precio");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Categoria");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using ApiMovieStoreDemo1_Net5.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMovieStoreDemo1_Net5.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { set; get; }
        public DbSet<Movie> Movies { set; get; }
        public DbSet<UserAuth> UsersAuth { set; get; }
    }
}

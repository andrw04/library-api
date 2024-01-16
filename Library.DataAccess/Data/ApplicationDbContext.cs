using Library.DataAccess.Models;
using Library.DataAccess.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());

            modelBuilder.SeedData();
        }
    }
}

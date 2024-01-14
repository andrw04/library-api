using Library.DataAccess.Models;
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

            var genres = modelBuilder.Entity<Genre>();

            genres.HasData(new Genre[]
            {
                new Genre(){ Id = 1, Name = "Genre1", Description = "Description 1"},
                new Genre() { Id = 2, Name = "Genre2", Description = "Description 2"},
            });

            var authors = modelBuilder.Entity<Author>();

            authors.HasData(new Author[]
            {
                new Author(){ Id = 1, FirstName = "FirstName1", LastName = "LastName1" },
                new Author(){ Id = 2, FirstName = "FirstName2", LastName = "LastName2"}
            });

            var books = modelBuilder.Entity<Book>();

            books.HasOne(b => b.Author).WithMany(a => a.Books);

            books.HasOne(b => b.Genre).WithMany(g => g.Books);
        }
    }
}

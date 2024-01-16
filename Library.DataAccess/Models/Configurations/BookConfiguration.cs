using Library.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Models.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasIndex(b => b.Isbn).IsUnique();

            builder.Property(b => b.Isbn).IsRequired();
            builder.Property(b => b.Title).IsRequired();

            builder
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

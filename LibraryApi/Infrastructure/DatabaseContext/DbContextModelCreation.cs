using LibraryApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Infrastructure.DataBaseContext
{
    public partial class ApplicationDbContext : DbContext
    {
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureAuthor(modelBuilder);
            ConfigureBook(modelBuilder);
            ConfigureLoan(modelBuilder);
    }

    private void ConfigureAuthor(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey("AuthorId")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Author>()
            .Navigation(a => a.Books)
            .AutoInclude();
    }

    private static void ConfigureBook(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey("AuthorId")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Book>()
            .Navigation(b => b.Author)
            .AutoInclude();

        modelBuilder.Entity<Book>()
            .Navigation(b => b.Loans)
            .AutoInclude();
    }

    private static void ConfigureLoan(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Loan>()
            .HasOne(l => l.Book)
            .WithMany(b => b.Loans)
            .HasForeignKey("BookId")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Loan>()
            .Navigation(l => l.Book)
            .AutoInclude();
    }

    }
}

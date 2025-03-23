using LibraryApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Infrastructure.DataBaseContext
{
    public partial class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Books (One-to-Many)
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany() // Now Author has a collection of Books
                .HasForeignKey("AuthorId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .Navigation(b => b.Author)
                .AutoInclude();

            // Loans (One-to-Many)
            modelBuilder.Entity<Loan>()
                .HasOne(b => b.Book)
                .WithMany() // A Loan can have multiple Books
                .HasForeignKey("BookId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Loan>()
                .Navigation(l => l.Book)
                .AutoInclude();
        }
    }
}

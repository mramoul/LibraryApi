using LibraryApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Infrastructure.DataBaseContext
{
    public partial class ApplicationDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithOne()
            .HasForeignKey<Book>("AuthorId")
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
            .Navigation(b => b.Author)
            .AutoInclude();
        }
    }
}

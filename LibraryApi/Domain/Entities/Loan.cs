using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Domain.Entities;

public class Loan: Entity
{
    [ForeignKey("BookId")]
    public required Book Book { get; set; }
    public DateTime BorrowDate { get; private set; } = DateTime.UtcNow;
    public DateOnly ReturnDate { get; set; }
}

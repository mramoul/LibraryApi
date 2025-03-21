namespace LibraryApi.Domain.Entities;

public class Loan: Entity
{
    public required Book Book { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
}

namespace LibraryApi.Domain;

public class Loan
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required Book Book { get; set; }
    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
}

namespace LibraryApi.Application.Loans.ListLoan._DTO;

public class LoanModel
{
    public required Guid Id {get; init;}
    public required BookModel Book { get; init; }
    public DateTime BorrowDate { get; init; }
    public DateOnly ReturnDate { get; init; }
}
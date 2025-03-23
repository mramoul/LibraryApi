using MediatR;

namespace LibraryApi.Application.Loans.CreateLoan
{
    /// <summary>
    /// Represents the data command required to create a new loan,
    //  used to trigger the creation process through Mediator.
    /// </summary>
    public class CreateLoanCommand : IRequest<CreateLoanCommandResult>
    {
        public required Guid BookId { get; set; }
        public DateOnly ReturnDate { get; set; }
    }
}

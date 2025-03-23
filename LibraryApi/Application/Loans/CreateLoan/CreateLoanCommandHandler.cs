using LibraryApi.Application.Books.CreateBook;
using LibraryApi.Application.Errors;
using LibraryApi.Application.Services.Loans;
using LibraryApi.Domain.Entities;
using LibraryApi.Infrastructure.DataBaseContext;
using MediatR;

namespace LibraryApi.Application.Loans.CreateLoan
{
    /// <summary>
    /// Handles the <see cref="CreateLoanCommand"/>, returns the result with the created loan's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="loanServices">Service to retrieve data from the Db Context</param>
    /// <param name="mapper">Maps the DB source data to the result representation</param>
    public class CreateLoanCommandHandler(IApplicationDbContext context, ILoanServices loanServices, ICreateLoanCommandMapper mapper) : IRequestHandler<CreateLoanCommand, CreateLoanCommandResult>
    {
        public async Task<CreateLoanCommandResult> Handle(CreateLoanCommand command, CancellationToken cancellationToken)
        {
            var book = loanServices.GetBookByIdAsync(command.BookId, cancellationToken);

            if(book.Result is null)
                throw new NotFoundError($"{nameof(Book)} with ID {command.BookId} was not found.");

            var loan = mapper.Map(command, book.Result);

            await context.AppendAsync(loan, cancellationToken);
            await context.SaveAsync(cancellationToken);

            return new CreateLoanCommandResult(loan.Id);
        }
    }
}

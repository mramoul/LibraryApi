using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Loans.CreateLoan
{
    /// <summary>
    /// Defines a mapper to convert a <see cref="CreateLoanCommand"/> into a <see cref="Loan"/> entity.
    /// </summary>
    public interface ICreateLoanCommandMapper
    {
        public Loan Map(CreateLoanCommand source, Book book);        
    }

    /// <inheritdoc />
    public class CreateLoanCommandMapper: ICreateLoanCommandMapper
    {
        public Loan Map(CreateLoanCommand source, Book book)
        {
            return new Loan()
            {
                Book = book,
                ReturnDate = source.ReturnDate,
            };
        }
    }
}

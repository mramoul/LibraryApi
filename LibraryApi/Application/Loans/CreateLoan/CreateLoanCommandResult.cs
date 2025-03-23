namespace LibraryApi.Application.Loans.CreateLoan
{
    /// <summary>
    /// Defines a record to return the result of <see cref="CreateLoanCommand"/>, containing the new loan's unique `Id`.
    /// </summary>
    /// <param name="Id">Id of the entity</param>
    public record CreateLoanCommandResult(Guid Id);
}

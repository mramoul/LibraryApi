using LibraryApi.Application.Loans.CreateLoan;
using LibraryApi.Application.Loans.GetLoan;
using LibraryApi.Application.Loans.ListLoan;
using MediatR;

namespace LibraryApi.Api.Loans
{
    /// <summary>
    /// Contains the complete Loan's endpoints registration.
    /// </summary>
    public static class LoanEndpoints{

        public static WebApplication Register(WebApplication application)
        {
            const string EntityName = "loan";

            application.MapPost($"/api/{EntityName}", async (CreateLoanCommand command, IMediator mediator) =>
            {
                var loanId = await mediator.Send(command);
                return Results.Created($"api/{EntityName}/{loanId}", loanId);
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Create a {EntityName}.");

            application.MapGet($"/api/{EntityName}", async (Guid id, IMediator mediator) =>
            {
                var loan = await mediator.Send(new GetLoanQuery(id));
                return Results.Ok(loan);
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Retrieves a {EntityName} by ID.");

            application.MapGet($"/api/{EntityName}-list", async (IMediator mediator) =>
            {
                var listLoans = await mediator.Send(new ListLoanQuery());
                return Results.Ok(listLoans);
            })
            .WithTags(EntityName.ToUpper())
            .WithSummary($"Retrieves all {EntityName}s.");

            return application;
        }
    }   
}

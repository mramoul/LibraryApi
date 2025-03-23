using LibraryApi.Application.Loans.CreateLoan;
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

            return application;
        }
    }   
}

using LibraryApi.Application.Errors;
using LibraryApi.Application.Services.Authors;
using LibraryApi.Domain.Entities;
using MediatR;

namespace LibraryApi.Application.Books.ListBook
{
    /// <summary>
    /// Handles the <see cref="ListBookQuery"/>, returns the result with the list of books data.
    /// </summary>
    /// <param name="bookServices">Service to retrieve data from the Db Context</param>
    /// <param name="mapper">Maps the DB source data to the result representation</param>
    public class ListAuthorQueryHandler(IBookServices bookServices, IListBookQueryMapper mapper) : IRequestHandler<ListBookQuery, ListBookQueryResult>
    {
        public async Task<ListBookQueryResult> Handle(ListBookQuery query, CancellationToken cancellationToken)
        {
            var books = await bookServices.GetListdAsync(cancellationToken);

            if(books is null)
                throw new NotFoundError($"No {nameof(Book)}s were found.");
                
            var result = mapper.Map(books);

            return result;
        }
    }
}

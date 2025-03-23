using LibraryApi.Application.Books.GetBook;
using LibraryApi.Application.Errors;
using LibraryApi.Application.Services.Books;
using LibraryApi.Domain.Entities;
using MediatR;

namespace LibraryApi.Application.Authors.GetAuthor
{
    /// <summary>
    /// Handles the <see cref="GetBookQuery"/>, returns the result with the book's data.
    /// </summary>
    /// <param name="bookServices">Service to retrieve data from the Db Context</param>
    /// <param name="mapper">Maps the DB source data to the result representation</param>
    public class GetBookQueryHandler(IBookServices bookServices, IGetBookQueryMapper mapper) : IRequestHandler<GetBookQuery, GetBookQueryResult>
    {
        public async Task<GetBookQueryResult> Handle(GetBookQuery query, CancellationToken cancellationToken)
        {
            var book = await bookServices.GetByIdAsync(query.Id, cancellationToken);

            if(book is null)
                throw new NotFoundError($"{nameof(Book)} with ID {query.Id} was not found.");
                
            var result = mapper.Map(book);

            return result;
        }
    }
}

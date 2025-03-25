using LibraryApi.Application.Errors;
using LibraryApi.Application.Services.Authors;
using LibraryApi.Domain.Entities;
using MediatR;

namespace LibraryApi.Application.Authors.GetAuthor
{
    /// <summary>
    /// Handles the <see cref="GetAuthorQuery"/>, returns the result with the author's data.
    /// </summary>
    /// <param name="authorServices">Service to retrieve data from the Db Context</param>
    /// <param name="mapper">Maps the DB source data to the result representation</param>
    public class GetAuthorQueryHandler(IAuthorServices authorServices, IGetAuthorQueryMapper mapper) : IRequestHandler<GetAuthorQuery, GetAuthorQueryResult>
    {
        public async Task<GetAuthorQueryResult> Handle(GetAuthorQuery query, CancellationToken cancellationToken)
        {
            var author = await authorServices.GetByIdAsync(query.Id, cancellationToken);

            if(author is null)
                throw new NotFoundError($"${nameof(Author)} with ID {query.Id} was not found.");
                
            var result = mapper.Map(author);

            return result;
        }
    }
}

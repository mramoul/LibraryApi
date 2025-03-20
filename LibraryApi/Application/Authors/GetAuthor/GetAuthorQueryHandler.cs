using LibraryApi.Application.Services.Authors;
using MediatR;

namespace LibraryApi.Application.Authors
{
    /// <summary>
    /// Handles the <see cref="GetAuthorCommand"/>, returns the result with the created author's ID.
    /// </summary>
    /// <param name="context">Db Context</param>
    /// <param name="mapper">Maps the command data to the entity representation</param>
    public class GetAuthorQueryHandler(IAuthorServices authorServices, IGetAuthorQueryMapper mapper) : IRequestHandler<GetAuthorQuery, GetAuthorQueryResult>
    {
        public async Task<GetAuthorQueryResult> Handle(GetAuthorQuery query, CancellationToken cancellationToken)
        {
            var author = await authorServices.GetByIdAsync(query.Id, cancellationToken);

            if(author is null)
                throw new NotFoundException($"Author with ID {query.Id} was not found.");
                
            var result = mapper.Map(author);

            return result;
        }
    }
}

using LibraryApi.Application.Errors;
using LibraryApi.Application.Services.Authors;
using MediatR;

namespace LibraryApi.Application.Authors.ListAuthor
{
    /// <summary>
    /// Handles the <see cref="ListAuthorQuery"/>, returns the result with the list of authors data.
    /// </summary>
    /// <param name="authorServices">Service to retrieve data from the Db Context</param>
    /// <param name="mapper">Maps the DB source data to the result representation</param>
    public class ListAuthorQueryHandler(IAuthorServices authorServices, IListAuthorQueryMapper mapper) : IRequestHandler<ListAuthorQuery, ListAuthorQueryResult>
    {
        public async Task<ListAuthorQueryResult> Handle(ListAuthorQuery query, CancellationToken cancellationToken)
        {
            var authors = await authorServices.GetListdAsync(cancellationToken);

            if(authors is null)
                throw new NotFoundError($"No Authors were found.");
                
            var result = mapper.Map(authors);

            return result;
        }
    }
}

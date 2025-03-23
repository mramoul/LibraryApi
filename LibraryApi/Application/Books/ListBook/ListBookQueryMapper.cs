using System.Collections.Immutable;
using LibraryApi.Application.Books.ListBook._Mappers;
using LibraryApi.Application.Books.Listbook._DTO;
using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Books.ListBook
{
    /// <summary>
    /// Defines a mapper to convert a list of <see cref="Book"/> into a <see cref="ListBookQueryResult"/>.
    /// </summary>
    public interface IListBookQueryMapper
    {
        public ListBookQueryResult Map(List<Book> source);        
    }

    /// <inheritdoc />
    public class ListBookQueryMapper(IAuthorMapper authorMapper) : IListBookQueryMapper
    {
        public ListBookQueryResult Map(List<Book> source)
        {
            
            return new ListBookQueryResult()
            {
              ListBooks = source.Select(x => MapItem(x)).ToImmutableList()
            };
        }

        private BookModel MapItem(Book source)
        {
            return new BookModel()
            {
                Id = source.Id,
                Title = source.Title,
                Author = authorMapper.Map(source.Author)
            };
        }
    }
}

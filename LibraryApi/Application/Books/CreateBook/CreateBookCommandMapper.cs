using LibraryApi.Domain.Entities;
namespace LibraryApi.Application.Books.CreateBook
{
    /// <summary>
    /// Defines a mapper to convert a <see cref="CreateBookCommand"/> into a <see cref="Book"/> entity.
    /// </summary>
    public interface ICreateBookCommandMapper
    {
        public Book Map(CreateBookCommand source, Author author);        
    }

    /// <inheritdoc />
    public class CreateBookCommandMapper: ICreateBookCommandMapper
    {
        public Book Map(CreateBookCommand source, Author author)
        {
            return new Book()
            {
                Title = source.Title,
                ISBN = source.ISBN,
                PublishedDate = source.PublishedDate,
                Author = author
            };
        }
    }
}

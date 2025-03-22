using LibraryApi.Domain.Entities;

namespace LibraryApi.Application.Books.UpdateBook
{
    /// <summary>
    /// Defines a mapper to convert an <see cref="UpdateBookCommand"/> into a <see cref="Book"/> entity.
    /// </summary>
    public interface IUpdateBookCommandMapper
    {
        public Book Map(UpdateBookCommand source, Author author);        
    }

    /// <inheritdoc />
    public class UpdateBookCommandMapper: IUpdateBookCommandMapper
    {
        public Book Map(UpdateBookCommand source, Author author)
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

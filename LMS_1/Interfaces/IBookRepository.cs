using LMS_1.Dtos;
using LMS_1.Entity;
using LMS_1.Sharing;

namespace LMS_1.Interfaces
{
    public interface IBookRepository
    {
        Task<(IEnumerable<BookDto>, int totalCount)> GetAllAvilableBooksAsync(BookParams bookParams);
        Task<(IEnumerable<BookDto>, int totalCount)> GetAllIssuedBooksAsync(BookParams bookParams);
        Task<Book> GetBookByIdAsync(int BookId);
        Task AddBookAsync(BookDto book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int BookId);
        Task IssueBooktAsync(int BookId);
    }
}

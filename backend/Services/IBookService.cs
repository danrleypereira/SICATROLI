using backend.Models;

namespace backend.Services
{
    public interface IBookService{
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBooksAsync(Book book);
        Task<Book> UpdateBooksAsync(Book book);
        Task DeleteBooksAsync(int id);
    }
}
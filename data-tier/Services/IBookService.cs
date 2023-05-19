using System.Collections.Generic;
using System.Threading.Tasks;
using dal.Models;

namespace dal.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book Book);
        Task<Book> UpdateBookAsync(Book Book);
        Task DeleteBookAsync(int id);
    }
}

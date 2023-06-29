using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Services
{
    public class BookService : IBookService
    {
        private readonly MyDbContext _context;
        public BookService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> AddBooksAsync(Book book)
        {   
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> UpdateBooksAsync(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(book.id))
                {
                    throw new ArgumentException($"Book with id:{book.id} not found");
                }
                throw;
            }
            return book;
        }

        public async Task DeleteBooksAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book == null){
                throw new ArgumentException($"Book with id:{id} not found");
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.id == id);
        }


    }
}
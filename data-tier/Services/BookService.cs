using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dal.Models;
using dal.Services;

namespace dal.Services
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

        public async Task<Book> AddBookAsync(Book Book)
        {
            await _context.Books.AddAsync(Book);
            await _context.SaveChangesAsync();

            return Book;
        }

        public async Task<Book> UpdateBookAsync(Book Book)
        {
            _context.Entry(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.Id))
                {
                    throw new ArgumentException($"Book with id {Book.Id} not found.");
                }

                throw;
            }

            return Book;
        }

        public async Task DeleteBookAsync(int id)
        {
            var Book = await _context.Books.FindAsync(id);
            if (Book == null)
            {
                throw new ArgumentException($"Book with id {id} not found.");
            }

            _context.Books.Remove(Book);
            await _context.SaveChangesAsync();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}

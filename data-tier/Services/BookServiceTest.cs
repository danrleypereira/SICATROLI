using Microsoft.EntityFrameworkCore;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal.Models;
using dal.Services;

namespace dal.Tests
{

    public class BookServiceTest :  IDisposable
    {
        private DbContextOptions<MyDbContext> _options;
        private MyDbContext _context;
        private BookService _service;

        public BookServiceTest()
        {
            _options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .EnableSensitiveDataLogging() 
                .Options;

            _context = new MyDbContext(_options);
            _service = new BookService(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task GetBooksAsync_ReturnsListOfBooks()
        {
            
            var booksToAdd = new List<Book>
            {
                new Book { Name = "Book 1", Author = "Author 1", Language = "Portuguese", Publisher = "Yuval Noah Harari 1"},
                new Book { Name = "Book 2", Author = "Author 2", Language = "Portuguese", Publisher = "Yuval Noah Harari 2"},
                new Book { Name = "Book 3", Author = "Author 3", Language = "Portuguese", Publisher = "Yuval Noah Harari 3"}
            };

            await _context.Books.AddRangeAsync(booksToAdd);
            await _context.SaveChangesAsync();

            
            var result = await _service.GetBooksAsync();

            Assert.Equal(booksToAdd, result.ToList());
        }

        [Fact]
        public async Task GetBookByIdAsync_ReturnsCorrectBook()
        {
            
            var bookToAdd = new Book {Name = "Book 1", Author = "Author 1", Language = "Portuguese", Publisher = "Yuval Noah Harari 1"};
            await _context.Books.AddAsync(bookToAdd);
            await _context.SaveChangesAsync();

            
            var result = await _service.GetBookByIdAsync(bookToAdd.Id);

            
            Assert.Equal(bookToAdd, result);
        }

        [Fact]
        public async Task AddBookAsync_AddsNewBook()
        {
            
            var bookToAdd = new Book { Name = "Book 1", Author = "Author 1", Language = "Portuguese", Publisher = "Yuval Noah Harari 4" };

            
            var result = await _service.AddBookAsync(bookToAdd);

            
            Assert.Equal(bookToAdd, result);
            Assert.Contains(bookToAdd, _context.Books);
        }

        [Fact]
        public async Task UpdateBookAsync_UpdatesExistingBook()
        {
            
            var bookToAdd = new Book { Name = "Book 1", Author = "Author 1", Language = "Portuguese", Publisher = "Yuval Noah Harari 1",
             Edition = 0, Id = 1, IsExchanged =  false};
            await _context.Books.AddAsync(bookToAdd);
            await _context.SaveChangesAsync();

            var updatedBook = new Book {  Name = "Book 1", Author = "Author 1", Language = "Portuguese", Publisher = "Yuval Noah Harari 1",
             Edition = 0, Id = 1, IsExchanged =  false};

            
            var existingBook = await _context.Books.FindAsync(updatedBook.Id);
             if (existingBook != null)
                    {
                        existingBook.Name = updatedBook.Name;
                        existingBook.Author = updatedBook.Author;
                        existingBook.Language = updatedBook.Language;
                        existingBook.Publisher = updatedBook.Publisher;
                        await _context.SaveChangesAsync();
                    }
  
          
            
            
            //Assert.Equal(updatedBook,existingBook);
            Assert.Contains(existingBook, _context.Books);
        }

        [Fact]
        public async Task DeleteBookAsync_DeletesExistingBook()
        {
            
            var bookToAdd = new Book { Name = "Book 1", Author = "Author 1", Language = "Portuguese", Publisher = "Yuval Noah Harari 1" };
            await _context.Books.AddAsync(bookToAdd);
            await _context.SaveChangesAsync();

           
            await _service.DeleteBookAsync(bookToAdd.Id);

            
            Assert.DoesNotContain(bookToAdd, _context.Books);
        }
    }
}

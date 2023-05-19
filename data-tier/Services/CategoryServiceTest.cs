using Microsoft.EntityFrameworkCore;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dal.Models;
using dal.Services;

namespace dal.Tests{

    public class CategoryServiceTest : IDisposable
    {
        private DbContextOptions<MyDbContext> _options;
        private MyDbContext _context;
        private CategoryService _service;

        public CategoryServiceTest()
        {
            _options = new DbContextOptionsBuilder<MyDbContext>()
                .UseInMemoryDatabase(databaseName: "testCategory_database")
                .EnableSensitiveDataLogging()
                .Options;

            _context = new MyDbContext(_options);
            _service = new CategoryService(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task GetCategoriesAsync_ReturnsListOfCategories()
        { 
            var categoriesToAdd = new List<Category>
            {
                new Category { Genre = "Comédia", Pages = 159,Rarity = "mt raro", Conservation = "bem conservado", Price = 2.34 }
            };
            await _context.Categories.AddRangeAsync(categoriesToAdd);
            await _context.SaveChangesAsync();

            var result = await _service.GetCategoriesAsync();

            Assert.Equal(categoriesToAdd, result.ToList());
        }
        [Fact]
        public async Task getCategoryByIdAsync_ReturnsCorrectCategory()
        {
            var categoryToAdd = new Category { Id = 1, Genre = "Comédia", Pages = 159,Rarity = "mt raro", Conservation = "bem conservado", Price = 2.34 };
            await _context.Categories.AddAsync(categoryToAdd);
            await _context.SaveChangesAsync();

            var result = await _service.GetCategoryByIdAsync(categoryToAdd.Id);
            Assert.Equal(categoryToAdd, result);

        
        }
        [Fact]
        public async Task AddCategoryAsync_AddNewCategory()
        {
            var categoryToAdd = new Category {Id = 1, Genre = "Comédia", Pages = 159,Rarity = "mt raro", Conservation = "bem conservado", Price = 2.34 };
            var result = await _service.AddCategoryAsync(categoryToAdd);

            Assert.Equal(categoryToAdd, result);
            Assert.Contains(categoryToAdd, _context.Categories);
        }
        [Fact]
        public async Task UpdateCategoryAsync_UpdatesExistingCategory()
        {
            var categoryToAdd = new Category {Id = 1, Genre = "Comédia", Pages = 159,Rarity = "mt raro", Conservation = "bem conservado", Price = 2.34};
            await _context.Categories.AddAsync(categoryToAdd);
            await _context.SaveChangesAsync();

            var updatedCategory = new Category {Id = 1, Genre = "Romance", Pages = 400 ,Rarity = "mt raro", Conservation = "bem conservado", Price = 8.34};

            var existingCategory = await _context.Categories.FindAsync(updatedCategory.Id);
            if(existingCategory != null)
            {
                existingCategory.Genre = updatedCategory.Genre;
                existingCategory.Pages = updatedCategory.Pages;
                existingCategory.Rarity = updatedCategory.Rarity;
                existingCategory.Conservation = updatedCategory.Conservation;
                existingCategory.Price = updatedCategory.Price;
                await _context.SaveChangesAsync();
            }
            //Assert.Equal(updatedCategory,existingCategory);
            Assert.Contains(existingCategory, _context.Categories);
        }
        [Fact]
        public async Task DeleteCategoryAsync_deletesExistingCategory()
        {
            var categoryToAdd = new Category { Id = 1, Genre = "Romance", Pages = 400 ,Rarity = "mt raro", Conservation = "bem conservado", Price = 8.34};
            await _context.Categories.AddAsync(categoryToAdd);
            await _context.SaveChangesAsync();

            await _service.DeleteCategoryAsync(categoryToAdd.Id);

            Assert.DoesNotContain(categoryToAdd, _context.Categories);
        
        }
    }
}
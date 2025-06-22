using SmartExpenses.Services.Infrastucture;
using SmartExpenses.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartExpenses.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly SmartExpensesContext _context;
        public CategoryService(SmartExpensesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new InvalidOperationException($"Category with ID {id} not found.");
            }
            return category;
        }

        public async Task CreateAsync(Category payload)
        {
            payload.CreatedOn = DateTime.UtcNow;
            _context.Categories.Add(payload);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category payload)
        {
            var existing = await _context.Categories.FindAsync(payload.Id);
            if (existing != null)
            {
                existing.Name = payload.Name;
                existing.Description = payload.Description;
                existing.CategoryType = payload.CategoryType;
                existing.ModifiedOn = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}

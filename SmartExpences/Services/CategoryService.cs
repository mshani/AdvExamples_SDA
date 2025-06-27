using SmartExpenses.Services.Infrastucture;
using SmartExpenses.Models;
using Microsoft.EntityFrameworkCore;
using SmartExpenses.Models.Enums;

namespace SmartExpenses.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly SmartExpensesContext _context;
        public CategoryService(SmartExpensesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CategoryTypeEnum? categoryType = null, bool? isActive = null)
        {
            var query = _context.Categories.AsQueryable();
            if (categoryType != null)
            {
                query = query.Where(x => x.CategoryType == categoryType);
            }
            if (isActive != null)
            {
                query = query.Where(x => x.IsActive == true);
            }
            var data = await query.ToListAsync();
            return data;
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
                existing.IsActive = payload.IsActive;
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

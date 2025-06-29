using SmartExpenses.Services.Infrastucture;
using SmartExpenses.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartExpenses.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly SmartExpensesContext _context;
        public ExpenseService(SmartExpensesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync(int ? categoryId = null, string? description = null, decimal? minValue = 0, decimal? maxValue = 0)
        {
            var query = _context.Expenses.AsQueryable();
            if (categoryId != null)
            {
                query = query.Where(x => x.CategoryId == categoryId);
            }
            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(x => x.Description != null && x.Description.Contains(description));
            }
            if (minValue.HasValue)
            {
                query = query.Where(x => x.Value >= minValue);
            }
            if (maxValue.HasValue)
            {
                query = query.Where(x => x.Value <= maxValue);
            }
            var data = await query.ToListAsync();
            return data;
        }

        public async Task<decimal> GetTotalAsync()
        {
            var result = await _context.Expenses.SumAsync(x => x.Value);
            return result;
        }

        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
            var expense = await _context.Expenses
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (expense == null)
            {
                throw new InvalidOperationException($"Expense with ID {id} not found.");
            }
            return expense;
        }

        public async Task CreateExpenseAsync(Expense payload)
        {
            payload.CreatedOn = DateTime.UtcNow;
            _context.Expenses.Add(payload);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExpenseAsync(Expense payload)
        {
            var existing = await _context.Expenses.FindAsync(payload.Id);
            if (existing != null)
            {
                existing.Value = payload.Value;
                existing.Description = payload.Description;
                existing.CategoryId = payload.CategoryId;
                existing.ExpenseDate = payload.ExpenseDate;
                existing.ModifiedOn = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
        }
    }
}

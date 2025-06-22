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

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            return await _context.Expenses.Include(x => x.Category).ToListAsync();
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

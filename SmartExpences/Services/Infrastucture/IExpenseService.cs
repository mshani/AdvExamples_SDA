using SmartExpenses.Models;

namespace SmartExpenses.Services.Infrastucture
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync(int? categoryId = null, string? description = null, decimal? minValue = 0, decimal? maxValue = 0);
        Task<decimal> GetTotalAsync();
        Task<Expense> GetExpenseByIdAsync(int id);
        Task CreateExpenseAsync(Expense payload);
        Task UpdateExpenseAsync(Expense payload);
        Task DeleteExpenseAsync(int id);
    }
}

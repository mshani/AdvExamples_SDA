using SmartExpenses.Models;

namespace SmartExpenses.Services.Infrastucture
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<Expense> GetExpenseByIdAsync(int id);
        Task CreateExpenseAsync(Expense payload);
        Task UpdateExpenseAsync(Expense payload);
        Task DeleteExpenseAsync(int id);
    }
}

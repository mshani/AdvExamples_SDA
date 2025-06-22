using SmartExpenses.Models;

namespace SmartExpenses.Services.Infrastucture
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task CreateAsync(Category payload);
        Task UpdateAsync(Category payload);
        Task DeleteAsync(int id);
    }
}

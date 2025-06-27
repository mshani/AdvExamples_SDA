using SmartExpenses.Models;
using SmartExpenses.Models.Enums;

namespace SmartExpenses.Services.Infrastucture
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync(CategoryTypeEnum? categoryType = null, bool? isActive = null);
        Task<Category> GetByIdAsync(int id);
        Task CreateAsync(Category payload);
        Task UpdateAsync(Category payload);
        Task DeleteAsync(int id);
    }
}

using SmartExpenses.Models;

namespace SmartExpenses.Services.Infrastucture
{
    public interface IIncomingService
    {
        Task<IEnumerable<Incoming>> GetAllIncomingsAsync();
        Task<Incoming> GetIncomingByIdAsync(int id);
        Task CreateIncomingAsync(Incoming payload);
        Task UpdateIncomingAsync(Incoming payload);
        Task DeleteIncomingAsync(int id);
    }
}

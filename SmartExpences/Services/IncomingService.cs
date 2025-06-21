using Microsoft.EntityFrameworkCore;
using SmartExpenses.Models;
using SmartExpenses.Services.Infrastucture;

namespace SmartExpenses.Services
{
    public class IncomingService : IIncomingService
    {
        private readonly SmartExpensesContext _context;
        public IncomingService(SmartExpensesContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Incoming>> GetAllIncomingsAsync()
        {
            return await _context.Incomings.ToListAsync();
        }
        public async Task<Incoming> GetIncomingByIdAsync(int id)
        {
            var incoming = await _context.Incomings.FindAsync(id);
            if (incoming == null)
            {
                throw new InvalidOperationException($"Incoming with ID {id} not found.");
            }
            return incoming;
        }
        public async Task CreateIncomingAsync(Incoming payload)
        {
            payload.CreatedOn = DateTime.UtcNow;
            _context.Incomings.Add(payload);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateIncomingAsync(Incoming payload)
        {
            var existing = await _context.Incomings.FindAsync(payload.Id);
            if (existing != null)
            {
                existing.Value = payload.Value;
                existing.Description = payload.Description;
                existing.ExpenseDate = payload.ExpenseDate;
                existing.ModifiedOn = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteIncomingAsync(int id)
        {
            var incoming = await _context.Incomings.FindAsync(id);
            if (incoming != null)
            {
                _context.Incomings.Remove(incoming);
                await _context.SaveChangesAsync();
            }
        }
    }
}
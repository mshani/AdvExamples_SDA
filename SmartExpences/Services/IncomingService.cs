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
        public async Task<IEnumerable<Incoming>> GetAllIncomingsAsync(int? categoryId = null)
        {
            var query = _context.Incomings.Include(x => x.Category).AsQueryable();
            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }
            var data = await query.ToListAsync();
            return data;
        }

        public async Task<decimal> GetTotalAsync()
        {
            var result = await _context.Incomings.SumAsync(x => x.Value);
            return result;
        }
        public async Task<Incoming> GetIncomingByIdAsync(int id)
        {
            var incoming = await _context.Incomings.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
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
                existing.CategoryId = payload.CategoryId;
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
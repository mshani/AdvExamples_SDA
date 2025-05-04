using GameAPI.BusinessLayer.Infrastructure;
using GameAPI.DataLayer;
using GameAPI.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.BusinessLayer.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly StoreContext _context;
        public PublisherService(StoreContext context) { 
            _context = context;
        }

        public List<Publisher> GetAll()
        {
            var result = _context.Publishers.ToList();
            return result;
        }

        public Publisher? GetById(int id)
        {
            var result = _context.Publishers
                        .Include(x => x.VideoGames)
                        .FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Publisher Create(Publisher videoGame) {
            videoGame.Id = 0;
            _context.Publishers.Add(videoGame);
            _context.SaveChanges();
            return videoGame;          
        }

        public Publisher? Update(Publisher videoGame)
        {
            var existing = _context.Publishers.FirstOrDefault(x => x.Id == videoGame.Id);
            if (existing != null)
            {
                existing.Name = videoGame.Name;
                existing.Phone = videoGame.Phone;
                existing.Address = videoGame.Address;

                _context.Publishers.Update(existing);
                _context.SaveChanges();
                return existing;
            }
            else
                return null;
        }
    }
}

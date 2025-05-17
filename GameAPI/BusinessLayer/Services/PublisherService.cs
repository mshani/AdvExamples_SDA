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

        public bool Delete(int id, bool? forceDeleteChildren)
        {
            var existing = _context
                           .Publishers
                           .Include(x => x.VideoGames)
                           .FirstOrDefault(x =>x.Id == id);
            if (existing != null) {
                if (forceDeleteChildren == true && existing?.VideoGames?.Count > 0) 
                { 
                    _context.VideoGames.RemoveRange(existing.VideoGames);
                    _context.Publishers.Remove(existing);
                    var result = _context .SaveChanges();
                    return result > 0 ? true : false;
                }
                else
                {
                    existing?.VideoGames?.ForEach(x => x.Publisher = null);
                    _context?.Publishers.Remove(existing);
                    var result = _context?.SaveChanges();
                    return result > 0 ? true : false;
                }
            }
            return false;
        }
    }
}

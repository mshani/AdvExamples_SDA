using GameAPI.BusinessLayer.Infrastructure;
using GameAPI.DataLayer;
using GameAPI.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace GameAPI.BusinessLayer.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly StoreContext _context;
        public VideoGameService(StoreContext context) { 
            _context = context;
        }

        public List<VideoGame> GetAll()
        {
            var result = _context.VideoGames.ToList();
            return result;
        }

        public VideoGame? GetById(int id)
        {
            var result = _context.VideoGames
                        .Include(x => x.Publisher)
                        .FirstOrDefault(x => x.Id == id);
            return result;
        }

        public VideoGame Create(VideoGame videoGame) {
            videoGame.Id = 0;
            videoGame.ModifiedTime = null;
            _context.VideoGames.Add(videoGame);
            _context.SaveChanges();
            return videoGame;          
        }

        public VideoGame? Update(VideoGame videoGame)
        {
            var existing = _context.VideoGames.FirstOrDefault(x => x.Id == videoGame.Id);
            if (existing != null)
            {
                existing.Name = videoGame.Name;
                existing.Category = videoGame.Category;
                existing.Size = videoGame.Size;
                existing.Publisher = videoGame.Publisher;
                existing.ModifiedTime = DateTime.Now;

                _context.VideoGames.Update(existing);
                _context.SaveChanges();
                return existing;
            }
            else
                return null;
        }

        public bool Delete(int id)
        {
            var existing = _context.VideoGames.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                _context.VideoGames.Remove(existing);
                var result = _context.SaveChanges();
                return result > 0 ? true : false;
            }
            return false;
        }
    }
}

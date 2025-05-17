using GameAPI.BusinessLayer.Infrastructure;
using GameAPI.DataLayer;
using GameAPI.DataLayer.DTOs;
using GameAPI.DataLayer.Filters;
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

        public List<VideoGame> GetAll(VideoGameFilter filter)
        {
            var query = _context.VideoGames.AsQueryable();
            if (filter != null) {
                if (filter.Id != null){
                    query = query.Where(x => x.Id == filter.Id);
                }
                if (!string.IsNullOrEmpty(filter.Name)) { 
                    query = query.Where(x => 
                                    x.Name != null &&
                                    x.Name.Contains(filter.Name));
                }
                if (filter.PublishingDate != null) {
                    query = query.Where(x => 
                                x.PublishingDate!= null  && 
                                x.PublishingDate.Value.Date == filter.PublishingDate.Value.Date);
                }
                if (filter.SizeMin != null) { 
                    query = query.Where(x => x.Size >= filter.SizeMin);           
                }
                if (filter.SizeMax != null)
                {
                    query = query.Where(x => x.Size <= filter.SizeMax);
                }
            }
            var result = query.ToList();
            return result;
        }

        public VideoGame? GetById(int id)
        {
            var result = _context.VideoGames
                        .Include(x => x.Publisher)
                        .FirstOrDefault(x => x.Id == id);
            return result;
        }

        public VideoGame Create(VideoGameDTO payload) {
            var toAdd = new VideoGame()
            {
                Name = payload.Name,
                Size = payload.Size,
                Category = payload.Category,
                PublisherId = payload.PublisherId,
                CreatedTime = DateTime.Now,
                ModifiedTime = null,
                PublishingDate = payload.PublishingDate
            };
            _context.VideoGames.Add(toAdd);
            _context.SaveChanges();
            return toAdd;          
        }

        public VideoGame? Update(int id, VideoGameDTO payload)
        {
            var existing = _context.VideoGames.FirstOrDefault(x => x.Id == id);
            if (existing != null)
            {
                existing.Name = payload.Name;
                existing.Category = payload.Category;
                existing.Size = payload.Size;
                existing.PublisherId = payload.PublisherId;
                existing.ModifiedTime = DateTime.Now;
                existing.PublishingDate = payload.PublishingDate;

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

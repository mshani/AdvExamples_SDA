using GameAPI.BusinessLayer.Infrastructure;
using GameAPI.DataLayer;
using GameAPI.DataLayer.Models;

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
    }
}

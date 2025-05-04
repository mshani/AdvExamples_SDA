using GameAPI.DataLayer.Models;

namespace GameAPI.BusinessLayer.Infrastructure
{
    public interface IVideoGameService
    {
        List<VideoGame> GetAll();
        VideoGame? GetById(int id);
        VideoGame Create(VideoGame videoGame);
        VideoGame? Update(VideoGame videoGame);
    }
}
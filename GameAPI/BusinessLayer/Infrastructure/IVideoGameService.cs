using GameAPI.DataLayer.Models;

namespace GameAPI.BusinessLayer.Infrastructure
{
    public interface IVideoGameService
    {
        List<VideoGame> GetAll();
    }
}
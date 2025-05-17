using GameAPI.DataLayer.DTOs;
using GameAPI.DataLayer.Filters;
using GameAPI.DataLayer.Models;

namespace GameAPI.BusinessLayer.Infrastructure
{
    public interface IVideoGameService
    {
        List<VideoGame> GetAll(VideoGameFilter filter);
        VideoGame? GetById(int id);
        VideoGame Create(VideoGameDTO payload);
        VideoGame? Update(int id, VideoGameDTO payload);
        bool Delete(int id);
    }
}
using GameAPI.DataLayer.Models;

namespace GameAPI.BusinessLayer.Infrastructure
{
    public interface IPublisherService
    {
        List<Publisher> GetAll();
        Publisher? GetById(int id);
        Publisher Create(Publisher videoGame);
        Publisher? Update(Publisher videoGame);
    }
}
using BookShop.Data.Models;

namespace BookShop.Data.Repositories;

public interface IEventRepository : IRepository<Event>
{
    List<Event> GetAvailableEvents(int userId);
}
using BookShop.Data.Models;

namespace BookShop.Data.Repositories;

public interface IUserEventRepository : IRepository<UserEvent>
{
    List<UserEvent> GetAllByUserId(int userId);
}
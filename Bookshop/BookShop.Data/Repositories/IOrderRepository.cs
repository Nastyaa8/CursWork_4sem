using BookShop.Data.Models;

namespace BookShop.Data.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    List<Order> GetAllByUserId(int userId);
}
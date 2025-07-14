using BookShop.Data.Models;

namespace BookShop.Data.Repositories;

public interface IOrderItemRepository : IRepository<OrderItem>
{
    void DeleteByOrderId(int orderId);
}
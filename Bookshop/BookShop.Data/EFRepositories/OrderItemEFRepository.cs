using BookShop.Data.Context;
using BookShop.Data.Models;
using BookShop.Data.Repositories;

namespace BookShop.Data.EFRepositories;

public class OrderItemEFRepository : IOrderItemRepository
{
    private readonly BookShopContext _context;

    public OrderItemEFRepository(BookShopContext context)
    {
        _context = context;
    }
    
    public List<OrderItem> GetAll()
    {
        return _context.OrderItems.ToList();
    }

    public OrderItem? GetById(int id)
    {
        return _context.OrderItems.FirstOrDefault(o => o.Id == id);
    }

    public void Add(OrderItem entity)
    {
        _context.OrderItems.Add(entity);
        _context.SaveChanges();
    }

    public void Update(OrderItem entity)
    {
        var orderItem = _context.OrderItems.FirstOrDefault(o => o.Id == entity.Id);

        if (orderItem == null) throw new NullReferenceException("OrderItem not found");
        
        orderItem.Quantity = entity.Quantity;
        orderItem.OrderId = entity.OrderId;
        orderItem.BookId = entity.BookId;

        _context.SaveChanges();
    }

    public void Delete(OrderItem entity)
    {
        var orderItem = _context.OrderItems.FirstOrDefault(oi => oi.Id == entity.Id);
        
        if(orderItem == null) throw new NullReferenceException("OrderItem not found");
        
        _context.OrderItems.Remove(orderItem);
        _context.SaveChanges();
    }

    public void DeleteByOrderId(int orderId)
    {
        _context.OrderItems.RemoveRange(_context.OrderItems.Where(x => x.OrderId == orderId));
        _context.SaveChanges();
    }
}
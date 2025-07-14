using BookShop.Data.Context;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data.EFRepositories;

public class OrderEFRepository : IOrderRepository
{
    private readonly BookShopContext _context;

    public OrderEFRepository(BookShopContext context)
    {
        _context = context;
    }
    
    public List<Order> GetAll()
    {
        return _context.Orders.ToList();
    }

    public Order? GetById(int id)
    {
        return _context.Orders.FirstOrDefault(o => o.Id == id);
    }

    public void Add(Order entity)
    {
        _context.Orders.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Order entity)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == entity.Id);
        
        if(order == null) throw new KeyNotFoundException("Order not found");
        
        order.Date = entity.Date;
        order.UserId = entity.UserId;
        order.Status = entity.Status;
        order.TotalPrice = entity.TotalPrice;

        _context.SaveChanges();
    }

    public void Delete(Order entity)
    {
        var order = _context.Orders.FirstOrDefault(o => o.Id == entity.Id);
        
        if(order == null) throw new Exception("Order not found");
        
        _context.Orders.Remove(order);
        _context.SaveChanges();
    }

    public List<Order> GetAllByUserId(int userId)
    {
        return _context.Orders
            .Include(x => x.User)
            .Where(o => o.UserId == userId).ToList();
    }
}
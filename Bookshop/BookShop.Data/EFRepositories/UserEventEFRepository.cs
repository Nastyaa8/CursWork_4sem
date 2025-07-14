using BookShop.Data.Context;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data.EFRepositories;

public class UserEventEFRepository : IUserEventRepository
{
    private readonly BookShopContext _context;

    public UserEventEFRepository(BookShopContext context)
    {
        _context = context;
    }
    
    public List<UserEvent> GetAll()
    {
        return _context.UserEvents.ToList();
    }

    public UserEvent? GetById(int id)
    {
        return _context.UserEvents.FirstOrDefault(x => x.Id == id);
    }

    public void Add(UserEvent entity)
    {
        _context.UserEvents.Add(entity);
        _context.SaveChanges();
    }

    public void Update(UserEvent entity)
    {
        var eventToUpdate = _context.UserEvents.FirstOrDefault(x => x.Id == entity.Id);
        
        if(eventToUpdate == null) throw new NullReferenceException("UserEvent does not exist");
        
        eventToUpdate.EventId = entity.EventId;
        eventToUpdate.UserId = entity.UserId;
        
        _context.SaveChanges();
    }

    public void Delete(UserEvent entity)
    {
        var eventToDelete = _context.UserEvents.FirstOrDefault(x => x.Id == entity.Id);
        
        if(eventToDelete == null) throw new NullReferenceException("UserEvent not found");
        
        _context.UserEvents.Remove(eventToDelete);
        _context.SaveChanges();
    }

    public List<UserEvent> GetAllByUserId(int userId)
    {
        return _context.UserEvents.Include(x => x.Event)
            .Include(x => x.User)
            .Where(x => x.UserId == userId).ToList();
    }
}
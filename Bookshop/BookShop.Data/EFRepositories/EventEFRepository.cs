using BookShop.Data.Context;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BookShop.Data.EFRepositories;

public class EventEFRepository : IEventRepository
{
    private readonly BookShopContext _context;

    public EventEFRepository(BookShopContext context)
    {
        _context = context;
    }
    
    public List<Event> GetAll()
    {
        return _context.Events.ToList();
    }

    public Event? GetById(int id)
    {
        return _context.Events.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Event entity)
    {
        _context.Events.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Event entity)
    {
        var eventToUpdate = _context.Events.FirstOrDefault(x => x.Id == entity.Id);
        
        if(eventToUpdate == null) throw new NullReferenceException("Event does not exist");
        
        eventToUpdate.Name = entity.Name;
        eventToUpdate.Description = entity.Description;
        eventToUpdate.Date = entity.Date;
        eventToUpdate.Location = entity.Location;
        
        _context.SaveChanges();
    }

    public void Delete(Event entity)
    {
        var eventToDelete = _context.Events.FirstOrDefault(x => x.Id == entity.Id);
        if(eventToDelete == null) throw new NullReferenceException("Event does not exist");
        _context.Events.Remove(eventToDelete);
        _context.SaveChanges();
    }

    public List<Event> GetAvailableEvents(int userId)
    {
        var data = _context.Events
            .GroupJoin(_context.UserEvents,
                ev => new { Id = ev.Id, UserId = userId},
                userEv => new { Id = userEv.EventId, UserId = userEv.UserId}, (@event, @userEvent) => new
                {
                    @event,
                    @userEvent
                })
                .SelectMany(x => x.userEvent.DefaultIfEmpty(), (source, collection) =>
                new Event
                {
                    Id =  source.@event.Id,
                    Name = source.@event.Name,
                    Description = source.@event.Description,
                    Date = source.@event.Date,
                    Location = source.@event.Location
                });
        
        return data.ToList();
    }
}
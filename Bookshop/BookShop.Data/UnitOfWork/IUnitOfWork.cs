using BookShop.Data.Repositories;

namespace BookShop.Data.UnitOfWork;

public interface IUnitOfWork
{
    IBookRepository Books { get; }
    
    IReferencesRepository References { get; }
    
    IUserRepository Users { get; }
    
    IEventRepository Events { get; }
    
    IOrderRepository Orders { get; }
    
    IOrderItemRepository OrderItems { get; }
}

/// <summary>
/// 
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IBookRepository books, IReferencesRepository references, IUserRepository users,
        IEventRepository events, IOrderRepository orders, IOrderItemRepository orderItems)
    {
        Books = books;
        References = references;
        Users = users;
        Events = events;
        Orders = orders;
        OrderItems = orderItems;
    }

    public IBookRepository Books { get; }
    public IReferencesRepository References { get; }
    public IUserRepository Users { get; }
    public IEventRepository Events { get; }
    public IOrderRepository Orders { get; }
    public IOrderItemRepository OrderItems { get; }
}
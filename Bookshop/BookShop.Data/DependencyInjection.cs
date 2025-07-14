using BookShop.Data.Context;
using BookShop.Data.EFRepositories;
using BookShop.Data.Repositories;
using BookShop.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Data;

public static class DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IReferencesRepository, ReferencesRepository>();
        services.AddScoped<IBookRepository, BookRepository>(_ => new BookRepository(connectionString));
        services.AddScoped<IUserRepository, UserRepository>(_ => new UserRepository(connectionString));
        services.AddScoped<IEventRepository, EventRepository>(_ => new EventRepository(connectionString));
        services.AddScoped<IUserEventRepository, UserEventRepository>(_ => new UserEventRepository(connectionString));
        services.AddScoped<IOrderRepository, OrderRepository>(_ => new OrderRepository(connectionString));
        services.AddScoped<IOrderItemRepository, OrderItemRepository>(_ => new OrderItemRepository(connectionString));
     
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        
        return services;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public static IServiceCollection AddEFRepositories(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<BookShopContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        });
        
        services.AddScoped<IReferencesRepository, ReferencesRepository>();
        services.AddScoped<IBookRepository, BookEFRepository>();
        services.AddScoped<IUserRepository, UserEFRepository>();
        services.AddScoped<IEventRepository, EventEFRepository>();
        services.AddScoped<IUserEventRepository, UserEventEFRepository>();
        services.AddScoped<IOrderRepository, OrderEFRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemEFRepository>();
     
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        
        return services;
    }
}
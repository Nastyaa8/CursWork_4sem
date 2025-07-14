using BookShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data.Context;

public class BookShopContext(DbContextOptions<BookShopContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<Book> Books { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OrderItem> OrderItems { get; set; }
    
    public DbSet<Event> Events { get; set; }
    
    public DbSet<UserEvent> UserEvents { get; set; }
}
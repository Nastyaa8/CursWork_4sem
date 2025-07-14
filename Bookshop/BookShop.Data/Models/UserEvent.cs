using BookShop.Data.Models.Base;

namespace BookShop.Data.Models;

/// <summary>
/// 
/// </summary>
public class UserEvent : BaseEntity
{
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public int EventId { get; set; }
    
    public Event Event { get; set; }
}
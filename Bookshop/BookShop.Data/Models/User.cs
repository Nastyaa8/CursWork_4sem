using BookShop.Data.Models.Base;

namespace BookShop.Data.Models;

/// <summary>
/// 
/// </summary>
public class User : BaseEntity
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public string Address { get; set; }
    
    public string Login { get; set; }
    
    public string PasswordHash { get; set; }
    
    public bool IsAdmin { get; set; }
    
    public byte[]? Image { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ICollection<UserEvent> UserEvents { get; set; } = new HashSet<UserEvent>();
    
    /// <summary>
    /// 
    /// </summary>
    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}
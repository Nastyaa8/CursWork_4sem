using BookShop.Data.Models.Base;

namespace BookShop.Data.Models;

public class Event : BaseEntity
{
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime Date { get; set; }
    
    public string Location { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public ICollection<UserEvent> UserEvents { get; set; } = new HashSet<UserEvent>();
}
using BookShop.Data.Models.Base;

namespace BookShop.Data.Models;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public DateTime Date { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    public string Status { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
}
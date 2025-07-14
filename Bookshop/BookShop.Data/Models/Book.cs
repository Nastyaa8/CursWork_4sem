using BookShop.Data.Models.Base;

namespace BookShop.Data.Models;

public class Book : BaseEntity
{
    public string Name { get; set; }
    
    public string Author { get; set; }
    
    public string Genre { get; set; }
    
    public decimal Price { get; set; }
    
    public string Image { get; set; }
    
    public bool Available { get; set; }

    public string? Description { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
}
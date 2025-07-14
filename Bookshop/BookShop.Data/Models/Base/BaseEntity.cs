using System.ComponentModel.DataAnnotations;

namespace BookShop.Data.Models.Base;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
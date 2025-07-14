using BookShop.Data.Models;

namespace BookShop.Stores;

public static class UserStore
{
    public static User? CurrentUser { get; set; }
    
    public static bool IsLogged { get; set; }
}
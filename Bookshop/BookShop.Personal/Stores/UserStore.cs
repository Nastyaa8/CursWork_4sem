using BookShop.Data.Models;

namespace BookShop.Personal.Stores;

public static class UserStore
{
    public static User? CurrentUser { get; set; }
    
    public static bool IsLogged { get; set; }
}
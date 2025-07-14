using BookShop.Data.Models;

namespace BookShop.Data.Repositories;

public interface IUserRepository : IRepository<User>
{
    User? GetUserByLoginOrEmail(string loginOrEmail);
}
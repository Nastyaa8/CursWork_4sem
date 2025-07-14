using BookShop.Data.Context;
using BookShop.Data.Models;
using BookShop.Data.Repositories;

namespace BookShop.Data.EFRepositories;

public class UserEFRepository : IUserRepository
{
    private readonly BookShopContext _context;

    public UserEFRepository(BookShopContext context)
    {
        _context = context;
    }
    
    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User? GetById(int id)
    {
        return _context.Users.FirstOrDefault(x => x.Id == id);
    }

    public void Add(User entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
    }

    public void Update(User entity)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == entity.Id);
        
        if(user == null) throw new Exception("User not found");
        
        user.FirstName = entity.FirstName;
        user.LastName = entity.LastName;
        user.Address = entity.Address;
        user.Email = entity.Email;
        user.Phone = entity.Phone;
        user.Image = entity.Image;
        user.Login = entity.Login;
        user.PasswordHash = entity.PasswordHash;
        user.IsAdmin = entity.IsAdmin;
        
        _context.SaveChanges();
    }

    public void Delete(User entity)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == entity.Id);
        if (user == null) throw new Exception("User not found");
        _context.Users.Remove(entity);
        _context.SaveChanges();
    }

    public User? GetUserByLoginOrEmail(string loginOrEmail)
    {
        return _context.Users.FirstOrDefault(x => x.Login == loginOrEmail || x.Email == loginOrEmail);
    }
}
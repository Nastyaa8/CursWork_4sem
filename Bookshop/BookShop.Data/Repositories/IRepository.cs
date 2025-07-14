using BookShop.Data.Models.Base;

namespace BookShop.Data.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    List<T> GetAll();
    
    T? GetById(int id);
    
    void Add(T entity);
    
    void Update(T entity);
    
    void Delete(T entity);
}
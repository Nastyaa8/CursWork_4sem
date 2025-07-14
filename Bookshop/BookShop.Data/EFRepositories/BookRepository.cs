using BookShop.Data.Context;
using BookShop.Data.Models;
using BookShop.Data.Repositories;

namespace BookShop.Data.EFRepositories;

public class BookEFRepository : IBookRepository
{
    private readonly BookShopContext _context;

    public BookEFRepository(BookShopContext context)
    {
        _context = context;
    }
    
    public List<Book> GetAll()
    {
        return _context.Books.ToList();
    }

    public Book? GetById(int id)
    {
        return _context.Books.FirstOrDefault(x => x.Id == id);
    }

    public void Add(Book entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Book entity)
    {
        _context.Database.BeginTransaction();
        
        var book = _context.Books.FirstOrDefault(x => x.Id == entity.Id);
        
        if(book == null) throw new NullReferenceException("Book not found");
        
        book.Name = entity.Name;
        book.Description = entity.Description;
        book.Price = entity.Price;
        book.Author = entity.Author;
        book.Available = entity.Available;
        book.Genre = entity.Genre;
        
        _context.SaveChanges();
        
        if (book.Name == "Default") throw new Exception("Имя Default недопустимо для книги");
        
        _context.Database.CommitTransaction();
    }

    public void Delete(Book entity)
    {
        var book = _context.Books.FirstOrDefault(x => x.Id == entity.Id);
        if (book == null) throw new NullReferenceException("Book not found");
        _context.Books.Remove(book);
        _context.SaveChanges();
    }
}
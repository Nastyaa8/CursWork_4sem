using System.Globalization;
using BookShop.Data.Models;
using Microsoft.Data.SqlClient;

namespace BookShop.Data.Repositories;

public class BookRepository : IBookRepository
{
    private readonly string _connectionString;
    
    public BookRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    private SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
    
    
    private Book MapFromReader(SqlDataReader reader)
    {
        var description = reader.GetOrdinal(nameof(Book.Description));

        //reader.GetFieldValue<string>(description);

        return new Book
        {
            Id = reader.GetFieldValue<int>(reader.GetOrdinal(nameof(Book.Id))),
            Name = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(Book.Name))),
            Author = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(Book.Author))),
            Genre = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(Book.Genre))),
            Price = reader.GetFieldValue<decimal>(reader.GetOrdinal(nameof(Book.Price))),
            Image = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(Book.Image))),
            Available = reader.GetFieldValue<bool>(reader.GetOrdinal(nameof(Book.Available))),
            Description = reader.IsDBNull(description) ? null : reader.GetFieldValue<string>(description)
        };
    }
    
    
    public List<Book> GetAll()
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand("SELECT * FROM Books", connection);
        using var reader = command.ExecuteReader();

        var books = new List<Book>();

        while (reader.Read())
        {
            books.Add(MapFromReader(reader));
        }

        return books;
    }

    public Book? GetById(int id)
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand("SELECT * FROM Books WHERE Id = @Id", connection);
        command.Parameters.AddWithValue("@Id", id);
        
        using var reader = command.ExecuteReader();

        Book? book = null;

        while (reader.Read())
        {
            book = MapFromReader(reader);
        }

        return book;
    }

    public void Add(Book entity)
    {
        var id = 0;
        
        using (var connection = CreateConnection())
        {
            connection.Open();

            using var command = new SqlCommand(
                @"INSERT INTO Books(Name, Author, Genre, Price, Image, Available, Description) output INSERTED.ID
                          VALUES(@Name, @Author, @Genre, @Price, @Image, @Available, @Description)",
                connection);
            
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Author", entity.Author);
            command.Parameters.AddWithValue("@Genre", entity.Genre);
            command.Parameters.AddWithValue("@Price", entity.Price);
            command.Parameters.AddWithValue("@Image", entity.Image);
            command.Parameters.AddWithValue("@Available", entity.Available);
            command.Parameters.AddWithValue("@Description", entity.Description);

            id = (int)command.ExecuteScalar();
        }
        
        entity.Id = id;
    }

    public void Update(Book entity)
    {
        using var connection = CreateConnection();
        var sqlTransaction = connection.BeginTransaction();
        
        connection.Open();

        var sqlString = @"UPDATE Books SET 
                    Name = @Name, Author = @Author, Genre = @Genre, Price = @Price, Image = @Image, Available = @Available, Description = @Description
                    WHERE Id = @Id";

        using var command = new SqlCommand(sqlString, connection);
        command.Transaction = sqlTransaction;

        try
        {
            command.Parameters.AddWithValue("@Id", entity.Id);
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Author", entity.Author);
            command.Parameters.AddWithValue("@Genre", entity.Genre);
            command.Parameters.AddWithValue("@Price", entity.Price);
            command.Parameters.AddWithValue("@Image", entity.Image);
            command.Parameters.AddWithValue("@Available", entity.Available);
            command.Parameters.AddWithValue("@Description", entity.Description);

            command.ExecuteNonQuery();
            
            if (entity.Name == "Default") throw new Exception("Имя Default недопустимо для книги");
            
            sqlTransaction.Commit();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            sqlTransaction.Rollback();
        }
    }

    public void Delete(Book entity)
    {
        using var connection = CreateConnection();
        connection.Open();
        
        using var command = new SqlCommand("DELETE FROM Books WHERE Id = @Id", connection);

        command.Parameters.AddWithValue("@Id", entity.Id);
        
        command.ExecuteNonQuery();
    }
}
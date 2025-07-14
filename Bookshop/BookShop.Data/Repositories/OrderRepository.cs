using BookShop.Data.Models;
using Microsoft.Data.SqlClient;

namespace BookShop.Data.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly string _connectionString;
    private const string DatabaseName = "Orders";

    public OrderRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    private SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
    
    
    private Order MapFromReader(SqlDataReader reader)
    {
        var order = new Order
        {
            Id = reader.GetFieldValue<int>(reader.GetOrdinal(nameof(Order.Id))),
            UserId = reader.GetFieldValue<int>(reader.GetOrdinal(nameof(Order.UserId))),
            Date = reader.GetFieldValue<DateTime>(reader.GetOrdinal(nameof(Order.Date))),
            TotalPrice = reader.GetFieldValue<decimal>(reader.GetOrdinal(nameof(Order.TotalPrice))),
            Status = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(Order.Status)))
        };

        bool userExists;
        try
        {
            var _ = reader.GetOrdinal(nameof(User.Login));
            userExists = true;
        }
        catch (Exception e)
        {
            userExists = false;
        }

        if (userExists)
        {
            order.User = new User
            {
                Id = reader.GetFieldValue<int>(reader.GetOrdinal(nameof(Order.UserId))),
                Login = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(User.Login))),
                FirstName = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(User.FirstName))),
                LastName = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(User.LastName))),
                Email = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(User.Email))),
                Phone = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(User.Phone))),
                Address = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(User.Address)))
            };
        }
        
        return order;
    }
    
    public List<Order> GetAll()
    {
        using var connection = CreateConnection();
        connection.Open();

        const string sqlScript = $"""
                                      SELECT {DatabaseName}.*, Users.* FROM {DatabaseName}
                                      INNER JOIN Users ON Users.Id = {DatabaseName}.UserId
                                  """;
        
        using var command = new SqlCommand(sqlScript, connection);
        using var reader = command.ExecuteReader();

        var entities = new List<Order>();

        while (reader.Read())
        {
            entities.Add(MapFromReader(reader));
        }

        return entities;
    }

    public Order? GetById(int id)
    {
        using var connection = CreateConnection();
        connection.Open();

        const string sqlScript = $"""
                                      SELECT {DatabaseName}.*, Users.* FROM {DatabaseName}
                                      INNER JOIN Users ON Users.Id = {DatabaseName}.UserId
                                      WHERE {DatabaseName}.Id = @Id
                                  """;
        
        using var command = new SqlCommand(sqlScript, connection);
        command.Parameters.AddWithValue("@Id", id);
        
        using var reader = command.ExecuteReader();

        Order? entity = null;

        while (reader.Read())
        {
            entity = MapFromReader(reader);
        }

        return entity;
    }

    public void Add(Order entity)
    {
        var id = 0;
        
        using (var connection = CreateConnection())
        {
            connection.Open();

            using var command = new SqlCommand(
                $"""
                 INSERT INTO {DatabaseName}(UserId, Date, TotalPrice, Status) output INSERTED.ID
                                           VALUES(@UserId, @Date, @TotalPrice, @Status)
                 """,
                connection);
            
            command.Parameters.AddWithValue("@UserId", entity.UserId);
            command.Parameters.AddWithValue("@Date", entity.Date);
            command.Parameters.AddWithValue("@TotalPrice", entity.TotalPrice);
            command.Parameters.AddWithValue("@Status", entity.Status);

            id = (int)command.ExecuteScalar();
        }
        
        entity.Id = id;
    }

    public void Update(Order entity)
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand(
            $"""
             UPDATE {DatabaseName} SET 
                                 UserId = @UserId, Date = @Date, TotalPrice = @TotalPrice, Status = @Status
                                 WHERE Id = @Id
             """, connection);

        command.Parameters.AddWithValue("@Id", entity.Id);
        command.Parameters.AddWithValue("@UserId", entity.UserId);
        command.Parameters.AddWithValue("@Date", entity.Date);
        command.Parameters.AddWithValue("@TotalPrice", entity.TotalPrice);
        command.Parameters.AddWithValue("@Status", entity.Status);

        command.ExecuteNonQuery();
    }

    public void Delete(Order entity)
    {
        using var connection = CreateConnection();
        connection.Open();
        
        using var command = new SqlCommand($"DELETE FROM {DatabaseName} WHERE Id = @Id", connection);

        command.Parameters.AddWithValue("@Id", entity.Id);
        
        command.ExecuteNonQuery();
    }

    public List<Order> GetAllByUserId(int userId)
    {
        using var connection = CreateConnection();
        connection.Open();

        const string sqlScript = $"""
                                      SELECT {DatabaseName}.*, Users.* FROM {DatabaseName}
                                      INNER JOIN Users ON Users.Id = {DatabaseName}.UserId
                                      WHERE {DatabaseName}.UserId = @UserId
                                  """;
        
        using var command = new SqlCommand(sqlScript, connection);
        command.Parameters.AddWithValue("@UserId", userId);
        
        using var reader = command.ExecuteReader();

        var entities = new List<Order>();

        while (reader.Read())
        {
            entities.Add(MapFromReader(reader));
        }

        return entities;
    }
}
using BookShop.Data.Models;
using Microsoft.Data.SqlClient;

namespace BookShop.Data.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly string _connectionString;
    private const string DatabaseName = "OrderItems";

    public OrderItemRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    private SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
    
    
    private OrderItem MapFromReader(SqlDataReader reader)
    {
        var order = new OrderItem
        {
            Id = reader.GetFieldValue<int>(reader.GetOrdinal(nameof(OrderItem.Id))),
            BookId = reader.GetFieldValue<int>(reader.GetOrdinal(nameof(OrderItem.BookId))),
            Quantity = reader.GetFieldValue<int>(reader.GetOrdinal(nameof(OrderItem.Quantity))),
            OrderId = reader.GetFieldValue<int>(reader.GetOrdinal(nameof(OrderItem.OrderId)))
        };
        
        return order;
    }
    
    public List<OrderItem> GetAll()
    {
        using var connection = CreateConnection();
        connection.Open();

        const string sqlScript = $"""
                                      SELECT * FROM {DatabaseName}
                                      INNER JOIN Books ON Books.Id = {DatabaseName}.BookId
                                  """;
        
        using var command = new SqlCommand(sqlScript, connection);
        using var reader = command.ExecuteReader();

        var entities = new List<OrderItem>();

        while (reader.Read())
        {
            entities.Add(MapFromReader(reader));
        }

        return entities;
    }

    public OrderItem? GetById(int id)
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand($"SELECT * FROM {DatabaseName} WHERE Id = @Id", connection);
        command.Parameters.AddWithValue("@Id", id);
        
        using var reader = command.ExecuteReader();

        OrderItem? entity = null;

        while (reader.Read())
        {
            entity = MapFromReader(reader);
        }

        return entity;
    }

    public void Add(OrderItem entity)
    {
        var id = 0;
        
        using (var connection = CreateConnection())
        {
            connection.Open();

            using var command = new SqlCommand(
                $"""
                 INSERT INTO {DatabaseName}(OrderId, BookId, Quantity) output INSERTED.ID
                                           VALUES(@OrderId, @BookId, @Quantity)
                 """,
                connection);
            
            command.Parameters.AddWithValue("@OrderId", id);
            command.Parameters.AddWithValue("@BookId", entity.BookId);
            command.Parameters.AddWithValue("@Quantity", entity.Quantity);

            id = (int)command.ExecuteScalar();
        }
        
        entity.Id = id;
    }

    public void Update(OrderItem entity)
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand(
            $"""
             UPDATE {DatabaseName} SET 
                                 OrderId = @OrderId, BookId = @BookId, Quantity = @Quantity
                                 WHERE Id = @Id
             """, connection);

        command.Parameters.AddWithValue("@Id", entity.Id);
        command.Parameters.AddWithValue("@OrderId", entity.OrderId);
        command.Parameters.AddWithValue("@BookId", entity.BookId);
        command.Parameters.AddWithValue("@Quantity", entity.Quantity);

        command.ExecuteNonQuery();
    }

    public void Delete(OrderItem entity)
    {
        using var connection = CreateConnection();
        connection.Open();
        
        using var command = new SqlCommand($"DELETE FROM {DatabaseName} WHERE Id = @Id", connection);

        command.Parameters.AddWithValue("@Id", entity.Id);
        
        command.ExecuteNonQuery();
    }

    public void DeleteByOrderId(int orderId)
    {
        using var connection = CreateConnection();
        connection.Open();
        
        using var command = new SqlCommand($"DELETE FROM {DatabaseName} WHERE OrderId = @OrderId", connection);

        command.Parameters.AddWithValue("@OrderId", orderId);
        
        command.ExecuteNonQuery();
    }
}
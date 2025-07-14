using BookShop.Data.Models;
using Microsoft.Data.SqlClient;

namespace BookShop.Data.Repositories;

public class EventRepository : IEventRepository
{
    private readonly string _connectionString;
    private readonly string _databaseName = "Events";
    
    public EventRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    private SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
    
    
    private Event MapFromReader(SqlDataReader reader)
    {
        return new Event
        {
            Id = reader.GetFieldValue<int>(reader.GetOrdinal(nameof(Event.Id))),
            Name = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(Event.Name))),
            Description = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(Event.Description))),
            Date = reader.GetFieldValue<DateTime>(reader.GetOrdinal(nameof(Event.Date))),
            Location = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(Event.Location)))
        };
    }
    
    
    public List<Event> GetAll()
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand($"SELECT * FROM {_databaseName}", connection);
        using var reader = command.ExecuteReader();

        var entities = new List<Event>();

        while (reader.Read())
        {
            entities.Add(MapFromReader(reader));
        }

        return entities;
    }

    public Event? GetById(int id)
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand($"SELECT * FROM {_databaseName} WHERE Id = @Id", connection);
        command.Parameters.AddWithValue("@Id", id);
        
        using var reader = command.ExecuteReader();

        Event? entity = null;

        while (reader.Read())
        {
            entity = MapFromReader(reader);
        }

        return entity;
    }

    public void Add(Event entity)
    {
        var id = 0;
        
        using (var connection = CreateConnection())
        {
            connection.Open();

            using var command = new SqlCommand(
                $"""
                 INSERT INTO {_databaseName}(Name, Description, Date, Location) output INSERTED.ID
                                           VALUES(@Name, @Description, @Date, @Location)
                 """,
                connection);
            
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Description", entity.Description);
            command.Parameters.AddWithValue("@Date", entity.Date);
            command.Parameters.AddWithValue("@Location", entity.Location);

            id = (int)command.ExecuteScalar();
        }
        
        entity.Id = id;
    }

    public void Update(Event entity)
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand(
            $"""
             UPDATE {_databaseName} SET 
                                 Name = @Name, Description = @Description, Date = @Date, Location = @Location
                                 WHERE Id = @Id
             """, connection);

        command.Parameters.AddWithValue("@Id", entity.Id);
        command.Parameters.AddWithValue("@Name", entity.Name);
        command.Parameters.AddWithValue("@Description", entity.Description);
        command.Parameters.AddWithValue("@Date", entity.Date);
        command.Parameters.AddWithValue("@Location", entity.Location);

        command.ExecuteNonQuery();
    }

    public void Delete(Event entity)
    {
        using var connection = CreateConnection();
        connection.Open();
        
        using var command = new SqlCommand($"DELETE FROM {_databaseName} WHERE Id = @Id", connection);

        command.Parameters.AddWithValue("@Id", entity.Id);
        
        command.ExecuteNonQuery();
    }

    public List<Event> GetAvailableEvents(int userId)
    {
        using var connection = CreateConnection();
        connection.Open();

        var sqlScript =
            $"""
                  SELECT {_databaseName}.* FROM {_databaseName}
                  LEFT JOIN UserEvents ON {_databaseName}.Id = UserEvents.EventId AND UserEvents.UserId = @UserId
                  WHERE UserEvents.UserId IS NULL
              """;
        
        using var command = new SqlCommand(sqlScript, connection);
        command.Parameters.AddWithValue("@UserId", userId);

        using var reader = command.ExecuteReader();

        var entities = new List<Event>();

        while (reader.Read())
        {
            entities.Add(MapFromReader(reader));
        }

        return entities;
    }
}
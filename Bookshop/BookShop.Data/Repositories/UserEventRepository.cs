using BookShop.Data.Models;
using Microsoft.Data.SqlClient;

namespace BookShop.Data.Repositories;

public class UserEventRepository : IUserEventRepository
{
    private readonly string _connectionString;
    private const string DatabaseName = "UserEvents";

    private const string UserEventsPrefix = "ue";
    private const string UserPrefix = "us";
    private const string EventPrefix = "ev";
    
    public UserEventRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    private SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
    
    
    private UserEvent MapFromReader(SqlDataReader reader)
    {
        var userEvent = new UserEvent
        {
            Id = reader.GetFieldValue<int>(reader.GetOrdinal(nameof(UserEvent.Id))),
            UserId = reader.GetFieldValue<int>(reader.GetOrdinal(nameof(UserEvent.UserId))),
            EventId = reader.GetFieldValue<int>(reader.GetOrdinal(nameof(UserEvent.EventId)))
        };

        bool userExists;
        try
        {
            var _ = reader.GetOrdinal(UserPrefix + nameof(User.Id));
            userExists = true;
        }
        catch (Exception e)
        {
            userExists = false;
        }
        
        if (userEvent.UserId != 0 && userExists)
        {
            var user = new User
            {
                Id = reader.GetFieldValue<int>(reader.GetOrdinal(UserPrefix + nameof(User.Id))),
                Login = reader.GetFieldValue<string>(reader.GetOrdinal(UserPrefix + nameof(User.Login))),
                Email = reader.GetFieldValue<string>(reader.GetOrdinal(UserPrefix + nameof(User.Email))),
                FirstName = reader.GetFieldValue<string>(reader.GetOrdinal(UserPrefix + nameof(User.FirstName))),
                LastName = reader.GetFieldValue<string>(reader.GetOrdinal(UserPrefix + nameof(User.LastName))),
            };
            
            userEvent.User = user;
        }

        bool eventExists;
        try
        {
            var _ = reader.GetOrdinal(EventPrefix+ nameof(Event.Id));
            eventExists = true;
        }
        catch (Exception e)
        {
            eventExists = false;
        }
        
        if (userEvent.EventId != 0 && eventExists)
        {
            var ev = new Event
            {
                Id = reader.GetFieldValue<int>(reader.GetOrdinal(EventPrefix + nameof(Event.Id))),
                Name = reader.GetFieldValue<string>(reader.GetOrdinal(EventPrefix + nameof(Event.Name))),
                Description = reader.GetFieldValue<string>(reader.GetOrdinal(EventPrefix + nameof(Event.Description))),
                Date = reader.GetFieldValue<DateTime>(reader.GetOrdinal(EventPrefix + nameof(Event.Date))),
                Location = reader.GetFieldValue<string>(reader.GetOrdinal(EventPrefix + nameof(Event.Location))),
            };
            
            userEvent.Event = ev;
        }
        
        return userEvent;
    }
    
    
    public List<UserEvent> GetAll()
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand($"SELECT * FROM {DatabaseName}", connection);
        using var reader = command.ExecuteReader();

        var entities = new List<UserEvent>();

        while (reader.Read())
        {
            entities.Add(MapFromReader(reader));
        }

        return entities;
    }
    
    public List<UserEvent> GetAllByUserId(int userId)
    {
        using var connection = CreateConnection();
        connection.Open();

        var sqlScript = $"""
                         SELECT  {UserEventsPrefix}.*,
                                 {EventPrefix}.Id as {EventPrefix}Id,
                                 {EventPrefix}.Name as {EventPrefix}Name,
                                 {EventPrefix}.Description as {EventPrefix}Description,
                                 {EventPrefix}.Location as {EventPrefix}Location,
                                 {EventPrefix}.Date as {EventPrefix}Date,
                                 {UserPrefix}.Id as {UserPrefix}Id,
                                 {UserPrefix}.Login as {UserPrefix}Login,
                                 {UserPrefix}.Email as {UserPrefix}Email,
                                 {UserPrefix}.FirstName as {UserPrefix}FirstName,
                                 {UserPrefix}.LastName as {UserPrefix}LastName
                                 FROM {DatabaseName} {UserEventsPrefix}
                                 INNER JOIN Events {EventPrefix} on {UserEventsPrefix}.EventId = {EventPrefix}.Id
                                 INNER JOIN Users {UserPrefix} on {UserEventsPrefix}.UserId = {UserPrefix}.Id 
                                 WHERE {UserEventsPrefix}.UserId = @UserId
                         """;
        
        using var command = new SqlCommand(sqlScript, connection);
        command.Parameters.AddWithValue("@UserId", userId);
        
        using var reader = command.ExecuteReader();

        var entities = new List<UserEvent>();

        while (reader.Read())
        {
            entities.Add(MapFromReader(reader));
        }

        return entities;
    }

    public UserEvent? GetById(int id)
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand($"SELECT * FROM {DatabaseName} WHERE Id = @Id", connection);
        command.Parameters.AddWithValue("@Id", id);
        
        using var reader = command.ExecuteReader();

        UserEvent? entity = null;

        while (reader.Read())
        {
            entity = MapFromReader(reader);
        }

        return entity;
    }

    public void Add(UserEvent entity)
    {
        var id = 0;
        
        using (var connection = CreateConnection())
        {
            connection.Open();

            using var command = new SqlCommand(
                $"""
                 INSERT INTO {DatabaseName}(UserId, EventId) output INSERTED.ID
                                           VALUES(@UserId, @EventId)
                 """,
                connection);
            
            command.Parameters.AddWithValue("@UserId", entity.UserId);
            command.Parameters.AddWithValue("@EventId", entity.EventId);

            id = (int)command.ExecuteScalar();
        }
        
        entity.Id = id;
    }

    public void Update(UserEvent entity)
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand(
            $"""
             UPDATE {DatabaseName} SET 
                                 Name = @UserId, Description = @EventId
                                 WHERE Id = @Id
             """, connection);

        command.Parameters.AddWithValue("@Id", entity.Id);
        command.Parameters.AddWithValue("@Name", entity.UserId);
        command.Parameters.AddWithValue("@Description", entity.EventId);

        command.ExecuteNonQuery();
    }

    public void Delete(UserEvent entity)
    {
        using var connection = CreateConnection();
        connection.Open();
        
        using var command = new SqlCommand($"DELETE FROM {DatabaseName} WHERE Id = @Id", connection);

        command.Parameters.AddWithValue("@Id", entity.Id);
        
        command.ExecuteNonQuery();
    }
}
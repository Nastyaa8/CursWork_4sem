using BookShop.Data.Models;
using Microsoft.Data.SqlClient;

namespace BookShop.Data.Repositories;

public class UserRepository : IUserRepository
{
    private string _connectionString;
    
    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    private SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public List<User> GetAll()
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand("SELECT * FROM Users", connection);
        using var reader = command.ExecuteReader();

        var users = new List<User>();

        while (reader.Read())
        {
            users.Add(MapFromReader(reader));
        }

        return users;
    }

    public User? GetById(int id)
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand("SELECT * FROM Users WHERE Id = @Id", connection);
        command.Parameters.AddWithValue("@Id", id);
        
        using var reader = command.ExecuteReader();

        User? user = null;

        while (reader.Read())
        {
            user = MapFromReader(reader);
        }

        return user;
    }

    private User MapFromReader(SqlDataReader reader)
    {
        return new User
        {
            Id = reader.GetFieldValue<int>(reader.GetOrdinal(nameof(User.Id))),
            Login = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(User.Login))),
            FirstName = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(User.FirstName))),
            LastName = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(User.LastName))),
            Address = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(User.Address))),
            Phone = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(User.Phone))),
            Email = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(User.Email))),
            PasswordHash = reader.GetFieldValue<string>(reader.GetOrdinal(nameof(User.PasswordHash))),
            IsAdmin = reader.GetFieldValue<bool>(reader.GetOrdinal(nameof(User.IsAdmin))),
            Image = reader.IsDBNull(reader.GetOrdinal(nameof(User.Image))) ? null : reader.GetFieldValue<byte[]?>(reader.GetOrdinal(nameof(User.Image))),
        };
    }

    public void Add(User entity)
    {
        var id = 0;
        
        using (var connection = CreateConnection())
        {
            connection.Open();

            using var command = new SqlCommand(
                @"INSERT INTO Users(FirstName, LastName, Email, Phone, Address, Login, PasswordHash, IsAdmin, Image) output INSERTED.ID
                          VALUES(@FirstName, @LastName, @Email, @Phone, @Address, @Login, @PasswordHash, @IsAdmin, @Image)",
                connection);
            
            command.Parameters.AddWithValue("@FirstName", entity.FirstName);
            command.Parameters.AddWithValue("@LastName", entity.LastName);
            command.Parameters.AddWithValue("@Email", entity.Email);
            command.Parameters.AddWithValue("@Phone", entity.Phone);
            command.Parameters.AddWithValue("@Address", entity.Address);
            command.Parameters.AddWithValue("@Login", entity.Login);
            command.Parameters.AddWithValue("@PasswordHash", entity.PasswordHash);
            command.Parameters.AddWithValue("@IsAdmin", entity.IsAdmin);
            command.Parameters.AddWithValue("@Image", entity.Image);

            id = (int)command.ExecuteScalar();
        }
        
        entity.Id = id;
    }

    public void Update(User entity)
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand(
            @"UPDATE Users SET 
                    FirstName = @FirstName,
                    LastName = @LastName,
                    Email = @Email,
                    Phone = @Phone,
                    Address = @Address,
                    Login = @Login,
                    PasswordHash = @PasswordHash,
                    IsAdmin = @IsAdmin,
                    Image = @Image
                    WHERE Id = @Id", connection);

        command.Parameters.AddWithValue("@Id", entity.Id);
        command.Parameters.AddWithValue("@FirstName", entity.FirstName);
        command.Parameters.AddWithValue("@LastName", entity.LastName);
        command.Parameters.AddWithValue("@Email", entity.Email);
        command.Parameters.AddWithValue("@Phone", entity.Phone);
        command.Parameters.AddWithValue("@Address", entity.Address);
        command.Parameters.AddWithValue("@Login", entity.Login);
        command.Parameters.AddWithValue("@PasswordHash", entity.PasswordHash);
        command.Parameters.AddWithValue("@IsAdmin", entity.IsAdmin);
        command.Parameters.AddWithValue("@Image", entity.Image);

        command.ExecuteNonQuery();
    }

    public void Delete(User entity)
    {
        using var connection = CreateConnection();
        connection.Open();
        
        using var command = new SqlCommand("DELETE FROM Users WHERE Id = @Id", connection);

        command.Parameters.AddWithValue("@Id", entity.Id);
        
        command.ExecuteNonQuery();
    }

    public User? GetUserByLoginOrEmail(string loginOrEmail)
    {
        using var connection = CreateConnection();
        connection.Open();

        using var command = new SqlCommand("SELECT * FROM Users WHERE Login = @LoginOrEmail OR Email = @LoginOrEmail", connection);
        command.Parameters.AddWithValue("@LoginOrEmail", loginOrEmail);
        
        using var reader = command.ExecuteReader();

        User? user = null;

        while (reader.Read())
        {
            user = MapFromReader(reader);
        }

        return user;
    }
}
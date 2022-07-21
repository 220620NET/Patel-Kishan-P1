using Models;
using Microsoft.Data.SqlClient;
using customExceptions;


namespace DataAccess;
public class UserRepository : IUserRepository
{
    private readonly ConnectionFactory _connectionFactory;

    public UserRepository(ConnectionFactory factory)
    {
        _connectionFactory = factory;
    }
    public List<User> GetAllUsers()
    {
        List<User> Users = new List<User>();
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();

        SqlCommand cmd = new SqlCommand("Select * From userlogin", conn);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            Users.Add
            (new User
            {
                userID = (int)reader["id"],
                userName = (string)reader["username"],
                password = (string)reader["password"],
                role = (string)reader["user_role"]
            }
            );
        }
        reader.Close();
        conn.Close();

        return Users;
    }

    public User GetUserById(int id)
    {
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();

        SqlCommand cmd = new SqlCommand("Select * From userlogin Where userId = @id", conn);
        
        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            return new User
            {
                userID = (int)reader["userId"],
                userName = (string)reader["username"],
                password = (string)reader["password"],
                role = (string)reader["user_role"]
            };
        }

        throw new RecordNotFoundException("Could not find the User with this id");
    }

    public User GetUserByUserName(string name)
    {
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();

        SqlCommand cmd = new SqlCommand("Select * From userlogin Where username = @name", conn);
        
        cmd.Parameters.AddWithValue("@name", name);

        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            return new User
            {
                userID = (int)reader["userId"],
                userName = (string)reader["username"],
                password = (string)reader["password"],
                role = (string)reader["user_role"]
            };
        }

        throw new RecordNotFoundException("Could not find the User with this name");
    }

    public User createUser(User newUserToRegister)
    {
        using SqlCommand cmd = new SqlCommand("insert into project1.userlogin (username, password, user_role) values (@username, @password, @user_role);", _connectionFactory.GetConnection());

        cmd.Parameters.AddWithValue("@username", newUserToRegister.userName);
        cmd.Parameters.AddWithValue("@password", newUserToRegister.password);
        cmd.Parameters.AddWithValue("@user_role", newUserToRegister.role);

        return newUserToRegister;
    }
}
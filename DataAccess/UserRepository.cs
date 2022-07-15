using Models;
using Microsoft.Data.SqlClient;
using CustomExceptions;
using System.Data;

namespace DataAccess;
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
    User foundUser;
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

    reader.Close();
    conn.Close();
}

public User GetUserByUserName(string name)
{
    User foundUser;
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

    reader.Close();
    conn.Close();
}

public User createUser(User newUser)
{
    DataSet userSet = new DataSet();

    SqlDataAdapter userAdapter = new SqlDataAdapter("Select * From userlogin", _conectionFactory.GetConnection());

    userAdapter.Fill(userSet, "userTable");

    DataTable? userTable = userSet.Tables["userTable"];

    if(userTable != null)
    {
    DataRow newUser = userTable.NewRow();
            newUser["username"] = newUserToRegister.Name;
            newUser["passowrd"] = newUserToRegister.Password;
            newUser["user_role"] = newUserToRegister.Role;
            newUser["userDd"] = newUserToRegister.Id;

            userTable.Rows.Add(newUser);

            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(userAdapter);

            SqlCommand insertCommand = cmdbuilder.GetInsertCommand();
            userAdapter.InsertCommand = insertCommand;

            userAdapter.Update(userTable);
        }
        return newUserToRegister;
}
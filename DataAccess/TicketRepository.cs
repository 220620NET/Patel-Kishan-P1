using Models;
using Microsoft.Data.SqlClient;
using customExceptions;
using System.Data;

namespace DataAccess;

public class TicketRepository : ITicketRepository
{
    private readonly ConnectionFactory _connectionFactory;

    public TicketRepository(ConnectionFactory factory)
    {
        _connectionFactory = factory;
    }
    public ticket GetReimbursmentById(int id)
    {
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();

        SqlCommand cmd = new SqlCommand("Select * From ticket Where id = @id", conn);
        
        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            return new ticket
            {
                id = (int)reader["id"],
                author = (string)reader["author_fk"],
                resolver = (string)reader["resolver_fk"],
                description = (string)reader["description"],
                status = (string)reader["status"],
                amount = (decimal)reader["amount"]

            };
        }
        throw new IndexOutOfRangeException();
    }
    public List<ticket> GetReimbursmentsByAuthor(string Author)
    {
        List<ticket> Tickets = new List<ticket>();
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();

        SqlCommand cmd = new SqlCommand("Select * From ticket Where author_fk = @author", conn);
        
        cmd.Parameters.AddWithValue("@author", Author);

        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            Tickets.Add(new ticket
            {
                id = (int)reader["id"],
                author = (string)reader["author_fk"],
                resolver = (string)reader["resolver_fk"],
                description = (string)reader["description"],
                status = (string)reader["status"],
                amount = (decimal)reader["amount"]

            });
        }
        reader.Close();
        conn.Close();
        return Tickets;
    }
    public List<ticket> GetReimbursmentsByStatus(string Status)
    {
        List<ticket> Tickets = new List<ticket>();
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();

        SqlCommand cmd = new SqlCommand("Select * From ticket Where status = @status", conn);
        
        cmd.Parameters.AddWithValue("@status", Status);

        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            Tickets.Add(new ticket
            {
                id = (int)reader["id"],
                author = (string)reader["author_fk"],
                resolver = (string)reader["resolver_fk"],
                description = (string)reader["description"],
                status = (string)reader["status"],
                amount = (decimal)reader["amount"]

            });
        }
        reader.Close();
        conn.Close();
        return Tickets;
    }

    public ticket CreateReimbursment(ticket newTicketToRegister)
    {
        using SqlCommand cmd = new SqlCommand("insert into project1.ticket (author_fk,resolver_fk,description,status,amount) values (@author_fk, @resolver_fk, @description, @status, @amount);", _connectionFactory.GetConnection());

        cmd.Parameters.AddWithValue("@author_fk", newTicketToRegister.author);
        cmd.Parameters.AddWithValue("@resolver_fk", newTicketToRegister.resolver);
        cmd.Parameters.AddWithValue("@description", newTicketToRegister.description);
        cmd.Parameters.AddWithValue("@id", newTicketToRegister.id);
        cmd.Parameters.AddWithValue("@status", newTicketToRegister.status);
        cmd.Parameters.AddWithValue("@amount", newTicketToRegister.amount);
        
        return newTicketToRegister;
    }

    public ticket UpdateReimbursmentString(string val,int id)
    {
        List<string> stat = new List<string>(){"Rejected","Approved","Pending"};
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();

        SqlCommand cmd = new SqlCommand("Update project1.ticket set @key = @val where id = @id", conn);
        
        cmd.Parameters.AddWithValue("@val", val);
        cmd.Parameters.AddWithValue("@id", id);

        if (stat.Contains(val)){
            cmd.Parameters.AddWithValue("@key", "status");
        }
        else{
            cmd.Parameters.AddWithValue("@key", "resolver_fk");
        }

        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            return new ticket
            {
                id = (int)reader["id"],
                author = (string)reader["author_fk"],
                resolver = (string)reader["resolver_fk"],
                description = (string)reader["description"],
                status = (string)reader["status"],
                amount = (decimal)reader["amount"]

            };
        }

        throw new RecordNotFoundException("Could not find the User");
    }

    public ticket UpdateReimbursmentAmount(decimal amount, int id)
    {
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();

        SqlCommand cmd = new SqlCommand("Update project1.ticket set @key = @val where id = @id", conn);
        
        cmd.Parameters.AddWithValue("@val", amount);
        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            return new ticket
            {
                id = (int)reader["id"],
                author = (string)reader["author_fk"],
                resolver = (string)reader["resolver_fk"],
                description = (string)reader["description"],
                status = (string)reader["status"],
                amount = (decimal)reader["amount"]

            };
        }

        throw new RecordNotFoundException("Could not find the User");
    }
}
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

        SqlCommand cmd = new SqlCommand("Select * From project1.ticket Where id = @id", conn);
        
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
                amount = (double)reader["amount"]

            };
        }
        throw new IndexOutOfRangeException();
    }
    public List<ticket> GetReimbursmentsByAuthor(int AuthorId)
    {
        List<ticket> Tickets = new List<ticket>();
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();

        SqlCommand cmd = new SqlCommand("select * from project1.ticket where author_fk = (SELECT username FROM project1.userlogin WHERE userId = @id);", conn);
        
        cmd.Parameters.AddWithValue("@id", AuthorId);

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
                amount = (double)reader["amount"]

            });
        }
        return Tickets;
    }
    public List<ticket> GetReimbursmentsByStatus(string Status)
    {
        List<ticket> Tickets = new List<ticket>();
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();

        SqlCommand cmd = new SqlCommand("Select * From project1.ticket Where status = @status", conn);
        
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
                amount = (double)reader["amount"]

            });
        }
        return Tickets;
    }

    public ticket CreateReimbursment(ticket newTicketToRegister)
    {
        using SqlCommand cmd = new SqlCommand("insert into project1.ticket (author_fk,resolver_fk,description,status,amount) output INSERTED.id values (@author_fk, @resolver_fk, @description, @status, @amount);", _connectionFactory.GetConnection());

        cmd.Parameters.AddWithValue("@author_fk", newTicketToRegister.author);
        cmd.Parameters.AddWithValue("@resolver_fk", newTicketToRegister.resolver);
        cmd.Parameters.AddWithValue("@description", newTicketToRegister.description);
        cmd.Parameters.AddWithValue("@status", newTicketToRegister.status);
        cmd.Parameters.AddWithValue("@amount", newTicketToRegister.amount);
        
        cmd.Connection.Open();
        int insertedId =  (int) cmd.ExecuteScalar();

        newTicketToRegister.id = insertedId;
        return newTicketToRegister;
    }

    public ticket UpdateReimbursmentString(string val,int id)
    {
        SqlConnection conn = _connectionFactory.GetConnection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("Update project1.ticket set status = @val where id = @id", conn);
        
        cmd.Parameters.AddWithValue("@val", val);
        cmd.Parameters.AddWithValue("@id", id);

        SqlDataReader reader = cmd.ExecuteReader();

        return GetReimbursmentById(id);
    }

    // public ticket UpdateReimbursmentAmount(decimal amount, int id)
    // {
    //     SqlConnection conn = _connectionFactory.GetConnection();

    //     conn.Open();

    //     SqlCommand cmd = new SqlCommand("Update project1.ticket set @key = @val where id = @id", conn);
        
    //     cmd.Parameters.AddWithValue("@val", amount);
    //     cmd.Parameters.AddWithValue("@id", id);

    //     SqlDataReader reader = cmd.ExecuteReader();

    //     while(reader.Read())
    //     {
    //         return new ticket
    //         {
    //             id = (int)reader["id"],
    //             author = (string)reader["author_fk"],
    //             resolver = (string)reader["resolver_fk"],
    //             description = (string)reader["description"],
    //             status = (string)reader["status"],
    //             amount = (double)reader["amount"]

    //         };
    //     }

    //     throw new RecordNotFoundException("Could not find the User");
    // }
    public List<ticket> GetAllTickets()
    {
        List<ticket> Users = new List<ticket>();
        SqlConnection conn = _connectionFactory.GetConnection();

        conn.Open();

        SqlCommand cmd = new SqlCommand("Select * From project1.ticket", conn);
        SqlDataReader reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            Users.Add
            (new ticket
            {
                id = (int)reader["id"],
                author = (string)reader["author_fk"],
                resolver = (string)reader["resolver_fk"],
                description = (string)reader["description"],
                status = (string)reader["status"],
                amount = (double)reader["amount"]
            }
            );
        }

        return Users;
    }
}
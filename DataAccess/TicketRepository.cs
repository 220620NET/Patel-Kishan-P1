using models;
using Microsoft.Data.SqlClient;
using CustomExceptions;
using System.Data;

namespace DataAccess;

public ticket GetReimbursmentById(int id)
{
    ticket foundticket;
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

    throw new RecordNotFoundException("Could not find the User with this id");

    reader.Close();
    conn.Close();
}
public ticket GetReimbursmentsByAuthor(string Author)
{
    ticket foundticket;
    SqlConnection conn = _connectionFactory.GetConnection();

    conn.Open();

    SqlCommand cmd = new SqlCommand("Select * From ticket Where author_fk = @author", conn);
    
    cmd.Parameters.AddWithValue("@author", Author);

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

    throw new RecordNotFoundException("Could not find the User with this Author");

    reader.Close();
    conn.Close();
}
public ticket GetReimbursmentsByStatus(string Status)
{
    ticket foundticket;
    SqlConnection conn = _connectionFactory.GetConnection();

    conn.Open();

    SqlCommand cmd = new SqlCommand("Select * From ticket Where status = @status", conn);
    
    cmd.Parameters.AddWithValue("@status", Status);

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

    throw new RecordNotFoundException("Could not find the User with this Status");

    reader.Close();
    conn.Close();
}

public ticket CreateReimbursment(User newTicket)
{
    DataSet ticketSet = new DataSet();

    SqlDataAdapter ticketAdapter = new SqlDataAdapter("Select * From ticket", _conectionFactory.GetConnection());

    ticketAdapter.Fill(ticketSet, "ticketTable");

    DataTable? ticketTable = ticketSet.Tables["ticketTable"];

    if(ticketTable != null)
    {
    DataRow newTicket = ticketTable.NewRow();
            newTicket["author_fk"] = newTicketToRegister.author;
            newTicket["resolver_fk"] = newTicketToRegister.resolver;
            newTicket["description"] = newTicketToRegister.description;
            newTicket["id"] = newTicketToRegister.Id;
            newTicket["status"] = newTicketToRegister.Status;
            newTicket["amount"] = newTicketToRegister.amount;

            ticketTable.Rows.Add(newTicket);

            SqlCommandBuilder cmdbuilder = new SqlCommandBuilder(ticketAdapter);

            SqlCommand insertCommand = cmdbuilder.GetInsertCommand();
            ticketAdapter.InsertCommand = insertCommand;

            ticketAdapter.Update(ticketTable);
        }
        return newTicketToRegister;
}

public ticket UpdateReimbursmentresolver(string resolver)
{
    ticket foundticket;
    SqlConnection conn = _connectionFactory.GetConnection();

    conn.Open();

    SqlCommand cmd = new SqlCommand("Update project1.ticket  set resolver_fk = @fk ", conn);
    
    cmd.Parameters.AddWithValue("@fk", resolver);

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

    throw new RecordNotFoundException("Could not find the User with this ");

    reader.Close();
    conn.Close();
}

public ticket UpdateReimbursmentAmount(decimal amount)
{
    ticket foundticket;
    SqlConnection conn = _connectionFactory.GetConnection();

    conn.Open();

    SqlCommand cmd = new SqlCommand("Update project1.ticket set amount = @fk ", conn);
    
    cmd.Parameters.AddWithValue("@fk", amount);

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

    throw new RecordNotFoundException("Could not find the User with this ");

    reader.Close();
    conn.Close();
}

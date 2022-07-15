using Models;

namespace DataAccess;

public interface ITicketRepository
{
    ticket GetReimbursmentById(int id);
    List<ticket> GetReimbursmentsByAuthor(string Author);
    List<ticket> GetReimbursmentsByStatus(string Status);
    ticket CreateReimbursment(User newTicket);
    ticket UpdateReimbursmentString(string val);
    ticket UpdateReimbursmentAmount(decimal amount);
}
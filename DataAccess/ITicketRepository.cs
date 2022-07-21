using Models;

namespace DataAccess;

public interface ITicketRepository
{
    ticket GetReimbursmentById(int id);
    List<ticket> GetReimbursmentsByAuthor(int AuthorId);
    List<ticket> GetReimbursmentsByStatus(string Status);
    ticket CreateReimbursment(ticket newTicket);
    ticket UpdateReimbursmentString(string val, int id);
    ticket UpdateReimbursmentAmount(decimal amount, int id);
    List<ticket> GetAllTickets();
}
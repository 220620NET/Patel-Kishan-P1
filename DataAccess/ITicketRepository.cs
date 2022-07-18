using Models;

namespace DataAccess;

public interface ITicketRepository
{
    List<ticket> GetReimbursmentsById(int id);
    List<ticket> GetReimbursmentsByAuthor(string Author);
    List<ticket> GetReimbursmentsByStatus(string Status);
    ticket CreateReimbursment(User newTicket);
    ticket UpdateReimbursmentString(string val, int id);
    ticket UpdateReimbursmentAmount(decimal amount, int id);
}
using Models;
using DataAccess;
using customExceptions;

namespace Services;

public class TicketService
{
    private readonly ITicketRepository _repo;

    public TicketService(ITicketRepository repository)
    {
        _repo = repository;
    }
    public ticket SubmitReimbursment(ticket newTicket)
    {
        try
        {
            return _repo.CreateReimbursment(newTicket);
        }
        catch (ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
    public ticket UpdateReimbursment(string val, int id)
    {
        try
        {
            return _repo.UpdateReimbursmentString(val, id);
        }
        catch (ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
    public ticket UpdateReimbursment(int val, int id)
    {
        try
        {
            return _repo.UpdateReimbursmentAmount(val, id);
        }
        catch (ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
    public ticket GetReimbursmentById(int id)
    {
        try
        {
            return _repo.GetReimbursmentById(id);
        }
        catch(IndexOutOfRangeException)
        {
            throw new IndexOutOfRangeException();
        }
    }
    /*public List<ticket> GetReimbursmentsByUserId(int userId)
    {
        try
        {
            return _repo.GetReimbursmentsByuserId(userId);
        }
        catch(ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }*/
    public List<ticket> GetReimbursmentsByStatus(string stat)
    {
        try
        {
            return _repo.GetReimbursmentsByStatus(stat);
        }
        catch(ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
}
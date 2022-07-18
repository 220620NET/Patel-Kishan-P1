using Models;
using DataAccess;
using customExceptions;

namespace Services;

public class TicketService
{
    private readonly ITicketRepository _repo;

    public AuthService(ITicketRepository repository)
    {
        _repo = repository;
    }
    public ticket SubmitReimbursment()
    {
        try
        {
            return ITicketRepository.CreateReimbursment();
        }
        catch (ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
    public ticket UpdateReimbursment(string val)
    {
        try
        {
            return ITicketRepository.UpdateReimbursmentString(val);
        }
        catch (ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
    public ticket UpdateReimbursment(int val)
    {
        try
        {
            return ITicketRepository.UpdateReimbursmentAmount(val);
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
            return ITicketRepository.GetReimbursmentById(val);
        }
        catch(IndexOutOfRangeException)
        {
            throw new IndexOutOfRangeException();
        }
    }
    public List<ticket> GetReimbursmentsByUserId(int userId)
    {
        try
        {
            return ITicketRepository.GetReimbursmentsByUserId(userId);
        }
        catch(ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
    public List<ticket> GetReimbursmentsByStatus(string stat)
    {
        try
        {
            return ITicketRepository.GetReimbursmentsByStatus(stat);
        }
        catch(ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
}
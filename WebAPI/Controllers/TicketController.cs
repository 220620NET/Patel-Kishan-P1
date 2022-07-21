using Services;
using Models;
using customExceptions;

namespace WebAPI.Controllers;

public class TicketController
{
    private readonly TicketService _service;

    public TicketController(TicketService Service)
    {
        _service = Service;
    }

    public IResult Submit(ticket newTicket)
    {
        try
        {
            bool pass = _service.SubmitReimbursment(newTicket);
            return Results.Accepted("/submit", _service.GetReimbursmentsByUserId(newTicket.author));
        }
        catch (ResourceNotFoundException)
        {
            return Results.Conflict("Reimbursment not submitted");
        }
    }
    public IResult Process(ticket exTicket)
    {
        try
        {
            bool pass = _service.UpdateReimbursment(exTicket);
            if (pass)
            {
                return Results.Accepted("/process", _service.GetReimbursmentById(exTicket.id));
            }
            return Results.BadRequest($"The Ticket is no longer being deliberated. Status: {_service.GetReimbursmentById(exTicket.iD).status}");
        }
        catch (ResourceNotFoundException)
        {
            return Results.Conflict("Ticket cannot be updated.");
        }
    }
    public IResult GetTicketByStatus(string status)
    {
        try
        {
            List<ticket> allTicks = _service.GetReimbursmentsByStatus(status);
            return Results.Accepted("/tickets", allTicks);
        }
        catch (ResourceNotFoundException)
        {
            return Results.NotFound($"No tickets currently {status}");
        }
    }
    public IResult getTicketByAuthor(int authID)
    {
        try
        {
            List<ticket> allTicks = _service.GetReimbursmentsByUserId(authID);
            return Results.Accepted("/tickets/author/{authID}", allTicks);
        }
        catch (ResourceNotFoundException)
        {
            return Results.BadRequest("The user in question has no prior tickets.");
        }
    }
    public IResult GetTicketByID(int id)
    {
        try
        {
            ticket exTicket = _service.GetReimbursmentById(id);
            return Results.Accepted("/tickets/id/{id}, exTicket");
        }
        catch (ResourceNotFoundException)
        {
            return Results.BadRequest($"There are no tickets with ID: {id}");
        }
    }
}
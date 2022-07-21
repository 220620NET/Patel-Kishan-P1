using Models;
using Services;
using customExceptions;

namespace WebAPI.Controllers;

public class UserController
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }
    public IResult GetAllUsers()
    {
        try
        {
            List<User> allUsers = _service.GetAllUsers();
            return Results.Accepted("/users", allUsers);
        }
        catch (ResourceNotFoundException)
        {
            return Results.NotFound("No users to return");
        }
    }

    public IResult GetUserById(int id)
    {
        try
        {
            User user = _service.GetUserById(id);
            return Results.Accepted("/users/id/{id}", user);
        }
        catch (IndexOutOfRangeException)
        {
            return Results.NotFound("No users with that ID");
        }
    }

    public IResult GetUserByUsername(string username)
    {
        try
        {
        User user = _service.GetUserByUsername(username);
            return Results.Accepted("/users/name/{username}", user);
        }
        catch (ResourceNotFoundException)
        {
            return Results.NotFound("No users with that username");
        }
    }
}
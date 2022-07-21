using Services;
using Models;
using customExceptions;

namespace WebAPI.Controllers;
public class AuthController
{
    private readonly AuthService _service;
    public AuthController(AuthService service)
    {
        _service = service;
    }

    public IResult Register(User UserToRegister)
    {
        try
        {
            _service.Register(UserToRegister);
            return Results.Created("/register", UserToRegister);
        }
        catch (UsernameNotAvailableException)
        {
            return Results.Conflict("User with this name already exists");
        }
    }

        public IResult Login(User UserToLogin)
    {
        try
        {
            return Results.Ok(_service.Login(UserToLogin));
        }
        catch (InvalidCredentialException)
        {
            return Results.NoContent();
        }
        catch (InvalidCredentialException)
        {
            return Results.BadRequest("Username or Password are incorrect");
        }
    }
}

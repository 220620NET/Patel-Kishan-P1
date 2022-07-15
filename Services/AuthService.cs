using Models;
using DataAccess;
using customExceptions;

namespace Services;

public class AuthService
{
    private readonly IUserRepository _repo;

    public AuthService(IUserRepository repository)
    {
        _repo = repository;
    }
    public User loginmeth(string userName,string password)
    {
        User foundUser;
        try
        {
            creds = _repo.GetUserByUserName(userName);
            if (creds.userName == "")
            {
                throw new ResourceNotFoundException();
            }
            else if (creds.password == password)
            {
                return creds;
            }
            else
            {
                InvalidCredentialsException();
                }
        }
        catch (ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
        catch (InvalidCredentialsException)
        {
            throw new InvalidCredentialsException();
        }

    }
    public User Register(User newUser)
    {
        try
        {
            User check = _repo.GetUserByUserName(userName);
            if (check.username == userName)
            {
                throw new UsernameNotAvailableException();
            }
            else 
            {
                User user = _repo.createUser(newUser);
            }
            if (user.id > 0)
            {
                return User;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        catch(UsernameNotAvailableException)
        {
            throw new UsernameNotAvailableException();
        }
        catch(NotImplementedException)
        {
            throw new NotImplementedException();
        }
    }
}
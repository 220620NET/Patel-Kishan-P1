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
    public User Login(string userName,string password)
    {
        try
        {
            User creds = _repo.GetUserByUserName(userName);
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
                throw new InvalidCredentialsException();
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
            User check = _repo.GetUserByUserName(newUser.userName);
            if (check.userName == newUser.userName)
            {
                throw new UsernameNotAvailableException();
            }
            else 
            {
                User user = _repo.createUser(newUser);
                if (newUser.userID > 0)
                {
                    return newUser;
                }
                else
                {
                    Console.WriteLine(user.userID);
                    throw new NotImplementedException();
                }
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
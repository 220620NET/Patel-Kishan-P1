using Models;
using DataAccess;
using customExceptions;

namespace Services;

public class UserService
{
    private readonly IUserRepository _repo;
    public AuthService(IUserRepository repository)
    {
        _repo = repository;
    }

    public User GetUserByUsername(string userName)
    {
        try
        {
            return IUserRepository.GetUserByUserName(userName);
        }
        catch(UsernameNotAvailableException)
        {
            throw new UsernameNotAvailableException();
        }
    }
    public User GetUserById(int id)
    {
        try
        {
            return IUserRepository.GetUserByUserId(id);
        }
        catch(IndexOutOfRangeException)
        {
            throw new IndexOutOfRangeException();
        }
    }
    public List<User> GetAllUsers()
    {
        try
        {
            return IUserRepository.GetAllUsers();
        }
        catch(ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
}
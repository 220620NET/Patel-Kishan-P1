using Models;
using DataAccess;
using customExceptions;

namespace Services;

public class UserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repository)
    {
        _repo = repository;
    }

    public User GetUserByUsername(string userName)
    {
        try
        {
            return _repo.GetUserByUserName(userName);
        }
        catch(ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
    public User GetUserById(int id)
    {
        try
        {
            User exUser =  _repo.GetUserById(id);
            return exUser;
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
            return _repo.GetAllUsers();
        }
        catch(ResourceNotFoundException)
        {
            throw new ResourceNotFoundException();
        }
    }
}
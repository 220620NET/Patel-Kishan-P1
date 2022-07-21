using Models;

namespace DataAccess;
public interface IUserRepository
{
    List<User> GetAllUsers();
    User GetUserById(int id);

    User GetUserByUserName(string name);
    User createUser(User newUser);
}
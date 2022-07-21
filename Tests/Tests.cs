using Moq;
using Models;
using customExceptions;
using Services;
using Xunit;
using DataAccess;
using System;

namespace AuthTesting;

public class AuthServicesTesting
{
    [Fact]
    public void PasswordFailToLogin()
    {
        var mockedRepo = new Mock<IUserRepository>();

        User newUser = new User{
            userID = 1,
            userName = "JoeR0g4n",
            password = "password",
            role = "client"
        };

        User PassWrong = new User {
            userName = "JoeR0g4n",
            password = "wrong",
        };
        

        mockedRepo.Setup(repo => repo.createUser(newUser)).Returns(newUser);


        AuthService service = new AuthService(mockedRepo.Object);

        Assert.Throws<NullReferenceException>(() => service.Login(PassWrong.userName, PassWrong.password));
    }
    [Fact]
    public void UsernameDoesNotExist()
    {
        var mockedRepo = new Mock<IUserRepository>();

        User newUser = new User{
            userID = 1,
            userName = "JoeR0g4n",
            password = "password",
            role = "client"
        };

        User UserWrong = new User {
            userName = "JoeBr0g4n",
            password = "wrong",
        };
        

        mockedRepo.Setup(repo => repo.createUser(newUser)).Returns(newUser);
        mockedRepo.Setup(repo => repo.GetUserByUserName(UserWrong.userName)).Throws(new ResourceNotFoundException());


        AuthService service = new AuthService(mockedRepo.Object);

        Assert.Throws<ResourceNotFoundException>(() => service.Login(UserWrong.userName,UserWrong.password));
    }
    [Fact]
    public void UsernameDoesExist()
    {
        var mockedRepo = new Mock<IUserRepository>();

        User newUser = new User{
            userID = 1,
            userName = "JoeR0g4n",
            password = "password",
            role = "client"
        };

        User UserDUP = new User {
            userName = "JoeR0g4n",
            password = "wrong",
            role = "admin"
        };
        

        mockedRepo.Setup(repo => repo.createUser(newUser)).Returns(newUser);
        mockedRepo.Setup(repo => repo.GetUserByUserName(UserDUP.userName)).Throws(new UsernameNotAvailableException());


        AuthService service = new AuthService(mockedRepo.Object);

        Assert.Throws<UsernameNotAvailableException>(() => service.Register(UserDUP));
    }
}
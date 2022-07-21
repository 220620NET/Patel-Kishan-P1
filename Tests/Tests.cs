using Models;
using Services;
using customExceptions;

namespace AuthTesting;

public class AuthServicesTesting
{
    [Theory]
    [InlineData("ksp223","3nc34")]
    [InlineData("ksp223"," ")]
    [InlineData("ksp223","dsf@#ml")]
    [InlineData("ksp223","")]
    public void PasswordLoginFailure(string username, string password)
    {
        Assert.Throws<InvalidCredentialsException>(() => new AuthService().Login(username, password));
    }

    [Theory]
    [InlineData("afee323", "password")]
    [InlineData(" ", "password")]
    [InlineData("", "password")]
    [InlineData("aoe4#$%!sd", "password")]
    public void UsernameLoginFailure(string username, string password)
    {
        Assert.Throws<ResourceNotFoundException>(()=>new AuthService().Login(username, password));
    }

    [Fact]
    [InlineData("ksp223")]
    public void DuplicateUserRegister(string username)
    {
        var fakeAuthService = new AuthService();
        User newUser = new User(username);
        Assert.Throws<UsernameNotAvailable>(() => AuthService.Register(newUser));
    }
}
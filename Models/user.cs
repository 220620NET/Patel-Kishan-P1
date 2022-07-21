using customExceptions;

namespace Models;

public class User {

    public int userID {get; set;}

    public string userName {get; set;} = null!;

    public string password {get; set;} = null!;
    public string role {get; set;} = null!;

    public User() {
        userID = 0;
        userName = "userName";
        password = "password";
        role = "";
    }
    public User (int userID, string userName, string password, string role){
        this.userID = userID;
        this.userName = userName;
        this.password = password;
        this.role = role;
    }


}
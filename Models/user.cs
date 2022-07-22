using customExceptions;

namespace Models;

public class User {

    public int userID {get; set;}

    public string userName {get; set;} = null!;

    public string password {get; set;} = null!;
    public string role {get; set;} = null!;

    public User() {
        userName = "userName";
        password = "password";
    }
     public User(string userName, string password, string role) {
        this.userName = userName;
        this.password = password;
        this.role = role;
    }
    public User (int userID, string userName, string password, string role){
        this.userID = userID;
        this.userName = userName;
        this.password = password;
        this.role = role;
    }


}


namespace user;

public class userModel {
    private string? userID {get; set;}

    private string? userName {get; set;}

    private string? password {get; set;}

    public enum role {
        customer, employee, admin
    }
    private role Role {get; set;}

    public void User (string userID, string userName, string password, role Role){
        this.userID = userID;
        this.userName = userName;
        this.password = password;
        this.Role = Role;
    }


}
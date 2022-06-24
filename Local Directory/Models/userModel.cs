using customExceptions;


namespace models;

public class userModel {

    private string userID {get; set;} = null!;

    private string userName {get; set;} = null!;

    private string password {get; set;} = null!;
    private string role {get; set;} = null!;

    public void User (string userID, string userName, string password, string role){
        this.userID = userID;
        this.userName = userName;
        this.password = password;
        this.role = role;
    }


}
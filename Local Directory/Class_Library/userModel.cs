

namespace user;

public class userModel {
    private string? userID {get; set;}

    private string? userName {get; set;}

    private string? password {get; set;}

    public enum role {
        customer, employee, admin
    }
    private role Role {get; set;}


}
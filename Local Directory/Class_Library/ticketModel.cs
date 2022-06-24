namespace models;

public class ticketModel {
    private string iD {get; set;} = null!;
    private string author {get; set;} = null!;
    private string resolver {get; set;} = null!;
    private string description {get; set;} = null!;

    public enum status {
        Incomplete, Pending, Approved, Rejected, Under_Consideration
    }
    private status Status {get; set;}
    private decimal amount {get; set;}

    public void User (string iD, string author, string resolver, string description, status Status, decimal amount){
        this.iD = iD;
        this.author = author;
        this.resolver = resolver;
        this.description = description;
        this.Status = Status;
        this.amount = amount;
    }
}

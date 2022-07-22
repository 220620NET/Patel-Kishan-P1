using customExceptions;


namespace Models;

public class ticket {
    public int id {get; set;}
    public string author {get; set;} = null!;
    public string resolver {get; set;} = null!;
    public string description {get; set;} = null!;

    public string status {get; set;} = null!;
    public double amount {get; set;}

    public ticket()
    {
        id = 0;
        author = "";
        resolver = "";
        description = "";
        status = "";
        amount = 0;
    }
    public ticket (int id, string author, string resolver, string description, string status, double amount){
        this.id = id;
        this.author = author;
        this.resolver = resolver;
        this.description = description;
        this.status = status;
        this.amount = amount;
    }
}

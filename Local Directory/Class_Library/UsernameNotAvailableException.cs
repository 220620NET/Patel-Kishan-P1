namespace customExceptions;

public class UsernameNotAvailableException : System.Exception
{
    public UsernameNotAvailableException() { }
    public UsernameNotAvailableException(string message) : base(message) { }
    public UsernameNotAvailableException(string message, System.Exception inner) : base(message, inner) { }
    protected UsernameNotAvailableException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
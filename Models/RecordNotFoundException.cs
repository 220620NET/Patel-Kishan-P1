namespace CustomExceptions;

[System.Serializable]
public class RecordNotFoundException : System.Exception
{
    public RecordNotFoundException() { }
    public RecordNotFoundException(string message) : base(message) { }
    public RecordNotFoundException(string message, System.Exception inner) : base(message, inner) { }
    protected RecordNotFoundException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
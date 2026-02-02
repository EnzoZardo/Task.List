namespace TaskList.Domain.Tools.ResultPattern;

public class Error(string message, ErrorKind kind = ErrorKind.InternalServer)
{
    public string Message { get; set; } = message;
    public ErrorKind Kind { get; set; } = kind;

    public static Error NotFound(string message) => new(message, ErrorKind.NotFound);
    public static Error BadRequest(string message) => new(message, ErrorKind.BadRequest);
    public static Error InternalServer(string message) => new(message, ErrorKind.InternalServer);
}

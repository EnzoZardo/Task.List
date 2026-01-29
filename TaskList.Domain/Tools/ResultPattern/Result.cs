namespace TaskList.Domain.Tools.ResultPattern;

public class ResultBase
{
    public bool IsSuccess { get; set; }
    public bool IsFailure { get => !IsSuccess; }
    public Error? Error { get; set; }
}

public class Result : ResultBase
{
    public static Result Ok() => new() { IsSuccess = true };
    public static Result Fail(Error error) => new() { IsSuccess = false, Error = error };
    public static Result Fail(string message) => new() { IsSuccess = false, Error = new Error { Message = message } };

    public static implicit operator Result(Error error) => Fail(error);
}

public class Result<T> : ResultBase
{
    public T? Value { get; set; }
    public static Result<T> Ok(T value) => new() { IsSuccess = true, Value = value };
    public static Result<T> Fail(Error error) => new() { IsSuccess = false, Error = error };
    public static Result<T> Fail(string message) => new() { IsSuccess = false, Error = new Error { Message = message } };
    public Result ToResult()
    {
        if (IsSuccess) return Result.Ok();
        return Result.Fail(Error!);
    }

    public static implicit operator Result<T>(T value) => Ok(value);
    public static implicit operator Result<T>(Error error) => Fail(error);
}
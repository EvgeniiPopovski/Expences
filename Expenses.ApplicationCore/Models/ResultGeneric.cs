namespace Expenses.ApplicationCore.Models;

public class Result<T>
{
    public bool IsSucceeded { get; set; }

    public T? Data { get; set; }

    public List<string> Errors { get; set; }

    public static Result<T> Success(T data)
    {
        return new Result<T>()
        {
            IsSucceeded = true,
            Data = data,
        };
    }

    public static Result<T> Failed(string error)
    {
        return new Result<T>()
        {
            IsSucceeded = false,
            Errors = [error],
        };
    }
}
namespace Expenses.ApplicationCore.Models;

public class Result
{
    public bool IsSucceeded { get; set; }
    
    public List<string> Errors { get; set; }

    public static Result Failed(string error)
    {
        return new Result()
        {
            IsSucceeded = false,
            Errors = [error],
        };
    }

    public static Result Success()
    {
        return new Result()
        {
            IsSucceeded = true,
        };
    }
}
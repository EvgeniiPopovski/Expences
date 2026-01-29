namespace Expenses.ApplicationCore.Extensions;

public static class StringExtension
{
    public static int ToInteger(this string value)
    {
        return int.Parse(value);
    }

    public static bool IsNotNullOrEmpty(this string value)
    {
        return !string.IsNullOrEmpty(value);
    }
}
namespace BuberDinner.Domain.Common.Exceptions;

public class ValidationException(IDictionary<string, string[]> errorsDictionary)
    : ApplicationException("Validation Failure", "One or more validation errors occurred")
{
    public IDictionary<string, string[]> ErrorsDictionary { get; } = errorsDictionary;
}

public abstract class ApplicationException(string title, string message) : Exception(message)
{
    public string Title { get; } = title;
}
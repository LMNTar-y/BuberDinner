namespace BuberDinner.Domain.Exceptions;

public class UserNotFoundException(string? message) : Exception(message);
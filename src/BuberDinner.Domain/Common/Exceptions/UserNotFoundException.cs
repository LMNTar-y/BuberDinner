namespace BuberDinner.Domain.Common.Exceptions;

public class UserNotFoundException(string? message) : Exception(message);
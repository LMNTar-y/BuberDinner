namespace BuberDinner.Domain.Exceptions;

public class InvalidPasswordException(string? message) : Exception(message);
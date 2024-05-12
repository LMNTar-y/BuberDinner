namespace BuberDinner.Domain.Common.Exceptions;

public class InvalidPasswordException(string? message) : Exception(message);
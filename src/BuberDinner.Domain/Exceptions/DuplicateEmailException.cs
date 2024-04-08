namespace BuberDinner.Domain.Exceptions;

public class DuplicateEmailException(string? message) : Exception(message);
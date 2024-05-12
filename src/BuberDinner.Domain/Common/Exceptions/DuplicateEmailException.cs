namespace BuberDinner.Domain.Common.Exceptions;

public class DuplicateEmailException(string? message) : Exception(message);
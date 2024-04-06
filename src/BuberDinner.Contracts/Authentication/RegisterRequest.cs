using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BuberDinner.Contracts.Authentication;

public record RegisterRequest(string FirstName, string LastName, [EmailAddress] string Email, [PasswordPropertyText] string Password);
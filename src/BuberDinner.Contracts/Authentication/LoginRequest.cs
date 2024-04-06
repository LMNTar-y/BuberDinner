using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BuberDinner.Contracts.Authentication;

public record LoginRequest([EmailAddress]string Email, [PasswordPropertyText]string Password);
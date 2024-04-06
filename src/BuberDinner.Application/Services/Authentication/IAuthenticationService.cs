using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Login(string email, string password);
    AuthenticationResult Register(string firstName, string lastName, [EmailAddress] string email, [PasswordPropertyText] string password);
}
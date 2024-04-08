using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using BuberDinner.Application.Authentication.Common;

namespace BuberDinner.Application.Authentication.Queries.Login;

public record LoginQuery([EmailAddress] string Email, [PasswordPropertyText] string Password) : IRequest<AuthenticationResult>;
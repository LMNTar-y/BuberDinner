using FluentValidation;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(v => v.Email)
            .MaximumLength(50)
            .NotEmpty()
            .EmailAddress();
        RuleFor(v => v.Password)
            .MaximumLength(50)
            .NotEmpty();
    }
}
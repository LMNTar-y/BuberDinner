using FluentValidation;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(v => v.FirstName)
            .MaximumLength(50)
            .NotEmpty();
        RuleFor(v => v.LastName)
            .MaximumLength(50)
            .NotEmpty();
        RuleFor(v => v.Email)
            .MaximumLength(50)
            .NotEmpty()
            .EmailAddress();
        RuleFor(v => v.Password)
            .MaximumLength(50)
            .NotEmpty();
    }
}
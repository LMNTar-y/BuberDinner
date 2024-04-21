using FluentValidation;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(50)
                .NotEmpty();
            RuleFor(v => v.Description)
                .MaximumLength(500)
                .NotEmpty();
            RuleFor(v => v.HostId)
                .NotEmpty();
            RuleFor(v => v.Sections)
                .NotEmpty();
        }
    }
}
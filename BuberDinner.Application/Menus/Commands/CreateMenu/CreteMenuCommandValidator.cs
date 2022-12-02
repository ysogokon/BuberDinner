using FluentValidation;

namespace BuberDinner.Application.Menus.Commands.CreateMenu
{
  public class CreteMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreteMenuCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Sections).NotEmpty();
        }
    }
}
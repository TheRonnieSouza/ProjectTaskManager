using Application.Commands.UserCommands.CreateUserCommand;
using FluentValidation;

namespace Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                    .WithMessage("Cannot be empity!")
                 .MaximumLength(100)
                  .WithMessage("The name need to be lower than 100 chacterer!");
            RuleFor(p => p.Email)
                .EmailAddress();
        }
    }
}

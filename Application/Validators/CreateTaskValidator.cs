using Application.Commands.TaskCommand.CreateTaskCommand;
using Application.Validators.Custom;
using FluentValidation;

namespace Application.Validators
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskValidator()
        {
            RuleFor(p => p.Title)
             .NotEmpty()
                 .WithMessage("Cannot be empity!")
             .MaximumLength(50)
                  .WithMessage("The title need to be lower than 50 chacterer!");

            RuleFor(p => p.Priority)
                .NotEmpty()
                    .WithMessage("Cannot be empity!");


            RuleFor(p => p.Priority)
              .ValidatePriority();
        }
    }
}

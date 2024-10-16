using Application.Commands.ProjectCommand.CreateProjectCommand;
using FluentValidation;

namespace Application.Validators
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                    .WithMessage("Cannot be empity!");
        }
    }
   
}

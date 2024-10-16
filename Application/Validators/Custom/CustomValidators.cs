using FluentValidation;

namespace Application.Validators.Custom
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, TElement> ValidatePriority<T, TElement>(this IRuleBuilder<T, TElement> rulesBuilder)
        {
            return rulesBuilder.Must(p => p.Equals(3)).WithMessage($"The priority needs to start, lower or medium.");

        }
    }
}

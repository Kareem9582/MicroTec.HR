using FluentValidation;

namespace MicroTec.Hr.Infrastructure.Shared
{
    public static class ValidationRulesBase
    {
        public static IRuleBuilderOptions<T, TProperty> RequiredRule<T, TProperty>(this IRuleBuilder<T, TProperty> rule, string fieldName)
       where TProperty : struct, IEquatable<TProperty>
        {
            return rule
                .NotEqual(default(TProperty))
                .WithMessage($"{fieldName} is required.");
        }
    }
}

using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "2.0")]

namespace Webinar.Demo.Basket.Application.Baskets.GetBaskets
{
    public class GetBasketsQueryValidator : AbstractValidator<GetBasketsQuery>
    {
        [IntentManaged(Mode.Merge)]
        public GetBasketsQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}
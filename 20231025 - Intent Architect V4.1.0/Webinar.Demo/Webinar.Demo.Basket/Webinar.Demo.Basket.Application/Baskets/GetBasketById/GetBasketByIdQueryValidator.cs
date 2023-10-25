using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.QueryValidator", Version = "2.0")]

namespace Webinar.Demo.Basket.Application.Baskets.GetBasketById
{
    public class GetBasketByIdQueryValidator : AbstractValidator<GetBasketByIdQuery>
    {
        [IntentManaged(Mode.Merge)]
        public GetBasketByIdQueryValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}
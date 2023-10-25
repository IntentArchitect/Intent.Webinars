using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace Webinar.Demo.Ordering.Application.Orders.ShipOrder
{
    public class ShipOrderCommandValidator : AbstractValidator<ShipOrderCommand>
    {
        [IntentManaged(Mode.Merge)]
        public ShipOrderCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}
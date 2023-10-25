using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace Webinar.Demo.Ordering.Application.Orders.AddOrderLineOrder
{
    public class AddOrderLineOrderCommandValidator : AbstractValidator<AddOrderLineOrderCommand>
    {
        [IntentManaged(Mode.Merge)]
        public AddOrderLineOrderCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}
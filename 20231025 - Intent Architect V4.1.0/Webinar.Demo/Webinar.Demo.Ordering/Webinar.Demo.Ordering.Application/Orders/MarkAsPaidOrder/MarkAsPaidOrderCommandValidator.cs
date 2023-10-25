using FluentValidation;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace Webinar.Demo.Ordering.Application.Orders.MarkAsPaidOrder
{
    public class MarkAsPaidOrderCommandValidator : AbstractValidator<MarkAsPaidOrderCommand>
    {
        [IntentManaged(Mode.Merge)]
        public MarkAsPaidOrderCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
        }
    }
}
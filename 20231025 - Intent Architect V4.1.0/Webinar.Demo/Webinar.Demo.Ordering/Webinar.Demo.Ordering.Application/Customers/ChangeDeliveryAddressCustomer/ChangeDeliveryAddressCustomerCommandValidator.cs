using FluentValidation;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Ordering.Application.Common.Validation;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.FluentValidation.CommandValidator", Version = "2.0")]

namespace Webinar.Demo.Ordering.Application.Customers.ChangeDeliveryAddressCustomer
{
    public class ChangeDeliveryAddressCustomerCommandValidator : AbstractValidator<ChangeDeliveryAddressCustomerCommand>
    {
        [IntentManaged(Mode.Merge)]
        public ChangeDeliveryAddressCustomerCommandValidator(IValidatorProvider provider)
        {
            ConfigureValidationRules(provider);
        }

        private void ConfigureValidationRules(IValidatorProvider provider)
        {
            RuleFor(v => v.Address)
                .NotNull()
                .SetValidator(provider.GetValidator<ChangeAddressDto>()!);
        }
    }
}
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Ordering.Domain;
using Webinar.Demo.Ordering.Domain.Common.Exceptions;
using Webinar.Demo.Ordering.Domain.Repositories;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandHandler", Version = "2.0")]

namespace Webinar.Demo.Ordering.Application.Customers.ChangeDeliveryAddressCustomer
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class ChangeDeliveryAddressCustomerCommandHandler : IRequestHandler<ChangeDeliveryAddressCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        [IntentManaged(Mode.Merge)]
        public ChangeDeliveryAddressCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [IntentManaged(Mode.Fully, Body = Mode.Fully)]
        public async Task Handle(ChangeDeliveryAddressCustomerCommand request, CancellationToken cancellationToken)
        {
            var existingCustomer = await _customerRepository.FindByIdAsync(request.Id, cancellationToken);
            if (existingCustomer is null)
            {
                throw new NotFoundException($"Could not find Customer '{request.Id}'");
            }

            existingCustomer.ChangeDeliveryAddress(CreateAddress(request.Address));
        }

        [IntentManaged(Mode.Fully)]
        public static Address CreateAddress(ChangeAddressDto dto)
        {
            return new Address(line1: dto.Line1, line2: dto.Line2, city: dto.City, postal: dto.Postal);
        }
    }
}
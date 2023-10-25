using System;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Ordering.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Webinar.Demo.Ordering.Application.Customers.ChangeDeliveryAddressCustomer
{
    public class ChangeDeliveryAddressCustomerCommand : IRequest, ICommand
    {
        public ChangeDeliveryAddressCustomerCommand(Guid id, ChangeAddressDto address)
        {
            Id = id;
            Address = address;
        }

        public Guid Id { get; set; }
        public ChangeAddressDto Address { get; set; }
    }
}
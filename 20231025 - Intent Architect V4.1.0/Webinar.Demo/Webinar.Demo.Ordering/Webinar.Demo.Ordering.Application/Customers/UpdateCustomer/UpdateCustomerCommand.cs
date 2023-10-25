using System;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Ordering.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Webinar.Demo.Ordering.Application.Customers.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest, ICommand
    {
        public UpdateCustomerCommand(Guid id,
            string name,
            string surname,
            string email,
            UpdateCustomerAddressDto deliveryAddress)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            DeliveryAddress = deliveryAddress;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public UpdateCustomerAddressDto DeliveryAddress { get; set; }
    }
}
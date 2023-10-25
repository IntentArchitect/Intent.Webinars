using System;
using Intent.RoslynWeaver.Attributes;
using MediatR;
using Webinar.Demo.Ordering.Application.Common.Interfaces;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.MediatR.CommandModels", Version = "1.0")]

namespace Webinar.Demo.Ordering.Application.Customers.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Guid>, ICommand
    {
        public CreateCustomerCommand(string name, string surname, string email, CreateCustomerAddressDto deliveryAddress)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DeliveryAddress = deliveryAddress;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public CreateCustomerAddressDto DeliveryAddress { get; set; }
    }
}
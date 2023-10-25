using System;
using AutoMapper;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Ordering.Application.Common.Mappings;
using Webinar.Demo.Ordering.Domain;
using Webinar.Demo.Ordering.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace Webinar.Demo.Ordering.Application.Orders
{
    public class OrderDto : IMapFrom<Order>
    {
        public OrderDto()
        {
        }

        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public OrderStatus Status { get; set; }

        public static OrderDto Create(Guid id, DateTime orderDate, Guid customerId, OrderStatus status)
        {
            return new OrderDto
            {
                Id = id,
                OrderDate = orderDate,
                CustomerId = customerId,
                Status = status
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDto>();
        }
    }
}
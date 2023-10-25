using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Ordering.Domain.Common;
using Webinar.Demo.Ordering.Domain.Events;

namespace Webinar.Demo.Ordering.Domain.Entities
{
    public class Order : IHasDomainEvent
    {
        public Order(Guid customerId)
        {
            CustomerId = customerId;
            DomainEvents.Add(new OrderCreatedDomainEvent(this));
        }

        /// <summary>
        /// Required by Entity Framework.
        /// </summary>
        protected Order()
        {
            Customer = null!;
        }

        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        public Guid CustomerId { get; set; }

        public OrderStatus Status { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

        public virtual Customer Customer { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public void AddOrderLine(Guid productId, int units, decimal unitPrice, decimal? discount)
        {
            throw new NotImplementedException("Replace with your implementation...");
        }

        public void MarkAsPaid()
        {
            DomainEvents.Add(new OrderPaidDomainEvent(this));
        }

        public void Ship()
        {
            DomainEvents.Add(new OrderShipedDomainEvent(this));
        }

        public void Cancel()
        {
            DomainEvents.Add(new OrderCancelledDomainEvent(this));
        }
    }
}
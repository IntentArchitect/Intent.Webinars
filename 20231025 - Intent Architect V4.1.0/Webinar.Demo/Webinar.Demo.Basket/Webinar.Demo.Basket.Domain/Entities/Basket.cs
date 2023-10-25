using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Basket.Domain.Common;

namespace Webinar.Demo.Basket.Domain.Entities
{
    public class Basket : IHasDomainEvent
    {
        public Guid Id { get; set; }

        public virtual ICollection<BasketLine> BasketLines { get; set; } = new List<BasketLine>();

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
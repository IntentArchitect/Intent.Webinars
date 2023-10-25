using System;
using Intent.RoslynWeaver.Attributes;

namespace Webinar.Demo.Ordering.Domain.Entities
{
    public class OrderLine
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid OrderId { get; set; }

        public int Units { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? Discount { get; set; }

        public virtual Product Product { get; set; }
    }
}
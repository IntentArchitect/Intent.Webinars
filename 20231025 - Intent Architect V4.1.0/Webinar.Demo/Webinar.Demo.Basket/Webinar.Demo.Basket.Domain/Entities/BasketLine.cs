using System;
using Intent.RoslynWeaver.Attributes;

namespace Webinar.Demo.Basket.Domain.Entities
{
    public class BasketLine
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public int Units { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal? Discount { get; set; }

        public Guid BasketId { get; set; }
    }
}
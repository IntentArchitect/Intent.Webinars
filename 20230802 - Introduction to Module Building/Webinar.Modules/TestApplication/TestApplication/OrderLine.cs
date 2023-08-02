using System;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Webinar.Modules.BasicEntities.Entity", Version = "1.0")]

namespace TestApplication
{
    public class OrderLine
    {
        public OrderLine(int units, decimal unitPrice, Guid productId)
        {
        }
        public Guid Id { get; set; }
        public int Units { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
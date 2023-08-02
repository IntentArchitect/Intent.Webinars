using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Webinar.Modules.BasicEntities.Entity", Version = "1.0")]

namespace TestApplication
{
    public class Order
    {
        public Order(DateTime orderDate, List<OrderLine> orderLines)
        {
        }
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderLine> OrderLines { get; set; }

        public void AddLine(OrderLine orderLine)
        {
        }
    }
}
using System;
using CleanArchitecture.Test.Domain.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace CleanArchitecture.Test.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods | Targets.Constructors, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class OrderLine
    {
        [IntentManaged(Mode.Fully, Body = Mode.Merge)]
        public OrderLine(int units, decimal unitPrice, Guid productId)
        {
            Units = units;
            UnitPrice = unitPrice;
            ProductId = productId;
        }

        public Guid Id { get; set; }

        public int Units { get; set; }

        public decimal UnitPrice { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
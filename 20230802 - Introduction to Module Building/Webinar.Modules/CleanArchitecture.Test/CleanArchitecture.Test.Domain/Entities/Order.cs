using System;
using System.Collections.Generic;
using CleanArchitecture.Test.Domain.Common;
using CleanArchitecture.Test.Domain.Common.Interfaces;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEntity", Version = "1.0")]

namespace CleanArchitecture.Test.Domain.Entities
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Properties)]
    [DefaultIntentManaged(Mode.Fully, Targets = Targets.Methods | Targets.Constructors, Body = Mode.Ignore, AccessModifiers = AccessModifiers.Public)]
    public class Order : IHasDomainEvent, IAudited
    {
        [IntentManaged(Mode.Fully, Body = Mode.Merge)]
        public Order(DateTime orderDate, IEnumerable<OrderLine> orderLines)
        {
            OrderDate = orderDate;
            OrderLines = new List<OrderLine>(orderLines);
        }

        /// <summary>
        /// Required by Entity Framework.
        /// </summary>
        [IntentManaged(Mode.Fully)]
        protected Order()
        {
            CreatedBy = null!;
        }

        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public void AddLine(OrderLine orderLine)
        {
            throw new NotImplementedException("Replace with your implementation...");
        }
    }
}
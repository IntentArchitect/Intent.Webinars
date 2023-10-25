using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Ordering.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.DomainMapping.MessageExtensions", Version = "1.0")]

namespace Webinar.Demo.Ordering.Eventing.Messages
{
    public static class ProductCreatedEventExtensions
    {
        public static ProductCreatedEvent MapToProductCreatedEvent(this Product projectFrom)
        {
            return new ProductCreatedEvent
            {
                Id = projectFrom.Id,
                Name = projectFrom.Name,
                Description = projectFrom.Description,
                Price = projectFrom.Price,
            };
        }
    }
}
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.DomainEnum", Version = "1.0")]

namespace Webinar.Demo.Ordering.Domain
{
    public enum OrderStatus
    {
        AwaitingConfirmation = 1,
        Paid = 2,
        Shipped = 3,
        Cancelled = 4
    }
}
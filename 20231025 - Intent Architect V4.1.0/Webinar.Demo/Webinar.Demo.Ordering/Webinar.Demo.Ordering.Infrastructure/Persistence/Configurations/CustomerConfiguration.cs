using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webinar.Demo.Ordering.Domain;
using Webinar.Demo.Ordering.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace Webinar.Demo.Ordering.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Surname)
                .IsRequired();

            builder.Property(x => x.Email)
                .IsRequired();

            builder.OwnsOne(x => x.BillingAddress, ConfigureBillingAddress);

            builder.OwnsOne(x => x.DeliveryAddress, ConfigureDeliveryAddress)
                .Navigation(x => x.DeliveryAddress).IsRequired();

            builder.Ignore(e => e.DomainEvents);
        }

        public void ConfigureBillingAddress(OwnedNavigationBuilder<Customer, Address> builder)
        {
            builder.WithOwner();

            builder.Property(x => x.Line1)
                .IsRequired();

            builder.Property(x => x.Line2)
                .IsRequired();

            builder.Property(x => x.City)
                .IsRequired();

            builder.Property(x => x.Postal)
                .IsRequired();
        }

        public void ConfigureDeliveryAddress(OwnedNavigationBuilder<Customer, Address> builder)
        {
            builder.WithOwner();

            builder.Property(x => x.Line1)
                .IsRequired();

            builder.Property(x => x.Line2)
                .IsRequired();

            builder.Property(x => x.City)
                .IsRequired();

            builder.Property(x => x.Postal)
                .IsRequired();
        }
    }
}
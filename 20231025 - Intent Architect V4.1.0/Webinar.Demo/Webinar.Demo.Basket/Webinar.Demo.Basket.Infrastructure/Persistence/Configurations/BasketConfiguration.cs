using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webinar.Demo.Basket.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.EntityTypeConfiguration", Version = "1.0")]

namespace Webinar.Demo.Basket.Infrastructure.Persistence.Configurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Domain.Entities.Basket>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Basket> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsMany(x => x.BasketLines, ConfigureBasketLines);

            builder.Ignore(e => e.DomainEvents);
        }

        public void ConfigureBasketLines(OwnedNavigationBuilder<Domain.Entities.Basket, BasketLine> builder)
        {
            builder.WithOwner()
                .HasForeignKey(x => x.BasketId);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductId)
                .IsRequired();

            builder.Property(x => x.Units)
                .IsRequired();

            builder.Property(x => x.UnitPrice)
                .IsRequired();

            builder.Property(x => x.Discount);

            builder.Property(x => x.BasketId)
                .IsRequired();
        }
    }
}
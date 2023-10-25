using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Basket.Domain.Entities;
using Webinar.Demo.Basket.Domain.Repositories;
using Webinar.Demo.Basket.Infrastructure.Persistence;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.Repository", Version = "1.0")]

namespace Webinar.Demo.Basket.Infrastructure.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public class BasketRepository : RepositoryBase<Domain.Entities.Basket, Domain.Entities.Basket, ApplicationDbContext>, IBasketRepository
    {
        public BasketRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Domain.Entities.Basket?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await FindAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<Domain.Entities.Basket>> FindByIdsAsync(
            Guid[] ids,
            CancellationToken cancellationToken = default)
        {
            return await FindAllAsync(x => ids.Contains(x.Id), cancellationToken);
        }
    }
}
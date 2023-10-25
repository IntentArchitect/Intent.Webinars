using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Webinar.Demo.Basket.Domain.Entities;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.EntityRepositoryInterface", Version = "1.0")]

namespace Webinar.Demo.Basket.Domain.Repositories
{
    [IntentManaged(Mode.Merge, Signature = Mode.Fully)]
    public interface IBasketRepository : IEFRepository<Domain.Entities.Basket, Domain.Entities.Basket>
    {
        [IntentManaged(Mode.Fully)]
        Task<Entities.Basket?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        [IntentManaged(Mode.Fully)]
        Task<List<Entities.Basket>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);
    }
}
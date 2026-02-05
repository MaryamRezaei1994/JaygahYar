using JaygahYar.Domain.Entities;

namespace JaygahYar.Domain.Interfaces;

public interface IStage3DeliveryFormRepository : IRepository<Stage3DeliveryForm>
{
    Task<IReadOnlyList<Stage3DeliveryForm>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default);
}

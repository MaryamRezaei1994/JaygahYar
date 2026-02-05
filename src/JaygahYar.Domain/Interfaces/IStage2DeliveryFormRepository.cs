using JaygahYar.Domain.Entities;

namespace JaygahYar.Domain.Interfaces;

public interface IStage2DeliveryFormRepository : IRepository<Stage2DeliveryForm>
{
    Task<IReadOnlyList<Stage2DeliveryForm>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default);
}

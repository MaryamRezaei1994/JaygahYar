using JaygahYar.Domain.Entities;

namespace JaygahYar.Domain.Interfaces;

public interface ITankMonitoringInstallationFormRepository : IRepository<TankMonitoringInstallationForm>
{
    Task<TankMonitoringInstallationForm?> GetByIdWithProbesAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TankMonitoringInstallationForm>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default);
}

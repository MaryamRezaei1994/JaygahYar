using JaygahYar.Domain.Entities;

namespace JaygahYar.Domain.Interfaces;

public interface IOilToolInstallationFormRepository : IRepository<OilToolInstallationForm>
{
    Task<OilToolInstallationForm?> GetByIdWithDispensersAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<OilToolInstallationForm>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default);
}

using JaygahYar.Domain.Entities;

namespace JaygahYar.Domain.Interfaces;

public interface IOilToolInstallationFormRepository : IRepository<OilToolInstallationForm>
{
    Task<IReadOnlyList<OilToolInstallationForm>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default);
}

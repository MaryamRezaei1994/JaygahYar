using JaygahYar.Application.DTOs;

namespace JaygahYar.Application.Interfaces;

public interface ITankMonitoringInstallationFormService
{
    Task<TankMonitoringInstallationFormDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TankMonitoringInstallationFormDto>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default);
    Task<TankMonitoringInstallationFormDto> CreateAsync(CreateTankMonitoringInstallationFormRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

using JaygahYar.Application.DTOs;

namespace JaygahYar.Application.Interfaces;

public interface IOilToolInstallationFormService
{
    Task<OilToolInstallationFormDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<OilToolInstallationFormDto>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default);
    Task<OilToolInstallationFormDto> CreateAsync(CreateOilToolInstallationFormRequest request, CancellationToken cancellationToken = default);
    Task<OilToolInstallationFormDto?> UpdateAsync(Guid id, UpdateOilToolInstallationFormRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

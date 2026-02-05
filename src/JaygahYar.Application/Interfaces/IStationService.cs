using JaygahYar.Application.DTOs;

namespace JaygahYar.Application.Interfaces;

public interface IStationService
{
    Task<StationDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<StationDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<StationDto> CreateAsync(CreateStationRequest request, CancellationToken cancellationToken = default);
    Task<StationDto?> UpdateAsync(Guid id, UpdateStationRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

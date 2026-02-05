using JaygahYar.Application.DTOs;

namespace JaygahYar.Application.Interfaces;

public interface IStage3DeliveryFormService
{
    Task<Stage3DeliveryFormDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Stage3DeliveryFormDto>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default);
    Task<Stage3DeliveryFormDto> CreateAsync(CreateStage3DeliveryFormRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

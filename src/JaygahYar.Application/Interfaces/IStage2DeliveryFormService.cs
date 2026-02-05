using JaygahYar.Application.DTOs;

namespace JaygahYar.Application.Interfaces;

public interface IStage2DeliveryFormService
{
    Task<Stage2DeliveryFormDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Stage2DeliveryFormDto>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default);
    Task<Stage2DeliveryFormDto> CreateAsync(CreateStage2DeliveryFormRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

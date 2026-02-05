using JaygahYar.Application.DTOs;

namespace JaygahYar.Application.Interfaces;

public interface IAfterSalesServiceReportService
{
    Task<AfterSalesServiceReportDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<AfterSalesServiceReportDto>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default);
    Task<AfterSalesServiceReportDto> CreateAsync(CreateAfterSalesServiceReportRequest request, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

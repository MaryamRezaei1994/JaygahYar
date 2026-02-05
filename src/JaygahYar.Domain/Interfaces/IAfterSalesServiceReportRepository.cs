using JaygahYar.Domain.Entities;

namespace JaygahYar.Domain.Interfaces;

public interface IAfterSalesServiceReportRepository : IRepository<AfterSalesServiceReport>
{
    Task<AfterSalesServiceReport?> GetByIdWithItemsAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<AfterSalesServiceReport>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default);
}

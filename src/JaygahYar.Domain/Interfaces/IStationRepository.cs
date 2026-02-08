using JaygahYar.Domain.Entities;

namespace JaygahYar.Domain.Interfaces;

public interface IStationRepository : IRepository<Station>
{
    Task<Station?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Station?> FindByNameOrMobileAsync(string stationName, string mobile, CancellationToken cancellationToken = default);
}

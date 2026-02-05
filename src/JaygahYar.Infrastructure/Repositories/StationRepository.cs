using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;
using JaygahYar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JaygahYar.Infrastructure.Repositories;

public class StationRepository : IStationRepository
{
    private readonly ApplicationDbContext _context;

    public StationRepository(ApplicationDbContext context) => _context = context;

    public async Task<Station?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Stations.FindAsync([id], cancellationToken);

    public async Task<Station?> GetByIdWithDetailsAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Stations
            .Include(x => x.OilToolInstallations).ThenInclude(x => x.DispenserItems)
            .Include(x => x.TankMonitoringInstallations).ThenInclude(x => x.ProbeItems)
            .Include(x => x.AfterSalesReports).ThenInclude(x => x.ServiceItems)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Station>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.Stations.ToListAsync(cancellationToken);

    public async Task<Station> AddAsync(Station entity, CancellationToken cancellationToken = default)
    {
        await _context.Stations.AddAsync(entity, cancellationToken);
        return entity;
    }

    public Task UpdateAsync(Station entity, CancellationToken cancellationToken = default)
    {
        _context.Stations.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Station entity, CancellationToken cancellationToken = default)
    {
        _context.Stations.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Stations.AnyAsync(x => x.Id == id, cancellationToken);
}

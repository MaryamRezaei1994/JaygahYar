using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;
using JaygahYar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JaygahYar.Infrastructure.Repositories;

public class TankMonitoringInstallationFormRepository : ITankMonitoringInstallationFormRepository
{
    private readonly ApplicationDbContext _context;

    public TankMonitoringInstallationFormRepository(ApplicationDbContext context) => _context = context;

    public async Task<TankMonitoringInstallationForm?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.TankMonitoringInstallationForms.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<TankMonitoringInstallationForm>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default)
        => await _context.TankMonitoringInstallationForms
            .Where(x => x.StationId == stationId)
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<TankMonitoringInstallationForm>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.TankMonitoringInstallationForms.ToListAsync(cancellationToken);

    public async Task<TankMonitoringInstallationForm> AddAsync(TankMonitoringInstallationForm entity, CancellationToken cancellationToken = default)
    {
        await _context.TankMonitoringInstallationForms.AddAsync(entity, cancellationToken);
        return entity;
    }

    public Task UpdateAsync(TankMonitoringInstallationForm entity, CancellationToken cancellationToken = default)
    {
        _context.TankMonitoringInstallationForms.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TankMonitoringInstallationForm entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        _context.TankMonitoringInstallationForms.Update(entity);
        return Task.CompletedTask;
    }
}

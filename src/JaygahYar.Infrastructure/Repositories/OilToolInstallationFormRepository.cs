using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;
using JaygahYar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JaygahYar.Infrastructure.Repositories;

public class OilToolInstallationFormRepository : IOilToolInstallationFormRepository
{
    private readonly ApplicationDbContext _context;

    public OilToolInstallationFormRepository(ApplicationDbContext context) => _context = context;

    public async Task<OilToolInstallationForm?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.OilToolInstallationForms.FindAsync([id], cancellationToken);

    public async Task<IReadOnlyList<OilToolInstallationForm>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default)
        => await _context.OilToolInstallationForms
            .Where(x => x.StationId == stationId)
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<OilToolInstallationForm>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.OilToolInstallationForms.ToListAsync(cancellationToken);

    public async Task<OilToolInstallationForm> AddAsync(OilToolInstallationForm entity, CancellationToken cancellationToken = default)
    {
        await _context.OilToolInstallationForms.AddAsync(entity, cancellationToken);
        return entity;
    }

    public Task UpdateAsync(OilToolInstallationForm entity, CancellationToken cancellationToken = default)
    {
        _context.OilToolInstallationForms.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(OilToolInstallationForm entity, CancellationToken cancellationToken = default)
    {
        _context.OilToolInstallationForms.Remove(entity);
        return Task.CompletedTask;
    }
}

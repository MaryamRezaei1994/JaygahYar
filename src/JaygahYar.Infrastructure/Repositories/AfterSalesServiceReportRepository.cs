using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;
using JaygahYar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JaygahYar.Infrastructure.Repositories;

public class AfterSalesServiceReportRepository : IAfterSalesServiceReportRepository
{
    private readonly ApplicationDbContext _context;

    public AfterSalesServiceReportRepository(ApplicationDbContext context) => _context = context;

    public async Task<AfterSalesServiceReport?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.AfterSalesServiceReports.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<AfterSalesServiceReport?> GetByIdWithItemsAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.AfterSalesServiceReports
            .Include(x => x.Station)
            .Include(x => x.ServiceItems)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<AfterSalesServiceReport>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default)
        => await _context.AfterSalesServiceReports
            .Include(x => x.ServiceItems)
            .Where(x => x.StationId == stationId)
            .ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<AfterSalesServiceReport>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.AfterSalesServiceReports.Include(x => x.ServiceItems).ToListAsync(cancellationToken);

    public async Task<AfterSalesServiceReport> AddAsync(AfterSalesServiceReport entity, CancellationToken cancellationToken = default)
    {
        await _context.AfterSalesServiceReports.AddAsync(entity, cancellationToken);
        return entity;
    }

    public Task UpdateAsync(AfterSalesServiceReport entity, CancellationToken cancellationToken = default)
    {
        _context.AfterSalesServiceReports.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(AfterSalesServiceReport entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        _context.AfterSalesServiceReports.Update(entity);
        return Task.CompletedTask;
    }
}

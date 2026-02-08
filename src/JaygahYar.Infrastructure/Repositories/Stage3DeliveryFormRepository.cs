using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;
using JaygahYar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JaygahYar.Infrastructure.Repositories;

public class Stage3DeliveryFormRepository : IStage3DeliveryFormRepository
{
    private readonly ApplicationDbContext _context;

    public Stage3DeliveryFormRepository(ApplicationDbContext context) => _context = context;

    public async Task<Stage3DeliveryForm?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Stage3DeliveryForms.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Stage3DeliveryForm>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default)
        => await _context.Stage3DeliveryForms.Where(x => x.StationId == stationId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Stage3DeliveryForm>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.Stage3DeliveryForms.ToListAsync(cancellationToken);

    public async Task<Stage3DeliveryForm> AddAsync(Stage3DeliveryForm entity, CancellationToken cancellationToken = default)
    {
        await _context.Stage3DeliveryForms.AddAsync(entity, cancellationToken);
        return entity;
    }

    public Task UpdateAsync(Stage3DeliveryForm entity, CancellationToken cancellationToken = default)
    {
        _context.Stage3DeliveryForms.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Stage3DeliveryForm entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        _context.Stage3DeliveryForms.Update(entity);
        return Task.CompletedTask;
    }
}

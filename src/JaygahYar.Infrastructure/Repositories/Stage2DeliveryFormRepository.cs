using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;
using JaygahYar.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JaygahYar.Infrastructure.Repositories;

public class Stage2DeliveryFormRepository : IStage2DeliveryFormRepository
{
    private readonly ApplicationDbContext _context;

    public Stage2DeliveryFormRepository(ApplicationDbContext context) => _context = context;

    public async Task<Stage2DeliveryForm?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => await _context.Stage2DeliveryForms.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Stage2DeliveryForm>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default)
        => await _context.Stage2DeliveryForms.Where(x => x.StationId == stationId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyList<Stage2DeliveryForm>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.Stage2DeliveryForms.ToListAsync(cancellationToken);

    public async Task<Stage2DeliveryForm> AddAsync(Stage2DeliveryForm entity, CancellationToken cancellationToken = default)
    {
        await _context.Stage2DeliveryForms.AddAsync(entity, cancellationToken);
        return entity;
    }

    public Task UpdateAsync(Stage2DeliveryForm entity, CancellationToken cancellationToken = default)
    {
        _context.Stage2DeliveryForms.Update(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Stage2DeliveryForm entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        _context.Stage2DeliveryForms.Update(entity);
        return Task.CompletedTask;
    }
}

using AutoMapper;
using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;

namespace JaygahYar.Application.Services;

public class StationService : IStationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<StationDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Stations.GetByIdWithDetailsAsync(id, cancellationToken);
        return entity == null ? null : _mapper.Map<StationDto>(entity);
    }

    public async Task<IReadOnlyList<StationDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _unitOfWork.Stations.GetAllAsync(cancellationToken);
        return _mapper.Map<List<StationDto>>(list);
    }

    public async Task<StationDto> CreateAsync(CreateStationRequest request, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Station>(request);
        await _unitOfWork.Stations.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<StationDto>(entity);
    }

    public async Task<StationDto?> UpdateAsync(Guid id, UpdateStationRequest request, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Stations.GetByIdAsync(id, cancellationToken);
        if (entity == null) return null;
        entity.Name = request.Name;
        entity.Address = request.Address;
        entity.Phone = request.Phone;
        entity.Mobile = request.Mobile;
        entity.OwnerName = request.OwnerName;
        entity.GasolineTankCount = request.GasolineTankCount;
        entity.DieselTankCount = request.DieselTankCount;
        entity.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.Stations.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<StationDto>(entity);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Stations.GetByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        await _unitOfWork.Stations.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}

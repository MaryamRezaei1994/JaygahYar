using AutoMapper;
using JaygahYar.Application.Constants;
using JaygahYar.Application.DTOs;
using JaygahYar.Application.Exceptions;
using JaygahYar.Application.Interfaces;
using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;
using StackExchange.Redis;

namespace JaygahYar.Application.Services;

public class StationService : IStationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IDatabase _cache;
    private readonly TimeSpan _cacheExpirationTime = TimeSpan.FromMinutes(5);

    private const string CacheKeyStationsList = "CacheKeyStationsList";
    private const string CacheKeyStationByIdPrefix = "CacheKeyStationById-";

    public StationService(IUnitOfWork unitOfWork, IMapper mapper, ICacheProvider cacheProvider)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cacheProvider.Database;
    }

    public async Task<StationDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cached = await _cache.GetJsonAsync<StationDto>(CacheKeyStationByIdPrefix + id);
        if (cached != null) return cached;

        var entity = await _unitOfWork.Stations.GetByIdWithDetailsAsync(id, cancellationToken);
        if (entity == null) return null;

        var dto = _mapper.Map<StationDto>(entity);
        await _cache.StringSetAsync(CacheKeyStationByIdPrefix + id, dto.JsonSerialize(), _cacheExpirationTime);
        return dto;
    }

    public async Task<IReadOnlyList<StationDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var cached = await _cache.GetJsonAsync<List<StationDto>>(CacheKeyStationsList);
        if (cached != null) return cached;

        var list = await _unitOfWork.Stations.GetAllAsync(cancellationToken);
        var dtos = _mapper.Map<List<StationDto>>(list);
        await _cache.StringSetAsync(CacheKeyStationsList, dtos.JsonSerialize(), _cacheExpirationTime);
        return dtos;
    }

    public async Task<StationDto> CreateAsync(CreateStationRequest request, CancellationToken cancellationToken = default)
    {
        var normalizedName = request.Name.Trim();
        if (await _unitOfWork.Stations.NameExistsAsync(normalizedName, excludeId: null, cancellationToken))
            throw new DuplicateNameException($"Station name '{normalizedName}' already exists.");

        var entity = _mapper.Map<Station>(request);
        entity.Name = normalizedName;
        await _unitOfWork.Stations.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _cache.KeyDeleteAsync(CacheKeyStationsList);
        var dto = _mapper.Map<StationDto>(entity);
        await _cache.StringSetAsync(CacheKeyStationByIdPrefix + dto.Id, dto.JsonSerialize(), _cacheExpirationTime);
        return dto;
    }

    public async Task<StationDto?> UpdateAsync(Guid id, UpdateStationRequest request, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Stations.GetByIdAsync(id, cancellationToken);
        if (entity == null) return null;

        var normalizedName = request.Name.Trim();
        if (await _unitOfWork.Stations.NameExistsAsync(normalizedName, excludeId: id, cancellationToken))
            throw new DuplicateNameException($"Station name '{normalizedName}' already exists.");

        entity.Name = normalizedName;
        entity.Address = request.Address;
        entity.Phone = request.Phone;
        entity.Mobile = request.Mobile;
        entity.OwnerName = request.OwnerName;
        entity.GasolineTankCount = request.GasolineTankCount;
        entity.DieselTankCount = request.DieselTankCount;
        entity.UpdatedAt = DateTime.UtcNow;
        await _unitOfWork.Stations.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _cache.KeyDeleteAsync(CacheKeyStationsList);
        await _cache.KeyDeleteAsync(CacheKeyStationByIdPrefix + id);
        var dto = _mapper.Map<StationDto>(entity);
        await _cache.StringSetAsync(CacheKeyStationByIdPrefix + id, dto.JsonSerialize(), _cacheExpirationTime);
        return dto;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Stations.GetByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        await _unitOfWork.Stations.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _cache.KeyDeleteAsync(CacheKeyStationsList);
        await _cache.KeyDeleteAsync(CacheKeyStationByIdPrefix + id);
        return true;
    }
}

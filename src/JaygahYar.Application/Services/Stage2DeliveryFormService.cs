using AutoMapper;
using JaygahYar.Application.Constants;
using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;
using StackExchange.Redis;

namespace JaygahYar.Application.Services;

public class Stage2DeliveryFormService : IStage2DeliveryFormService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IDatabase _cache;
    private readonly TimeSpan _cacheExpirationTime = TimeSpan.FromMinutes(5);

    private const string CacheKeyByIdPrefix = "CacheKeyStage2ById-";
    private const string CacheKeyByStationPrefix = "CacheKeyStage2ByStation-";

    public Stage2DeliveryFormService(IUnitOfWork unitOfWork, IMapper mapper, ICacheProvider cacheProvider)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cacheProvider.Database;
    }

    public async Task<Stage2DeliveryFormDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cached = await _cache.GetJsonAsync<Stage2DeliveryFormDto>(CacheKeyByIdPrefix + id);
        if (cached != null) return cached;

        var entity = await _unitOfWork.Stage2DeliveryForms.GetByIdAsync(id, cancellationToken);
        if (entity == null) return null;
        var dto = _mapper.Map<Stage2DeliveryFormDto>(entity);
        await _cache.StringSetAsync(CacheKeyByIdPrefix + id, dto.JsonSerialize(), _cacheExpirationTime);
        return dto;
    }

    public async Task<IReadOnlyList<Stage2DeliveryFormDto>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default)
    {
        var cached = await _cache.GetJsonAsync<List<Stage2DeliveryFormDto>>(CacheKeyByStationPrefix + stationId);
        if (cached != null) return cached;

        var list = await _unitOfWork.Stage2DeliveryForms.GetByStationIdAsync(stationId, cancellationToken);
        var dtos = _mapper.Map<List<Stage2DeliveryFormDto>>(list);
        await _cache.StringSetAsync(CacheKeyByStationPrefix + stationId, dtos.JsonSerialize(), _cacheExpirationTime);
        return dtos;
    }

    public async Task<Stage2DeliveryFormDto> CreateAsync(CreateStage2DeliveryFormRequest request, CancellationToken cancellationToken = default)
    {
        var stationName = request.StationName.Trim();
        var station = await _unitOfWork.Stations.FindByNameOrMobileAsync(stationName, request.Mobile, cancellationToken);
        if (station == null)
        {
            station = new Station
            {
                Name = stationName,
                Address = request.StationAddress,
                Mobile = request.Mobile
            };
            await _unitOfWork.Stations.AddAsync(station, cancellationToken);
        }
        else
        {
            station.Address = request.StationAddress;
            station.Mobile = request.Mobile;
            await _unitOfWork.Stations.UpdateAsync(station, cancellationToken);
        }

        var form = new Stage2DeliveryForm
        {
            FormNumber = request.FormNumber,
            BuyerFullName = request.BuyerFullName,
            StationId = station.Id,
            StationAddress = request.StationAddress,
            Mobile = request.Mobile,
            DeviceInstallationDate = request.DeviceInstallationDate,
            DeviceCommissioningDate = request.DeviceCommissioningDate,
            DispenserManufacturer = request.DispenserManufacturer,
            UploadedFormFilePath = request.UploadedFormFilePath,
            Description = request.Description
        };
        await _unitOfWork.Stage2DeliveryForms.AddAsync(form, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _cache.KeyDeleteAsync(CacheKeyByStationPrefix + station.Id);
        var dto = _mapper.Map<Stage2DeliveryFormDto>(form);
        await _cache.StringSetAsync(CacheKeyByIdPrefix + dto.Id, dto.JsonSerialize(), _cacheExpirationTime);
        return dto;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Stage2DeliveryForms.GetByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        await _unitOfWork.Stage2DeliveryForms.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _cache.KeyDeleteAsync(CacheKeyByIdPrefix + id);
        await _cache.KeyDeleteAsync(CacheKeyByStationPrefix + entity.StationId);
        return true;
    }
}

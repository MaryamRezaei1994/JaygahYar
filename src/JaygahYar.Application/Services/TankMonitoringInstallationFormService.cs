using AutoMapper;
using JaygahYar.Application.Constants;
using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;
using StackExchange.Redis;

namespace JaygahYar.Application.Services;

public class TankMonitoringInstallationFormService : ITankMonitoringInstallationFormService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IDatabase _cache;
    private readonly TimeSpan _cacheExpirationTime = TimeSpan.FromMinutes(5);

    private const string CacheKeyByIdPrefix = "CacheKeyTankMonitoringById-";
    private const string CacheKeyByStationPrefix = "CacheKeyTankMonitoringByStation-";

    public TankMonitoringInstallationFormService(IUnitOfWork unitOfWork, IMapper mapper, ICacheProvider cacheProvider)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cacheProvider.Database;
    }

    public async Task<TankMonitoringInstallationFormDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cached = await _cache.GetJsonAsync<TankMonitoringInstallationFormDto>(CacheKeyByIdPrefix + id);
        if (cached != null) return cached;

        var entity = await _unitOfWork.TankMonitoringInstallationForms.GetByIdAsync(id, cancellationToken);
        if (entity == null) return null;
        var dto = _mapper.Map<TankMonitoringInstallationFormDto>(entity);
        await _cache.StringSetAsync(CacheKeyByIdPrefix + id, dto.JsonSerialize(), _cacheExpirationTime);
        return dto;
    }

    public async Task<IReadOnlyList<TankMonitoringInstallationFormDto>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default)
    {
        var cached = await _cache.GetJsonAsync<List<TankMonitoringInstallationFormDto>>(CacheKeyByStationPrefix + stationId);
        if (cached != null) return cached;

        var list = await _unitOfWork.TankMonitoringInstallationForms.GetByStationIdAsync(stationId, cancellationToken);
        var dtos = _mapper.Map<List<TankMonitoringInstallationFormDto>>(list);
        await _cache.StringSetAsync(CacheKeyByStationPrefix + stationId, dtos.JsonSerialize(), _cacheExpirationTime);
        return dtos;
    }

    public async Task<TankMonitoringInstallationFormDto> CreateAsync(CreateTankMonitoringInstallationFormRequest request, CancellationToken cancellationToken = default)
    {
        var station = await _unitOfWork.Stations.FindByNameOrMobileAsync(request.StationName, request.Mobile, cancellationToken);
        if (station == null)
        {
            station = new Station
            {
                Name = request.StationName.Trim(),
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

        var form = new TankMonitoringInstallationForm
        {
            FormNumber = request.FormNumber,
            BuyerFullName = request.BuyerFullName,
            StationAddress = request.StationAddress,
            Mobile = request.Mobile,
            StationId = station.Id,
            TankCount = request.TankCount,
            DeviceModel = request.DeviceModel,
            DisplaySerialNumber = request.DisplaySerialNumber,
            DeviceInstallationDate = request.DeviceInstallationDate,
            DeviceCommissioningDate = request.DeviceCommissioningDate,
            UploadedFormFilePath = request.UploadedFormFilePath
        };
        await _unitOfWork.TankMonitoringInstallationForms.AddAsync(form, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _cache.KeyDeleteAsync(CacheKeyByStationPrefix + station.Id);
        var dto = _mapper.Map<TankMonitoringInstallationFormDto>(form);
        await _cache.StringSetAsync(CacheKeyByIdPrefix + dto.Id, dto.JsonSerialize(), _cacheExpirationTime);
        return dto;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.TankMonitoringInstallationForms.GetByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        await _unitOfWork.TankMonitoringInstallationForms.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _cache.KeyDeleteAsync(CacheKeyByIdPrefix + id);
        await _cache.KeyDeleteAsync(CacheKeyByStationPrefix + entity.StationId);
        return true;
    }
}

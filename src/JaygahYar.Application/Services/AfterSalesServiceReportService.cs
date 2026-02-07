using AutoMapper;
using JaygahYar.Application.Constants;
using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;
using StackExchange.Redis;

namespace JaygahYar.Application.Services;

public class AfterSalesServiceReportService : IAfterSalesServiceReportService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IDatabase _cache;
    private readonly TimeSpan _cacheExpirationTime = TimeSpan.FromMinutes(5);

    private const string CacheKeyByIdPrefix = "CacheKeyAfterSalesById-";
    private const string CacheKeyByStationPrefix = "CacheKeyAfterSalesByStation-";

    public AfterSalesServiceReportService(IUnitOfWork unitOfWork, IMapper mapper, ICacheProvider cacheProvider)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _cache = cacheProvider.Database;
    }

    public async Task<AfterSalesServiceReportDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cached = await _cache.GetJsonAsync<AfterSalesServiceReportDto>(CacheKeyByIdPrefix + id);
        if (cached != null) return cached;

        var entity = await _unitOfWork.AfterSalesServiceReports.GetByIdWithItemsAsync(id, cancellationToken);
        if (entity == null) return null;
        var dto = _mapper.Map<AfterSalesServiceReportDto>(entity);
        await _cache.StringSetAsync(CacheKeyByIdPrefix + id, dto.JsonSerialize(), _cacheExpirationTime);
        return dto;
    }

    public async Task<IReadOnlyList<AfterSalesServiceReportDto>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default)
    {
        var cached = await _cache.GetJsonAsync<List<AfterSalesServiceReportDto>>(CacheKeyByStationPrefix + stationId);
        if (cached != null) return cached;

        var list = await _unitOfWork.AfterSalesServiceReports.GetByStationIdAsync(stationId, cancellationToken);
        var dtos = _mapper.Map<List<AfterSalesServiceReportDto>>(list);
        await _cache.StringSetAsync(CacheKeyByStationPrefix + stationId, dtos.JsonSerialize(), _cacheExpirationTime);
        return dtos;
    }

    public async Task<AfterSalesServiceReportDto> CreateAsync(CreateAfterSalesServiceReportRequest request, CancellationToken cancellationToken = default)
    {
        var report = new AfterSalesServiceReport
        {
            FormNumber = request.FormNumber,
            ReportDate = request.ReportDate,
            PersonnelDispatch = request.PersonnelDispatch,
            WarehouseReceipt = request.WarehouseReceipt,
            Reference = request.Reference,
            CustomerName = request.CustomerName,
            Address = request.Address,
            LandlineAndMobile = request.LandlineAndMobile,
            StationId = request.StationId,
            DeviceCommissioningDate = request.DeviceCommissioningDate,
            DefectsReportedByCustomer = request.DefectsReportedByCustomer,
            ContactDate = request.ContactDate,
            ContactTime = request.ContactTime,
            SerialNumber = request.SerialNumber,
            DeviceType = request.DeviceType,
            ElectronicSystemType = request.ElectronicSystemType,
            PerformanceSideA = request.PerformanceSideA,
            PerformanceSideB = request.PerformanceSideB,
            PerformanceSideC = request.PerformanceSideC,
            PerformanceSideD = request.PerformanceSideD,
            ExpertOpinion = request.ExpertOpinion,
            BarrierPlaced = request.BarrierPlaced,
            FireExtinguisherNearby = request.FireExtinguisherNearby,
            DevicePowerCutOff = request.DevicePowerCutOff,
            ShutOffValveClosed = request.ShutOffValveClosed,
            LeakCheckAfterService = request.LeakCheckAfterService,
            IsWarranty = request.IsWarranty,
            DefectResolutionDate = request.DefectResolutionDate,
            DefectResolutionTime = request.DefectResolutionTime,
            TravelCost = request.TravelCost,
            DistanceKm = request.DistanceKm,
            Downtime = request.Downtime,
            GrandTotal = request.GrandTotal,
            GrandTotalInWords = request.GrandTotalInWords,
            StationManagerName = request.StationManagerName,
            OilCompanyApprovalRequired = request.OilCompanyApprovalRequired,
            RepairTechnicianName = request.RepairTechnicianName,
            ProvincialRepresentativeName = request.ProvincialRepresentativeName
        };
        foreach (var item in request.ServiceItems)
        {
            report.ServiceItems.Add(new ServiceReportItem
            {
                RowNumber = item.RowNumber,
                Description = item.Description,
                Quantity = item.Quantity,
                Price = item.Price,
                TotalAmount = item.Quantity * item.Price,
                DefectivePartSerialNumber = item.DefectivePartSerialNumber,
                NewPartSerialNumber = item.NewPartSerialNumber,
                Notes = item.Notes
            });
        }
        await _unitOfWork.AfterSalesServiceReports.AddAsync(report, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _cache.KeyDeleteAsync(CacheKeyByStationPrefix + request.StationId);
        var dto = _mapper.Map<AfterSalesServiceReportDto>(report);
        await _cache.StringSetAsync(CacheKeyByIdPrefix + dto.Id, dto.JsonSerialize(), _cacheExpirationTime);
        return dto;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.AfterSalesServiceReports.GetByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        await _unitOfWork.AfterSalesServiceReports.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _cache.KeyDeleteAsync(CacheKeyByIdPrefix + id);
        await _cache.KeyDeleteAsync(CacheKeyByStationPrefix + entity.StationId);
        return true;
    }
}

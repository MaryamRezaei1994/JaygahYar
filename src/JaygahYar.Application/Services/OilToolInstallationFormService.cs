using AutoMapper;
using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using JaygahYar.Domain.Common.Enums;
using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;

namespace JaygahYar.Application.Services;

public class OilToolInstallationFormService : IOilToolInstallationFormService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OilToolInstallationFormService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<OilToolInstallationFormDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.OilToolInstallationForms.GetByIdWithDispensersAsync(id, cancellationToken);
        return entity == null ? null : _mapper.Map<OilToolInstallationFormDto>(entity);
    }

    public async Task<IReadOnlyList<OilToolInstallationFormDto>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default)
    {
        var list = await _unitOfWork.OilToolInstallationForms.GetByStationIdAsync(stationId, cancellationToken);
        return _mapper.Map<List<OilToolInstallationFormDto>>(list);
    }

    public async Task<OilToolInstallationFormDto> CreateAsync(CreateOilToolInstallationFormRequest request, CancellationToken cancellationToken = default)
    {
        var form = new OilToolInstallationForm
        {
            FormNumber = request.FormNumber,
            FormCompletionDate = request.FormCompletionDate,
            BuyerName = request.BuyerName,
            StationId = request.StationId,
            StationAddress = request.StationAddress,
            Mobile = request.Mobile,
            DeviceInstallationDate = request.DeviceInstallationDate,
            CommissioningDate = request.CommissioningDate,
            FloatQuantity = request.FloatQuantity,
            StationType = request.StationType.HasValue ? (StationType)request.StationType.Value : null,
            ShutOffValveInstalledCorrectly = request.ShutOffValveInstalledCorrectly,
            CheckValveInstalledForMotorized = request.CheckValveInstalledForMotorized,
            SuitableGlandsForInputCables = request.SuitableGlandsForInputCables,
            InstallerName = request.InstallerName
        };
        foreach (var item in request.DispenserItems)
        {
            form.DispenserItems.Add(new DispenserInstallationItem
            {
                RowNumber = item.RowNumber,
                DispenserType = item.DispenserType,
                NozzleCount = item.NozzleCount,
                SerialNumber = item.SerialNumber,
                FuelTypeA = item.FuelTypeA,
                FuelTypeB = item.FuelTypeB,
                CurrentPerformanceC = item.CurrentPerformanceC,
                CurrentPerformanceD = item.CurrentPerformanceD
            });
        }
        await _unitOfWork.OilToolInstallationForms.AddAsync(form, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<OilToolInstallationFormDto>(form);
    }

    public async Task<OilToolInstallationFormDto?> UpdateAsync(Guid id, UpdateOilToolInstallationFormRequest request, CancellationToken cancellationToken = default)
    {
        var form = await _unitOfWork.OilToolInstallationForms.GetByIdWithDispensersAsync(id, cancellationToken);
        if (form == null) return null;

        form.FormNumber = request.FormNumber;
        form.FormCompletionDate = request.FormCompletionDate;
        form.BuyerName = request.BuyerName;
        form.StationAddress = request.StationAddress;
        form.Mobile = request.Mobile;
        form.DeviceInstallationDate = request.DeviceInstallationDate;
        form.CommissioningDate = request.CommissioningDate;
        form.FloatQuantity = request.FloatQuantity;
        form.StationType = request.StationType.HasValue ? (StationType)request.StationType.Value : null;
        form.ShutOffValveInstalledCorrectly = request.ShutOffValveInstalledCorrectly;
        form.CheckValveInstalledForMotorized = request.CheckValveInstalledForMotorized;
        form.SuitableGlandsForInputCables = request.SuitableGlandsForInputCables;
        form.InstallerName = request.InstallerName;
        form.UpdatedAt = DateTime.UtcNow;

        form.DispenserItems.Clear();
        foreach (var item in request.DispenserItems)
        {
            form.DispenserItems.Add(new DispenserInstallationItem
            {
                RowNumber = item.RowNumber,
                DispenserType = item.DispenserType,
                NozzleCount = item.NozzleCount,
                SerialNumber = item.SerialNumber,
                FuelTypeA = item.FuelTypeA,
                FuelTypeB = item.FuelTypeB,
                CurrentPerformanceC = item.CurrentPerformanceC,
                CurrentPerformanceD = item.CurrentPerformanceD
            });
        }
        await _unitOfWork.OilToolInstallationForms.UpdateAsync(form, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<OilToolInstallationFormDto>(form);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.OilToolInstallationForms.GetByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        await _unitOfWork.OilToolInstallationForms.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}

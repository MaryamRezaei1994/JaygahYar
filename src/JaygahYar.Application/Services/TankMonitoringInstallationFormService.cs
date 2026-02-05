using AutoMapper;
using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;

namespace JaygahYar.Application.Services;

public class TankMonitoringInstallationFormService : ITankMonitoringInstallationFormService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TankMonitoringInstallationFormService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TankMonitoringInstallationFormDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.TankMonitoringInstallationForms.GetByIdWithProbesAsync(id, cancellationToken);
        return entity == null ? null : _mapper.Map<TankMonitoringInstallationFormDto>(entity);
    }

    public async Task<IReadOnlyList<TankMonitoringInstallationFormDto>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default)
    {
        var list = await _unitOfWork.TankMonitoringInstallationForms.GetByStationIdAsync(stationId, cancellationToken);
        return _mapper.Map<List<TankMonitoringInstallationFormDto>>(list);
    }

    public async Task<TankMonitoringInstallationFormDto> CreateAsync(CreateTankMonitoringInstallationFormRequest request, CancellationToken cancellationToken = default)
    {
        var form = new TankMonitoringInstallationForm
        {
            FormNumber = request.FormNumber,
            FormDate = request.FormDate,
            BuyerFullName = request.BuyerFullName,
            StationId = request.StationId,
            StationAddress = request.StationAddress,
            Mobile = request.Mobile,
            GasolineTankCount = request.GasolineTankCount,
            DieselTankCount = request.DieselTankCount,
            DeviceInstallationDate = request.DeviceInstallationDate,
            DeviceCommissioningDate = request.DeviceCommissioningDate,
            DeviceType = request.DeviceType,
            DisplaySerialNumber = request.DisplaySerialNumber,
            PowerSerialNumber = request.PowerSerialNumber,
            DisplayPowerInstalledCorrectly = request.DisplayPowerInstalledCorrectly,
            SuitableCableUsed = request.SuitableCableUsed,
            ProbesInstalledCorrectly = request.ProbesInstalledCorrectly,
            JunctionBoxInstalledCorrectly = request.JunctionBoxInstalledCorrectly,
            CableEntryGasTight = request.CableEntryGasTight,
            FloatsInstalledCorrectly = request.FloatsInstalledCorrectly,
            ConsoleGroundAndProtectionUsed = request.ConsoleGroundAndProtectionUsed,
            SoftwarePurchased = request.SoftwarePurchased,
            SoftwareSetupPerformed = request.SoftwareSetupPerformed,
            TankInfoMatchesDipstick = request.TankInfoMatchesDipstick,
            TrainingProvided = request.TrainingProvided,
            StationManagerName = request.StationManagerName
        };
        foreach (var item in request.ProbeItems)
        {
            form.ProbeItems.Add(new ProbeItem
            {
                RowNumber = item.RowNumber,
                ProbeType = item.ProbeType,
                ProbeSerialNumber = item.ProbeSerialNumber,
                FuelType = item.FuelType,
                TankNumber = item.TankNumber,
                Remarks = item.Remarks
            });
        }
        await _unitOfWork.TankMonitoringInstallationForms.AddAsync(form, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<TankMonitoringInstallationFormDto>(form);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.TankMonitoringInstallationForms.GetByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        await _unitOfWork.TankMonitoringInstallationForms.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}

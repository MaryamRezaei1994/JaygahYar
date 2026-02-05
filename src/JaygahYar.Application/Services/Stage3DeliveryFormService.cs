using AutoMapper;
using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;

namespace JaygahYar.Application.Services;

public class Stage3DeliveryFormService : IStage3DeliveryFormService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Stage3DeliveryFormService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Stage3DeliveryFormDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Stage3DeliveryForms.GetByIdAsync(id, cancellationToken);
        return entity == null ? null : _mapper.Map<Stage3DeliveryFormDto>(entity);
    }

    public async Task<IReadOnlyList<Stage3DeliveryFormDto>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default)
    {
        var list = await _unitOfWork.Stage3DeliveryForms.GetByStationIdAsync(stationId, cancellationToken);
        return _mapper.Map<List<Stage3DeliveryFormDto>>(list);
    }

    public async Task<Stage3DeliveryFormDto> CreateAsync(CreateStage3DeliveryFormRequest request, CancellationToken cancellationToken = default)
    {
        var form = new Stage3DeliveryForm
        {
            FormNumber = request.FormNumber,
            FormDate = request.FormDate,
            Revision = request.Revision,
            CustomerName = request.CustomerName,
            StationName = request.StationName,
            StationId = request.StationId,
            StationOwnerName = request.StationOwnerName,
            CompanyBrand = request.CompanyBrand,
            DeliveryCommissioningDate = request.DeliveryCommissioningDate,
            IsDelivery = request.IsDelivery,
            IsCommissioning = request.IsCommissioning,
            HasStage2Commissioning = request.HasStage2Commissioning,
            HPGaugePressureBeforeStart = request.HPGaugePressureBeforeStart,
            LPGaugePressureBeforeStart = request.LPGaugePressureBeforeStart,
            HPGaugePressureAfterStart = request.HPGaugePressureAfterStart,
            LPGaugePressureAfterStart = request.LPGaugePressureAfterStart,
            InitialTemperature = request.InitialTemperature,
            SecondaryTemperatureMin = request.SecondaryTemperatureMin,
            CompressorMaxCurrentAmpere = request.CompressorMaxCurrentAmpere,
            ThermometerOffTempC = request.ThermometerOffTempC,
            ThermometerOnTempC = request.ThermometerOnTempC,
            CompressorHasOil = request.CompressorHasOil,
            TimeToSecondaryTempMinutes = request.TimeToSecondaryTempMinutes,
            VaporInletOutletValvesChecked = request.VaporInletOutletValvesChecked,
            DipHatchGasTightChecked = request.DipHatchGasTightChecked,
            DrainHoseCapGasTightChecked = request.DrainHoseCapGasTightChecked,
            PVValvesOperationChecked = request.PVValvesOperationChecked,
            StationGroundToDeviceChecked = request.StationGroundToDeviceChecked,
            FlameArresterInstalled = request.FlameArresterInstalled,
            ManualTakeoffBlockerInstalled = request.ManualTakeoffBlockerInstalled,
            PVCalibrationCertificateOnCollector = request.PVCalibrationCertificateOnCollector,
            DeviceModel = request.DeviceModel,
            DeviceSerialNumber = request.DeviceSerialNumber,
            TrainingDate = request.TrainingDate,
            Trainee1Name = request.Trainee1Name,
            Trainee1NationalId = request.Trainee1NationalId,
            Trainee2Name = request.Trainee2Name,
            Trainee2NationalId = request.Trainee2NationalId,
            Trainee3Name = request.Trainee3Name,
            Trainee3NationalId = request.Trainee3NationalId,
            Remarks = request.Remarks
        };
        await _unitOfWork.Stage3DeliveryForms.AddAsync(form, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<Stage3DeliveryFormDto>(form);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Stage3DeliveryForms.GetByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        await _unitOfWork.Stage3DeliveryForms.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}

using AutoMapper;
using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using JaygahYar.Domain.Entities;
using JaygahYar.Domain.Interfaces;

namespace JaygahYar.Application.Services;

public class Stage2DeliveryFormService : IStage2DeliveryFormService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Stage2DeliveryFormService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Stage2DeliveryFormDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Stage2DeliveryForms.GetByIdAsync(id, cancellationToken);
        return entity == null ? null : _mapper.Map<Stage2DeliveryFormDto>(entity);
    }

    public async Task<IReadOnlyList<Stage2DeliveryFormDto>> GetByStationIdAsync(Guid stationId, CancellationToken cancellationToken = default)
    {
        var list = await _unitOfWork.Stage2DeliveryForms.GetByStationIdAsync(stationId, cancellationToken);
        return _mapper.Map<List<Stage2DeliveryFormDto>>(list);
    }

    public async Task<Stage2DeliveryFormDto> CreateAsync(CreateStage2DeliveryFormRequest request, CancellationToken cancellationToken = default)
    {
        var form = new Stage2DeliveryForm
        {
            FormNumber = request.FormNumber,
            FormDate = request.FormDate,
            Revision = request.Revision,
            CustomerName = request.CustomerName,
            StationName = request.StationName,
            StationId = request.StationId,
            StationOwnerName = request.StationOwnerName,
            CompanyBrand = request.CompanyBrand,
            SendDate = request.SendDate,
            Phone = request.Phone,
            Address = request.Address,
            HasReceivedItems = request.HasReceivedItems,
            VacuumPumpCount = request.VacuumPumpCount,
            MotorThreePhase = request.MotorThreePhase,
            SinglePhaseMotorCount = request.SinglePhaseMotorCount,
            DualWallHoseCount = request.DualWallHoseCount,
            SeparatorCount = request.SeparatorCount,
            CutoffCount = request.CutoffCount,
            NozzleCount = request.NozzleCount,
            DeliveryDate = request.DeliveryDate,
            DeliveryAddress = request.DeliveryAddress,
            DispenserModel = request.DispenserModel,
            DispenserManufacturer = request.DispenserManufacturer,
            SingleNozzleDispenserCount = request.SingleNozzleDispenserCount,
            TwoNozzleDispenserCount = request.TwoNozzleDispenserCount,
            FourNozzleDispenserCount = request.FourNozzleDispenserCount,
            EquipmentInstalled = request.EquipmentInstalled,
            Stage2PipingInsideDispensers = request.Stage2PipingInsideDispensers,
            Stage2TestApproved = request.Stage2TestApproved,
            PipeSlopeTowardTank = request.PipeSlopeTowardTank,
            TrainingDate = request.TrainingDate,
            Trainee1Name = request.Trainee1Name,
            Trainee1NationalId = request.Trainee1NationalId,
            Trainee2Name = request.Trainee2Name,
            Trainee2NationalId = request.Trainee2NationalId,
            Trainee3Name = request.Trainee3Name,
            Trainee3NationalId = request.Trainee3NationalId,
            Remarks = request.Remarks
        };
        await _unitOfWork.Stage2DeliveryForms.AddAsync(form, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _mapper.Map<Stage2DeliveryFormDto>(form);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.Stage2DeliveryForms.GetByIdAsync(id, cancellationToken);
        if (entity == null) return false;
        await _unitOfWork.Stage2DeliveryForms.DeleteAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}

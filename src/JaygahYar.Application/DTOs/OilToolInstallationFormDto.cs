namespace JaygahYar.Application.DTOs;

public record OilToolInstallationFormDto(
    Guid Id,
    string FormNumber,
    DateTime FormCompletionDate,
    string BuyerName,
    Guid StationId,
    string? StationAddress,
    string? Mobile,
    DateTime? DeviceInstallationDate,
    DateTime? CommissioningDate,
    int? FloatQuantity,
    string? StationType,
    bool ShutOffValveInstalledCorrectly,
    bool CheckValveInstalledForMotorized,
    bool SuitableGlandsForInputCables,
    string? InstallerName,
    List<DispenserInstallationItemDto> DispenserItems,
    DateTime CreatedAt
);

public record CreateOilToolInstallationFormRequest(
    string FormNumber,
    DateTime FormCompletionDate,
    string BuyerName,
    Guid StationId,
    string? StationAddress,
    string? Mobile,
    DateTime? DeviceInstallationDate,
    DateTime? CommissioningDate,
    int? FloatQuantity,
    int? StationType,
    bool ShutOffValveInstalledCorrectly,
    bool CheckValveInstalledForMotorized,
    bool SuitableGlandsForInputCables,
    string? InstallerName,
    List<CreateDispenserItemRequest> DispenserItems
);

public record UpdateOilToolInstallationFormRequest(
    string FormNumber,
    DateTime FormCompletionDate,
    string BuyerName,
    string? StationAddress,
    string? Mobile,
    DateTime? DeviceInstallationDate,
    DateTime? CommissioningDate,
    int? FloatQuantity,
    int? StationType,
    bool ShutOffValveInstalledCorrectly,
    bool CheckValveInstalledForMotorized,
    bool SuitableGlandsForInputCables,
    string? InstallerName,
    List<CreateDispenserItemRequest> DispenserItems
);

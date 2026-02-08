namespace JaygahYar.Application.DTOs;

public record TankMonitoringInstallationFormDto(
    Guid Id,
    string FormNumber,
    string BuyerFullName,
    Guid StationId,
    string StationAddress,
    string Mobile,
    int TankCount,
    string DeviceModel,
    string DisplaySerialNumber,
    DateTime DeviceInstallationDate,
    DateTime DeviceCommissioningDate,
    string UploadedFormFilePath,
    DateTime CreatedAt
);

public record CreateTankMonitoringInstallationFormRequest(
    string FormNumber,
    string BuyerFullName,
    string StationName,
    string StationAddress,
    string Mobile,
    int TankCount,
    string DeviceModel,
    string DisplaySerialNumber,
    DateTime DeviceInstallationDate,
    DateTime DeviceCommissioningDate,
    string UploadedFormFilePath
);

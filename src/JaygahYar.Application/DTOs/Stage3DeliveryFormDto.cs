namespace JaygahYar.Application.DTOs;

public record Stage3DeliveryFormDto(
    Guid Id,
    string FormNumber,
    Guid StationId,
    string BuyerFullName,
    string StationAddress,
    string Mobile,
    DateTime DeviceInstallationDate,
    DateTime DeviceCommissioningDate,
    string DeviceModel,
    string DeviceSerialNumber,
    string UploadedFormFilePath,
    string? Description,
    DateTime CreatedAt
);

public record CreateStage3DeliveryFormRequest(
    string FormNumber,
    string StationName,
    string BuyerFullName,
    string StationAddress,
    string Mobile,
    DateTime DeviceInstallationDate,
    DateTime DeviceCommissioningDate,
    string DeviceModel,
    string DeviceSerialNumber,
    string UploadedFormFilePath,
    string? Description
);

namespace JaygahYar.Application.DTOs;

public record Stage2DeliveryFormDto(
    Guid Id,
    string FormNumber,
    Guid StationId,
    string BuyerFullName,
    string StationAddress,
    string Mobile,
    DateTime DeviceInstallationDate,
    DateTime DeviceCommissioningDate,
    string DispenserManufacturer,
    string UploadedFormFilePath,
    string? Description,
    DateTime CreatedAt
);

public record CreateStage2DeliveryFormRequest(
    string FormNumber,
    string StationName,
    string BuyerFullName,
    string StationAddress,
    string Mobile,
    DateTime DeviceInstallationDate,
    DateTime DeviceCommissioningDate,
    string DispenserManufacturer,
    string UploadedFormFilePath,
    string? Description
);

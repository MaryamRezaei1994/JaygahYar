namespace JaygahYar.Application.DTOs;

public record OilToolInstallationFormDto(
    Guid Id,
    string FormNumber,
    string BuyerFullName,
    Guid StationId,
    string StationAddress,
    string Mobile,
    DateTime DeviceInstallationDate,
    DateTime CommissioningDate,
    string InstallationFormFilePath,
    string PeymanegarTestFormFilePath,
    DateTime CreatedAt
);

public record CreateOilToolInstallationFormRequest(
    string FormNumber,
    string BuyerFullName,
    string StationName,
    string StationAddress,
    string Mobile,
    DateTime DeviceInstallationDate,
    DateTime CommissioningDate,
    string InstallationFormFilePath,
    string PeymanegarTestFormFilePath
);

public record UpdateOilToolInstallationFormRequest(
    string FormNumber,
    string BuyerFullName,
    string StationAddress,
    string Mobile,
    DateTime DeviceInstallationDate,
    DateTime CommissioningDate,
    string InstallationFormFilePath,
    string PeymanegarTestFormFilePath
);

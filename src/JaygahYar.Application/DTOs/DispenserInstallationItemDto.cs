namespace JaygahYar.Application.DTOs;

public record DispenserInstallationItemDto(
    Guid Id,
    int RowNumber,
    string DispenserType,
    int NozzleCount,
    string SerialNumber,
    string? FuelTypeA,
    string? FuelTypeB,
    decimal? CurrentPerformanceC,
    decimal? CurrentPerformanceD
);

public record CreateDispenserItemRequest(
    int RowNumber,
    string DispenserType,
    int NozzleCount,
    string SerialNumber,
    string? FuelTypeA,
    string? FuelTypeB,
    decimal? CurrentPerformanceC,
    decimal? CurrentPerformanceD
);

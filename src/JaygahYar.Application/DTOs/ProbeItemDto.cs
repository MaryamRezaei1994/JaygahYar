namespace JaygahYar.Application.DTOs;

public record ProbeItemDto(
    Guid Id,
    int RowNumber,
    string ProbeType,
    string ProbeSerialNumber,
    string FuelType,
    string? TankNumber,
    string? Remarks
);

public record CreateProbeItemRequest(
    int RowNumber,
    string ProbeType,
    string ProbeSerialNumber,
    string FuelType,
    string? TankNumber,
    string? Remarks
);

namespace JaygahYar.Application.DTOs;

public record StationDto(
    Guid Id,
    string Name,
    string Address,
    string? Phone,
    string? Mobile,
    string? OwnerName,
    int GasolineTankCount,
    int DieselTankCount,
    DateTime CreatedAt
);

public record CreateStationRequest(
    string Name,
    string Address,
    string? Phone,
    string? Mobile,
    string? OwnerName,
    int GasolineTankCount = 0,
    int DieselTankCount = 0
);

public record UpdateStationRequest(
    string Name,
    string Address,
    string? Phone,
    string? Mobile,
    string? OwnerName,
    int GasolineTankCount,
    int DieselTankCount
);

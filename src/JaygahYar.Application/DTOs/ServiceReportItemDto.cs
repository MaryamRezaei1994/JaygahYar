namespace JaygahYar.Application.DTOs;

public record ServiceReportItemDto(
    Guid Id,
    int RowNumber,
    string Description,
    int Quantity,
    decimal Price,
    decimal TotalAmount,
    string? DefectivePartSerialNumber,
    string? NewPartSerialNumber,
    string? Notes
);

public record CreateServiceReportItemRequest(
    int RowNumber,
    string Description,
    int Quantity,
    decimal Price,
    string? DefectivePartSerialNumber,
    string? NewPartSerialNumber,
    string? Notes
);

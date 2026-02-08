using Microsoft.AspNetCore.Http;

namespace JaygahYar.WebAPI.Requests;

public class Stage2DeliveryFormCreateFormRequest
{
    public string FormNumber { get; set; } = string.Empty;
    public string BuyerFullName { get; set; } = string.Empty;
    public string StationName { get; set; } = string.Empty;
    public string StationAddress { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;

    public DateTime DeviceInstallationDate { get; set; }
    public DateTime DeviceCommissioningDate { get; set; }

    public string DispenserManufacturer { get; set; } = string.Empty;
    public string? Description { get; set; }

    public IFormFile UploadedFormFile { get; set; } = null!;
}


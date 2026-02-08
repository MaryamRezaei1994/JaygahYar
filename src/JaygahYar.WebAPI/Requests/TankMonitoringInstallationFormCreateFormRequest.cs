using Microsoft.AspNetCore.Http;

namespace JaygahYar.WebAPI.Requests;

public class TankMonitoringInstallationFormCreateFormRequest
{
    public string FormNumber { get; set; } = string.Empty;
    public string BuyerFullName { get; set; } = string.Empty;
    public string StationName { get; set; } = string.Empty;
    public string StationAddress { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;

    public int TankCount { get; set; }
    public string DeviceModel { get; set; } = string.Empty;
    public string DisplaySerialNumber { get; set; } = string.Empty;

    public DateTime DeviceInstallationDate { get; set; }
    public DateTime DeviceCommissioningDate { get; set; }

    public IFormFile UploadedFormFile { get; set; } = null!;
}


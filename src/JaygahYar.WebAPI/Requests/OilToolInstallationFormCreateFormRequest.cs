using Microsoft.AspNetCore.Http;

namespace JaygahYar.WebAPI.Requests;

public class OilToolInstallationFormCreateFormRequest
{
    public string FormNumber { get; set; } = string.Empty;
    public string BuyerFullName { get; set; } = string.Empty;
    public string StationName { get; set; } = string.Empty;
    public string StationAddress { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public DateTime DeviceInstallationDate { get; set; }
    public DateTime CommissioningDate { get; set; }

    public IFormFile InstallationFormFile { get; set; } = null!;
    public IFormFile PeymanegarTestFormFile { get; set; } = null!;
}


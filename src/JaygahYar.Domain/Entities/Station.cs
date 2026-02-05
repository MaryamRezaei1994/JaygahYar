using JaygahYar.Domain.Common;

namespace JaygahYar.Domain.Entities;

/// <summary>
/// جایگاه (JAYGAH) - ایستگاه سوخت
/// </summary>
public class Station : BaseEntity
{
    public string Name { get; set; } = string.Empty;           // نام جایگاه
    public string Address { get; set; } = string.Empty;          // آدرس و تلفن جایگاه
    public string? Phone { get; set; }                          // تلفن ثابت
    public string? Mobile { get; set; }                         // تلفن همراه
    public string? OwnerName { get; set; }                      // نام مالک/صاحب جایگاه

    public int GasolineTankCount { get; set; }                  // تعداد مخزن بنزین
    public int DieselTankCount { get; set; }                    // تعداد مخزن نفت گاز

    public ICollection<OilToolInstallationForm> OilToolInstallations { get; set; } = new List<OilToolInstallationForm>();
    public ICollection<TankMonitoringInstallationForm> TankMonitoringInstallations { get; set; } = new List<TankMonitoringInstallationForm>();
    public ICollection<AfterSalesServiceReport> AfterSalesReports { get; set; } = new List<AfterSalesServiceReport>();
    public ICollection<Stage2DeliveryForm> Stage2DeliveryForms { get; set; } = new List<Stage2DeliveryForm>();
    public ICollection<Stage3DeliveryForm> Stage3DeliveryForms { get; set; } = new List<Stage3DeliveryForm>();
}

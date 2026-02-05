using JaygahYar.Domain.Common;

namespace JaygahYar.Domain.Entities;

/// <summary>
/// آیتم پراب در فرم نصب سیستم مانیتورینگ مخازن
/// </summary>
public class ProbeItem : BaseEntity
{
    public Guid TankMonitoringInstallationFormId { get; set; }
    public TankMonitoringInstallationForm TankMonitoringInstallationForm { get; set; } = null!;

    public int RowNumber { get; set; }                          // ردیف
    public string ProbeType { get; set; } = string.Empty;       // نوع پراب
    public string ProbeSerialNumber { get; set; } = string.Empty; // سریال پراب
    public string FuelType { get; set; } = string.Empty;        // نوع سوخت
    public string? TankNumber { get; set; }                     // شماره مخزن
    public string? Remarks { get; set; }                        // ملاحظات
}

using JaygahYar.Domain.Common;

namespace JaygahYar.Domain.Entities;

/// <summary>
/// فرم نصب و راه‌اندازی سیستم تانک مانیتورینگ (نسخه جدید: هدر + آپلود فرم)
/// </summary>
public class TankMonitoringInstallationForm : BaseEntity
{
    public string FormNumber { get; set; } = string.Empty;       // شماره فرم
    public string BuyerFullName { get; set; } = string.Empty;    // نام و نام خانوادگی خریدار

    public Guid StationId { get; set; }
    public Station Station { get; set; } = null!;

    public string StationAddress { get; set; } = string.Empty;   // آدرس و تلفن جایگاه
    public string Mobile { get; set; } = string.Empty;           // تلفن همراه

    public int TankCount { get; set; }                           // تعداد مخازن جایگاه
    public string DeviceModel { get; set; } = string.Empty;      // نوع/مدل دستگاه (مثلاً TM 4000)
    public string DisplaySerialNumber { get; set; } = string.Empty; // شماره سریال نمایشگر

    public DateTime DeviceInstallationDate { get; set; }         // تاریخ نصب دستگاه
    public DateTime DeviceCommissioningDate { get; set; }        // تاریخ راه‌اندازی دستگاه

    public string UploadedFormFilePath { get; set; } = string.Empty; // فایل فرم نصب تانک مانیتورینگ
}

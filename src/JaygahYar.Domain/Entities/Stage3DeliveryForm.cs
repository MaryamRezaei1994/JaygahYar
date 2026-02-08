using JaygahYar.Domain.Common;

namespace JaygahYar.Domain.Entities;

/// <summary>
/// فرم تحویل / راه‌اندازی کهاب استیج 3 (نسخه جدید: هدر + آپلود فرم)
/// </summary>
public class Stage3DeliveryForm : BaseEntity
{
    public string FormNumber { get; set; } = string.Empty;       // شماره فرم
    public string BuyerFullName { get; set; } = string.Empty;    // نام و نام خانوادگی خریدار

    public Guid StationId { get; set; }
    public Station Station { get; set; } = null!;

    public string StationAddress { get; set; } = string.Empty;   // آدرس و تلفن جایگاه
    public string Mobile { get; set; } = string.Empty;           // تلفن همراه

    public DateTime DeviceInstallationDate { get; set; }         // تاریخ نصب
    public DateTime DeviceCommissioningDate { get; set; }        // تاریخ راه اندازی

    public string DeviceModel { get; set; } = string.Empty;      // مدل دستگاه (مثلاً یک کابینت)
    public string DeviceSerialNumber { get; set; } = string.Empty; // شماره سریال

    public string UploadedFormFilePath { get; set; } = string.Empty; // فایل فرم استیج 3

    public string? Description { get; set; }                     // توضیحات (اختیاری)
}

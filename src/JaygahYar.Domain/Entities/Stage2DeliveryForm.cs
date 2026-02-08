using JaygahYar.Domain.Common;

namespace JaygahYar.Domain.Entities;

/// <summary>
/// فرم تحویل / راه‌اندازی کهاب استیج 2 (نسخه جدید: هدر + آپلود فرم)
/// </summary>
public class Stage2DeliveryForm : BaseEntity
{
    public string FormNumber { get; set; } = string.Empty;       // شماره فرم
    public string BuyerFullName { get; set; } = string.Empty;    // نام و نام خانوادگی خریدار

    public Guid StationId { get; set; }
    public Station Station { get; set; } = null!;

    public string StationAddress { get; set; } = string.Empty;   // آدرس و تلفن جایگاه
    public string Mobile { get; set; } = string.Empty;           // تلفن همراه

    public DateTime DeviceInstallationDate { get; set; }         // تاریخ نصب
    public DateTime DeviceCommissioningDate { get; set; }        // تاریخ راه اندازی

    public string DispenserManufacturer { get; set; } = string.Empty; // شرکت سازنده دیسپنسر (مثلاً نفت ابزار)

    public string UploadedFormFilePath { get; set; } = string.Empty; // فایل فرم استیج 2

    public string? Description { get; set; }                     // توضیحات (اختیاری)
}

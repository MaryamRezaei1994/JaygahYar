using JaygahYar.Domain.Common;

namespace JaygahYar.Domain.Entities;

/// <summary>
/// فرم نصب محصولات نفت ابزار - (نسخه جدید: ثبت اطلاعات هدر + آپلود فرم‌ها)
/// </summary>
public class OilToolInstallationForm : BaseEntity
{
    public string FormNumber { get; set; } = string.Empty;       // شماره فرم
    public string BuyerFullName { get; set; } = string.Empty;    // نام و نام خانوادگی خریدار

    public Guid StationId { get; set; }
    public Station Station { get; set; } = null!;

    public string StationAddress { get; set; } = string.Empty;   // آدرس و تلفن جایگاه (طبق UI جدید)
    public string Mobile { get; set; } = string.Empty;           // تلفن همراه (طبق UI جدید)

    public DateTime DeviceInstallationDate { get; set; }         // تاریخ نصب دستگاه
    public DateTime CommissioningDate { get; set; }              // تاریخ راه‌اندازی (طبق فرم آزمایش پیمانه‌گر)

    // آپلود فایل‌ها (مسیر/کلید ذخیره سازی)
    public string InstallationFormFilePath { get; set; } = string.Empty;   // فرم نصب محصولات نفت ابزار
    public string PeymanegarTestFormFilePath { get; set; } = string.Empty; // فرم آزمایش پیمانه‌گر
}

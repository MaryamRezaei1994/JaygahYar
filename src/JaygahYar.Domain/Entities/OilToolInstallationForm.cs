using JaygahYar.Domain.Common;
using JaygahYar.Domain.Common.Enums;

namespace JaygahYar.Domain.Entities;

/// <summary>
/// فرم نصب محصولات نفت ابزار - جایگاه یار
/// </summary>
public class OilToolInstallationForm : BaseEntity
{
    public string FormNumber { get; set; } = string.Empty;     // شماره فرم
    public DateTime FormCompletionDate { get; set; }            // تاریخ تکمیل فرم

    public string BuyerName { get; set; } = string.Empty;        // نام خریدار
    public Guid StationId { get; set; }
    public Station Station { get; set; } = null!;
    public string? StationAddress { get; set; }                 // آدرس و تلفن جایگاه
    public string? Mobile { get; set; }                          // تلفن همراه
    public DateTime? DeviceInstallationDate { get; set; }       // تاریخ نصب دستگاه
    public DateTime? CommissioningDate { get; set; }              // تاریخ راه‌اندازی طبق فرم آزمایش پیمانه‌گر

    public int? FloatQuantity { get; set; }                      // تعداد شناور نصب شده (در صورت خرید از نفت ابزار)
    public StationType? StationType { get; set; }               // جایگاه قدیمی / جدیدالاحداث

    public bool ShutOffValveInstalledCorrectly { get; set; }    // Shut off valve صحیح نصب شده؟
    public bool CheckValveInstalledForMotorized { get; set; }    // چک والو برای دستگاه‌های موتوردار نصب شده؟
    public bool SuitableGlandsForInputCables { get; set; }      // گلند مناسب برای کابل‌های ورودی؟

    public string? InstallerName { get; set; }                   // نام نصب‌کننده
    public string? InstallerSignature { get; set; }             // امضاء نصب‌کننده
    public string? RepresentativeStamp { get; set; }            // مهر نمایندگی
    public string? RepresentativeSignature { get; set; }         // امضاء نمایندگی
    public string? StationOwnerStamp { get; set; }              // مهر صاحب جایگاه
    public string? StationOwnerSignature { get; set; }          // امضاء صاحب جایگاه

    public ICollection<DispenserInstallationItem> DispenserItems { get; set; } = new List<DispenserInstallationItem>();
}

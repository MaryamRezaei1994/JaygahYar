using JaygahYar.Domain.Common;

namespace JaygahYar.Domain.Entities;

/// <summary>
/// فرم نصب و راه‌اندازی سیستم مانیتورینگ مخازن - جایگاه یار
/// </summary>
public class TankMonitoringInstallationForm : BaseEntity
{
    public string FormNumber { get; set; } = string.Empty;     // شماره فرم
    public DateTime? FormDate { get; set; }                     // تاریخ فرم

    public string BuyerFullName { get; set; } = string.Empty;   // نام و نام خانوادگی خریدار
    public Guid StationId { get; set; }
    public Station Station { get; set; } = null!;
    public string? StationAddress { get; set; }                 // آدرس و تلفن جایگاه
    public string? Mobile { get; set; }                          // تلفن همراه
    public int GasolineTankCount { get; set; }                  // تعداد مخزن بنزین
    public int DieselTankCount { get; set; }                    // تعداد مخزن نفت گاز

    public DateTime? DeviceInstallationDate { get; set; }       // تاریخ نصب دستگاه
    public DateTime? DeviceCommissioningDate { get; set; }       // تاریخ راه‌اندازی دستگاه
    public string? DeviceType { get; set; }                     // نوع دستگاه
    public string? DisplaySerialNumber { get; set; }            // شماره سریال نمایشگر
    public string? PowerSerialNumber { get; set; }              // شماره سریال پاور

    // چک‌لیست نصب
    public bool DisplayPowerInstalledCorrectly { get; set; }    // نمایشگر/پاور در محل مناسب نصب شده؟
    public bool SuitableCableUsed { get; set; }                 // کابل ۵ رشته شیلدار استفاده شده؟
    public bool ProbesInstalledCorrectly { get; set; }          // پراب‌ها صحیح نصب شده؟
    public bool JunctionBoxInstalledCorrectly { get; set; }     // جانکشن باکس با براکت نصب شده؟
    public bool CableEntryGasTight { get; set; }                 // ورود کابل به جانکشن گازبند شده؟
    public bool FloatsInstalledCorrectly { get; set; }           // فلوترها با بست مناسب نصب شده؟
    public bool ConsoleGroundAndProtectionUsed { get; set; }     // ارت و محافظ الکتریکی؟
    public bool SoftwarePurchased { get; set; }                 // نرم‌افزار نمایش مخازن خریداری شده؟
    public bool SoftwareSetupPerformed { get; set; }            // نصب و راه‌اندازی نرم‌افزار انجام شد؟
    public bool TankInfoMatchesDipstick { get; set; }            // اطلاعات مخزن با میله دیپ همخوانی دارد؟
    public bool TrainingProvided { get; set; }                   // آموزش به مسئول جایگاه داده شده؟

    public string? StationManagerName { get; set; }             // نام جایگاه‌دار
    public string? StationManagerSignature { get; set; }
    public string? AuthorizedRepresentativeName { get; set; }    // نام نماینده مجاز
    public string? AuthorizedRepresentativeSignature { get; set; }
    public string? JaygahYarManagementName { get; set; }         // نام مدیریت جایگاه یار
    public string? JaygahYarManagementSignature { get; set; }

    public ICollection<ProbeItem> ProbeItems { get; set; } = new List<ProbeItem>();
}

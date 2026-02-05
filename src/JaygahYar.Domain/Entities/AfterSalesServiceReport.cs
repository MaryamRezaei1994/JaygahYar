using JaygahYar.Domain.Common;

namespace JaygahYar.Domain.Entities;

/// <summary>
/// گزارش خدمات پس از فروش - مرکز خدمات پس از فروش نفت ابزار
/// </summary>
public class AfterSalesServiceReport : BaseEntity
{
    public string FormNumber { get; set; } = string.Empty;     // شماره فرم
    public DateTime? ReportDate { get; set; }                   // تاریخ
    public string? PersonnelDispatch { get; set; }              // اعزام نیرو
    public string? WarehouseReceipt { get; set; }               // رسید انبار
    public string? Reference { get; set; }                       // اشاره

    public string CustomerName { get; set; } = string.Empty;    // نام مشتری
    public string? Address { get; set; }                         // آدرس
    public string? LandlineAndMobile { get; set; }               // تلفن ثابت و همراه
    public Guid StationId { get; set; }
    public Station Station { get; set; } = null!;
    public DateTime? DeviceCommissioningDate { get; set; }      // تاریخ راه‌اندازی دستگاه
    public string? DefectsReportedByCustomer { get; set; }      // عیوب بیان شده از طرف مشتری یا نماینده
    public DateTime? ContactDate { get; set; }                   // تاریخ تماس
    public TimeSpan? ContactTime { get; set; }                  // زمان تماس
    public string? SerialNumber { get; set; }                    // شماره سریال
    public string? DeviceType { get; set; }                     // نوع دستگاه
    public string? ElectronicSystemType { get; set; }            // نوع سیستم الکترونیک
    public decimal? PerformanceSideA { get; set; }               // کارکرد ساید A
    public decimal? PerformanceSideB { get; set; }               // کارکرد ساید B
    public decimal? PerformanceSideC { get; set; }               // کارکرد ساید C
    public decimal? PerformanceSideD { get; set; }               // کارکرد ساید D
    public string? ExpertOpinion { get; set; }                    // نظریه کارشناس

    // اقدامات ایمنی
    public bool BarrierPlaced { get; set; }                     // راهبند در محل قرار گرفت
    public bool FireExtinguisherNearby { get; set; }             // کپسول آتش‌نشانی نزدیک
    public bool DevicePowerCutOff { get; set; }                  // برق دستگاه قطع شد
    public bool ShutOffValveClosed { get; set; }                 // شات آف والو قطع شد
    public bool LeakCheckAfterService { get; set; }              // کنترل نشتی بعد از اتمام سرویس
    public bool IsWarranty { get; set; }                         // عملیات جزء گارانتی؟
    public DateTime? DefectResolutionDate { get; set; }          // تاریخ رفع عیب
    public TimeSpan? DefectResolutionTime { get; set; }          // زمان رفع عیب

    public decimal? TravelCost { get; set; }                     // هزینه ایاب و ذهاب طبق تعرفه
    public decimal? DistanceKm { get; set; }                    // فاصله جایگاه تا نمایندگی (کیلومتر)
    public string? Downtime { get; set; }                        // توقف
    public decimal GrandTotal { get; set; }                      // جمع کل
    public string? GrandTotalInWords { get; set; }              // به حروف

    public string? StationManagerName { get; set; }              // نام مسئول جایگاه
    public string? StationManagerSignature { get; set; }         // مهر و امضاء جایگاه
    public bool OilCompanyApprovalRequired { get; set; }        // نیاز به تایید شرکت نفت برای ادامه کار تلمبه
    public string? RepairTechnicianName { get; set; }           // نام تعمیرکار
    public string? RepairTechnicianSignature { get; set; }
    public string? ProvincialRepresentativeName { get; set; }   // نام نماینده استان
    public string? ProvincialRepresentativeSignature { get; set; }

    public ICollection<ServiceReportItem> ServiceItems { get; set; } = new List<ServiceReportItem>();
}

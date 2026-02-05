using JaygahYar.Domain.Common;

namespace JaygahYar.Domain.Entities;

/// <summary>
/// فرم تحویل / راه‌اندازی STAGE II - شرکت کهاب گستران آیریک (تجهیزات جمع‌آوری بخار بنزین)
/// </summary>
public class Stage2DeliveryForm : BaseEntity
{
    public string FormNumber { get; set; } = string.Empty;     // شماره
    public DateTime? FormDate { get; set; }                     // تاریخ
    public string? Revision { get; set; }                       // بازنگری

    public string? CustomerName { get; set; }                   // نام مشتری
    public string? StationName { get; set; }                     // نام جایگاه
    public string? StationOwnerName { get; set; }                // مالک جایگاه
    public string? CompanyBrand { get; set; }                    // شرکت/برند
    public string? SendDate { get; set; }                       // تاریخ ارسال
    public string? Phone { get; set; }                           // تلفن
    public string? Address { get; set; }                         // آدرس

    public bool HasReceivedItems { get; set; }                  // اقلام دریافتی دارد؟
    public int? VacuumPumpCount { get; set; }                   // پمپ وکیوم - عدد
    public bool? MotorThreePhase { get; set; }                   // موتور سه فاز
    public int? SinglePhaseMotorCount { get; set; }             // موتور تک فاز - عدد
    public int? DualWallHoseCount { get; set; }                  // شیلنگ دو جداره - عدد
    public int? SeparatorCount { get; set; }                    // جدا کننده - عدد
    public int? CutoffCount { get; set; }                       // قطع کن - عدد
    public int? NozzleCount { get; set; }                       // نازل - عدد

    public DateTime? DeliveryDate { get; set; }                 // تاریخ تحویل
    public string? DeliveryAddress { get; set; }                 // تحویل به آدرس

    public string? DispenserModel { get; set; }                  // مدل دیسپنسر
    public string? DispenserManufacturer { get; set; }          // نام سازنده دیسپنسر
    public int? SingleNozzleDispenserCount { get; set; }        // تعداد دیسپنسر تک نازل
    public int? TwoNozzleDispenserCount { get; set; }           // تعداد دیسپنسر 2 نازل
    public int? FourNozzleDispenserCount { get; set; }          // تعداد دیسپنسر 4 نازل
    public bool EquipmentInstalled { get; set; }                // نصب تجهیزات (پمپ، شیلنگ، نازل) انجام شده؟
    public bool Stage2PipingInsideDispensers { get; set; }      // لوله‌کشی STAGE II داخل دیسپنسرها انجام شده؟
    public bool Stage2TestApproved { get; set; }                // تست عملکرد نازل‌های STAGE II تایید شده؟
    public bool PipeSlopeTowardTank { get; set; }               // شیب مسیر لوله به سمت مخزن رعایت شده؟

    public DateTime? TrainingDate { get; set; }                 // تاریخ آموزش بهره‌برداری
    public string? Trainee1Name { get; set; }                    // نام بردار 1
    public string? Trainee1NationalId { get; set; }
    public string? Trainee2Name { get; set; }
    public string? Trainee2NationalId { get; set; }
    public string? Trainee3Name { get; set; }
    public string? Trainee3NationalId { get; set; }

    public string? Remarks { get; set; }                         // توضیحات

    public string? RepresentativeSignature { get; set; }         // امضا و تاریخ نماینده شرکت
    public string? BrandCompanyStamp { get; set; }               // مهر شرکت برند
    public string? StationStamp { get; set; }                    // مهر جایگاه
    public string? StationManagerSignature { get; set; }         // امضا مسئول جایگاه

    public Guid StationId { get; set; }
    public Station Station { get; set; } = null!;
}

using JaygahYar.Domain.Common;

namespace JaygahYar.Domain.Entities;

/// <summary>
/// فرم تحویل / راه‌اندازی STAGE III - دستگاه بازیافت بخار بنزین (VRU - واحد چیلر و واحد بازیافت)
/// </summary>
public class Stage3DeliveryForm : BaseEntity
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

    public DateTime? DeliveryCommissioningDate { get; set; }    // تاریخ تحویل/راه‌اندازی در جایگاه
    public bool IsDelivery { get; set; }                         // تحویل
    public bool IsCommissioning { get; set; }                    // راه‌اندازی
    public DateTime? TrainingDate { get; set; }                 // تاریخ آموزش بهره‌برداری VRU
    public string? Trainee1Name { get; set; }
    public string? Trainee1NationalId { get; set; }
    public string? Trainee2Name { get; set; }
    public string? Trainee2NationalId { get; set; }
    public string? Trainee3Name { get; set; }
    public string? Trainee3NationalId { get; set; }

    public bool HasStage2Commissioning { get; set; }           // راه‌اندازی دستگاه استیج 2 دارد؟

    // بررسی عملکرد دستگاه
    public decimal? HPGaugePressureBeforeStart { get; set; }    // فشار گیج HP قبل از روشن شدن
    public decimal? LPGaugePressureBeforeStart { get; set; }    // فشار گیج LP قبل از روشن شدن
    public decimal? HPGaugePressureAfterStart { get; set; }     // فشار گیج HP بعد از روشن شدن
    public decimal? LPGaugePressureAfterStart { get; set; }     // فشار گیج LP بعد از روشن شدن
    public decimal? InitialTemperature { get; set; }           // دمای اولیه
    public decimal? SecondaryTemperatureMin { get; set; }        // دمای ثانویه (حداقل دما)
    public decimal? CompressorMaxCurrentAmpere { get; set; }    // حداکثر جریان کمپرسور (آمپر)
    public decimal? ThermometerOffTempC { get; set; }           // دمای OFF ترمومتر (35- درجه C)
    public decimal? ThermometerOnTempC { get; set; }            // دمای ON ترمومتر (15 درجه C)
    public bool CompressorHasOil { get; set; }                  // کمپرسور روغن دارد؟
    public int? TimeToSecondaryTempMinutes { get; set; }         // مدت زمان رسیدن به دمای ثانویه (دقیقه)

    public bool VaporInletOutletValvesChecked { get; set; }    // شیرهای ورود و خروج بخار بررسی شد
    public bool DipHatchGasTightChecked { get; set; }          // گازبند بودن دریچه دیپ‌ها کنترل شد
    public bool DrainHoseCapGasTightChecked { get; set; }       // گازبند بودن درپوش شیلنگ‌های تخلیه کنترل شد
    public bool PVValvesOperationChecked { get; set; }          // صحت عملکرد شیرهای P&V بررسی شد
    public bool StationGroundToDeviceChecked { get; set; }       // اتصال سیم ارت جایگاه به دستگاه کنترل شد
    public bool FlameArresterInstalled { get; set; }             // نصب شعله‌پوش در مسیر ورود و خروج بررسی شد
    public bool ManualTakeoffBlockerInstalled { get; set; }     // نصب مسدودکننده بر روی مسیر برداشت دستی بررسی شد
    public bool PVCalibrationCertificateOnCollector { get; set; } // گواهی کالیبراسیون P&V روی کلکتور مطابق دستورالعمل کنترل شد

    public string? DeviceModel { get; set; }                    // مدل دستگاه
    public string? DeviceSerialNumber { get; set; }              // شماره سریال دستگاه
    public string? Remarks { get; set; }                         // توضیحات

    public string? RepresentativeSignature { get; set; }
    public string? BrandCompanyStamp { get; set; }
    public string? StationStamp { get; set; }
    public string? StationManagerSignature { get; set; }

    public Guid StationId { get; set; }
    public Station Station { get; set; } = null!;
}

using JaygahYar.Domain.Common;

namespace JaygahYar.Domain.Entities;

/// <summary>
/// آیتم نصب دیسپنسر در فرم نصب محصولات نفت ابزار
/// </summary>
public class DispenserInstallationItem : BaseEntity
{
    public Guid OilToolInstallationFormId { get; set; }
    public OilToolInstallationForm OilToolInstallationForm { get; set; } = null!;

    public int RowNumber { get; set; }                          // ردیف
    public string DispenserType { get; set; } = string.Empty;   // نوع دیسپنسر
    public int NozzleCount { get; set; }                        // تعداد نازل
    public string SerialNumber { get; set; } = string.Empty;    // شماره سریال
    public string? FuelTypeA { get; set; }                      // نوع سوخت A
    public string? FuelTypeB { get; set; }                      // نوع سوخت B
    public decimal? CurrentPerformanceC { get; set; }            // کارکرد فعلی C
    public decimal? CurrentPerformanceD { get; set; }            // کارکرد فعلی D
}

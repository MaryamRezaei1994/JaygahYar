using JaygahYar.Domain.Common;

namespace JaygahYar.Domain.Entities;

/// <summary>
/// آیتم خدمات یا قطعات در گزارش پس از فروش
/// </summary>
public class ServiceReportItem : BaseEntity
{
    public Guid AfterSalesServiceReportId { get; set; }
    public AfterSalesServiceReport AfterSalesServiceReport { get; set; } = null!;

    public int RowNumber { get; set; }                          // ردیف
    public string Description { get; set; } = string.Empty;     // شرح خدمات یا قطعات
    public int Quantity { get; set; }                            // تعداد
    public decimal Price { get; set; }                           // قیمت
    public decimal TotalAmount { get; set; }                     // مبلغ کل
    public string? DefectivePartSerialNumber { get; set; }      // شماره سریال قطعه معیوب
    public string? NewPartSerialNumber { get; set; }             // شماره سریال قطعه جدید
    public string? Notes { get; set; }                            // ملاحظات
}

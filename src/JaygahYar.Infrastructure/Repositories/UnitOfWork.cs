using JaygahYar.Domain.Interfaces;
using JaygahYar.Infrastructure.Persistence;

namespace JaygahYar.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IStationRepository? _stations;
    private IOilToolInstallationFormRepository? _oilToolInstallationForms;
    private ITankMonitoringInstallationFormRepository? _tankMonitoringInstallationForms;
    private IAfterSalesServiceReportRepository? _afterSalesServiceReports;
    private IStage2DeliveryFormRepository? _stage2DeliveryForms;
    private IStage3DeliveryFormRepository? _stage3DeliveryForms;

    public UnitOfWork(
        ApplicationDbContext context,
        IStationRepository stations,
        IOilToolInstallationFormRepository oilToolInstallationForms,
        ITankMonitoringInstallationFormRepository tankMonitoringInstallationForms,
        IAfterSalesServiceReportRepository afterSalesServiceReports,
        IStage2DeliveryFormRepository stage2DeliveryForms,
        IStage3DeliveryFormRepository stage3DeliveryForms)
    {
        _context = context;
        _stations = stations;
        _oilToolInstallationForms = oilToolInstallationForms;
        _tankMonitoringInstallationForms = tankMonitoringInstallationForms;
        _afterSalesServiceReports = afterSalesServiceReports;
        _stage2DeliveryForms = stage2DeliveryForms;
        _stage3DeliveryForms = stage3DeliveryForms;
    }

    public IStationRepository Stations => _stations ?? throw new ObjectDisposedException(nameof(UnitOfWork));
    public IOilToolInstallationFormRepository OilToolInstallationForms => _oilToolInstallationForms!;
    public ITankMonitoringInstallationFormRepository TankMonitoringInstallationForms => _tankMonitoringInstallationForms!;
    public IAfterSalesServiceReportRepository AfterSalesServiceReports => _afterSalesServiceReports!;
    public IStage2DeliveryFormRepository Stage2DeliveryForms => _stage2DeliveryForms!;
    public IStage3DeliveryFormRepository Stage3DeliveryForms => _stage3DeliveryForms!;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => _context.SaveChangesAsync(cancellationToken);

    public void Dispose() => _context.Dispose();
}

namespace JaygahYar.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IStationRepository Stations { get; }
    IOilToolInstallationFormRepository OilToolInstallationForms { get; }
    ITankMonitoringInstallationFormRepository TankMonitoringInstallationForms { get; }
    IAfterSalesServiceReportRepository AfterSalesServiceReports { get; }
    IStage2DeliveryFormRepository Stage2DeliveryForms { get; }
    IStage3DeliveryFormRepository Stage3DeliveryForms { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

using JaygahYar.Domain.Common;
using JaygahYar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JaygahYar.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Station> Stations => Set<Station>();
    public DbSet<OilToolInstallationForm> OilToolInstallationForms => Set<OilToolInstallationForm>();
    public DbSet<TankMonitoringInstallationForm> TankMonitoringInstallationForms => Set<TankMonitoringInstallationForm>();
    public DbSet<AfterSalesServiceReport> AfterSalesServiceReports => Set<AfterSalesServiceReport>();
    public DbSet<ServiceReportItem> ServiceReportItems => Set<ServiceReportItem>();
    public DbSet<Stage2DeliveryForm> Stage2DeliveryForms => Set<Stage2DeliveryForm>();
    public DbSet<Stage3DeliveryForm> Stage3DeliveryForms => Set<Stage3DeliveryForm>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("JaygahYar");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // Global filter for soft delete (BaseEntity.IsDeleted == false)
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var clrType = entityType.ClrType;
            if (clrType == null) continue;
            if (!typeof(BaseEntity).IsAssignableFrom(clrType)) continue;

            var parameter = Expression.Parameter(clrType, "e");
            var prop = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
            var body = Expression.Equal(prop, Expression.Constant(false));
            var lambda = Expression.Lambda(body, parameter);

            modelBuilder.Entity(clrType).HasQueryFilter(lambda);
        }

        modelBuilder.Entity<Station>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasMaxLength(200);
            e.Property(x => x.Address).HasMaxLength(500);
        });

        modelBuilder.Entity<OilToolInstallationForm>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Station).WithMany(x => x.OilToolInstallations).HasForeignKey(x => x.StationId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TankMonitoringInstallationForm>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Station).WithMany(x => x.TankMonitoringInstallations).HasForeignKey(x => x.StationId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AfterSalesServiceReport>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Station).WithMany(x => x.AfterSalesReports).HasForeignKey(x => x.StationId).OnDelete(DeleteBehavior.Restrict);
            e.HasMany(x => x.ServiceItems).WithOne(x => x.AfterSalesServiceReport).HasForeignKey(x => x.AfterSalesServiceReportId).OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ServiceReportItem>(e => e.HasKey(x => x.Id));

        modelBuilder.Entity<Stage2DeliveryForm>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Station).WithMany(x => x.Stage2DeliveryForms).HasForeignKey(x => x.StationId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Stage3DeliveryForm>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasOne(x => x.Station).WithMany(x => x.Stage3DeliveryForms).HasForeignKey(x => x.StationId).OnDelete(DeleteBehavior.Restrict);
        });
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is not BaseEntity entity) continue;

            if (entry.State == EntityState.Deleted)
            {
                // Convert hard delete to soft delete
                entry.State = EntityState.Modified;
                entity.IsDeleted = true;
                entity.UpdatedAt = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entity.UpdatedAt = DateTime.UtcNow;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}

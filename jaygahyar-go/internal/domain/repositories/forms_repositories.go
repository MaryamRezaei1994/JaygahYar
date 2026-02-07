package repositories

import (
	"context"

	"github.com/google/uuid"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
)

type OilToolInstallationFormRepository interface {
	GetByID(ctx context.Context, id uuid.UUID) (*entities.OilToolInstallationForm, error)
	GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.OilToolInstallationForm, error)
	Create(ctx context.Context, f *entities.OilToolInstallationForm) error
	Update(ctx context.Context, f *entities.OilToolInstallationForm) error
	Delete(ctx context.Context, id uuid.UUID) error
}

type TankMonitoringInstallationFormRepository interface {
	GetByID(ctx context.Context, id uuid.UUID) (*entities.TankMonitoringInstallationForm, error)
	GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.TankMonitoringInstallationForm, error)
	Create(ctx context.Context, f *entities.TankMonitoringInstallationForm) error
	Delete(ctx context.Context, id uuid.UUID) error
}

type AfterSalesServiceReportRepository interface {
	GetByID(ctx context.Context, id uuid.UUID) (*entities.AfterSalesServiceReport, error)
	GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.AfterSalesServiceReport, error)
	Create(ctx context.Context, r *entities.AfterSalesServiceReport) error
	Delete(ctx context.Context, id uuid.UUID) error
}

type Stage2DeliveryFormRepository interface {
	GetByID(ctx context.Context, id uuid.UUID) (*entities.Stage2DeliveryForm, error)
	GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.Stage2DeliveryForm, error)
	Create(ctx context.Context, f *entities.Stage2DeliveryForm) error
	Delete(ctx context.Context, id uuid.UUID) error
}

type Stage3DeliveryFormRepository interface {
	GetByID(ctx context.Context, id uuid.UUID) (*entities.Stage3DeliveryForm, error)
	GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.Stage3DeliveryForm, error)
	Create(ctx context.Context, f *entities.Stage3DeliveryForm) error
	Delete(ctx context.Context, id uuid.UUID) error
}

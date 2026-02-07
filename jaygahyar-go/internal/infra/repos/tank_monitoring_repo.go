package repos

import (
	"context"

	"github.com/google/uuid"
	"gorm.io/gorm"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/repositories"
)

type tankMonitoringInstallationFormRepository struct {
	db *gorm.DB
}

func NewTankMonitoringInstallationFormRepository(db *gorm.DB) repositories.TankMonitoringInstallationFormRepository {
	return &tankMonitoringInstallationFormRepository{db: db}
}

func (r *tankMonitoringInstallationFormRepository) GetByID(ctx context.Context, id uuid.UUID) (*entities.TankMonitoringInstallationForm, error) {
	var f entities.TankMonitoringInstallationForm
	err := r.db.WithContext(ctx).
		Preload("ProbeItems").
		First(&f, "id = ?", id).Error
	if err != nil {
		if err == gorm.ErrRecordNotFound {
			return nil, nil
		}
		return nil, err
	}
	return &f, nil
}

func (r *tankMonitoringInstallationFormRepository) GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.TankMonitoringInstallationForm, error) {
	var list []entities.TankMonitoringInstallationForm
	if err := r.db.WithContext(ctx).
		Preload("ProbeItems").
		Where("station_id = ?", stationID).
		Find(&list).Error; err != nil {
		return nil, err
	}
	return list, nil
}

func (r *tankMonitoringInstallationFormRepository) Create(ctx context.Context, f *entities.TankMonitoringInstallationForm) error {
	return r.db.WithContext(ctx).Create(f).Error
}

func (r *tankMonitoringInstallationFormRepository) Delete(ctx context.Context, id uuid.UUID) error {
	return r.db.WithContext(ctx).Delete(&entities.TankMonitoringInstallationForm{}, "id = ?", id).Error
}

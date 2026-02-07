package repos

import (
	"context"

	"github.com/google/uuid"
	"gorm.io/gorm"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/repositories"
)

type afterSalesServiceReportRepository struct {
	db *gorm.DB
}

func NewAfterSalesServiceReportRepository(db *gorm.DB) repositories.AfterSalesServiceReportRepository {
	return &afterSalesServiceReportRepository{db: db}
}

func (r *afterSalesServiceReportRepository) GetByID(ctx context.Context, id uuid.UUID) (*entities.AfterSalesServiceReport, error) {
	var f entities.AfterSalesServiceReport
	err := r.db.WithContext(ctx).
		Preload("ServiceItems").
		First(&f, "id = ?", id).Error
	if err != nil {
		if err == gorm.ErrRecordNotFound {
			return nil, nil
		}
		return nil, err
	}
	return &f, nil
}

func (r *afterSalesServiceReportRepository) GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.AfterSalesServiceReport, error) {
	var list []entities.AfterSalesServiceReport
	if err := r.db.WithContext(ctx).
		Preload("ServiceItems").
		Where("station_id = ?", stationID).
		Find(&list).Error; err != nil {
		return nil, err
	}
	return list, nil
}

func (r *afterSalesServiceReportRepository) Create(ctx context.Context, f *entities.AfterSalesServiceReport) error {
	// calculate totals for items if not provided
	for i := range f.ServiceItems {
		if f.ServiceItems[i].TotalAmount == 0 {
			f.ServiceItems[i].TotalAmount = float64(f.ServiceItems[i].Quantity) * f.ServiceItems[i].Price
		}
	}
	return r.db.WithContext(ctx).Create(f).Error
}

func (r *afterSalesServiceReportRepository) Delete(ctx context.Context, id uuid.UUID) error {
	return r.db.WithContext(ctx).Delete(&entities.AfterSalesServiceReport{}, "id = ?", id).Error
}

package repos

import (
	"context"

	"github.com/google/uuid"
	"gorm.io/gorm"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/repositories"
)

type stage2DeliveryFormRepository struct {
	db *gorm.DB
}

func NewStage2DeliveryFormRepository(db *gorm.DB) repositories.Stage2DeliveryFormRepository {
	return &stage2DeliveryFormRepository{db: db}
}

func (r *stage2DeliveryFormRepository) GetByID(ctx context.Context, id uuid.UUID) (*entities.Stage2DeliveryForm, error) {
	var f entities.Stage2DeliveryForm
	err := r.db.WithContext(ctx).First(&f, "id = ?", id).Error
	if err != nil {
		if err == gorm.ErrRecordNotFound {
			return nil, nil
		}
		return nil, err
	}
	return &f, nil
}

func (r *stage2DeliveryFormRepository) GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.Stage2DeliveryForm, error) {
	var list []entities.Stage2DeliveryForm
	if err := r.db.WithContext(ctx).Where("station_id = ?", stationID).Find(&list).Error; err != nil {
		return nil, err
	}
	return list, nil
}

func (r *stage2DeliveryFormRepository) Create(ctx context.Context, f *entities.Stage2DeliveryForm) error {
	return r.db.WithContext(ctx).Create(f).Error
}

func (r *stage2DeliveryFormRepository) Delete(ctx context.Context, id uuid.UUID) error {
	return r.db.WithContext(ctx).Delete(&entities.Stage2DeliveryForm{}, "id = ?", id).Error
}

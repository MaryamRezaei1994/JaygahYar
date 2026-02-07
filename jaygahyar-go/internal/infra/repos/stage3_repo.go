package repos

import (
	"context"

	"github.com/google/uuid"
	"gorm.io/gorm"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/repositories"
)

type stage3DeliveryFormRepository struct {
	db *gorm.DB
}

func NewStage3DeliveryFormRepository(db *gorm.DB) repositories.Stage3DeliveryFormRepository {
	return &stage3DeliveryFormRepository{db: db}
}

func (r *stage3DeliveryFormRepository) GetByID(ctx context.Context, id uuid.UUID) (*entities.Stage3DeliveryForm, error) {
	var f entities.Stage3DeliveryForm
	err := r.db.WithContext(ctx).First(&f, "id = ?", id).Error
	if err != nil {
		if err == gorm.ErrRecordNotFound {
			return nil, nil
		}
		return nil, err
	}
	return &f, nil
}

func (r *stage3DeliveryFormRepository) GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.Stage3DeliveryForm, error) {
	var list []entities.Stage3DeliveryForm
	if err := r.db.WithContext(ctx).Where("station_id = ?", stationID).Find(&list).Error; err != nil {
		return nil, err
	}
	return list, nil
}

func (r *stage3DeliveryFormRepository) Create(ctx context.Context, f *entities.Stage3DeliveryForm) error {
	return r.db.WithContext(ctx).Create(f).Error
}

func (r *stage3DeliveryFormRepository) Delete(ctx context.Context, id uuid.UUID) error {
	return r.db.WithContext(ctx).Delete(&entities.Stage3DeliveryForm{}, "id = ?", id).Error
}

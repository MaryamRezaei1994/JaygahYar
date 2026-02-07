package repos

import (
	"context"

	"github.com/google/uuid"
	"gorm.io/gorm"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/repositories"
)

type stationRepository struct {
	db *gorm.DB
}

func NewStationRepository(db *gorm.DB) repositories.StationRepository {
	return &stationRepository{db: db}
}

func (r *stationRepository) GetAll(ctx context.Context) ([]entities.Station, error) {
	var list []entities.Station
	if err := r.db.WithContext(ctx).Find(&list).Error; err != nil {
		return nil, err
	}
	return list, nil
}

func (r *stationRepository) GetByID(ctx context.Context, id uuid.UUID) (*entities.Station, error) {
	var s entities.Station
	err := r.db.WithContext(ctx).First(&s, "id = ?", id).Error
	if err != nil {
		if err == gorm.ErrRecordNotFound {
			return nil, nil
		}
		return nil, err
	}
	return &s, nil
}

func (r *stationRepository) Create(ctx context.Context, s *entities.Station) error {
	return r.db.WithContext(ctx).Create(s).Error
}

func (r *stationRepository) Update(ctx context.Context, s *entities.Station) error {
	return r.db.WithContext(ctx).Save(s).Error
}

func (r *stationRepository) Delete(ctx context.Context, id uuid.UUID) error {
	return r.db.WithContext(ctx).Delete(&entities.Station{}, "id = ?", id).Error
}

func (r *stationRepository) Exists(ctx context.Context, id uuid.UUID) (bool, error) {
	var count int64
	if err := r.db.WithContext(ctx).Model(&entities.Station{}).Where("id = ?", id).Count(&count).Error; err != nil {
		return false, err
	}
	return count > 0, nil
}

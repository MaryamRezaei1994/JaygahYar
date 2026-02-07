package repos

import (
	"context"

	"github.com/google/uuid"
	"gorm.io/gorm"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/repositories"
)

type oilToolInstallationFormRepository struct {
	db *gorm.DB
}

func NewOilToolInstallationFormRepository(db *gorm.DB) repositories.OilToolInstallationFormRepository {
	return &oilToolInstallationFormRepository{db: db}
}

func (r *oilToolInstallationFormRepository) GetByID(ctx context.Context, id uuid.UUID) (*entities.OilToolInstallationForm, error) {
	var f entities.OilToolInstallationForm
	err := r.db.WithContext(ctx).
		Preload("DispenserItems").
		First(&f, "id = ?", id).Error
	if err != nil {
		if err == gorm.ErrRecordNotFound {
			return nil, nil
		}
		return nil, err
	}
	return &f, nil
}

func (r *oilToolInstallationFormRepository) GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.OilToolInstallationForm, error) {
	var list []entities.OilToolInstallationForm
	if err := r.db.WithContext(ctx).
		Preload("DispenserItems").
		Where("station_id = ?", stationID).
		Find(&list).Error; err != nil {
		return nil, err
	}
	return list, nil
}

func (r *oilToolInstallationFormRepository) Create(ctx context.Context, f *entities.OilToolInstallationForm) error {
	return r.db.WithContext(ctx).Create(f).Error
}

func (r *oilToolInstallationFormRepository) Update(ctx context.Context, f *entities.OilToolInstallationForm) error {
	// Replace nested items: simple approach
	return r.db.WithContext(ctx).Transaction(func(tx *gorm.DB) error {
		// delete existing items
		if err := tx.Where("oil_tool_installation_form_id = ?", f.ID).Delete(&entities.DispenserInstallationItem{}).Error; err != nil {
			return err
		}
		// save parent
		if err := tx.Save(f).Error; err != nil {
			return err
		}
		// recreate items (if any)
		for i := range f.DispenserItems {
			f.DispenserItems[i].OilToolInstallationFormID = f.ID
		}
		if len(f.DispenserItems) > 0 {
			if err := tx.Create(&f.DispenserItems).Error; err != nil {
				return err
			}
		}
		return nil
	})
}

func (r *oilToolInstallationFormRepository) Delete(ctx context.Context, id uuid.UUID) error {
	return r.db.WithContext(ctx).Delete(&entities.OilToolInstallationForm{}, "id = ?", id).Error
}

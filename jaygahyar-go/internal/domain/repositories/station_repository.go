package repositories

import (
	"context"

	"github.com/google/uuid"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
)

type StationRepository interface {
	GetAll(ctx context.Context) ([]entities.Station, error)
	GetByID(ctx context.Context, id uuid.UUID) (*entities.Station, error)
	Create(ctx context.Context, s *entities.Station) error
	Update(ctx context.Context, s *entities.Station) error
	Delete(ctx context.Context, id uuid.UUID) error
	Exists(ctx context.Context, id uuid.UUID) (bool, error)
}

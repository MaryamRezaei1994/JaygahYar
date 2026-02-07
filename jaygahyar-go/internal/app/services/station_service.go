package services

import (
	"context"

	"github.com/google/uuid"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/repositories"
)

type StationService struct {
	repo repositories.StationRepository
}

func NewStationService(repo repositories.StationRepository) *StationService {
	return &StationService{repo: repo}
}

func (s *StationService) GetAll(ctx context.Context) ([]entities.Station, error) {
	return s.repo.GetAll(ctx)
}

func (s *StationService) GetByID(ctx context.Context, id uuid.UUID) (*entities.Station, error) {
	return s.repo.GetByID(ctx, id)
}

func (s *StationService) Create(ctx context.Context, station *entities.Station) error {
	return s.repo.Create(ctx, station)
}

func (s *StationService) Update(ctx context.Context, station *entities.Station) error {
	return s.repo.Update(ctx, station)
}

func (s *StationService) Delete(ctx context.Context, id uuid.UUID) error {
	return s.repo.Delete(ctx, id)
}

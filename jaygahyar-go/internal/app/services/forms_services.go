package services

import (
	"context"
	"errors"

	"github.com/google/uuid"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/repositories"
)

var ErrStationNotFound = errors.New("station not found")

type OilToolInstallationFormService struct {
	repo        repositories.OilToolInstallationFormRepository
	stationRepo repositories.StationRepository
}

func NewOilToolInstallationFormService(repo repositories.OilToolInstallationFormRepository, stationRepo repositories.StationRepository) *OilToolInstallationFormService {
	return &OilToolInstallationFormService{repo: repo, stationRepo: stationRepo}
}

func (s *OilToolInstallationFormService) GetByID(ctx context.Context, id uuid.UUID) (*entities.OilToolInstallationForm, error) {
	return s.repo.GetByID(ctx, id)
}

func (s *OilToolInstallationFormService) GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.OilToolInstallationForm, error) {
	return s.repo.GetByStationID(ctx, stationID)
}

func (s *OilToolInstallationFormService) Create(ctx context.Context, form *entities.OilToolInstallationForm) error {
	ok, err := s.stationRepo.Exists(ctx, form.StationID)
	if err != nil {
		return err
	}
	if !ok {
		return ErrStationNotFound
	}
	for i := range form.DispenserItems {
		form.DispenserItems[i].OilToolInstallationFormID = form.ID
	}
	return s.repo.Create(ctx, form)
}

func (s *OilToolInstallationFormService) Update(ctx context.Context, form *entities.OilToolInstallationForm) error {
	return s.repo.Update(ctx, form)
}

func (s *OilToolInstallationFormService) Delete(ctx context.Context, id uuid.UUID) error {
	return s.repo.Delete(ctx, id)
}

type TankMonitoringInstallationFormService struct {
	repo        repositories.TankMonitoringInstallationFormRepository
	stationRepo repositories.StationRepository
}

func NewTankMonitoringInstallationFormService(repo repositories.TankMonitoringInstallationFormRepository, stationRepo repositories.StationRepository) *TankMonitoringInstallationFormService {
	return &TankMonitoringInstallationFormService{repo: repo, stationRepo: stationRepo}
}

func (s *TankMonitoringInstallationFormService) GetByID(ctx context.Context, id uuid.UUID) (*entities.TankMonitoringInstallationForm, error) {
	return s.repo.GetByID(ctx, id)
}

func (s *TankMonitoringInstallationFormService) GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.TankMonitoringInstallationForm, error) {
	return s.repo.GetByStationID(ctx, stationID)
}

func (s *TankMonitoringInstallationFormService) Create(ctx context.Context, form *entities.TankMonitoringInstallationForm) error {
	ok, err := s.stationRepo.Exists(ctx, form.StationID)
	if err != nil {
		return err
	}
	if !ok {
		return ErrStationNotFound
	}
	for i := range form.ProbeItems {
		form.ProbeItems[i].TankMonitoringInstallationFormID = form.ID
	}
	return s.repo.Create(ctx, form)
}

func (s *TankMonitoringInstallationFormService) Delete(ctx context.Context, id uuid.UUID) error {
	return s.repo.Delete(ctx, id)
}

type AfterSalesServiceReportService struct {
	repo        repositories.AfterSalesServiceReportRepository
	stationRepo repositories.StationRepository
}

func NewAfterSalesServiceReportService(repo repositories.AfterSalesServiceReportRepository, stationRepo repositories.StationRepository) *AfterSalesServiceReportService {
	return &AfterSalesServiceReportService{repo: repo, stationRepo: stationRepo}
}

func (s *AfterSalesServiceReportService) GetByID(ctx context.Context, id uuid.UUID) (*entities.AfterSalesServiceReport, error) {
	return s.repo.GetByID(ctx, id)
}

func (s *AfterSalesServiceReportService) GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.AfterSalesServiceReport, error) {
	return s.repo.GetByStationID(ctx, stationID)
}

func (s *AfterSalesServiceReportService) Create(ctx context.Context, report *entities.AfterSalesServiceReport) error {
	ok, err := s.stationRepo.Exists(ctx, report.StationID)
	if err != nil {
		return err
	}
	if !ok {
		return ErrStationNotFound
	}
	for i := range report.ServiceItems {
		report.ServiceItems[i].AfterSalesServiceReportID = report.ID
		if report.ServiceItems[i].TotalAmount == 0 {
			report.ServiceItems[i].TotalAmount = float64(report.ServiceItems[i].Quantity) * report.ServiceItems[i].Price
		}
	}
	return s.repo.Create(ctx, report)
}

func (s *AfterSalesServiceReportService) Delete(ctx context.Context, id uuid.UUID) error {
	return s.repo.Delete(ctx, id)
}

type Stage2DeliveryFormService struct {
	repo        repositories.Stage2DeliveryFormRepository
	stationRepo repositories.StationRepository
}

func NewStage2DeliveryFormService(repo repositories.Stage2DeliveryFormRepository, stationRepo repositories.StationRepository) *Stage2DeliveryFormService {
	return &Stage2DeliveryFormService{repo: repo, stationRepo: stationRepo}
}

func (s *Stage2DeliveryFormService) GetByID(ctx context.Context, id uuid.UUID) (*entities.Stage2DeliveryForm, error) {
	return s.repo.GetByID(ctx, id)
}

func (s *Stage2DeliveryFormService) GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.Stage2DeliveryForm, error) {
	return s.repo.GetByStationID(ctx, stationID)
}

func (s *Stage2DeliveryFormService) Create(ctx context.Context, form *entities.Stage2DeliveryForm) error {
	ok, err := s.stationRepo.Exists(ctx, form.StationID)
	if err != nil {
		return err
	}
	if !ok {
		return ErrStationNotFound
	}
	return s.repo.Create(ctx, form)
}

func (s *Stage2DeliveryFormService) Delete(ctx context.Context, id uuid.UUID) error {
	return s.repo.Delete(ctx, id)
}

type Stage3DeliveryFormService struct {
	repo        repositories.Stage3DeliveryFormRepository
	stationRepo repositories.StationRepository
}

func NewStage3DeliveryFormService(repo repositories.Stage3DeliveryFormRepository, stationRepo repositories.StationRepository) *Stage3DeliveryFormService {
	return &Stage3DeliveryFormService{repo: repo, stationRepo: stationRepo}
}

func (s *Stage3DeliveryFormService) GetByID(ctx context.Context, id uuid.UUID) (*entities.Stage3DeliveryForm, error) {
	return s.repo.GetByID(ctx, id)
}

func (s *Stage3DeliveryFormService) GetByStationID(ctx context.Context, stationID uuid.UUID) ([]entities.Stage3DeliveryForm, error) {
	return s.repo.GetByStationID(ctx, stationID)
}

func (s *Stage3DeliveryFormService) Create(ctx context.Context, form *entities.Stage3DeliveryForm) error {
	ok, err := s.stationRepo.Exists(ctx, form.StationID)
	if err != nil {
		return err
	}
	if !ok {
		return ErrStationNotFound
	}
	return s.repo.Create(ctx, form)
}

func (s *Stage3DeliveryFormService) Delete(ctx context.Context, id uuid.UUID) error {
	return s.repo.Delete(ctx, id)
}

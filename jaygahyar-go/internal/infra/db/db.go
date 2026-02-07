package db

import (
	"time"

	"gorm.io/driver/postgres"
	"gorm.io/gorm"
	"gorm.io/gorm/logger"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
)

func OpenPostgres(dsn string) (*gorm.DB, error) {
	return gorm.Open(postgres.Open(dsn), &gorm.Config{
		Logger: logger.Default.LogMode(logger.Warn),
		NowFunc: func() time.Time {
			return time.Now().UTC()
		},
	})
}

func AutoMigrate(db *gorm.DB) error {
	return db.AutoMigrate(
		&entities.Station{},
		&entities.OilToolInstallationForm{},
		&entities.DispenserInstallationItem{},
		&entities.TankMonitoringInstallationForm{},
		&entities.ProbeItem{},
		&entities.AfterSalesServiceReport{},
		&entities.ServiceReportItem{},
		&entities.Stage2DeliveryForm{},
		&entities.Stage3DeliveryForm{},
	)
}

package entities

import (
	"time"

	"github.com/google/uuid"
)

type OilToolInstallationForm struct {
	BaseEntity

	FormNumber         string    `json:"formNumber" gorm:"size:50;not null"`
	FormCompletionDate time.Time `json:"formCompletionDate" gorm:"not null"`
	BuyerName          string    `json:"buyerName" gorm:"size:200;not null"`

	StationID      uuid.UUID `json:"stationId" gorm:"type:uuid;not null;index"`
	Station        Station   `json:"-" gorm:"constraint:OnDelete:RESTRICT"`
	StationAddress *string   `json:"stationAddress"`
	Mobile         *string   `json:"mobile"`

	DeviceInstallationDate *time.Time `json:"deviceInstallationDate"`
	CommissioningDate      *time.Time `json:"commissioningDate"`

	FloatQuantity *int `json:"floatQuantity"`
	StationType   *int `json:"stationType"` // 0 Old, 1 NewlyBuilt (مثل .NET)

	ShutOffValveInstalledCorrectly  bool `json:"shutOffValveInstalledCorrectly"`
	CheckValveInstalledForMotorized bool `json:"checkValveInstalledForMotorized"`
	SuitableGlandsForInputCables    bool `json:"suitableGlandsForInputCables"`

	InstallerName *string `json:"installerName"`

	DispenserItems []DispenserInstallationItem `json:"dispenserItems" gorm:"foreignKey:OilToolInstallationFormID;constraint:OnDelete:CASCADE"`
}

type DispenserInstallationItem struct {
	BaseEntity

	OilToolInstallationFormID uuid.UUID `json:"oilToolInstallationFormId" gorm:"type:uuid;not null;index"`

	RowNumber     int    `json:"rowNumber"`
	DispenserType string `json:"dispenserType" gorm:"size:200"`
	NozzleCount   int    `json:"nozzleCount"`
	SerialNumber  string `json:"serialNumber" gorm:"size:200"`

	FuelTypeA           *string  `json:"fuelTypeA"`
	FuelTypeB           *string  `json:"fuelTypeB"`
	CurrentPerformanceC *float64 `json:"currentPerformanceC"`
	CurrentPerformanceD *float64 `json:"currentPerformanceD"`
}

package entities

import (
	"time"

	"github.com/google/uuid"
)

type TankMonitoringInstallationForm struct {
	BaseEntity

	FormNumber    string     `json:"formNumber" gorm:"size:50;not null"`
	FormDate      *time.Time `json:"formDate"`
	BuyerFullName string     `json:"buyerFullName" gorm:"size:200;not null"`

	StationID uuid.UUID `json:"stationId" gorm:"type:uuid;not null;index"`
	Station   Station   `json:"-" gorm:"constraint:OnDelete:RESTRICT"`

	StationAddress *string `json:"stationAddress"`
	Mobile         *string `json:"mobile"`

	GasolineTankCount int `json:"gasolineTankCount"`
	DieselTankCount   int `json:"dieselTankCount"`

	DeviceInstallationDate  *time.Time `json:"deviceInstallationDate"`
	DeviceCommissioningDate *time.Time `json:"deviceCommissioningDate"`
	DeviceType              *string    `json:"deviceType"`
	DisplaySerialNumber     *string    `json:"displaySerialNumber"`
	PowerSerialNumber       *string    `json:"powerSerialNumber"`

	DisplayPowerInstalledCorrectly bool `json:"displayPowerInstalledCorrectly"`
	SuitableCableUsed              bool `json:"suitableCableUsed"`
	ProbesInstalledCorrectly       bool `json:"probesInstalledCorrectly"`
	JunctionBoxInstalledCorrectly  bool `json:"junctionBoxInstalledCorrectly"`
	CableEntryGasTight             bool `json:"cableEntryGasTight"`
	FloatsInstalledCorrectly       bool `json:"floatsInstalledCorrectly"`
	ConsoleGroundAndProtectionUsed bool `json:"consoleGroundAndProtectionUsed"`
	SoftwarePurchased              bool `json:"softwarePurchased"`
	SoftwareSetupPerformed         bool `json:"softwareSetupPerformed"`
	TankInfoMatchesDipstick        bool `json:"tankInfoMatchesDipstick"`
	TrainingProvided               bool `json:"trainingProvided"`

	StationManagerName *string `json:"stationManagerName"`

	ProbeItems []ProbeItem `json:"probeItems" gorm:"foreignKey:TankMonitoringInstallationFormID;constraint:OnDelete:CASCADE"`
}

type ProbeItem struct {
	BaseEntity

	TankMonitoringInstallationFormID uuid.UUID `json:"tankMonitoringInstallationFormId" gorm:"type:uuid;not null;index"`

	RowNumber         int     `json:"rowNumber"`
	ProbeType         string  `json:"probeType" gorm:"size:200;not null"`
	ProbeSerialNumber string  `json:"probeSerialNumber" gorm:"size:200;not null"`
	FuelType          string  `json:"fuelType" gorm:"size:100;not null"`
	TankNumber        *string `json:"tankNumber"`
	Remarks           *string `json:"remarks"`
}

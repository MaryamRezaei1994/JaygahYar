package entities

import (
	"time"

	"github.com/google/uuid"
)

type Stage2DeliveryForm struct {
	BaseEntity

	FormNumber string     `json:"formNumber" gorm:"size:50;not null"`
	FormDate   *time.Time `json:"formDate"`
	Revision   *string    `json:"revision"`

	CustomerName     *string `json:"customerName"`
	StationName      *string `json:"stationName"`
	StationOwnerName *string `json:"stationOwnerName"`
	CompanyBrand     *string `json:"companyBrand"`
	SendDate         *string `json:"sendDate"`
	Phone            *string `json:"phone"`
	Address          *string `json:"address"`

	HasReceivedItems      bool  `json:"hasReceivedItems"`
	VacuumPumpCount       *int  `json:"vacuumPumpCount"`
	MotorThreePhase       *bool `json:"motorThreePhase"`
	SinglePhaseMotorCount *int  `json:"singlePhaseMotorCount"`
	DualWallHoseCount     *int  `json:"dualWallHoseCount"`
	SeparatorCount        *int  `json:"separatorCount"`
	CutoffCount           *int  `json:"cutoffCount"`
	NozzleCount           *int  `json:"nozzleCount"`

	DeliveryDate    *time.Time `json:"deliveryDate"`
	DeliveryAddress *string    `json:"deliveryAddress"`

	DispenserModel             *string `json:"dispenserModel"`
	DispenserManufacturer      *string `json:"dispenserManufacturer"`
	SingleNozzleDispenserCount *int    `json:"singleNozzleDispenserCount"`
	TwoNozzleDispenserCount    *int    `json:"twoNozzleDispenserCount"`
	FourNozzleDispenserCount   *int    `json:"fourNozzleDispenserCount"`

	EquipmentInstalled           bool `json:"equipmentInstalled"`
	Stage2PipingInsideDispensers bool `json:"stage2PipingInsideDispensers"`
	Stage2TestApproved           bool `json:"stage2TestApproved"`
	PipeSlopeTowardTank          bool `json:"pipeSlopeTowardTank"`

	TrainingDate       *time.Time `json:"trainingDate"`
	Trainee1Name       *string    `json:"trainee1Name"`
	Trainee1NationalId *string    `json:"trainee1NationalId"`
	Trainee2Name       *string    `json:"trainee2Name"`
	Trainee2NationalId *string    `json:"trainee2NationalId"`
	Trainee3Name       *string    `json:"trainee3Name"`
	Trainee3NationalId *string    `json:"trainee3NationalId"`

	Remarks *string `json:"remarks"`

	StationID uuid.UUID `json:"stationId" gorm:"type:uuid;not null;index"`
	Station   Station   `json:"-" gorm:"constraint:OnDelete:RESTRICT"`
}

type Stage3DeliveryForm struct {
	BaseEntity

	FormNumber string     `json:"formNumber" gorm:"size:50;not null"`
	FormDate   *time.Time `json:"formDate"`
	Revision   *string    `json:"revision"`

	CustomerName     *string `json:"customerName"`
	StationName      *string `json:"stationName"`
	StationOwnerName *string `json:"stationOwnerName"`
	CompanyBrand     *string `json:"companyBrand"`
	SendDate         *string `json:"sendDate"`
	Phone            *string `json:"phone"`
	Address          *string `json:"address"`

	DeliveryCommissioningDate *time.Time `json:"deliveryCommissioningDate"`
	IsDelivery                bool       `json:"isDelivery"`
	IsCommissioning           bool       `json:"isCommissioning"`

	TrainingDate       *time.Time `json:"trainingDate"`
	Trainee1Name       *string    `json:"trainee1Name"`
	Trainee1NationalId *string    `json:"trainee1NationalId"`
	Trainee2Name       *string    `json:"trainee2Name"`
	Trainee2NationalId *string    `json:"trainee2NationalId"`
	Trainee3Name       *string    `json:"trainee3Name"`
	Trainee3NationalId *string    `json:"trainee3NationalId"`

	HasStage2Commissioning bool `json:"hasStage2Commissioning"`

	HPGaugePressureBeforeStart *float64 `json:"hpGaugePressureBeforeStart"`
	LPGaugePressureBeforeStart *float64 `json:"lpGaugePressureBeforeStart"`
	HPGaugePressureAfterStart  *float64 `json:"hpGaugePressureAfterStart"`
	LPGaugePressureAfterStart  *float64 `json:"lpGaugePressureAfterStart"`

	InitialTemperature         *float64 `json:"initialTemperature"`
	SecondaryTemperatureMin    *float64 `json:"secondaryTemperatureMin"`
	CompressorMaxCurrentAmpere *float64 `json:"compressorMaxCurrentAmpere"`
	ThermometerOffTempC        *float64 `json:"thermometerOffTempC"`
	ThermometerOnTempC         *float64 `json:"thermometerOnTempC"`
	CompressorHasOil           bool     `json:"compressorHasOil"`
	TimeToSecondaryTempMinutes *int     `json:"timeToSecondaryTempMinutes"`

	VaporInletOutletValvesChecked       bool `json:"vaporInletOutletValvesChecked"`
	DipHatchGasTightChecked             bool `json:"dipHatchGasTightChecked"`
	DrainHoseCapGasTightChecked         bool `json:"drainHoseCapGasTightChecked"`
	PVValvesOperationChecked            bool `json:"pvValvesOperationChecked"`
	StationGroundToDeviceChecked        bool `json:"stationGroundToDeviceChecked"`
	FlameArresterInstalled              bool `json:"flameArresterInstalled"`
	ManualTakeoffBlockerInstalled       bool `json:"manualTakeoffBlockerInstalled"`
	PVCalibrationCertificateOnCollector bool `json:"pvCalibrationCertificateOnCollector"`

	DeviceModel        *string `json:"deviceModel"`
	DeviceSerialNumber *string `json:"deviceSerialNumber"`
	Remarks            *string `json:"remarks"`

	StationID uuid.UUID `json:"stationId" gorm:"type:uuid;not null;index"`
	Station   Station   `json:"-" gorm:"constraint:OnDelete:RESTRICT"`
}

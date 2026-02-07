package entities

import (
	"time"

	"github.com/google/uuid"
)

type AfterSalesServiceReport struct {
	BaseEntity

	FormNumber string     `json:"formNumber" gorm:"size:50;not null"`
	ReportDate *time.Time `json:"reportDate"`

	PersonnelDispatch *string `json:"personnelDispatch"`
	WarehouseReceipt  *string `json:"warehouseReceipt"`
	Reference         *string `json:"reference"`

	CustomerName      string  `json:"customerName" gorm:"size:200;not null"`
	Address           *string `json:"address"`
	LandlineAndMobile *string `json:"landlineAndMobile"`

	StationID uuid.UUID `json:"stationId" gorm:"type:uuid;not null;index"`
	Station   Station   `json:"-" gorm:"constraint:OnDelete:RESTRICT"`

	DeviceCommissioningDate   *time.Time `json:"deviceCommissioningDate"`
	DefectsReportedByCustomer *string    `json:"defectsReportedByCustomer"`
	ContactDate               *time.Time `json:"contactDate"`
	ContactTime               *string    `json:"contactTime"` // HH:mm

	SerialNumber         *string `json:"serialNumber"`
	DeviceType           *string `json:"deviceType"`
	ElectronicSystemType *string `json:"electronicSystemType"`

	PerformanceSideA *float64 `json:"performanceSideA"`
	PerformanceSideB *float64 `json:"performanceSideB"`
	PerformanceSideC *float64 `json:"performanceSideC"`
	PerformanceSideD *float64 `json:"performanceSideD"`

	ExpertOpinion *string `json:"expertOpinion"`

	BarrierPlaced          bool `json:"barrierPlaced"`
	FireExtinguisherNearby bool `json:"fireExtinguisherNearby"`
	DevicePowerCutOff      bool `json:"devicePowerCutOff"`
	ShutOffValveClosed     bool `json:"shutOffValveClosed"`
	LeakCheckAfterService  bool `json:"leakCheckAfterService"`

	IsWarranty           bool       `json:"isWarranty"`
	DefectResolutionDate *time.Time `json:"defectResolutionDate"`
	DefectResolutionTime *string    `json:"defectResolutionTime"` // HH:mm

	TravelCost *float64 `json:"travelCost"`
	DistanceKm *float64 `json:"distanceKm"`
	Downtime   *string  `json:"downtime"`

	GrandTotal        float64 `json:"grandTotal"`
	GrandTotalInWords *string `json:"grandTotalInWords"`

	StationManagerName           *string `json:"stationManagerName"`
	OilCompanyApprovalRequired   bool    `json:"oilCompanyApprovalRequired"`
	RepairTechnicianName         *string `json:"repairTechnicianName"`
	ProvincialRepresentativeName *string `json:"provincialRepresentativeName"`

	ServiceItems []ServiceReportItem `json:"serviceItems" gorm:"foreignKey:AfterSalesServiceReportID;constraint:OnDelete:CASCADE"`
}

type ServiceReportItem struct {
	BaseEntity

	AfterSalesServiceReportID uuid.UUID `json:"afterSalesServiceReportId" gorm:"type:uuid;not null;index"`

	RowNumber                 int     `json:"rowNumber"`
	Description               string  `json:"description" gorm:"size:500;not null"`
	Quantity                  int     `json:"quantity"`
	Price                     float64 `json:"price"`
	TotalAmount               float64 `json:"totalAmount"`
	DefectivePartSerialNumber *string `json:"defectivePartSerialNumber"`
	NewPartSerialNumber       *string `json:"newPartSerialNumber"`
	Notes                     *string `json:"notes"`
}

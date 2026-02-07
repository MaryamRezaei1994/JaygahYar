package entities

type Station struct {
	BaseEntity

	Name      string  `json:"name" gorm:"size:200;not null"`
	Address   string  `json:"address" gorm:"size:500;not null"`
	Phone     *string `json:"phone"`
	Mobile    *string `json:"mobile"`
	OwnerName *string `json:"ownerName"`

	GasolineTankCount int `json:"gasolineTankCount"`
	DieselTankCount   int `json:"dieselTankCount"`

	OilToolInstallations        []OilToolInstallationForm        `json:"oilToolInstallations,omitempty" gorm:"foreignKey:StationID"`
	TankMonitoringInstallations []TankMonitoringInstallationForm `json:"tankMonitoringInstallations,omitempty" gorm:"foreignKey:StationID"`
	AfterSalesReports           []AfterSalesServiceReport        `json:"afterSalesReports,omitempty" gorm:"foreignKey:StationID"`
	Stage2DeliveryForms         []Stage2DeliveryForm             `json:"stage2DeliveryForms,omitempty" gorm:"foreignKey:StationID"`
	Stage3DeliveryForms         []Stage3DeliveryForm             `json:"stage3DeliveryForms,omitempty" gorm:"foreignKey:StationID"`
}

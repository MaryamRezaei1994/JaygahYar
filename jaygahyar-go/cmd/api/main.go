package main

import (
	"log"
	"net/http"
	"os"
	"time"

	"github.com/gin-gonic/gin"
	"github.com/joho/godotenv"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/app/services"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/infra/db"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/infra/repos"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/transport/http/handlers"
)

func main() {
	_ = godotenv.Load()

	port := os.Getenv("PORT")
	if port == "" {
		port = "8080"
	}

	databaseURL := os.Getenv("DATABASE_URL")
	if databaseURL == "" {
		log.Fatal("DATABASE_URL is required (PostgreSQL connection string)")
	}

	gormDB, err := db.OpenPostgres(databaseURL)
	if err != nil {
		log.Fatalf("db connect failed: %v", err)
	}

	// Auto-migrate (simple approach; replace with SQL migrations if needed)
	if err := db.AutoMigrate(gormDB); err != nil {
		log.Fatalf("auto migrate failed: %v", err)
	}

	// Repositories
	stationRepo := repos.NewStationRepository(gormDB)
	oilToolRepo := repos.NewOilToolInstallationFormRepository(gormDB)
	tankMonRepo := repos.NewTankMonitoringInstallationFormRepository(gormDB)
	afterSalesRepo := repos.NewAfterSalesServiceReportRepository(gormDB)
	stage2Repo := repos.NewStage2DeliveryFormRepository(gormDB)
	stage3Repo := repos.NewStage3DeliveryFormRepository(gormDB)

	// Services
	stationSvc := services.NewStationService(stationRepo)
	oilToolSvc := services.NewOilToolInstallationFormService(oilToolRepo, stationRepo)
	tankMonSvc := services.NewTankMonitoringInstallationFormService(tankMonRepo, stationRepo)
	afterSalesSvc := services.NewAfterSalesServiceReportService(afterSalesRepo, stationRepo)
	stage2Svc := services.NewStage2DeliveryFormService(stage2Repo, stationRepo)
	stage3Svc := services.NewStage3DeliveryFormService(stage3Repo, stationRepo)

	// Handlers
	stationHandler := handlers.NewStationsHandler(stationSvc)
	oilToolHandler := handlers.NewOilToolInstallationFormsHandler(oilToolSvc)
	tankMonHandler := handlers.NewTankMonitoringInstallationFormsHandler(tankMonSvc)
	afterSalesHandler := handlers.NewAfterSalesServiceReportsHandler(afterSalesSvc)
	stage2Handler := handlers.NewStage2DeliveryFormsHandler(stage2Svc)
	stage3Handler := handlers.NewStage3DeliveryFormsHandler(stage3Svc)

	r := gin.New()
	r.Use(gin.Logger(), gin.Recovery())

	r.GET("/healthz", func(c *gin.Context) {
		c.JSON(http.StatusOK, gin.H{"status": "ok", "time": time.Now().UTC()})
	})

	api := r.Group("/api")
	{
		stationHandler.Register(api.Group("/Stations"))
		oilToolHandler.Register(api.Group("/OilToolInstallationForms"))
		tankMonHandler.Register(api.Group("/TankMonitoringInstallationForms"))
		afterSalesHandler.Register(api.Group("/AfterSalesServiceReports"))
		stage2Handler.Register(api.Group("/Stage2DeliveryForms"))
		stage3Handler.Register(api.Group("/Stage3DeliveryForms"))
	}

	log.Printf("listening on :%s", port)
	if err := r.Run(":" + port); err != nil {
		log.Fatal(err)
	}
}

package handlers

import (
	"net/http"

	"github.com/gin-gonic/gin"
	"github.com/google/uuid"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/app/services"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
)

type OilToolInstallationFormsHandler struct {
	svc *services.OilToolInstallationFormService
}

func NewOilToolInstallationFormsHandler(svc *services.OilToolInstallationFormService) *OilToolInstallationFormsHandler {
	return &OilToolInstallationFormsHandler{svc: svc}
}

func (h *OilToolInstallationFormsHandler) Register(rg *gin.RouterGroup) {
	rg.GET("/:id", h.getByID)
	rg.GET("/station/:stationId", h.getByStation)
	rg.POST("", h.create)
	rg.PUT("/:id", h.update)
	rg.DELETE("/:id", h.delete)
}

func (h *OilToolInstallationFormsHandler) getByID(c *gin.Context) {
	id, err := uuid.Parse(c.Param("id"))
	if err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": "invalid id"})
		return
	}
	dto, err := h.svc.GetByID(c.Request.Context(), id)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	if dto == nil {
		c.Status(http.StatusNotFound)
		return
	}
	c.JSON(http.StatusOK, dto)
}

func (h *OilToolInstallationFormsHandler) getByStation(c *gin.Context) {
	stationID, err := uuid.Parse(c.Param("stationId"))
	if err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": "invalid stationId"})
		return
	}
	list, err := h.svc.GetByStationID(c.Request.Context(), stationID)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, list)
}

func (h *OilToolInstallationFormsHandler) create(c *gin.Context) {
	var req entities.OilToolInstallationForm
	if err := c.ShouldBindJSON(&req); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	req.ID = uuid.Nil
	for i := range req.DispenserItems {
		req.DispenserItems[i].ID = uuid.Nil
	}

	err := h.svc.Create(c.Request.Context(), &req)
	if err != nil {
		if err == services.ErrStationNotFound {
			c.JSON(http.StatusBadRequest, gin.H{"error": "station not found"})
			return
		}
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusCreated, req)
}

func (h *OilToolInstallationFormsHandler) update(c *gin.Context) {
	id, err := uuid.Parse(c.Param("id"))
	if err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": "invalid id"})
		return
	}
	existing, err := h.svc.GetByID(c.Request.Context(), id)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	if existing == nil {
		c.Status(http.StatusNotFound)
		return
	}

	var req entities.OilToolInstallationForm
	if err := c.ShouldBindJSON(&req); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	req.ID = id
	req.StationID = existing.StationID
	for i := range req.DispenserItems {
		req.DispenserItems[i].ID = uuid.Nil
		req.DispenserItems[i].OilToolInstallationFormID = id
	}

	if err := h.svc.Update(c.Request.Context(), &req); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, req)
}

func (h *OilToolInstallationFormsHandler) delete(c *gin.Context) {
	id, err := uuid.Parse(c.Param("id"))
	if err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": "invalid id"})
		return
	}
	if err := h.svc.Delete(c.Request.Context(), id); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.Status(http.StatusNoContent)
}

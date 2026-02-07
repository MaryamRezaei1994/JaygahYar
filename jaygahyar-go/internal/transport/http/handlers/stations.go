package handlers

import (
	"net/http"

	"github.com/gin-gonic/gin"
	"github.com/google/uuid"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/app/services"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
)

type StationsHandler struct {
	svc *services.StationService
}

func NewStationsHandler(svc *services.StationService) *StationsHandler {
	return &StationsHandler{svc: svc}
}

func (h *StationsHandler) Register(rg *gin.RouterGroup) {
	rg.GET("", h.getAll)
	rg.GET("/:id", h.getByID)
	rg.POST("", h.create)
	rg.PUT("/:id", h.update)
	rg.DELETE("/:id", h.delete)
}

func (h *StationsHandler) getAll(c *gin.Context) {
	list, err := h.svc.GetAll(c.Request.Context())
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, list)
}

func (h *StationsHandler) getByID(c *gin.Context) {
	id, err := uuid.Parse(c.Param("id"))
	if err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": "invalid id"})
		return
	}
	s, err := h.svc.GetByID(c.Request.Context(), id)
	if err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	if s == nil {
		c.Status(http.StatusNotFound)
		return
	}
	c.JSON(http.StatusOK, s)
}

func (h *StationsHandler) create(c *gin.Context) {
	var req entities.Station
	if err := c.ShouldBindJSON(&req); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	req.ID = uuid.Nil
	if err := h.svc.Create(c.Request.Context(), &req); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusCreated, req)
}

func (h *StationsHandler) update(c *gin.Context) {
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

	var req entities.Station
	if err := c.ShouldBindJSON(&req); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}

	existing.Name = req.Name
	existing.Address = req.Address
	existing.Phone = req.Phone
	existing.Mobile = req.Mobile
	existing.OwnerName = req.OwnerName
	existing.GasolineTankCount = req.GasolineTankCount
	existing.DieselTankCount = req.DieselTankCount

	if err := h.svc.Update(c.Request.Context(), existing); err != nil {
		c.JSON(http.StatusInternalServerError, gin.H{"error": err.Error()})
		return
	}
	c.JSON(http.StatusOK, existing)
}

func (h *StationsHandler) delete(c *gin.Context) {
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

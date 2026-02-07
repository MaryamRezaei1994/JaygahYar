package handlers

import (
	"net/http"

	"github.com/gin-gonic/gin"
	"github.com/google/uuid"

	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/app/services"
	"github.com/MaryamRezaei1994/JaygahYar/jaygahyar-go/internal/domain/entities"
)

type Stage3DeliveryFormsHandler struct {
	svc *services.Stage3DeliveryFormService
}

func NewStage3DeliveryFormsHandler(svc *services.Stage3DeliveryFormService) *Stage3DeliveryFormsHandler {
	return &Stage3DeliveryFormsHandler{svc: svc}
}

func (h *Stage3DeliveryFormsHandler) Register(rg *gin.RouterGroup) {
	rg.GET("/:id", h.getByID)
	rg.GET("/station/:stationId", h.getByStation)
	rg.POST("", h.create)
	rg.DELETE("/:id", h.delete)
}

func (h *Stage3DeliveryFormsHandler) getByID(c *gin.Context) {
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

func (h *Stage3DeliveryFormsHandler) getByStation(c *gin.Context) {
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

func (h *Stage3DeliveryFormsHandler) create(c *gin.Context) {
	var req entities.Stage3DeliveryForm
	if err := c.ShouldBindJSON(&req); err != nil {
		c.JSON(http.StatusBadRequest, gin.H{"error": err.Error()})
		return
	}
	req.ID = uuid.Nil
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

func (h *Stage3DeliveryFormsHandler) delete(c *gin.Context) {
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

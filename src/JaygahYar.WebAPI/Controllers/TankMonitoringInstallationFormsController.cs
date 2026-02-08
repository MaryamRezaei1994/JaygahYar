using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using JaygahYar.WebAPI.Helpers;
using JaygahYar.WebAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JaygahYar.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TankMonitoringInstallationFormsController : ControllerBase
{
    private readonly ITankMonitoringInstallationFormService _service;
    private readonly IWebHostEnvironment _env;

    public TankMonitoringInstallationFormsController(ITankMonitoringInstallationFormService service, IWebHostEnvironment env)
    {
        _service = service;
        _env = env;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TankMonitoringInstallationFormDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var dto = await _service.GetByIdAsync(id, cancellationToken);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpGet("station/{stationId:guid}")]
    public async Task<ActionResult<IReadOnlyList<TankMonitoringInstallationFormDto>>> GetByStation(Guid stationId, CancellationToken cancellationToken)
    {
        var list = await _service.GetByStationIdAsync(stationId, cancellationToken);
        return Ok(list);
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(134_217_728)] // 128MB
    public async Task<ActionResult<TankMonitoringInstallationFormDto>> Create([FromForm] TankMonitoringInstallationFormCreateFormRequest request, CancellationToken cancellationToken)
    {
        var uploadedPath = await UploadFileHelper.SaveAsync(
            request.UploadedFormFile,
            _env.ContentRootPath,
            "tank-monitoring",
            cancellationToken);

        var appRequest = new CreateTankMonitoringInstallationFormRequest(
            request.FormNumber,
            request.BuyerFullName,
            request.StationName,
            request.StationAddress,
            request.Mobile,
            request.TankCount,
            request.DeviceModel,
            request.DisplaySerialNumber,
            request.DeviceInstallationDate,
            request.DeviceCommissioningDate,
            uploadedPath
        );

        var dto = await _service.CreateAsync(appRequest, cancellationToken);
        return Ok(dto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _service.DeleteAsync(id, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}

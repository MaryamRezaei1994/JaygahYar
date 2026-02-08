using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using JaygahYar.WebAPI.Helpers;
using JaygahYar.WebAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JaygahYar.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Stage2DeliveryFormsController : ControllerBase
{
    private readonly IStage2DeliveryFormService _service;
    private readonly IWebHostEnvironment _env;

    public Stage2DeliveryFormsController(IStage2DeliveryFormService service, IWebHostEnvironment env)
    {
        _service = service;
        _env = env;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Stage2DeliveryFormDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var dto = await _service.GetByIdAsync(id, cancellationToken);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpGet("station/{stationId:guid}")]
    public async Task<ActionResult<IReadOnlyList<Stage2DeliveryFormDto>>> GetByStation(Guid stationId, CancellationToken cancellationToken)
    {
        var list = await _service.GetByStationIdAsync(stationId, cancellationToken);
        return Ok(list);
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(134_217_728)] // 128MB
    public async Task<ActionResult<Stage2DeliveryFormDto>> Create([FromForm] Stage2DeliveryFormCreateFormRequest request, CancellationToken cancellationToken)
    {
        var uploadedPath = await UploadFileHelper.SaveAsync(
            request.UploadedFormFile,
            _env.ContentRootPath,
            "stage2",
            cancellationToken);

        var appRequest = new CreateStage2DeliveryFormRequest(
            request.FormNumber,
            request.StationName,
            request.BuyerFullName,
            request.StationAddress,
            request.Mobile,
            request.DeviceInstallationDate,
            request.DeviceCommissioningDate,
            request.DispenserManufacturer,
            uploadedPath,
            request.Description
        );

        var dto = await _service.CreateAsync(appRequest, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _service.DeleteAsync(id, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}

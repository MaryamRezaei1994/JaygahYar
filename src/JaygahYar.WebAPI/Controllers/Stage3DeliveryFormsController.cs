using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using JaygahYar.WebAPI.Helpers;
using JaygahYar.WebAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace JaygahYar.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Stage3DeliveryFormsController : ControllerBase
{
    private readonly IStage3DeliveryFormService _service;
    private readonly IWebHostEnvironment _env;

    public Stage3DeliveryFormsController(IStage3DeliveryFormService service, IWebHostEnvironment env)
    {
        _service = service;
        _env = env;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Stage3DeliveryFormDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var dto = await _service.GetByIdAsync(id, cancellationToken);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpGet("station/{stationId:guid}")]
    public async Task<ActionResult<IReadOnlyList<Stage3DeliveryFormDto>>> GetByStation(Guid stationId, CancellationToken cancellationToken)
    {
        var list = await _service.GetByStationIdAsync(stationId, cancellationToken);
        return Ok(list);
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(134_217_728)] // 128MB
    public async Task<ActionResult<Stage3DeliveryFormDto>> Create([FromForm] Stage3DeliveryFormCreateFormRequest request, CancellationToken cancellationToken)
    {
        var uploadedPath = await UploadFileHelper.SaveAsync(
            request.UploadedFormFile,
            _env.ContentRootPath,
            "stage3",
            cancellationToken);

        var appRequest = new CreateStage3DeliveryFormRequest(
            request.FormNumber,
            request.StationName,
            request.BuyerFullName,
            request.StationAddress,
            request.Mobile,
            request.DeviceInstallationDate,
            request.DeviceCommissioningDate,
            request.DeviceModel,
            request.DeviceSerialNumber,
            uploadedPath,
            request.Description
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

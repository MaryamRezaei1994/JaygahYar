using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using JaygahYar.WebAPI.Helpers;
using JaygahYar.WebAPI.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JaygahYar.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OilToolInstallationFormsController : ControllerBase
{
    private readonly IOilToolInstallationFormService _service;
    private readonly IWebHostEnvironment _env;

    public OilToolInstallationFormsController(IOilToolInstallationFormService service, IWebHostEnvironment env)
    {
        _service = service;
        _env = env;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<OilToolInstallationFormDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var dto = await _service.GetByIdAsync(id, cancellationToken);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpGet("station/{stationId:guid}")]
    public async Task<ActionResult<IReadOnlyList<OilToolInstallationFormDto>>> GetByStation(Guid stationId, CancellationToken cancellationToken)
    {
        var list = await _service.GetByStationIdAsync(stationId, cancellationToken);
        return Ok(list);
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    [RequestSizeLimit(134_217_728)] // 128MB
    public async Task<ActionResult<OilToolInstallationFormDto>> Create([FromForm] OilToolInstallationFormCreateFormRequest request, CancellationToken cancellationToken)
    {
        var installationFormPath = await UploadFileHelper.SaveAsync(
            request.InstallationFormFile,
            _env.ContentRootPath,
            "oiltool",
            cancellationToken);

        var peymanegarTestPath = await UploadFileHelper.SaveAsync(
            request.PeymanegarTestFormFile,
            _env.ContentRootPath,
            "oiltool",
            cancellationToken);

        var appRequest = new CreateOilToolInstallationFormRequest(
            request.FormNumber,
            request.BuyerFullName,
            request.StationName,
            request.StationAddress,
            request.Mobile,
            request.DeviceInstallationDate,
            request.CommissioningDate,
            installationFormPath,
            peymanegarTestPath
        );

        var dto = await _service.CreateAsync(appRequest, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<OilToolInstallationFormDto>> Update(Guid id, [FromBody] UpdateOilToolInstallationFormRequest request, CancellationToken cancellationToken)
    {
        var dto = await _service.UpdateAsync(id, request, cancellationToken);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _service.DeleteAsync(id, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}

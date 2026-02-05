using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JaygahYar.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AfterSalesServiceReportsController : ControllerBase
{
    private readonly IAfterSalesServiceReportService _service;

    public AfterSalesServiceReportsController(IAfterSalesServiceReportService service) => _service = service;

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AfterSalesServiceReportDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var dto = await _service.GetByIdAsync(id, cancellationToken);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpGet("station/{stationId:guid}")]
    public async Task<ActionResult<IReadOnlyList<AfterSalesServiceReportDto>>> GetByStation(Guid stationId, CancellationToken cancellationToken)
    {
        var list = await _service.GetByStationIdAsync(stationId, cancellationToken);
        return Ok(list);
    }

    [HttpPost]
    public async Task<ActionResult<AfterSalesServiceReportDto>> Create([FromBody] CreateAfterSalesServiceReportRequest request, CancellationToken cancellationToken)
    {
        var dto = await _service.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _service.DeleteAsync(id, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}

using JaygahYar.Application.DTOs;
using JaygahYar.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JaygahYar.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class Stage3DeliveryFormsController : ControllerBase
{
    private readonly IStage3DeliveryFormService _service;

    public Stage3DeliveryFormsController(IStage3DeliveryFormService service) => _service = service;

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
    public async Task<ActionResult<Stage3DeliveryFormDto>> Create([FromBody] CreateStage3DeliveryFormRequest request, CancellationToken cancellationToken)
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

using JaygahYar.Application.DTOs;
using JaygahYar.Application.Exceptions;
using JaygahYar.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JaygahYar.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StationsController : ControllerBase
{
    private readonly IStationService _stationService;

    public StationsController(IStationService stationService) => _stationService = stationService;

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<StationDto>>> GetAll(CancellationToken cancellationToken)
    {
        var list = await _stationService.GetAllAsync(cancellationToken);
        return Ok(list);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StationDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var dto = await _stationService.GetByIdAsync(id, cancellationToken);
        return dto == null ? NotFound() : Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<StationDto>> Create([FromBody] CreateStationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var dto = await _stationService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }
        catch (DuplicateNameException ex)
        {
            return Conflict(new ProblemDetails
            {
                Title = "Duplicate name",
                Detail = ex.Message,
                Status = StatusCodes.Status409Conflict
            });
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<StationDto>> Update(Guid id, [FromBody] UpdateStationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var dto = await _stationService.UpdateAsync(id, request, cancellationToken);
            return dto == null ? NotFound() : Ok(dto);
        }
        catch (DuplicateNameException ex)
        {
            return Conflict(new ProblemDetails
            {
                Title = "Duplicate name",
                Detail = ex.Message,
                Status = StatusCodes.Status409Conflict
            });
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _stationService.DeleteAsync(id, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}

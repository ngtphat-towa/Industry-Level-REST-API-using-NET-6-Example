using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;
[ApiController]
[Route("breakfasts")]
public class BreakfastController : ControllerBase
{
    private readonly IBreakfastService _breakfastService;

    public BreakfastController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        _breakfastService.CreateBreakfast(breakfast);

        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description!,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory!,
            breakfast.Sweet!
        );
        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new { id = breakfast.Id },
            value: response
        );
    }
    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        Breakfast breakfast = _breakfastService.GetBreakfast(id);
        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description!,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory!,
            breakfast.Sweet!
        );
        return Ok(breakfast);
    }
    [HttpPut("{id:guid}")]
    public IActionResult UpdateBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );
        _breakfastService.UpsertBreakfast(breakfast);

        // TODO : return 201 if a new breakfast was created
        return NoContent();
    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        _breakfastService.DeleteBreafast(id);
        return NoContent();
    }
}



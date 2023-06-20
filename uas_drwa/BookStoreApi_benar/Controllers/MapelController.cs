using System.Net;
using UasDRWA.Models;
using UasDRWA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MapelController : ControllerBase
{
    private readonly MapelService _mapelService;

    public MapelController(MapelService mapelService) =>
        _mapelService = mapelService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<Mapel>> Get() =>
        await _mapelService.GetAsync();

    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Mapel>> Get(string id)
    {
        var mapel = await _mapelService.GetAsync(id);

        if (mapel is null)
        {
            return NotFound();
        }

        return mapel;
    }

    // public HttpResponseMessage Post(Book book)
    //     {
    //         if (ModelState.IsValid)
    //         {
    //             // Do something with the product (not shown).

    //             return new HttpResponseMessage(HttpStatusCode.OK);
    //         }
    //         else
    //         {
    //             return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
    //         }
    //     }

    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <param name="item"></param>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(Mapel newMapel)
    {
        await _mapelService.CreateAsync(newMapel);

        return CreatedAtAction(nameof(Get), new { id = newMapel.Id }, newMapel);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, Mapel updatedMapel)
    {
        var mapel = await _mapelService.GetAsync(id);

        if (mapel is null)
        {
            return NotFound();
        }

        updatedMapel.Id = mapel.Id;

        await _mapelService.UpdateAsync(id, updatedMapel);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _mapelService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _mapelService.RemoveAsync(id);

        return NoContent();
    }
}
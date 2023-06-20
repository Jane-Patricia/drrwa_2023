using System.Net;
using UasDRWA.Models;
using UasDRWA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresensiMengajarController : ControllerBase
{
    private readonly PresensiMengajarService _presensiMengajarService;

    public PresensiMengajarController(PresensiMengajarService presensiMengajarService) =>
        _presensiMengajarService = presensiMengajarService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<PresensiMengajar>> Get() =>
        await _presensiMengajarService.GetAsync();

    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PresensiMengajar>> Get(string id)
    {
        var presensi = await _presensiMengajarService.GetAsync(id);

        if (presensi is null)
        {
            return NotFound();
        }

        return presensi;
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
    public async Task<IActionResult> Post(PresensiMengajar newPresensi)
    {
        await _presensiMengajarService.CreateAsync(newPresensi);

        return CreatedAtAction(nameof(Get), new { id = newPresensi.Id }, newPresensi);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, PresensiMengajar updatedPresensi)
    {
        var presensi = await _presensiMengajarService.GetAsync(id);

        if (presensi is null)
        {
            return NotFound();
        }

        updatedPresensi.Id = presensi.Id;

        await _presensiMengajarService.UpdateAsync(id, updatedPresensi);

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
        var presensi = await _presensiMengajarService.GetAsync(id);

        if (presensi is null)
        {
            return NotFound();
        }

        await _presensiMengajarService.RemoveAsync(id);

        return NoContent();
    }
}
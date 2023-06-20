using System.Net;
using UasDRWA.Models;
using UasDRWA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UasDRWA.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KelasController : ControllerBase
{
    private readonly KelasService _kelasService;

    public KelasController(KelasService kelasService) =>
        _kelasService = kelasService;

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<Kelas>> Get() =>
        await _kelasService.GetAsync();

    [HttpGet("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Kelas>> Get(string id)
    {
        var kelas = await _kelasService.GetAsync(id);

        if (kelas is null)
        {
            return NotFound();
        }

        return kelas;
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
    public async Task<IActionResult> Post(Kelas newKelas)
    {
        await _kelasService.CreateAsync(newKelas);

        return CreatedAtAction(nameof(Get), new { id = newKelas.Id }, newKelas);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, Kelas updatedKelas)
    {
        var kelas = await _kelasService.GetAsync(id);

        if (kelas is null)
        {
            return NotFound();
        }

        updatedKelas.Id = kelas.Id;

        await _kelasService.UpdateAsync(id, updatedKelas);

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
        var book = await _kelasService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _kelasService.RemoveAsync(id);

        return NoContent();
    }
}
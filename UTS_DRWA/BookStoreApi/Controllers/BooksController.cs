using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BooksService _booksService;

    public BooksController(BooksService booksService) =>
        _booksService = booksService;

    [HttpGet]
    public async Task<List<Guru>> Get() =>
        await _booksService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Guru>> Get(string id)
    {
        var guru = await _booksService.GetAsync(id);

        if (guru is null)
        {
            return NotFound();
        }

        return guru;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Guru newGuru)
    {
        await _booksService.CreateAsync(newGuru);

        return CreatedAtAction(nameof(Get), new { id = newGuru.Id }, newGuru);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Guru updatedGuru)
    {
        var guru = await _booksService.GetAsync(id);

        if (guru is null)
        {
            return NotFound();
        }

        updatedGuru.Id = guru.Id;

        await _booksService.UpdateAsync(id, updatedGuru);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var guru = await _booksService.GetAsync(id);

        if (guru is null)
        {
            return NotFound();
        }

        await _booksService.RemoveAsync(id);

        return NoContent();
    }
}
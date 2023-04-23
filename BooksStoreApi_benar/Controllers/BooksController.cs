using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreApi.Controllers;

[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[ApiController]
public class BooksController : ApiController
{
    private readonly BooksService _booksService;

    public BooksController(BooksService booksService) =>
        _booksService = booksService;

        [System.Web.Http.HttpPost]
        // [ValidateModel]
        public HttpResponseMessage Post (Book book)
        {
        if (ModelState.IsValid)
            {
                // Do something with the product (not shown).

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
          }

    [System.Web.Http.HttpGet]
    public async Task<List<Book>> Get() =>
        await _booksService.GetAsync();

    [System.Web.Http.HttpGet()]
    public async Task<ActionResult<Book>> Get(string id)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return null;
        }

        return book;
    }

    // [HttpPost]
    // public async Task<IActionResult> Post(Book newBook)
    // {
    //     if (!ModelState.IsValid)
    //         return BadRequest(ModelState);

    //     await _booksService.CreateAsync(newBook);

    //     return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    // }

    [System.Web.Http.HttpPut()]
    public async Task<IActionResult> Update(string id, Book updatedBook)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return null;
        }

        updatedBook.Id = book.Id;

        await _booksService.UpdateAsync(id, updatedBook);

        return null;
    }

    [System.Web.Http.HttpDelete()]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return null;
        }

        await _booksService.RemoveAsync(id);

        return null;
    }

}
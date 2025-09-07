using cp4.Models;
using cp4.Services;
using Microsoft.AspNetCore.Mvc;

namespace cp4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : Controller
{
    private readonly BookService _service;

    public BookController(BookService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<Book>> Create(Book book)
    {
        await _service.InsertBook(book);
        return  CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetAll() => await _service.GetBooks();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Book>> GetById(string id)
    {
        var book = await  _service.GetBook(id);
        return book is null ? NotFound() : book;
    }

    [HttpPut("{id:length(24)}")]
    public async Task<ActionResult<Book>> Update(string id, Book book)
    {
        var existingBook = await _service.GetBook(id);
        if (existingBook is null) return  NotFound();

        book.Id = existingBook.Id;
        var updatedBook = await _service.UpdateBook(id, book);
        
        return updatedBook is null ? NotFound() : updatedBook;
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existingBook = await _service.GetBook(id);
        if (existingBook is null) return NotFound();
        
        var wasDeleted = await _service.DeleteBook(id);
        return wasDeleted ? NoContent() : NotFound();
    }
}
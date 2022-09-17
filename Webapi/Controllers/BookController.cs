using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;

namespace Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly BookServices _service;

    public BookController()
    {
        _service = new BookServices();
    }
    [HttpPost]
    public async Task<string> Create(Books book)
    {
        return await _service.AddBook(book);
    }

    [HttpGet]
    public async Task<List<Books>> Get(int id)

    {
        return await _service.GetBooks();
    }
    [HttpPut]
    public async Task<int> Put(Books book)

    {
        return await _service.UpdateBook(book);
    }
    [HttpDelete]
    public async Task<int> Delete(int id)

    {
        return await _service.DeleteBook(id);
    }
}


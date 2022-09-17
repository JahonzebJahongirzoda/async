using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;

namespace Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly AuthorServices _service;

    public AuthorController()
    {
        _service = new AuthorServices();
    }
    [HttpPost]
    public async Task<string> Create(Authors author)
    {
        return await _service.AddAuthor(author);

    }

    [HttpGet]
    public async Task<List<Authors>> Get()

    {
        return await _service.GetAuthors();
    }
    [HttpPut]
    public async Task<int> Put(Authors author)

    {
        return await _service.UpdateAuthor(author);
    }
    [HttpDelete]
    public async Task<int> Delete(int id)

    {
        return await _service.DeleteAuthor(id);
    }
















}

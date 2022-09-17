using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;

namespace Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly CategoryServices _service;

    public CategoryController()
    {
        _service = new CategoryServices();
    }
    [HttpPost]
    public async Task<string> Create(Categories category)
    {
        return await _service.AddCategory(category);
    }

    [HttpGet]
    public async Task<List<Categories>> Get()

    {
        return await _service.GetCategory();
    }
    [HttpPut]
    public async Task<int> Put(Categories category)

    {
        return await _service.UpdateCategory(category);
    }
    [HttpDelete]
    public async Task<int> Delete(int id)

    {
        return await _service.DeleteCategory(id);
    }
















}

using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;

namespace Webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly StudentServices _service;

    public StudentController()
    {
        _service = new StudentServices();
    }
    [HttpPost]
    public async Task<string> Create(Students student)
    {
        return await _service.AddStudent(student);
    }

    [HttpGet]
    public async Task<List<Students>> Get()

    {
        return await _service.GetStudents();
    }
    [HttpPut]
    public async Task<int> Put(Students student)

    {
        return await _service.UpdateStudent(student);
    }
    [HttpDelete]
    public async Task<int> Delete(int id)

    {
        return await _service.DeleteStudent(id);
    }
















}

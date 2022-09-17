namespace WebApi.Controllers;
using Domain;
using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]

public class GetBookDtoController : ControllerBase
{

    private GetBookDtoServices _getBookDtoService;
    public GetBookDtoController()
    {
        _getBookDtoService = new GetBookDtoServices();
    }

    [HttpGet]
    public async Task<List<GetBookDto>> GetGetBookDtoss()
    {
        return await _getBookDtoService.GetGetBookDtos();
    }


}
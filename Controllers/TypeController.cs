using Microsoft.AspNetCore.Mvc;
using NotesApi.DTOs;
using NotesApi.Services;

namespace NotesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TypeController : ControllerBase
{
    private readonly ITypeService _typeService;

    public TypeController(ITypeService typeService)
    {
        _typeService = typeService;
    }

    // GET: api/Type
    [HttpGet]
    public IActionResult GetAllTypes()
    {
        var types = _typeService.GetAllTypes();
        return Ok(types);
    }

    // GET: api/Type/{id}
    [HttpGet("{id}")]
    public IActionResult GetTypeById(int id)
    {
        var type = _typeService.GetTypeById(id);
        return type == null ? NotFound() : Ok(type);
    }

    // POST: api/Type
    [HttpPost]
    public IActionResult AddType([FromBody] TypeDto typeDto)
    {
        _typeService.AddType(typeDto);
        return CreatedAtAction(nameof(GetTypeById), new { id = typeDto.Id }, typeDto);
    }

    // PUT: api/Type/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateType(int id, [FromBody] TypeDto typeDto)
    {
        _typeService.UpdateType(id, typeDto);
        return NoContent();
    }
}
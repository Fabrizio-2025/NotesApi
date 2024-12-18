using Microsoft.AspNetCore.Mvc;
using NotesApi.DTOs;
using NotesApi.Services;

namespace NotesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/User
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    // GET: api/User/{id}
    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        return user == null ? NotFound() : Ok(user);
    }

    // POST: api/User
    [HttpPost]
    public IActionResult AddUser([FromBody] UserDto userDto)
    {
        _userService.AddUser(userDto);
        return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
    }

    // PUT: api/User/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] UserDto userDto)
    {
        _userService.UpdateUser(id, userDto);
        return NoContent();
    }
}
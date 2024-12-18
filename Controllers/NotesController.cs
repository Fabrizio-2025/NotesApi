using Microsoft.AspNetCore.Mvc;
using NotesApi.DTOs;
using NotesApi.Services;

namespace NotesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;

    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }

    // GET: api/Notes
    [HttpGet]
    public IActionResult GetAllNotes()
    {
        return Ok(_noteService.GetAllNotes());
    }

    // GET: api/Notes/{id}
    [HttpGet("{id}")]
    public IActionResult GetNoteById(int id)
    {
        var note = _noteService.GetNoteById(id);
        return note == null ? NotFound() : Ok(note);
    }

    // POST: api/Notes
    [HttpPost]
    public IActionResult AddNote([FromBody] NoteDto noteDto)
    {
        _noteService.AddNote(noteDto);
        // Aquí asumimos que las notas tienen un ID generado en la base de datos
        return CreatedAtAction(nameof(GetNoteById), new { id = noteDto.CreatedById }, noteDto);
    }

    // PUT: api/Notes/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateNote(int id, [FromBody] NoteDto noteDto)
    {
        _noteService.UpdateNote(id, noteDto);
        return NoContent();
    }

    // DELETE: api/Notes/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteNoteById(int id)
    {
        _noteService.DeleteNote(id);
        return NoContent();
    }

    // GET: api/Notes/category/{category}
    [HttpGet("category/{category}")]
    public IActionResult GetNotesByCategory(string category)
    {
        var notes = _noteService.GetNotesByCategory(category);
        return Ok(notes);
    }
}
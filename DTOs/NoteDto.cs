namespace NotesApi.DTOs;

public class NoteDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int TypeId { get; set; }       // Relación con Type
    public int CreatedById { get; set; }
}
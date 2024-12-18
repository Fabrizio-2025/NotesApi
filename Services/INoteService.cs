using NotesApi.DTOs;

namespace NotesApi.Services;

public interface INoteService
{
    IEnumerable<NoteDto> GetAllNotes();
    NoteDto GetNoteById(int id);
    void AddNote(NoteDto note);
    void UpdateNote(int id, NoteDto note);
    void DeleteNote(int id);
    IEnumerable<NoteDto> GetNotesByCategory(string category);
}
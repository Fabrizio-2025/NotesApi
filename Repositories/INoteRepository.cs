using NotesApi.Entities;

namespace NotesApi.Repositories;

public interface INoteRepository
{
    IEnumerable<Note> GetAllNotes();
    Note GetNoteById(int id);
    void AddNote(Note note);
    void UpdateNote(Note note);
    void DeleteNote(int id);
    IEnumerable<Note> GetNotesByCategory(string category);
}
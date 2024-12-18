using Microsoft.EntityFrameworkCore;
using NotesApi.Data;
using NotesApi.Entities;

namespace NotesApi.Repositories.Implementations
{
    public class NoteRepository : INoteRepository
    {
        private readonly NotesDbContext _context;

        public NoteRepository(NotesDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Note> GetAllNotes()
        {
            return _context.Notes
                .Include(n => n.CreatedBy) // Incluye el usuario creador
                .Include(n => n.Type)      // Incluye la categoría (Type)
                .ToList();
        }

        public Note GetNoteById(int id)
        {
            return _context.Notes
                .Include(n => n.CreatedBy)
                .Include(n => n.Type)
                .FirstOrDefault(n => n.Id == id);
        }

        public void AddNote(Note note)
        {
            note.CreatedAt = DateTime.UtcNow;
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        public void UpdateNote(Note updatedNote)
        {
            var existingNote = _context.Notes.Find(updatedNote.Id);
            if (existingNote != null)
            {
                existingNote.Title = updatedNote.Title;
                existingNote.Content = updatedNote.Content;
                existingNote.TypeId = updatedNote.TypeId;
                existingNote.CreatedById = updatedNote.CreatedById;

                _context.SaveChanges();
            }
        }

        public void DeleteNote(int id)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Note> GetNotesByCategory(string categoryName)
        {
            return _context.Notes
                .Include(n => n.Type)
                .Where(n => n.Type.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}

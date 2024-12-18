using NotesApi.DTOs;
using NotesApi.Entities;
using NotesApi.Repositories;

namespace NotesApi.Services.Implementations
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // Obtener todas las notas
        public IEnumerable<NoteDto> GetAllNotes()
        {
            return _noteRepository.GetAllNotes().Select(n => new NoteDto
            {
                Title = n.Title,
                Content = n.Content,
                TypeId = n.TypeId,
                CreatedById = n.CreatedById
            });
        }

        // Obtener una nota por ID
        public NoteDto GetNoteById(int id)
        {
            var note = _noteRepository.GetNoteById(id);
            return note == null ? null : new NoteDto
            {
                Title = note.Title,
                Content = note.Content,
                TypeId = note.TypeId,
                CreatedById = note.CreatedById
            };
        }

        // Agregar una nueva nota
        public void AddNote(NoteDto noteDto)
        {
            var note = new Note
            {
                Title = noteDto.Title,
                Content = noteDto.Content,
                TypeId = noteDto.TypeId,
                CreatedById = noteDto.CreatedById,
                CreatedAt = DateTime.UtcNow
            };
            _noteRepository.AddNote(note);
        }
        

        // Actualizar una nota existente
        public void UpdateNote(int id, NoteDto noteDto)
        {
            var note = new Note
            {
                Id = id,
                Title = noteDto.Title,
                Content = noteDto.Content,
                TypeId = noteDto.TypeId,
                CreatedById = noteDto.CreatedById
            };
            _noteRepository.UpdateNote(note);
        }

        // Eliminar una nota por ID
        public void DeleteNote(int id)
        {
            _noteRepository.DeleteNote(id);
        }

        // Obtener todas las notas por categoría (Type)
        public IEnumerable<NoteDto> GetNotesByCategory(string categoryName)
        {
            return _noteRepository.GetNotesByCategory(categoryName).Select(n => new NoteDto
            {
                Title = n.Title,
                Content = n.Content,
                TypeId = n.TypeId,
                CreatedById = n.CreatedById
            });
        }
    }
}

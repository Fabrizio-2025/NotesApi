using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApi.Entities;

public class Type
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Descripcion { get; set; }

    // Relación uno a muchos: Un tipo puede ser asignado a muchas notas
    public ICollection<Note> Notes { get; set; }
}
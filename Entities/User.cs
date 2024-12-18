using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApi.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Nickname { get; set; }

    // Relación uno a muchos: Un usuario puede tener muchas notas
    public ICollection<Note> Notes { get; set; }
}
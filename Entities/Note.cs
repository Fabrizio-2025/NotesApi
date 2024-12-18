using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApi.Entities;

public class Note
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Content { get; set; }

    [Required] 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Relación con Usuario
    [Required]
    public int CreatedById { get; set; } // Clave foránea a Usuario
    public User CreatedBy { get; set; }
    
    // Relación con Type
    [Required]
    public int TypeId { get; set; } // Clave foránea a Type
    public Type Type { get; set; }
}
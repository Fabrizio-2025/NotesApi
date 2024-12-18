using NotesApi.Entities;
using Type = NotesApi.Entities.Type;

namespace NotesApi.Data;
using Microsoft.EntityFrameworkCore;

public class NotesDbContext : DbContext
{
    
    public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
    {
    }

    public DbSet<Note> Notes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Type> Types { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración opcional para la tabla Notes
        modelBuilder.Entity<Note>(entity =>
        {
            entity.Property(n => n.CreatedAt)
                .HasDefaultValueSql("NOW()"); // Asigna un valor predeterminado
        });

        base.OnModelCreating(modelBuilder);
    }
}
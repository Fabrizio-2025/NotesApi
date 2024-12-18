using NotesApi.Data;
using NotesApi.DTOs;
using Type = NotesApi.Entities.Type;

namespace NotesApi.Repositories.Implementations;

public class TypeRepository : ITypeRepository
{
    private readonly NotesDbContext _context;

    public TypeRepository(NotesDbContext context)
    {
        _context = context;
    }

    public IEnumerable<TypeDto> GetAllTypes()
    {
        return _context.Types.Select(t => new TypeDto
        {
            Id = t.Id,
            Name = t.Name,
            Description = t.Descripcion
        }).ToList();
    }

    public TypeDto GetTypeById(int id)
    {
        var type = _context.Types.Find(id);
        return type == null ? null : new TypeDto
        {
            Id = type.Id,
            Name = type.Name,
            Description = type.Descripcion
        };
    }

    public void AddType(TypeDto typeDto)
    {
        var type = new Type
        {
            Name = typeDto.Name,
            Descripcion = typeDto.Description
        };
        _context.Types.Add(type);
        _context.SaveChanges();
    }

    public void UpdateType(int id, TypeDto typeDto)
    {
        var type = _context.Types.Find(id);
        if (type != null)
        {
            type.Name = typeDto.Name;
            type.Descripcion = typeDto.Description;
            _context.SaveChanges();
        }
    }
}
using NotesApi.DTOs;
using NotesApi.Repositories;

namespace NotesApi.Services.Implementations;

public class TypeService : ITypeService
{
    private readonly ITypeRepository _typeRepository;

    public TypeService(ITypeRepository typeRepository)
    {
        _typeRepository = typeRepository;
    }

    public IEnumerable<TypeDto> GetAllTypes()
    {
        return _typeRepository.GetAllTypes();
    }

    public TypeDto GetTypeById(int id)
    {
        return _typeRepository.GetTypeById(id);
    }

    public void AddType(TypeDto typeDto)
    {
        _typeRepository.AddType(typeDto);
    }

    public void UpdateType(int id, TypeDto typeDto)
    {
        _typeRepository.UpdateType(id, typeDto);
    }
}
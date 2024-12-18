using NotesApi.DTOs;

namespace NotesApi.Repositories;

public interface ITypeRepository
{
    IEnumerable<TypeDto> GetAllTypes();
    TypeDto GetTypeById(int id);
    void AddType(TypeDto typeDto);
    void UpdateType(int id, TypeDto typeDto);
}
using NotesApi.DTOs;

namespace NotesApi.Services;

public interface ITypeService
{
    IEnumerable<TypeDto> GetAllTypes();
    TypeDto GetTypeById(int id);
    void AddType(TypeDto typeDto);
    void UpdateType(int id, TypeDto typeDto);
}
using NotesApi.DTOs;

namespace NotesApi.Repositories;

public interface IUserRepository
{
    IEnumerable<UserDto> GetAllUsers();
    UserDto GetUserById(int id);
    void AddUser(UserDto userDto);
    void UpdateUser(int id, UserDto userDto);
}
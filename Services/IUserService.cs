using NotesApi.DTOs;

namespace NotesApi.Services;

public interface IUserService
{
    IEnumerable<UserDto> GetAllUsers();
    UserDto GetUserById(int id);
    void AddUser(UserDto userDto);
    void UpdateUser(int id, UserDto userDto);
}
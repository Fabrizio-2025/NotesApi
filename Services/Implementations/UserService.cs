using NotesApi.DTOs;
using NotesApi.Repositories;

namespace NotesApi.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IEnumerable<UserDto> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    public UserDto GetUserById(int id)
    {
        return _userRepository.GetUserById(id);
    }

    public void AddUser(UserDto userDto)
    {
        _userRepository.AddUser(userDto);
    }

    public void UpdateUser(int id, UserDto userDto)
    {
        _userRepository.UpdateUser(id, userDto);
    }
}
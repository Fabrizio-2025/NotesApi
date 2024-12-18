using NotesApi.Data;
using NotesApi.DTOs;
using NotesApi.Entities;

namespace NotesApi.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly NotesDbContext _context;

    public UserRepository(NotesDbContext context)
    {
        _context = context;
    }

    public IEnumerable<UserDto> GetAllUsers()
    {
        return _context.Users.Select(u => new UserDto
        {
            Id = u.Id,
            Nombre = u.Nombre,
            Nickname = u.Nickname
        }).ToList();
    }

    public UserDto GetUserById(int id)
    {
        var user = _context.Users.Find(id);
        return user == null ? null : new UserDto
        {
            Id = user.Id,
            Nombre = user.Nombre,
            Nickname = user.Nickname
        };
    }

    public void AddUser(UserDto userDto)
    {
        var user = new User
        {
            Nombre = userDto.Nombre,
            Nickname = userDto.Nickname
        };
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void UpdateUser(int id, UserDto userDto)
    {
        var user = _context.Users.Find(id);
        if (user != null)
        {
            user.Nombre = userDto.Nombre;
            user.Nickname = userDto.Nickname;
            _context.SaveChanges();
        }
    }
}
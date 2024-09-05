using GreenGoat.Core.Entities;
namespace GreenGoat.Core.Interfaces;

public interface IUserService{
    Task<User> GetUserByIdAsync(int id);
    Task<IEnumerable<User?>> GetAllUsersAsync();
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
}

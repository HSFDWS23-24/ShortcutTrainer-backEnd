using ShortcutTrainerBackend.Data.Models;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(UserParameter request);
        Task<User> AddUserAsync(User newUser);
        Task<User> UpdateUserAsync(User updatedUser);
    }
}

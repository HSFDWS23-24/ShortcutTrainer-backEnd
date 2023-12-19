using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Data.TransferObjects;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<DtoUser>> GetUsersAsync();
        Task<DtoUser> GetUserAsync(UserParameter request);
        Task<DtoUser> AddUserAsync(User newUser);
        Task<DtoUser> UpdateUserAsync(User updatedUser);
    }
}

using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Data.TransferObjects;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<DtoUser>> GetUsersAsync();
        Task<DtoUser> GetUserAsync(UserParameter request);
        Task<bool> AddUserAsync(UserParameter request);
        Task<bool> UpdateUserAsync(UserParameter request);
    }
}

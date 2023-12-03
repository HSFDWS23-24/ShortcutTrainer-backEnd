using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IMockDatabase<User> _mockDatabase;
        public UserService(IMockDatabase<User> mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(UserParameter request)
        {
            var user = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == request.UserID);

            if (user != null)
            {
                return await Task.FromResult(new List<User>());
            }
            return await Task.FromResult(Enumerable.Empty<User>());
        }
    }
}

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
            var userList = _mockDatabase.DataStore;

            if (userList != null)
            {
                return await Task.FromResult(_mockDatabase.DataStore);
            }
            return await Task.FromResult(Enumerable.Empty<User>());
        }

        public async Task<User> GetUserAsync(UserParameter request)
        {
            var user = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == request.UserID);

            if (user != null)
            {
                //var userList = new List<User>();
                //userList.Add(user);

                return await Task.FromResult(user);
            }
            return await Task.FromResult(new User());
        }

        public async Task<User> AddUserAsync(User newUser)
        {
            if (newUser == null)
            {
                throw new ArgumentNullException(nameof(newUser));
            }

            // Check if the user already exists
            var existingUser = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == newUser.Id);

            if (existingUser != null)
            {
                //Check if the user should be updated, if already exists
                throw new InvalidOperationException("User with the same ID already exists");
            }

            // Add the new user to the database
            _mockDatabase.DataStore.Add(newUser);

            // Simulate asynchronous operation with Task.Delay
            await Task.Delay(1);

            return newUser;
        }

        public async Task<User> UpdateUserAsync(User updatedUser)
        {
            if (updatedUser == null)
            {
                throw new ArgumentNullException(nameof(updatedUser));
            }

            // Find the user in the database
            var existingUser = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == updatedUser.Id);

            if (existingUser == null)
            {
                throw new InvalidOperationException("User does not exist");
            }

            // Update the user properties in the DataStore
            existingUser.Name = updatedUser.Name;
            existingUser.Email = updatedUser.Email;
            existingUser.PreferedLanguage = updatedUser.PreferedLanguage;
            existingUser.PreferedKeyboardLayout = updatedUser.PreferedKeyboardLayout;
            existingUser.PreferedOperatingSystem = updatedUser.PreferedOperatingSystem;
            // Add other properties as needed

            // Simulate asynchronous operation with Task.Delay
            await Task.Delay(1);

            return existingUser;
        }
    }
}

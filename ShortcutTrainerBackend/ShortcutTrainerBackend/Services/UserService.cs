using DevExpress.Xpo;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Data.TransferObjects;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Services
{
    public class UserService : IUserService
    {
        public UserService(Session session)
        {
            _session = session;
        }

        private readonly Session _session;

        //public async Task<IEnumerable<DtoUser>> GetUsersAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<DtoUser> GetUserAsync(UserParameter request)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<DtoUser> AddUserAsync(UserParameter request)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<DtoUser> UpdateUserAsync(UserParameter request)
        //{
        //    throw new NotImplementedException();
        //}

        private User UserParameterToUser(UserParameter parameter)
        {
            User user = new User(_session)
            {
                Id = parameter.UserID,
                Name = parameter.Name,
                Email = parameter.Email,
                PreferredKeyboardLayout = parameter.PreferredKeyboardLayout,
                PreferredLanguage = parameter.PreferredLanguage,
                PreferredOperatingSystem = parameter.PreferredOperatingSystem
            };
            return user;
        }

        public IEnumerable<DtoUser> GetUsers()
        {
            var users = new XPCollection<User>(_session)
                .Select(q => new DtoUser
                {
                    Id = q.Id,
                    Email = q.Email,
                    Name = q.Name,
                    PreferredKeyboardLayout = q.PreferredKeyboardLayout,
                    PreferredLanguage = q.PreferredLanguage,
                    PreferredOperatingSystem = q.PreferredOperatingSystem
                });

            return users;
        }
        public DtoUser GetUser(string userId)
        {
            var users = new XPCollection<User>(_session)
                .Where(q => q.Id == userId)
                .Select(q => new DtoUser
                {
                    Id = q.Id,
                    Email = q.Email,
                    Name = q.Name,
                    PreferredKeyboardLayout = q.PreferredKeyboardLayout,
                    PreferredLanguage = q.PreferredLanguage,
                    PreferredOperatingSystem = q.PreferredOperatingSystem
                });

            if (users.Any())
                return users.FirstOrDefault(q => q.Id == userId);
            else
                return new DtoUser()
                {
                    Id = default(Guid).ToString(),
                    Name = string.Empty,
                    Email = string.Empty
                };
        }
        public DtoUser AddUser(User user)
        {
            var users = new XPCollection<User>(_session);
            users.Add(user);

            return GetUser(user.Id);
        }
        public DtoUser UpdateUser(User user)
        {
            var users = new XPCollection<User>(_session);

            var oldUser = users.FirstOrDefault(u => u.Id.Equals(user.Id));
            users.Remove(oldUser);

            users.Add(user);

            return GetUser(user.Id);
        }

        public async Task<IEnumerable<DtoUser>> GetUsersAsync()
        {
            return await Task.FromResult(GetUsers());
        }

        public async Task<DtoUser> GetUserAsync(UserParameter request)
        {
            return await Task.FromResult(GetUser(request.UserID));
        }

        public async Task<DtoUser> AddUserAsync(UserParameter request)
        {
            var oldUser = GetUser(request.UserID);

            if (!oldUser.Id.Equals(default(Guid).ToString()))
            {
                return await Task.FromResult(new DtoUser()
                {
                    Id = default(Guid).ToString(),
                    Name = string.Empty,
                    Email = string.Empty
                });
            }
            var user = UserParameterToUser(request);
            return await Task.FromResult(AddUser(user));
        }

        public async Task<DtoUser> UpdateUserAsync(UserParameter request)
        {
            var oldUser = GetUser(request.UserID);

            if (!oldUser.Id.Equals(request.UserID))
            {
                return await Task.FromResult(new DtoUser()
                {
                    Id = default(Guid).ToString(),
                    Name = string.Empty,
                    Email = string.Empty
                });
            }

            var user = UserParameterToUser(request);
            return await Task.FromResult(UpdateUser(user));
        }
    }
}

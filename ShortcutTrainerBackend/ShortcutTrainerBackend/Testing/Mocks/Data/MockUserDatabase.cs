using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Testing.Mocks.Data
{
    public class MockUserDatabase : IMockDatabase<User>
    {
        public List<User> DataStore { get; } = new List<User>
        {
             new()
             {
                 Id = Guid.NewGuid().ToString(),
                 Name = "User1",
                 Email = "harmonischsensibelerhamster@muell.xyz",
                 PreferedLanguage = "de-DE",
                 PreferedKeyboardLayout = "QWERTZ",
                 PreferedOperatingSystem = "Windows 10",
                 UserCourses = new List<UserCourse>()
             },
             new()
             {
                 Id = Guid.NewGuid().ToString(),
                 Name = "User2",
                 Email = "anziehendzaghaftergorilla@oida.icu",
                 PreferedLanguage = "de-DE",
                 PreferedKeyboardLayout = "QWERTZ",
                 PreferedOperatingSystem = "Windows 10",
                 UserCourses = new List<UserCourse>()
             },
             new()
             {
                 Id = Guid.NewGuid().ToString(),
                 Name = "User3",
                 Email = "charismatischliebenswerterfuchs@10minmail.de",
                 PreferedLanguage = "de-DE",
                 PreferedKeyboardLayout = "QWERTZ",
                 PreferedOperatingSystem = "Windows 10",
                 UserCourses = new List<UserCourse>()
             }
        };

        public async Task<IEnumerable<User>> GetDataAsync()
        {
            return await Task.FromResult(DataStore.AsEnumerable());
        }

        public async Task SetDataAsync(IEnumerable<User> data)
        {
            DataStore.AddRange(data);
            await Task.CompletedTask;
        }
    }
}
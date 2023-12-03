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
                 Email = "harmonischsensibelerhamster@muell.xyz"
             },
             new()
             {
                 Id = Guid.NewGuid().ToString(),
                 Name = "User2",
                 Email = "anziehendzaghaftergorilla@oida.icu"
             },
             new()
             {
                 Id = Guid.NewGuid().ToString(),
                 Name = "User3",
                 Email = "charismatischliebenswerterfuchs@10minmail.de"
             },
            // new()
            // {
            //     Id = 4,
            //     Content = "Was ist die Tastenkombination, um rückgängig zu machen?",
            //     Shortcut = "Strg+Z"
            // },
            // new()
            // {
            //     Id = 5,
            //     Content = "Wie öffnet man die Entwicklertools im Browser?",
            //     Shortcut = "Strg+Shift+I"
            // },
            // new()
            // {
            //     Id = 6,
            //     Content = "Tastenkombination zum Neuladen einer Seite im Browser?",
            //     Shortcut = "Strg+R"
            // }
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
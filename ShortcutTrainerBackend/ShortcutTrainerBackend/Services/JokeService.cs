using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Services;

public class JokeService : IJokeService
{
    public JokeService(IMockDatabase<Joke> mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    private readonly IMockDatabase<Joke> _mockDatabase;
    
    public async Task<Joke?> GetRandomJokeAsync()
    {
        return (await _mockDatabase.GetDataAsync()).FirstOrDefault();
    }

    public async Task<IEnumerable<Joke>?> GetRandomJokesAsync()
    {
        return await _mockDatabase.GetDataAsync();;
    }
}
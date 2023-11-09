using ShortcutTrainerBackend.Data.Models;

namespace ShortcutTrainerBackend.Services.Interfaces;

public interface IJokeService
{
    Task<IEnumerable<Joke>?> GetRandomJokesAsync();
}
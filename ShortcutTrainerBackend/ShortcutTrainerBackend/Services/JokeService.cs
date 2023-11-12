using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;
// ToDo: Namespaces organize related classes and prevent naming conflicts by providing a hierarchical structure in the
// code.
namespace ShortcutTrainerBackend.Services;
// ToDo: naming patterns in C# include Pascal Case for classes (SomeClass) and public properties (PublicProperty),
// underscore with Camel Case for private properties (_privateProperty) and descriptive names (instead of "GetRndJks"
// something like "GetRandomJokes")
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
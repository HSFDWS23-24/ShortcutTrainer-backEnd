
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Testing.Mocks.Data;

public class MockJokeDatabase : IMockDatabase<Joke>
{
    private readonly Random _random = new Random();
    public List<Joke> DataStore { get; } = new List<Joke>
    {
        new() { Id = 1, Content = "First Joke" },
        new() { Id = 2, Content = "Second Joke" },
        new() { Id = 3, Content = "Third Joke" },
        new() { Id = 4, Content = "Fourth Joke" },
        new() { Id = 5, Content = "Fifth Joke" }
    };
    
    public async Task<IEnumerable<Joke>> GetDataAsync()
    {
        await Task.Delay(2000); // wait 2 seconds before returning any result
        var randomCount = _random.Next(1, DataStore.Count);
        return DataStore.OrderBy(i => _random.Next()).Take(randomCount).ToList();
    }

    public async Task SetDataAsync(IEnumerable<Joke> data)
    {
        await Task.Delay(2000); // wait 2 seconds before returning any result
        DataStore.AddRange(data);
    }
}
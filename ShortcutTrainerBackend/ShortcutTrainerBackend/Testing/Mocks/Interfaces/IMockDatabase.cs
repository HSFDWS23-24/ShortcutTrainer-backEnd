namespace ShortcutTrainerBackend.Testing.Mocks.Interfaces;

public interface IMockDatabase<T>
{
    List<T> DataStore { get; }
    Task<IEnumerable<T>> GetDataAsync();
    Task SetDataAsync(IEnumerable<T> data);
    Task SaveChangesAsync();
}
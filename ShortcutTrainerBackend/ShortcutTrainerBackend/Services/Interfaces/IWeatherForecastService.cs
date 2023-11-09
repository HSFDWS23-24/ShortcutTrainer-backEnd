using ShortcutTrainerBackend.Data.Models;

namespace ShortcutTrainerBackend.Services.Interfaces;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecast>> GetRandomWeatherForecastAsync();
}
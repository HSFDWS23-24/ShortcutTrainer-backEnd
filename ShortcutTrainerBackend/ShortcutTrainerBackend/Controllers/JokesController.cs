using Microsoft.AspNetCore.Mvc;
using ShortcutTrainerBackend.Services.Interfaces;

namespace ShortcutTrainerBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JokesController : ControllerBase
{
    public JokesController(ILogger<JokesController> logger, IJokeService jokeService)
    {
        _logger = logger;
        _jokeService = jokeService;
    }
    
    private readonly ILogger<JokesController> _logger;
    private readonly IJokeService _jokeService;
    
    [HttpGet(Name = nameof(GetRandomJokes))]
    public async Task<IActionResult> GetRandomJokes()
    {
        var joke = await _jokeService.GetRandomJokesAsync();
        return Ok(joke);
    }
}
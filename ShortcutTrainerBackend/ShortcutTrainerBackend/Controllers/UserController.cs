using Microsoft.AspNetCore.Mvc;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;

namespace ShortcutTrainerBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("unanswered")]
        public async Task<IActionResult> GetUnansweredQuestionsAsync(int courseId, string language, string keyboardLayout)
        {
            try
            {
                var unansweredQuestions = await _userService.GetUnansweredQuestionsAsync(courseId, language, keyboardLayout);

                if (unansweredQuestions != null && unansweredQuestions.Any())
                {
                    return Ok(unansweredQuestions);
                }
                else
                {
                    return NotFound("Es wurden keine unbeantworteten Fragen gefunden.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen unbeantworteter Fragen: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }

        [HttpGet("incorrect")]
        public async Task<IActionResult> GetIncorrectQuestionsAsync(int courseId, string language, string keyboardLayout)
        {
            try
            {
                var incorrectQuestions = await _userService.GetIncorrectQuestionsAsync(courseId, language, keyboardLayout);

                if (incorrectQuestions != null && incorrectQuestions.Any())
                {
                    return Ok(incorrectQuestions);
                }
                else
                {
                    return NotFound("Es wurden keine falsch beantworteten Fragen gefunden.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen falsch beantworteter Fragen: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }

        [HttpGet("correct")]
        public async Task<IActionResult> GetCorrectQuestionsAsync(int courseId, string language, string keyboardLayout)
        {
            try
            {
                var correctQuestions = await _userService.GetCorrectQuestionsAsync(courseId, language, keyboardLayout);

                if (correctQuestions != null && correctQuestions.Any())
                {
                    return Ok(correctQuestions);
                }
                else
                {
                    return NotFound("Es wurden keine richtig beantworteten Fragen gefunden.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen richtig beantworteter Fragen: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }

        //Post-Methode
    }


}

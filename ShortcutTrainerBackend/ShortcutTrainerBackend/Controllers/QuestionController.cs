using Microsoft.AspNetCore.Mvc;
using ShortcutTrainerBackend.Services.Interfaces;

namespace ShortcutTrainerBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(ILogger<QuestionController> logger, IQuestionService questionService)
        {
            _logger = logger;
            _questionService = questionService;

        }

        [HttpGet(Name = nameof(GetQuestions))]
        public async Task<IActionResult> GetQuestions(string? userId, int courseId, string language, string system)
        {
            var questions = await _questionService.GetQuestionsAsync(userId, courseId, language, system);
            return Ok(questions);
        }

        [HttpGet("unanswered")]
        public async Task<IActionResult> GetUnansweredQuestions(string? userId, int courseId, string language, string system)
        {
            try
            {
                var unansweredQuestions = await _questionService.GetUnansweredQuestionsAsync(userId, courseId, language, system);

                return (unansweredQuestions.Any()) ?
                       Ok(unansweredQuestions) :
                       NotFound("Es wurden keine unbeantworteten Fragen gefunden.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen unbeantworteter Fragen: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }

        [HttpGet("incorrect")]
        public async Task<IActionResult> GetIncorrectQuestions(string? userId, int courseId, string language, string system)
        {
            try
            {
                var incorrectQuestions = await _questionService.GetIncorrectQuestionsAsync(userId, courseId, language, system);

                return (incorrectQuestions.Any()) ?
                       Ok(incorrectQuestions) :
                       NotFound("Es wurden keine falsch beantworteten Fragen gefunden.");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen falsch beantworteter Fragen: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }

        [HttpGet("correct")]
        public async Task<IActionResult> GetCorrectQuestions(string? userId, int courseId, string language, string system)
        {
            try
            {
                var correctQuestions = await _questionService.GetCorrectQuestionsAsync(userId, courseId, language, system);

                return (correctQuestions.Any()) ?
                       Ok(correctQuestions) :
                       NotFound("Es wurden keine richtig beantworteten Fragen gefunden.");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen richtig beantworteter Fragen: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }

        [HttpPost("updateAnswer")]
        public async Task<IActionResult> UpdateQuestionStatus(string? userId, int questionId, string questionStatus)
        {
            if (questionId <= 0 || !IsValidQuestionStatus(questionStatus))
            {
                return BadRequest("Invalid request data");
            }

            var updateResult = await _questionService.UpdateQuestionStatusAsync(userId, questionId, questionStatus);
            if (updateResult)
            {
                return Ok(new { Message = "Fragestatus erfolgreich aktualisiert", UpdatedQuestionStatus = questionStatus });
            }
            else
            {
                return BadRequest("Fehler beim Aktualisieren des Fragestatus");
            }
        }

        private bool IsValidQuestionStatus(string questionStatus)
        {
            return questionStatus == "Correct" || questionStatus == "Incorrect" || questionStatus == "Unanswered";
        }
    }
}

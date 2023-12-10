using Microsoft.AspNetCore.Mvc;
using ShortcutTrainerBackend.Data.Models;
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
        public async Task<IActionResult> GetQuestions([FromQuery] QuestionParameter request)
        {
            var questions = await _questionService.GetQuestionsAsync(request);
            return Ok(questions);
        }

        [HttpGet("unanswered")]
        public async Task<IActionResult> GetUnansweredQuestions([FromQuery] QuestionParameter request)
        {
            try
            {
                var unansweredQuestions = await _questionService.GetUnansweredQuestionsAsync(request);

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
        public async Task<IActionResult> GetIncorrectQuestions([FromQuery] QuestionParameter request)
        {
            try
            {
                var incorrectQuestions = await _questionService.GetIncorrectQuestionsAsync(request);

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
        public async Task<IActionResult> GetCorrectQuestions([FromQuery] QuestionParameter request)
        {
            try
            {
                var correctQuestions = await _questionService.GetCorrectQuestionsAsync(request);

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
        public async Task<IActionResult> UpdateQuestionStatus(int questionId, QuestionStatus result)
        {
            if (questionId <= 0 || !Enum.IsDefined(typeof(QuestionStatus), result))
            {
                return BadRequest("Invalid request data");
            }

            try
            {
               await _questionService.UpdateQuestionStatusAsync(questionId, result);
               return Ok(new { Message = "Fragestatus erfolgreich aktualisiert", UpdatedQuestionStatus = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

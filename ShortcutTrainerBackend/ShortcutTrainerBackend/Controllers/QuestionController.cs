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
        public async Task<IActionResult> GetUnansweredQuestions(int courseId, string language, string OperatingSystem)
        {
            try
            {
                var unansweredQuestions = await _questionService.GetUnansweredQuestions(courseId, language, OperatingSystem);

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
        public async Task<IActionResult> GetIncorrectQuestions(int courseId, string language, string OperatingSystem)
        {
            try
            {
                var incorrectQuestions = await _questionService.GetIncorrectQuestions(courseId, language, OperatingSystem);

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
        public async Task<IActionResult> GetCorrectQuestions(int courseId, string language, string OperatingSystem)
        {
            try
            {
                var correctQuestions = await _questionService.GetCorrectQuestions(courseId, language, OperatingSystem);

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

        //Post-Methode
        [HttpPost("updateAnswer")]
        public async Task<IActionResult> UpdateQuestionStatus(int questionId, QuestionStatus result)
        {
            //if (questionId <= 0 || !Enum.IsDefined(typeof(QuestionStatus), result) || !Enum.TryParse<QuestionStatus>(result.ToString(), out _))
            if (questionId <= 0 || !Enum.IsDefined(typeof(QuestionStatus), result))
            {
                return BadRequest("Invalid request data");
            }

            try
            {
               await _questionService.UpdateQuestionStatus(questionId, result);
               return Ok(new { Message = "Fragestatus erfolgreich aktualisiert", UpdatedQuestionStatus = result });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

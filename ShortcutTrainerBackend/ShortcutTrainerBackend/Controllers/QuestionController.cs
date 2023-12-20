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
        public async Task<IActionResult> GetQuestions(int courseId, string language, string system)
        {
            var questions = await _questionService.GetQuestionsAsync(courseId, language, system);
            return Ok(questions);
        }

        [HttpGet("unanswered")]
        public async Task<IActionResult> GetUnansweredQuestions(int courseId, string language, string system, string userId)
        {
            try
            {
                var unansweredQuestions = await _questionService.GetUnansweredQuestionsAsync(courseId, language, system, userId);

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
        public async Task<IActionResult> GetIncorrectQuestions(int courseId, string language, string system, string userId)
        {
            try
            {
                var incorrectQuestions = await _questionService.GetIncorrectQuestionsAsync(courseId, language, system, userId);

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
        public async Task<IActionResult> GetCorrectQuestions(int courseId, string language, string system, string userId)
        {
            try
            {
                var correctQuestions = await _questionService.GetCorrectQuestionsAsync(courseId, language, system, userId);

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
        public async Task<IActionResult> UpdateQuestionStatus(int questionId, string userId, string questionStatus)
        {
            if (questionId <= 0 || !IsValidQuestionStatus(questionStatus))
            {
                return BadRequest("Invalid request data");
            }

            try
            {
                await _questionService.UpdateQuestionStatusAsync(questionId, userId, questionStatus);
                return Ok(new { Message = "Fragestatus erfolgreich aktualisiert", UpdatedQuestionStatus = questionStatus });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        private bool IsValidQuestionStatus(string questionStatus)
        {
            return questionStatus == "Correct" || questionStatus == "Incorrect" || questionStatus == "Unanswered";
        }
    }
}

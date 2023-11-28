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

    }
}

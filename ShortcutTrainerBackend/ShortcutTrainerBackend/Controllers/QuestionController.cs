using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShortcutTrainerBackend.Controllers
{
    [Route("api/questions")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _questionService.GetAllQuestionsAsync();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var question = await _questionService.GetQuestionByIdAsync(id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        /*
        [HttpPost]
        public async Task<IActionResult> AddQuestion([FromBody] Question question)
        {
            if (question == null)
            {
                return BadRequest("Invalid question data");
            }

            await _questionService.AddQuestionAsync(question);

            return CreatedAtAction(nameof(GetQuestionById), new { id = question.Id }, question);
        }*/
    }
}


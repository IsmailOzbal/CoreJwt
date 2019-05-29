using Core2_2ApiJwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Core2_2ApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestions questions;
        public QuestionController(IQuestions _questions)
        {
            questions = _questions;
        }

        [HttpGet("GetQuestions")]
        public IActionResult GetQuestions(string Id)
        {
            var data = questions.GetQuestionList(10,Id);

            if (data == null)
                return BadRequest(new { message = "Questions data couldn`t get" });

            return Ok(data);
        }

    }
}
using Core2_2ApiJwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExamController : ControllerBase
    {
        private readonly ISolveExam solveExamData;
        private readonly IAddExam addExam;
        public ExamController(ISolveExam _solveExamData, IAddExam _addExam)
        {
            solveExamData = _solveExamData;
            addExam = _addExam;
        }

        [HttpGet("GetSolveExam")]
        public IActionResult GetSolveExam(string Id)
        {
            var data = solveExamData.GetExam(Id);

            if (data == null)
                return BadRequest(new { message = "Application don't find solved exam" });

            return Ok(data);
        }
        [HttpPost("AddExam")]
        public IActionResult InsertExamScore([FromBody]Exam exam)
        {
            bool retVal = addExam.AddExam(exam);

            if (retVal)
            {
                return Ok(new { message = "Application add exam score succesfully" });
            }
            else
            {
                return BadRequest(new { message = "Application don't insert exam score" });
            }

        }
   }
}
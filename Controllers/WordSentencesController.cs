using Core2_2ApiJwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WordSentencesController : ControllerBase
    {
        private readonly IAddSentence addSentences;
        public WordSentencesController(IAddSentence _addSentences)
        {
            addSentences = _addSentences; 
        }

        [HttpPost("AddSentences")]
        public IActionResult AddSentences([FromBody]WordSampleSentences wordSentences)
        {
            bool retVal = addSentences.Add(wordSentences);

            if (retVal == false)
                return BadRequest(new { message = "Words sentences dont add because application get some errors" });
            else
                return Ok(new { message = "Words sentences add succesfully" });
        }
    }
}
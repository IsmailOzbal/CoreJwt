using Core2_2ApiJwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WordController : ControllerBase
    {
        private readonly IGetWord getWord;
        private readonly IAddWord addWord;
        private readonly IUpdateWord updateWord;
        private readonly IDeleteWord deleteWord;
        public WordController(IGetWord _getWord, IAddWord _addWord, IUpdateWord _updateWord, IDeleteWord _deleteWord)
        {
            getWord = _getWord;
            addWord = _addWord;
            updateWord = _updateWord;
            deleteWord = _deleteWord;
        }

        [HttpGet("GetWord")]
        public IActionResult GetWord()
        {
            var data = getWord.GetWords();

            if (data == null)
                return BadRequest(new { message = "Words data couldn`t get" });

            return Ok(data);
        }

        [HttpPost("AddWord")]
        public IActionResult AddWord([FromBody]Words word)
        {
            bool retVal = addWord.Add(word);

            if (retVal == false)
                return BadRequest(new { message = "Words dont add because application get some errors" });
            else
                return Ok(new { message = "Words add succesfully" });
        }

        [HttpDelete("DeleteWord")]
        public IActionResult DeleteWord(int id)
        {
            bool retVal = deleteWord.Delete(id);

            if (retVal == false)
                return BadRequest(new { message = "Words dont delete because application get some errors" });
            else
                return Ok(new { message = "Words delete succesfully" });
        }

        [HttpPut("UpdateWord")]
        public IActionResult UpdateWord(int id, [FromBody]Words word)
        {
            bool retVal = updateWord.Update(id,word);
            if (retVal == false)
                return BadRequest(new { message = "Words dont update because application get some errors" });
            else
                return Ok(new { message = "Words update succesfully" });
        }




    }
}
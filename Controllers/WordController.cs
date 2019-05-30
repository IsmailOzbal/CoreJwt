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
        private readonly IGetWordLevel wordLevel;
        public WordController(IGetWord _getWord, IAddWord _addWord, IUpdateWord _updateWord, IDeleteWord _deleteWord, IGetWordLevel _wordLevel)
        {
            getWord = _getWord;
            addWord = _addWord;
            updateWord = _updateWord;
            deleteWord = _deleteWord;
            wordLevel = _wordLevel;
        }

        [HttpGet("GetWord")]
        public IActionResult GetWord()
        {
            var data = getWord.GetWords();

            if (data == null)
                return BadRequest(new { message = "Words data couldn`t get" });

            return Ok(data);
        }

        [HttpGet("GetWordLevel")]
        public IActionResult GetWordLevel()
        {
            var data = wordLevel.GetLevel();

            if (data == null)
                return BadRequest(new { message = "Word level data couldn`t get" });

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
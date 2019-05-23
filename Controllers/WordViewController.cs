using Core2_2ApiJwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core2_2ApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WordViewController : ControllerBase
    {
        private readonly IWordDetailView wordDetail;
        private readonly IWordDetailViewById wordDetailById;
        public WordViewController(IWordDetailView _wordDetail, IWordDetailViewById _wordDetailById)
        {
            wordDetail = _wordDetail;
            wordDetailById = _wordDetailById;
        }

        [HttpGet("GetWordDetailView")]
        public IActionResult GetWordDetailView()
        {
            var data = wordDetail.GetView();

            if (data == null)
                return BadRequest(new { message = "Word details data couldn`t get" });

            return Ok(data);
        }


        [HttpGet("GetWordDetailViewById")]
        public IActionResult GetWordDetailViewById(string id)
        {
            var data = wordDetailById.GetView(id);

            if (data == null)
                return BadRequest(new { message = "Word details data couldn`t get" });

            return Ok(data);
        }
    }
}
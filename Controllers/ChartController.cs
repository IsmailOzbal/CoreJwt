using Core2_2ApiJwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core2_2ApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChartController : ControllerBase
    {
        private readonly IGetChart chartData;
        private readonly IExamScore chartExamScoreData;
        public ChartController(IGetChart _chartData, IExamScore _chartExamScoreData)
        {
            chartData = _chartData;
            chartExamScoreData = _chartExamScoreData;
        }

        [HttpGet("GetChartData")]
        public IActionResult GetChart(string Id)
        {
            var data = chartData.GetChartDataValue(Id);

            if (data == null)
                return BadRequest(new { message = "Chart data couldn`t get" });

            return Ok(data);
        }

        [HttpGet("GetExamScore")]
        public IActionResult GetChartExamScore(string Id)
        {
            var data = chartExamScoreData.GetExamScore(Id);

            if (data == null)
                return BadRequest(new { message = "Exam score data couldn`t get" });

            return Ok(data);
        }


    }
}
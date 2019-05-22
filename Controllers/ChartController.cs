using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core2_2ApiJwt.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public IActionResult GetChart()
        {
            var data = chartData.GetChartDataValue();

            if (data == null)
                return BadRequest(new { message = "Chart data couldn`t get" });

            return Ok(data);
        }

        [HttpGet("GetExamScore")]
        public IActionResult GetChartExamScore()
        {
            var data = chartExamScoreData.GetExamScore();

            if (data == null)
                return BadRequest(new { message = "Exam score data couldn`t get" });

            return Ok(data);
        }


    }
}
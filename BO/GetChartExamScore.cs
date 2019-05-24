using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Entities.DTO;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class GetChartExamScore : IExamScore
    {
        private IUnitOfWork uow;
        private IGenericRepository<Exam> _examRepo;
        public GetChartExamScore(IUnitOfWork _uow)
        {
            uow = _uow;
            _examRepo = uow.GetRepository<Exam>();
        }
        public Chart GetExamScore()
        {

            Chart chart = new Chart();

            try
            {

                var data = _examRepo.GetAll().GroupBy(s => new { s.Score },
            (key, group) => new ChartScore
            {
                name = key.ToString(),
                count = group.Count()
            }).ToList();



                string[] list = data.Select(a => a.name).ToArray();
                int[] arrayData = data.Select(a => a.count).ToArray();
                string series = "Exam Result";

                chart.data = arrayData;
                chart.Labels = list;
                chart.series = series;
            }
            catch (Exception e)
            {
                chart.series = "Exam Result";
                return chart;
            }


            return chart;

        }
    }
}

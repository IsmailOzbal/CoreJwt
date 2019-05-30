using Core2_2ApiJwt.Entities.DTO;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class GetChartWordLevel : IGetChartWordLevel
    {
        private IUnitOfWork uow;
        private IGenericRepository<Words> _wordsRepo;
        private IGenericRepository<WordsLevel> _wordsLevelRepo;
        public GetChartWordLevel(IUnitOfWork _uow)
        {
            uow = _uow;
            _wordsRepo = uow.GetRepository<Words>();
            _wordsLevelRepo = uow.GetRepository<WordsLevel>();
        }
        public Chart GetChartLevel(string Id)
        {
            int userId = int.Parse(Id);
            var data = (from a in _wordsRepo.GetAll()
                        join b in _wordsLevelRepo.GetAll() on a.WordLevelId equals b.Id
                        where a.UserId == userId
                        group a by b.Level into ab
                        select new
                        {
                            name = ab.Key,
                            count = ab.Count()

                        }).ToList();

            string[] list = data.Select(a => a.name).ToArray();
            int[] arrayData = data.Select(a => a.count).ToArray();
            string series = "Word Level";

            Chart chart = new Chart();
            chart.data = arrayData;
            chart.Labels = list;
            chart.series = series;

            return chart;

        }
    }
}

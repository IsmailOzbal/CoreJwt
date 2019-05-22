using Core2_2ApiJwt.Entities.DTO;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class GetChartData : IGetChart
    {
        private IUnitOfWork uow;
        private IGenericRepository<Words> _wordsRepo;
        private IGenericRepository<WordType> _wordsTypeRepo;
        public GetChartData(IUnitOfWork _uow)
        {
            uow = _uow;
            _wordsRepo = uow.GetRepository<Words>();
            _wordsTypeRepo = uow.GetRepository<WordType>();
        }

        public Chart GetChartDataValue()
        {
            var data = (from a in _wordsRepo.GetAll()
                        join b in _wordsTypeRepo.GetAll() on a.WordTypeId equals b.Id
                        group a by b.Type into ab
                        select new
                        {
                            name = ab.Key,
                            count = ab.Count()

                        }).ToList();

                string[] list = data.Select(a => a.name).ToArray();
                int[] arrayData = data.Select(a => a.count).ToArray();
                string series = "WordType";

                Chart chart = new Chart();
                chart.data = arrayData;
                chart.Labels = list;
                chart.series = series;

                return chart;
            
        }
    }
}

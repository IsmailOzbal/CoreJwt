using Core2_2ApiJwt.Entities.DTO;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class GetNotCompleteWord : IGetNotCompleteWord
    {
        private IUnitOfWork uow;
        private IGenericRepository<Words> _wordsRepo;
        private IGenericRepository<WordDescription> _wordsDescRepo;
        public GetNotCompleteWord(IUnitOfWork _uow)
        {
            uow = _uow;
            _wordsRepo = uow.GetRepository<Words>();
            _wordsDescRepo = uow.GetRepository<WordDescription>();
        }
        public Chart GetAllNotCompleteWord(string Id)
        {
            Chart chartData = new Chart();
            int userId = int.Parse(Id);
            var wordData = _wordsRepo.GetAll().Where(a=>a.UserId==userId).Select(a => a.Id).ToList();
            var wordDesc = (from a in _wordsDescRepo.GetAll()
                            join b in _wordsRepo.GetAll() on a.WordsId equals b.Id
                            select a
                            ).Select(a=>a.WordsId).ToList();
            int notEntryWordDescCount = wordData.Except(wordDesc).Count();
            int EntryWordDescCount = wordData.Count() - notEntryWordDescCount;

            string[] labels = { "Complete Word","Not Complete Word"};
            int[] data = { EntryWordDescCount, notEntryWordDescCount };

            chartData.series = "Word Description Information";
            chartData.Labels = labels;
            chartData.data = data;

            return chartData;
        }
    }
}

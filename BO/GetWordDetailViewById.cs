using Core2_2ApiJwt.Entities.DTO;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class GetWordDetailViewById : IWordDetailViewById
    {
        private IUnitOfWork uow;
        private IGenericRepository<Words> _wordsRepo;
        private IGenericRepository<WordDescription> _wordsDescRepo;
        private IGenericRepository<WordSampleSentences> _wordsSentencesRepo;
        private IGenericRepository<WordType> _wordTypeRepo;
        public GetWordDetailViewById(IUnitOfWork _uow)
        {
            uow = _uow;
            _wordsRepo = uow.GetRepository<Words>();
            _wordsDescRepo = uow.GetRepository<WordDescription>();
            _wordsSentencesRepo = uow.GetRepository<WordSampleSentences>();
            _wordTypeRepo = uow.GetRepository<WordType>();
        }
        public List<WordView> GetView(string Id)
        {
            int id = Int32.Parse(Id);
            var data = (from a in _wordsRepo.GetAll().Where(a => a.Id == id)
                        join b in _wordTypeRepo.GetAll() on a.WordTypeId equals b.Id
                        join d in _wordsDescRepo.GetAll() on a.Id equals d.WordsId into gj
                        join s in _wordsSentencesRepo.GetAll() on a.Id equals s.WordId into sj
                        from x in gj.DefaultIfEmpty()
                        from y in sj.DefaultIfEmpty()
                        select new WordView
                        {
                            Id = a.Id,
                            Word = a.Word,
                            Type = b.Type,
                            Description = x.Description,
                            SampleSentences = y.SampleSentences
                        }).OrderByDescending(a => a.Id).ToList();

            return data;

        }
    }
}

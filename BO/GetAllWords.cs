using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class GetAllWords : IGetWord
    {
        private IUnitOfWork uow;
        private IGenericRepository<Words> _wordsRepo;
        private IGenericRepository<WordDescription> _wordsDesc;
        public GetAllWords(IUnitOfWork _uow)
        {
            uow = _uow;
            _wordsRepo = uow.GetRepository<Words>();
            _wordsDesc = uow.GetRepository<WordDescription>();
        }
        public List<Words> GetWords()
        {
            int[] desc = _wordsDesc.GetAll().Select(a => a.WordsId).ToArray();
            var fulldata = _wordsRepo.GetAll().ToList();
            var data = fulldata.Where(a => desc.Contains(a.Id)).ToList();
            var filterdata = fulldata.Except(data);
            return filterdata.ToList();
        }
    }
}

using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class GetWordLevel : IGetWordLevel
    {
        private IUnitOfWork uow;
        private IGenericRepository<WordsLevel> wordLevel;
        public GetWordLevel(IUnitOfWork _uow)
        {
            uow = _uow;
            wordLevel = uow.GetRepository<WordsLevel>();
        }
        public List<WordsLevel> GetLevel()
        {
            return wordLevel.GetAll().ToList();
        }
    }
}

using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class AddWord : IAddWord
    {
        private IUnitOfWork uow;
        private IGenericRepository<Words> _wordsRepo;
        private bool retVal;
        public AddWord(IUnitOfWork _uow)
        {
            uow = _uow;
            _wordsRepo = uow.GetRepository<Words>();
        }
        public bool Add(Words word)
        {
            try
            {
                _wordsRepo.Insert(word);
                uow.SaveChanges();
                retVal = true;
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }
    }
}

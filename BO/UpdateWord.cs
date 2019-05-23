using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class UpdateWord : IUpdateWord
    {
        private bool retVal;
        private IUnitOfWork uow;
        private IGenericRepository<Words> _wordsRepo;
        public UpdateWord(IUnitOfWork _uow)
        {
            uow = _uow;
            _wordsRepo = uow.GetRepository<Words>();
        }
        public bool Update(int id, Entity.Words word)
        {
            try
            {
                word.Id = id;
                _wordsRepo.Update(word);
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

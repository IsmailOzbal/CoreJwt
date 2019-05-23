using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class AddWordType : IAddWordType
    {
        private bool retVal;
        private IUnitOfWork uow;
        private IGenericRepository<WordType> _wordsTypeRepo;
        public AddWordType(IUnitOfWork _uow)
        {
            uow = _uow;
            _wordsTypeRepo = uow.GetRepository<WordType>();
        }
        public bool Add(WordType type)
        {
            try
            {
                _wordsTypeRepo.Insert(type);
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

using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Interfaces;
using System;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class AddWordDescription : IAddWordDescription
    {
        private bool retVal;
        private IUnitOfWork uow;
        private IGenericRepository<WordDescription> _wordDescriptionRepo;
        public AddWordDescription(IUnitOfWork _uow)
        {
            uow = _uow;
            _wordDescriptionRepo = uow.GetRepository<WordDescription>();
        }
        public bool Add(WordDescription wordDesc)
        {
            try
            {
                _wordDescriptionRepo.Insert(wordDesc);
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

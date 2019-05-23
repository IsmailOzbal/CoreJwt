using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class DeleteWord : IDeleteWord
    {
        private bool retVal;
        private IUnitOfWork uow;
        private IGenericRepository<Words> _wordsRepo;
        public DeleteWord(IUnitOfWork _uow)
        {
            uow = _uow;
            _wordsRepo = uow.GetRepository<Words>();
        }
        public bool Delete(int id)
        {
            try
            {
                var data = _wordsRepo.GetAll().Where(a => a.Id == id).FirstOrDefault();
                _wordsRepo.Delete(data);
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

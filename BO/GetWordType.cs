using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class GetWordType : IWordType
    {
        private IUnitOfWork uow;
        private IGenericRepository<WordType> _wordsTypeRepo;
        public GetWordType(IUnitOfWork _uow)
        {
            uow = _uow;
            _wordsTypeRepo = uow.GetRepository<WordType>();
        }
        public List<WordType> GetAll()
        {
            var data = _wordsTypeRepo.GetAll().ToList();

            return data;
        }
    }
}

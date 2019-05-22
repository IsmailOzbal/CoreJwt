using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class GetAllLanguage : ILanguauge
    {
        private IUnitOfWork uow;
        private IGenericRepository<Language> _langRepo;
        public GetAllLanguage(IUnitOfWork _uow)
        {
            uow = _uow;
            _langRepo = uow.GetRepository<Language>();
        }
        public List<Language> GetLanguage()
        {
            var data = _langRepo.GetAll().ToList();

            return data;
        }
    }
}

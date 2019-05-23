using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class AddSentence : IAddSentence
    {
        private IUnitOfWork uow;
        private IGenericRepository<WordSampleSentences> _wordSampleRepo;
        private bool retVal;
        public AddSentence(IUnitOfWork _uow)
        {
            uow = _uow;
            _wordSampleRepo = uow.GetRepository<WordSampleSentences>();
        }
        public bool Add(WordSampleSentences sentences)
        {
            try
            {
                _wordSampleRepo.Insert(sentences);
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

using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class AddExamScore : IAddExam
    {
        private IUnitOfWork uow;
        private IGenericRepository<Exam> _examRepo;
        private bool retVal;
        public AddExamScore(IUnitOfWork _uow)
        {
            uow = _uow;
            _examRepo = uow.GetRepository<Exam>();
        }

        public bool AddExam(Exam exam)
        {
            try
            {
                exam.InsertDate = DateTime.Now;
                _examRepo.Insert(exam);
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

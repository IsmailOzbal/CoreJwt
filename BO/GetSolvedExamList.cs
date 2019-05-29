using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Entities.DTO;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class GetSolvedExamList : ISolveExam
    {
        private IUnitOfWork uow;
        private IGenericRepository<Exam> _examRepo;
        private IGenericRepository<User> _userRepo;
        public GetSolvedExamList(IUnitOfWork _uow)
        {
            uow = _uow;
            _examRepo = uow.GetRepository<Exam>();
            _userRepo = uow.GetRepository<User>();
        }
        public List<ExamView> GetExam(string Id)
        {
            int userId = int.Parse(Id);
            var data = (from a in _examRepo.GetAll()
                        join b in _userRepo.GetAll() on a.UserId equals b.Id
                        where a.UserId==userId
                        select new ExamView
                        {
                            UserName = b.FirstName + " " + b.LastName,
                            Score = a.Score,
                            CreateDate = a.InsertDate.ToString(),
                        }
                       ).ToList();
            return data;
        }
    }
}

using Core2_2ApiJwt.Entities.DTO;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class GetQuestions : IQuestions
    {

        private IUnitOfWork uow;
        private IGenericRepository<Words> _wordsRepo;
        private IGenericRepository<WordDescription> _wordsDesc;
        public GetQuestions(IUnitOfWork _uow)
        {
            uow = _uow;
            _wordsRepo = uow.GetRepository<Words>();
            _wordsDesc = uow.GetRepository<WordDescription>();
        }
        public List<Questions> GetQuestionList(int count)
        {
            Random rnd = new Random();
            List<Questions> questions = new List<Questions>();
            var description = _wordsDesc.GetAll().ToList();
            var _words = _wordsRepo.GetAll().ToList();
            string[] words = _words.Select(a => a.Word).ToArray();
            string[] desc = description.Select(a => a.Description).ToArray();
            int length = words.Length - 1;

            for (int i = 0; i < count; i++)
            {

                var randomNumbers = Enumerable.Range(0, length).OrderBy(x => rnd.Next()).Take(5).ToList();
                int rand_number = randomNumbers[0];
                Questions que = new Questions();
                que.count = i + 1;
                que.tag = words[rand_number];
                int number = _words.Where(a => a.Word == words[rand_number]).Select(a => a.Id).FirstOrDefault();
                int answer = rnd.Next(1, 4);
                que.answerone = answer == 1 ? description.Where(a => a.WordsId == number).Select(a => a.Description).FirstOrDefault() : desc[randomNumbers[1]];
                que.answertwo = answer == 2 ? description.Where(a => a.WordsId == number).Select(a => a.Description).FirstOrDefault() : desc[randomNumbers[2]];
                que.answerthree = answer == 3 ? description.Where(a => a.WordsId == number).Select(a => a.Description).FirstOrDefault() : desc[randomNumbers[3]];
                que.answerfour = answer == 4 ? description.Where(a => a.WordsId == number).Select(a => a.Description).FirstOrDefault() : desc[randomNumbers[4]];
                que.correctanswer = description.Where(a => a.WordsId == number).Select(a => a.Description).FirstOrDefault();
                questions.Add(que);
            }

            return questions;

        }
    }
}

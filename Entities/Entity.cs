using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core2_2ApiJwt.Entities
{
    public class Entity
    {
        public class Language
        {
            [Key]
            public int Id { get; set; }
            public string Key { get; set; }
        }

        public class Words
        {
            [Key]
            public int Id { get; set; }
            public int WordTypeId { get; set; }
            public string Word { get; set; }
            public int UserId { get; set; }
            public int WordLevelId { get; set; }
        }

        public class WordsLevel
        {
            [Key]
            public int Id { get; set; }
            public string Level { get; set; }
        }

        public class WordDescription
        {
            [Key]
            public int Id { get; set; }
            public int WordsId { get; set; }
            public int LanguageTypeId { get; set; }
            public string Description { get; set; }
        }

        public class WordSampleSentences
        {
            [Key]
            public int Id { get; set; }
            public int WordId { get; set; }
            public string SampleSentences { get; set; }
        }

        public class WordType
        {
            [Key]
            public int Id { get; set; }
            public string Type { get; set; }
        }

        public class Exam
        {
            [Key]
            public int Id { get; set; }
            public int UserId { get; set; }
            public int Score { get; set; }
            public DateTime InsertDate { get; set; }
        }

        public class User
        {
            [Key]
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
        }
    }
}

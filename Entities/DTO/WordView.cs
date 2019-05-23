using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2_2ApiJwt.Entities.DTO
{
    public class WordView
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string SampleSentences { get; set; }
    }
}

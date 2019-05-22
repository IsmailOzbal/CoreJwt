using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2_2ApiJwt.Entities.DTO
{
    public class Chart
    {
        public string[] Labels { get; set; }

        public int[] data { get; set; }

        public string series { get; set; }
    }
}

﻿using Core2_2ApiJwt.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2_2ApiJwt.Interfaces
{
    public interface ISolveExam
    {
        List<ExamView> GetExam(string Id);
    }
}

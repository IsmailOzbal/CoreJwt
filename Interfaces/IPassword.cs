﻿using Core2_2ApiJwt.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.Interfaces
{
    public interface IPassword
    {
        bool Change(Password password);
    }
}

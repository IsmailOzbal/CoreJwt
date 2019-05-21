using Core2_2ApiJwt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2_2ApiJwt.Interfaces
{
    public interface IGetUser
    {
         List<User> GetUsers();
    }
}

using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2_2ApiJwt.BO
{
    public class GetAllUser : IGetUser
    {
        public List<User> GetUsers()
        {
            List<User> _users = new List<User>
            {
                 new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
            };
            return _users;
        }
    }
}

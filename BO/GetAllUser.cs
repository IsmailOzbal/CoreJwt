using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class GetAllUser : IGetUser
    {
        private IUnitOfWork uow;
        private IGenericRepository<User> user;
        public GetAllUser(IUnitOfWork _uow)
        {
            uow = _uow;
            user= uow.GetRepository<User>();
        }

        public List<User> GetUsers()
        {
            return user.GetAll().ToList();
        }
    }
}

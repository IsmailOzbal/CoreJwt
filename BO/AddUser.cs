using Core2_2ApiJwt.Entities;
using Core2_2ApiJwt.Helpers;
using Core2_2ApiJwt.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.BO
{
    public class AddUser : IAddUser
    {
        private IUnitOfWork uow;
        private IGenericRepository<User> _usersRepo;
        private bool retVal;
        private readonly AppSettings appSettings;
        public AddUser(IOptions<AppSettings> _appSettings,IUnitOfWork _uow)
        {
            uow = _uow;
            _usersRepo = uow.GetRepository<User>();
            appSettings = _appSettings.Value;
        }
        public bool AddUsers(User user)
        {
            try
            {
                user.Password = Cryptography.Encrypt(user.Password.Trim(),appSettings.Secret);
                _usersRepo.Insert(user);
                uow.SaveChanges();
                retVal = true;
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }

    }
}

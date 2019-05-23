using Core2_2ApiJwt.Entities.DTO;
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
    public class ChangePassword : IPassword
    {
        private IUnitOfWork uow;
        private IGenericRepository<User> _usersRepo;
        private readonly AppSettings appSettings;
        private bool retVal;
        public ChangePassword(IOptions<AppSettings> _appSettings,IUnitOfWork _uow)
        {
            uow = _uow;
            _usersRepo= uow.GetRepository<User>();
            appSettings = _appSettings.Value;
        }

        public bool Change(Password password)
        {
            try
            {
                var data = _usersRepo.GetAll().Where(a => a.Id == password.id).FirstOrDefault();
                data.Password = Cryptography.Encrypt(password.password,appSettings.Secret);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2_2ApiJwt.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        int SaveChanges();

        void BeginTransaction();

        void Commit();

        void RollBack();
    }
}

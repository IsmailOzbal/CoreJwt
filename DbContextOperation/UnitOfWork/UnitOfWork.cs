using Core2_2ApiJwt.Context.DbOperation;
using Core2_2ApiJwt.Context.Repository;
using Core2_2ApiJwt.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace Core2_2ApiJwt.Context.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private bool disposed = false;
        private IDbContextTransaction transaction = null;
        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(_context);
        }

        public void RollBack()
        {
            transaction.Rollback();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}

using Core2_2ApiJwt.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Core2_2ApiJwt.Entities.Entity;

namespace Core2_2ApiJwt.Context.DbOperation
{
    public class DatabaseContext : DbContext
    {
        private readonly DatabaseContext _context;
        IDbContextTransaction transaction;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Words> Wordss { get; set; }
        public DbSet<WordDescription> WordDescriptions { get; set; }
        public DbSet<WordSampleSentences> WordSampleSentencess { get; set; }
        public DbSet<WordType> WordTypes { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public void BeginTransaction()
        {
            transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void RollBack()
        {
            transaction.Rollback();
        }
    }
}

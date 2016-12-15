using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepositoryImplementations
{
    public class UnitOfWork : IDisposable
    {
        public DbContext Context { get; }
        private bool disposed;

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context?.SaveChanges();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Context?.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

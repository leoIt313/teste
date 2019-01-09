using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage;
using Teste.Domain.Interfaces.Repository;
using Teste.Infra.Context;

namespace Teste.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork, IDbContextTransaction
    {
        private readonly TesteContext _context;
        private bool _disposed;
        private IDbContextTransaction _dbContextTransaction;

        public virtual Guid TransactionId { get; } = Guid.NewGuid();

        public UnitOfWork(TesteContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
            _dbContextTransaction.Commit();
        }

        public void Rollback()
        {
            _dbContextTransaction.Rollback();
            _disposed = false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

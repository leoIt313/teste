using System;

namespace Teste.Domain.Interfaces.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}

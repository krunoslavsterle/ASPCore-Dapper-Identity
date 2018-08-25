using System;
using System.Data;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDbTransaction DbTransaction { get; }

        Task CommitAsync();
    }
}

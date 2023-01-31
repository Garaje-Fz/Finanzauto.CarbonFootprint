using Finanzauto.HuellaCarbono.Domain.Common;

namespace Finanzauto.HuellaCarbono.App.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : Ordering;
        Task<int> Complete();
    }
}

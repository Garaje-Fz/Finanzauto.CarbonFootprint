using Finanzauto.HuellaCarbono.App.Contracts.Persistence;
using Finanzauto.HuellaCarbono.Domain.Common;
using Finanzauto.HuellaCarbono.Infra.Persistence;
using System.Collections;
using System.Security;

namespace Finanzauto.HuellaCarbono.Infra.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly HuellaCarbonoDbContext _context;

        public UnitOfWork(HuellaCarbonoDbContext context)
        {
            _context = context;
        }

        public HuellaCarbonoDbContext HuellaCarbonoDbContext => _context;

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : Ordering
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repository);
            }

            return (IRepository<TEntity>)_repositories[type];
        }
    }
}

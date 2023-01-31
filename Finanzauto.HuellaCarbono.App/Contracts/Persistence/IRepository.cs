using Finanzauto.HuellaCarbono.Domain.Common;
using System.Linq.Expressions;

namespace Finanzauto.HuellaCarbono.App.Contracts.Persistence
{
    public interface IRepository<T> where T : Ordering
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeString = null,
            bool disableTracking = true);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<Expression<Func<T, object>>> includes = null,
            bool disableTracking = true);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T[]> AddRangeAsync(T[] entities);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        void AddEntity(T entity);
        void AddEntityRange(T[] entities);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
        //Task<T> GetByIdWithSpec(ISpecification<T> spec);
        //Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);
        //Task<int> CountAsync(ISpecification<T> spec);
    }
}

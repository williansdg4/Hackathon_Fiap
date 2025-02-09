using Shared.Domain.Entities;

namespace Shared.Infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> DbSetIncluded();
        IList<T> GetAll();
        T? Get(Func<T, bool> predicate);
        T? Get(int id);
        bool Exists(Func<T, bool> predicate);
        IEnumerable<T> Where(Func<T, bool> predicate, bool loadNavigations = false);
        T Insert(T entity);
        void Update(T entity);
        void Delete(T? entity);
        void Delete(int id);
    }
}

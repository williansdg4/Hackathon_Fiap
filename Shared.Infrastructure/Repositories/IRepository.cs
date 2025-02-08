using Shared.Domain.Entities;

namespace Shared.Infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IList<T> GetAll();
        T? Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}

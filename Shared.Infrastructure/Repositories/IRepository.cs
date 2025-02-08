using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> DbSetIncluded();
        IList<T> GetAll();
        T? Get(Func<T, bool> predicate);
        bool Exists(Func<T, bool> predicate);
        IEnumerable<T> Where(Func<T, bool> predicate, bool loadNavigations = false);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

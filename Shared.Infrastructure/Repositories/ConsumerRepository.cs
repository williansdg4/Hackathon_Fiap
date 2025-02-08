using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;

namespace Shared.Infrastructure.Repositories
{
    public class ConsumerRepository<T>(ApplicationDbContextConsumer context) : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContextConsumer _context = context;
        protected readonly DbSet<T> _dbSet = context.Set<T>();

        public void Delete(T? entity)
        {
            if (entity == null)
                return;

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void Delete(int id) => Delete(Get(id));

        public virtual IQueryable<T> DbSetIncluded() => _dbSet;

        public T? Get(Func<T, bool> predicate) =>
            _dbSet.FirstOrDefault(predicate);

        public T? Get(int id) =>
            _dbSet.FirstOrDefault(e => e.Id == id);

        public bool Exists(Func<T, bool> predicate) =>
            _dbSet.Any(predicate);

        public IEnumerable<T> Where(Func<T, bool> predicate, bool loadNavigations = false) =>
            loadNavigations ?
            DbSetIncluded().Where(predicate) :
            _dbSet.Where(predicate);

        public IList<T> GetAll() =>
            _dbSet.ToList();

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}

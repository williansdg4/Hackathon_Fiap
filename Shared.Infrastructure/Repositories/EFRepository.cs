using Microsoft.EntityFrameworkCore;
using Shared.Domain.Entities;
using Shared.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Infrastructure.Repositories
{
    public class EFRepository<T>(ApplicationDbContext context) : IRepository<T> where T : class
    {
        protected ApplicationDbContext _context = context;
        protected DbSet<T> _dbSet = context.Set<T>();

        public void Delete(T entity)
        {
            if (entity == null)
                return;

            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public T? Get(Func<T, bool> predicate) =>
            _dbSet.FirstOrDefault(predicate);

        public IEnumerable<T> Where(Func<T, bool> predicate) =>
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

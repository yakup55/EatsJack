    using DataAccesLayer.Abstract;
using DataAccesLayer.Conceret;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccesLayer.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Add(T item)
        {
            var add = c.Entry(item);
            add.State = EntityState.Added;
            c.SaveChanges();
        }

        public void Delete(T item)
        {
            var delete = c.Entry(item);
            delete.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
           return _object.Where(filter).ToList();
        }

        public void Update(T item)
        {
            var update = c.Entry(item);
            update.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T Get(Expression<Func<T,bool>>filter);
        List<T> List(Expression<Func<T,bool>>filter);

    }
}

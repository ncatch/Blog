using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.IDAL
{
    public interface IBaseDAO<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> Query(Func<T,bool> where);

        List<T> QueryByPage<S>(int PageIndex, int PageSize, Func<T, bool> where, bool isAsc, Func<T, S> Order, out int MaxPage);

    }
}

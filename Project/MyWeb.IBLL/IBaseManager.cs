using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.IBLL
{
    public interface IBaseManager<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        List<T> Query(Func<T, bool> lambdaWhere);
        List<T> PagingQuery<S>(int pageIndex,//页码
            int pageSize,//每页多少条
            bool IsAsc,//是否升序排序
            Func<T, bool> lambdaWhere,//where条件
            Func<T, S> lambdaOrder,//排序依据
            out int pages);//总页数
    }
}

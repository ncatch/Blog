using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.Factory;
using MyWeb.IDAL;
using MyWeb.IBLL;
using MyWeb.Model;

namespace MyWeb.BLL
{
    public abstract class BaseManager<T, S> : IBaseManager<T> where S : class,IBaseDAO<T>
    {
        //返回DAO类对象
        public S _dal {
            get {
                return DbSession.GetDAO<S>();
            }
        }

        public void Add(T obj)
        {
            _dal.Add(obj);
        }

        public List<T> Query(Func<T, bool> lambdaWhere)
        {
            return _dal.Query(lambdaWhere);
        }

        public void Update(T obj)
        {
            _dal.Update(obj);
        }

        public void Delete(T obj)
        {
            _dal.Delete(obj);
        }

        public List<T> PagingQuery<S>(int pageIndex, int pageSize, bool IsAsc, Func<T, bool> lambdaWhere, Func<T, S> lambdaOrder, out int pages)
        {
            return _dal.QueryByPage<S>(pageIndex, pageSize, lambdaWhere, IsAsc, lambdaOrder, out pages);
        }
    }
}

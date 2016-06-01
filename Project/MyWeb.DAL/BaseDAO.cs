using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyWeb.IDAL;
using MyWeb.Model;

namespace MyWeb.DAL
{
    public class BaseDAO<T> where T : class,new()
    {
        private MyWebDBEntities context = EFDbContextFactory.GetDbContext();

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
            //return SaveChanges();
        }

        public void Update(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Modified;
            //return SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Entry<T>(entity).State = EntityState.Deleted;
            //return SaveChanges();
        }

        public List<T> Query(Func<T,bool> where)
        {
            if (where != null)
            {
                return context.Set<T>().ToList().Where(where).ToList();
            }
            else
            {
                return context.Set<T>().ToList();
            }
        }

        public List<T> QueryByPage<S>(int PageIndex,int PageSize,Func<T,bool> where,bool isAsc,Func<T,S> Order,out int MaxPage)
        {
            var result = context.Set<T>().Where(where);

            MaxPage = context.Set<T>().Count() / PageSize + ((context.Set<T>().Count() % PageSize == 0) ? 0 : 1);

            return (isAsc ? result.OrderBy(Order) : result.OrderByDescending(Order))
                .Skip((PageIndex - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }
    }
}

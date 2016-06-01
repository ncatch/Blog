using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using MyWeb.Model;

namespace MyWeb.Factory
{
    public class DbSession
    {
        public static T GetDAO<T>() where T:class
        {
            string dllfile = ConfigurationManager.AppSettings["DAL"];
            Assembly ass = Assembly.Load(dllfile);
            //Assembly ass = Assembly.LoadFrom(dllfile+".dll");//使用loadfrom则传绝对路径

            Type[] types = ass.GetTypes();
            T obj = default(T);
            foreach (Type type in types)
            {
                if (typeof(T).IsAssignableFrom(type))
                {
                    obj = (T)Activator.CreateInstance(type);
                    break;
                }
            }

            return obj;
        }

        public static bool SaveChange()
        {
            return EFDbContextFactory.GetDbContext().SaveChanges() > 0 ? true : false;
        }
    }
}

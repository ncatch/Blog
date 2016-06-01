using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Model
{
    public static class EFDbContextFactory
    {
        public static MyWebDBEntities GetDbContext()
        {
            MyWebDBEntities context = CallContext.GetData("MyWebDBEntities") as MyWebDBEntities;
            if(context == null){
                context = new MyWebDBEntities();
                CallContext.SetData("MyWebDBEntities", context);
            }
            return context;
        }
    }
}

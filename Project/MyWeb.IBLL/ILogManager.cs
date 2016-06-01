using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.Model;

namespace MyWeb.IBLL
{
    public interface ILogManager : IBaseManager<Log>
    {
        bool Add(Log log);

        List<Log> GetLogsByPage(int page, out int maxpage,int userid);

        Log GetLogById(int logid);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.IBLL;
using MyWeb.Model;
using MyWeb.IDAL;
using MyWeb.Factory;

namespace MyWeb.BLL
{
    public class LogManager:BaseManager<Log,ILogDAL>,ILogManager
    {

        public new bool Add(Model.Log log)
        {
            _dal.Add(log);
            return DbSession.SaveChange();
        }

        public List<Log> GetLogsByPage(int page,out int maxpage,int userid)
        {
            return _dal.QueryByPage<DateTime>(1, 10, l => l.UserId == userid, false, l => l.AddDate.Value, out maxpage);
        }

        public Log GetLogById(int logid)
        {
            return _dal.Query(l => l.id == logid)[0];
        }
    }
}

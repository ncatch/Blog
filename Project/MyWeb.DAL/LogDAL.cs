using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MyWeb.Model;
using System.Data.Entity;

namespace MyWeb.DAL
{
    public class LogDAL : BaseDAO<Log>,IDAL.ILogDAL
    {
        public bool AddLog(Model.Log log)
        {
            Add(log);

            return true;
        }
    }
}

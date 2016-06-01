using MyWeb.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MyWeb.IDAL;
using MyWeb.Model;
using MyWeb.Factory;

namespace MyWeb.BLL
{
    public class UserInfoManager:BaseManager<UserInfo,IUserInfoDAL>,IUserInfoManager
    {
        public Model.UserInfo GetUserInfoById(int id)
        {
            return _dal.Query(u => u.UserId == id).First();
        }
    }
}

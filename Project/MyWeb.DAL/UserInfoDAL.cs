using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.Model;
using System.Data.SqlClient;
using System.Data;
using MyWeb.IDAL;

namespace MyWeb.DAL
{
    public class UserInfoDAL : BaseDAO<UserInfo>,IUserInfoDAL
    {
        #region 新增用户信息
        public void AddUserInfo(UserInfo userinfo)
        {
            this.Add(userinfo);
        }
        #endregion

        #region 根据id查找用户信息
        public UserInfo GetUserInfoById(int id)
        {
            return EFDbContextFactory.GetDbContext().UserInfo.Single(u => u.UserId == id); ;
        }
        #endregion
    }
}

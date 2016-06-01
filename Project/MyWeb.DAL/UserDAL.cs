using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.IDAL;
using MyWeb.Model;
using System.Data.SqlClient;
using System.Data;

namespace MyWeb.DAL
{
    public class UserDAL:BaseDAO<Users>,IUserDAL
    {

        #region 用户登录
        public int Login(Users user)
        {
            return EFDbContextFactory.GetDbContext().Users.Single(u => u.UserLoginName == user.UserLoginName && u.UserLoginPwd == user.UserLoginPwd).id;
        }
        #endregion

        #region 用户注册
        public bool Register(Users user)
        {
            string sqluser = "insert into Users(UserLoginName,UserLoginPwd) values(@username,@userpwd);";

            SqlParameter[] pars =
            {
                new SqlParameter("@username", user.UserLoginName),
                new SqlParameter("@userpwd", user.UserLoginPwd)
            };

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqluser, pars) > 0;
        }
        #endregion

        #region 更改密码
        public bool RePwd(Users user)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 检查用户名是否存在
        public bool Exists(string userLoginName)
        {
            string sql = "select 1 from Users where UserLoginName = @username";

            SqlParameter par = new SqlParameter("@username", userLoginName);

            return SqlHelper.ExecuteScalar(CommandType.Text, sql, par) != null;
        }
        #endregion
    }
}

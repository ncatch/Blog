using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.Model;
using MyWeb.IDAL;
using MyWeb.Factory;
using MyWeb.IBLL;

namespace MyWeb.BLL
{
    public class UserManager : BaseManager<Users,IUserDAL>,IUserManager
    {
        private IUserInfoDAL _userInfoDAL = DbSession.GetDAO<IUserInfoDAL>();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public int Login(Users user)
        {
            return _dal.Login(user);
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public bool Register(Users user)
        {
            _dal.Register(user);
            UserInfo userinfo = new UserInfo()
            {
                UserId = _dal.Login(user),
                NickName = user.UserLoginName,
                Sex = "0",
                Constellation = 1
            };
            //添加用户并添加用户信息
            _userInfoDAL.AddUserInfo(userinfo);

            return DbSession.SaveChange();
        }

        /// <summary>
        /// 存在返回真
        /// </summary>
        /// <param name="userLoginName">用户名</param>
        /// <returns></returns>
        public bool Exists(string userLoginName)
        {
            return _dal.Exists(userLoginName) != false;
        }
    }
}

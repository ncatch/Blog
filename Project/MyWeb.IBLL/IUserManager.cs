using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.Model;

namespace MyWeb.IBLL
{
    public interface IUserManager:IBaseManager<Users>
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        int Login(Users user);

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        bool Register(Users user);

        /// <summary>
        /// 存在返回真
        /// </summary>
        /// <param name="userLoginName">用户名</param>
        /// <returns></returns>
        bool Exists(string userLoginName);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.Model;

namespace MyWeb.IDAL
{
    public interface IUserInfoDAL : IBaseDAO<UserInfo>
    {
        void AddUserInfo(UserInfo userinfo);

        UserInfo GetUserInfoById(int id);
    }
}

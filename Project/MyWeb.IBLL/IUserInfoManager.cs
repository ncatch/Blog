using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.Model;

namespace MyWeb.IBLL
{
    public interface IUserInfoManager:IBaseManager<UserInfo>
    {
        UserInfo GetUserInfoById(int id);
    }
}

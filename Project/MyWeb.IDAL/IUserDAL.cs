using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWeb.Model;

namespace MyWeb.IDAL
{
    public interface IUserDAL:IBaseDAO<Users>
    {
        int Login(Users user);

        bool Register(Users user);

        bool RePwd(Users user);

        bool Exists(string userLoginName);

    }
}

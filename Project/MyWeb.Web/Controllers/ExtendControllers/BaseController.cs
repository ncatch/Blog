using MyWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWeb.Web.SocketClient;

namespace System.Web.Mvc
{
    public class BaseController:System.Web.Mvc.Controller
    {
        //得到当前登录用户
        public UserInfo _user
        {
            get
            {
                if (Session["CurrentBlog"] != null)
                {
                    return Session["CurrentBlog"] as UserInfo;
                }
                return Session["user"] as UserInfo;
            }
        }

        public SocketClient _socket
        {
            get
            {
                return Session["socket"] as SocketClient;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Model;
using MyWeb.IBLL;
using MyWeb.BLL;
using System.Text;
using System.Threading;
using System.Reflection;

namespace MyWeb.Web.Controllers
{
    [Auther]
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        private IUserManager _um;
        private IUserInfoManager _uim;

        //private Thread getmsgth = new Thread(writeMsg);

        #region AutoFac注入
        public HomeController(IUserManager um, IUserInfoManager uim)
        {
            this._um = um;
            this._uim = uim;
        }
        #endregion

        #region 主页面
        public ActionResult Index(string UserName,int? width)
        {
            if(UserName != null){
                Session["CurrentBlog"] = _uim.Query(u => u.NickName == UserName).FirstOrDefault();
            }

            ViewBag.User = _user;

            ViewBag.Width = 0;

            if (width != null)
            {
                ViewBag.Width = width.Value;
            }

            return View();
        }

        public ActionResult BlogList()
        {
            return View();
        }

        public ActionResult My()
        {
            ViewBag.User = _user;
            return View();
        }

        public ActionResult Shar()
        {
            return View();
        }

        #endregion

        #region 用户登录
        public ActionResult Login(Users user)
        {
            if(user.UserLoginName == null){
                return View();
            }

            try
            {
                Session["user"] = _uim.GetUserInfoById(_um.Login(user));
                return Json("ok");
            }
            catch{
                ViewBag.Tip = "账号或密码错误!";
                return View();
            }
        }
        #endregion

        #region 注册
        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users user)
        {
            try
            {
                bool isok = _um.Register(user);
                ViewBag.UserId = _um.Login(user);

                return RedirectToAction("Login", user);
            }
            catch {
                return JavaScript("<script>alert('注册失败,请重试!');window.location.reload();</script>");
            }
        }
        #endregion

        #region 检查用户名是否存在
        [HttpGet]
        public ActionResult UserNameExists(string userLoginName)
        {
            return Json(_um.Exists(userLoginName) ? "no" : "ok");
        }
        #endregion

        #region 聊天室
        public ActionResult ChatRoom()
        {
            try
            {
                SocketClient.SocketClient client;

                if (Session["socket"] == null)
                {
                    client = new SocketClient.SocketClient(_user.NickName);
                    Session["socket"] = client;
                }
                else
                {
                    client = Session["socket"] as SocketClient.SocketClient;
                }

                byte[] me = new byte[1024];
                int i;

                i = client.socket.Receive(me);

                string msg = Encoding.Unicode.GetString(me, 0, i);

                string[] users = msg.Split(':');

                ViewBag.Users = users;
                ViewBag.NickName = _user.NickName;
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View();
        }
        #endregion

        #region 接收消息
        public ActionResult GetMsg()
        {
            byte[] me = new byte[1024];
            int i = 0;

            _socket.socket.ReceiveTimeout = 1000;
            try
            {
                i = _socket.socket.Receive(me);
            }
            catch { }

            string msg = Encoding.Unicode.GetString(me, 0, i);

            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 发送消息
        public ActionResult sendMsg(string msg)
        {
            try
            {
                if(msg == "delete"){

                    _socket.socket.Send(Encoding.Unicode.GetBytes("delete:" + _user.NickName));

                    SocketClient.SocketClient client = Session["socket"] as SocketClient.SocketClient;

                    client.socket.Close();

                    Session["socket"] = null;
                }
                else
                {
                    _socket.socket.Send(Encoding.Unicode.GetBytes(_user.NickName + ":" + msg));
                }
                
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("no", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}
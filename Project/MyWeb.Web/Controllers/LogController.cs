using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using MyWeb.Model;
using MyWeb.IBLL;
using System.Text.RegularExpressions;
using System.Configuration;

namespace MyWeb.Web.Controllers
{
    [Auther]
    public class LogController : BaseController
    {
        //
        // GET: /Log/

        private ILogManager lm;

        public LogController(ILogManager lm)
        {
            this.lm = lm;
        }

        #region 日志主页
        public ActionResult Index(int page = 1)
        {
            int maxpage = 0;

            ViewBag.Logs = lm.GetLogsByPage(page,out maxpage,_user.UserId);
            ViewBag.MaxPage = maxpage;
            ViewBag.Page = page;

            return View();
        }
        #endregion

        #region 写日志
        [HttpGet]
        public ActionResult WriteLog()
        {
            return View();
        }

        //保存日志
        [HttpPost]
        public ActionResult WriteLog(string content, string pwd = "0000")
        {
            int pass = CommonController.getInt(pwd);

            StringBuilder sb = new StringBuilder();

            sb.Append((int)content[0] + pass);

            for (int i = 1; i < content.Length;i++ )
            {
                sb.Append(ConfigurationManager.AppSettings["SplitKey"]);
                sb.Append((int)content[i] + pass);
            }

            Log log = new Log
            {
                AddDate = DateTime.Now,
                Content = sb.ToString(),
                UserId = _user.UserId
            };

            if (lm.Add(log))
            {
                return Json("ok");
            }

            return Json("发生了未知的错误!");
        }
        #endregion

        #region 读日志
        public ActionResult ReadLog(int? logid,string pwd = "0000")
        {
            int pass = CommonController.getInt(pwd);

            if(logid == null){
                return Json("此日志不存在!");
            }
            Log log = lm.GetLogById(logid.Value);

            if(log.UserId != _user.UserId){
                return Json("你无权查看此日志!");
            }

            StringBuilder sb = new StringBuilder();

            string[] content = log.Content.Split(ConfigurationManager.AppSettings["SplitKey"]);

            foreach(string s in content){
                sb.Append((char)(Convert.ToInt32(s) - pass));
            }

            return Json(sb.ToString());
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Web.Controllers
{
    [Auther]
    public class AboutController : BaseController
    {
        //
        // GET: /About/
        public ActionResult Index()
        {
            ViewBag.User = _user;
            return View();
        }
	}
}
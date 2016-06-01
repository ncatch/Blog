using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.IBLL;

namespace MyWeb.Web.Controllers
{
    [Auther]
    public class GustBookController : BaseController
    {
        private IMessageBoardManager _mm;

        public GustBookController(IMessageBoardManager mm)
        {
            this._mm = mm;
        }

        public ActionResult Index(int? pageIndex = 1)
        {
            int pages;
            ViewBag.List = _mm.PagingQuery<DateTime>(pageIndex.Value, 15, false, m => m.UserId == _user.UserId && m.IsPublic == true, m => m.LeveaTime.Value, out pages);
            ViewBag.MaxPage = pages;
            return View();
        }
	}
}
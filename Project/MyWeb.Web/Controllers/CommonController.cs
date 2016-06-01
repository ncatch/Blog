using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Web.Controllers
{
    public class CommonController : Controller
    {
        //
        // GET: /Common/

        /// <summary>
        /// 把string类型转换为int类型(想加)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int getInt(string str)
        {
            int result = 0;

            foreach(char c in str){
                result += (int)c;
            }

            return result;
        }
	}
}
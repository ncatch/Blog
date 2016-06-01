using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtend
    {
        /// <summary>
        /// //分割字符串
        /// </summary>
        /// <param name="oldstr">要分割的字符串</param>
        /// <param name="str">按str来分割</param>
        /// <returns></returns>
        public static string[] Split(this string oldstr, string str)
        {
            List<string> strlist = new List<string>();

            while (oldstr.IndexOf(str) > 0)
            {
                strlist.Add(oldstr.Substring(0, oldstr.IndexOf(str)));
                oldstr = oldstr.Substring(oldstr.IndexOf(str) + str.Length);
            }

            strlist.Add(oldstr);

            return strlist.ToArray();
        }
    }
}

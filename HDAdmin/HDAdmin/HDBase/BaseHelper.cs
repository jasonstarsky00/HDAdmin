using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HDAdmin.HDBase
{
    /// <summary>
    /// base帮助类
    /// </summary>
    public class BaseHelper
    {
        /// <summary>
        /// 结果返回帮助类
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static JsonResult ResultJson(int code,string msg)
        {
                   return new JsonResult
                    {
                        Data = new { code = code, msg = msg },
                        ContentEncoding = System.Text.Encoding.UTF8,
                        ContentType = "application/json",
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
        }
    }
}
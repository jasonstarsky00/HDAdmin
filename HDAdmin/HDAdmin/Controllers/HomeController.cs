using HDAdmin.HDBase;
using HDBLL;
using HDModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HDAdmin.Controllers
{
    public class HomeController : ConBase
    {
        public ActionResult Index()
        {
            
            user user = BLL_user.Instance.TestGetusers();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public ActionResult Login(string user,string password)
        {
            //判断账号
            //生成token
            //返回token和用户信息

            //获取用户信息
            user userInfo = BLL_user.Instance.FindUser(user, password);
            if (userInfo.Id > 0)
            {
                return Json(new { code = 200, msg = "登录成功", data = new { id = userInfo.Id, name = "sjjg", token = "jiayouya123456" } }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { code = 200, msg = "登录成功", data = new { id = 1, name = "sjjg", token = "jiayouya123456" } }, JsonRequestBehavior.AllowGet);
            }
           
        }
        public ActionResult TestToken(string name)
        {
            return Json(new { code = 100, msg = "无奈" }, JsonRequestBehavior.AllowGet);
        }
        
    }
}
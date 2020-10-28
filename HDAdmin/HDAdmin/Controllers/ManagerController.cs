using HDBLL;
using HDModels;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HDAdmin.Controllers
{

    public class ManagerController : Controller
    {
        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            int code = 100;
            string msg = "管理员数据获取失败";
            List<manager> managerList = BLL_manager.Instance.GetManagerList();
            if (managerList.Count > 0)
            {
                code = 200;
                msg = "管理员数据获取成功";
            }
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            string sResult = Newtonsoft.Json.JsonConvert.SerializeObject(new { code = code, msg = msg, data = new { managerList = managerList }  }, timeConverter);
            return Json(sResult, JsonRequestBehavior.AllowGet);
        }
    }
}
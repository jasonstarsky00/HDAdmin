using HDAdmin.HDBase;
using HDBLL;
using HDModels;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using XXCommon;

namespace HDAdmin.Controllers
{
    public class UserController : ConBase
    {
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult List(string userName="",string name="",int isVip = -1, int pageSize = 30, int pageIndex = 1)
        {
            int code = 100;
            string msg = "获取用户数据失败";
            StringBuilder sb = new StringBuilder();
            //删除空白符
            userName = userName.Trim();
            name = name.Trim();
            //构造查询语句
            if (userName != null && userName != "")
            {
                sb.Append($"and userName='{userName}'");
            }
            if(name !=null && name != "")
            {
                sb.Append($"and name = '{name}'");
            }
            if (isVip > -1)
            {
                sb.Append($"and isVip >={isVip} ");
            }
            DataTable dt = BLL_user.Instance.GetUserList(sb.ToString(), pageSize, pageIndex);
            List<user> userList = ModelConvertHelper<user>.ConverModel(dt);
            if (userList.Count > 0)
            {
                code = 200;
                msg = "获取用户数据成功";
            }
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            string sResult = Newtonsoft.Json.JsonConvert.SerializeObject(new { code = code, msg = msg, data = new { total = dt.Rows.Count > 0 ? dt.Rows[0]["total"] : 0, userName = userName, pageIndex = pageIndex, pageSize = pageSize, userList = userList } }, timeConverter);
            //return Json(new { code = code, msg = msg, data= new { total = dt.Rows.Count > 0 ? dt.Rows[0]["total"] : 0, userName = userName, pageIndex = pageIndex, pageSize = pageSize, userList = userList } }, JsonRequestBehavior.AllowGet);
            return Json(sResult, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id=-1)
        {
            int code = 100;
            string msg = "用户信息获取失败";
            user userInfo = new user();
            if (id > 0)
            {
                 userInfo = BLL_user.Instance.FindById(id);
                if (userInfo != null && userInfo.Id > 0)
                {
                    code = 200;
                    msg = "用户信息获取成功";
                }
            }
            return Json(new { code = code, msg = msg, data = new { user = userInfo } },JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name">昵称</param>
        /// <param name="integral">积分</param>
        /// <param name="haveDownloads">剩余下载次数</param>
        /// <param name="isManager">是否管理员</param>
        /// <param name="isVip">vip级别</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id,string name,int integral,int haveDownloads,int isManager,int isVip)
        {
            int code = 100;
            string msg = "编辑失败";
            if(id>0&& !string.IsNullOrWhiteSpace(name)&& integral>0&&haveDownloads>0&& isManager>-1&& isVip > -1)
            {
                int res = BLL_user.Instance.EditUserInfo(id, name, integral, haveDownloads, isManager, isVip);
                if (res > 0)
                {
                    code = 200;
                    msg = "修改成功";
                }
            }
            return Json(new { code = code, msg = msg },JsonRequestBehavior.AllowGet);
        }
    }
}
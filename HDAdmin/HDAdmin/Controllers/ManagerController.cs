using HDAdmin.HDBase;
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

    public class ManagerController : ConBase
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
        /// <summary>
        /// 获取角色列表信息
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleList()
        {
            int code = 100;
            string msg = "角色列表信息获取失败";
            List<role> roleList = BLL_manager.Instance.GetRoleList();
            if(roleList.Count>0 && roleList != null)
            {
                code = 200;
                msg = "角色列表信息获取成功";
            }
            return Json(new { code = code, msg = msg, data = new { roleList = roleList } }, JsonRequestBehavior.AllowGet);    

        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userName"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddManager(int roleId=-1,string userName="",int status=-1)
        {
            int code = 100;
            string msg = "管理员添加失败";
            if (roleId > 0 && userName != "" && status > 0)
            {
                //查找用户id
                user user = BLL_user.Instance.FindByUserName(userName);
                //管理员是否存在
                bool isHaveUid = BLL_manager.Instance.IsHaveManager(user.Id);
                if (user.Id > 0&& !isHaveUid)
                {
                    //添加角色
                    int res = BLL_manager.Instance.AddManager(roleId, user.Id, status);
                    if (res > 0)
                    {
                        code = 200;
                        msg = "管理员添加成功";
                    }
                }else
                {
                    if (isHaveUid)
                    {
                        msg = "该管理员已存在";
                    }else
                    {
                        msg = "用户不存在";

                    }
                }
            }
            return Json(new { code = code, msg = msg }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 编辑管理员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditManager(int mid)
        {
            int code = 100;
            string msg = "获取管理员信息失败";
            roleUser ruser = new roleUser();
            user user = new user();
            if (mid > 0)
            {
                //获取基本信息
                 ruser = BLL_manager.Instance.GetManagerById(mid);
                if (ruser.id > 0)
                {
                    //获取用户名
                     user = BLL_user.Instance.FindById(ruser.uid);
                    if (user.Id > 0)
                    {
                        code = 200;
                        msg = "获取管理员信息成功";
                    }
                }
                
            }
            return Json(new { code = code, msg = msg, data = new { mid = ruser.id,rid=ruser.rid, userName = user.UserName, status = ruser.isFreeze } }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult EditManager(int mid=-1,int rid =-1,string userName = "",int status=-1)
        {
            int code = 100;
            string msg = "修改失败";
            if (mid < 0)
            {
                msg = "管理员id不存在";
            }
            if (rid < 0)
            {
                msg = "角色不存在";
            }
            if (userName == "")
            {
                msg = "用户名不能为空";
            }
            if (status == -1)
            {
                msg = "请设置管理员状态";
            }
            else
            {
                
                //查找用户id
                user user = BLL_user.Instance.FindByUserName(userName);
                if(user.Id > 0 )
                {
                    //更新管理员信息
                    int res = BLL_manager.Instance.EditManager(rid, user.Id, status, mid);
                    if (res > 0)
                    {
                        code = 200;
                        msg = "修改管理信息成功";
                    }
                }

            }
            return Json(new { code = code, msg = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}
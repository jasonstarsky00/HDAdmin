using HDBLL;
using HDModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XXCommon;

namespace HDAdmin.Controllers
{
    public class PptTypeController : Controller
    {
        /// <summary>
        /// 模板类型列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult list(int pageSize = 30, int pageIndex = 1)
        {
            int code = 100;
            string msg = "模板类型获取失败";
            string queryStr = "";
            DataTable dt = BLL_templateType.Instance.GetTemplateTypeList(queryStr, pageSize, pageIndex);
            List<templateType> list = ModelConvertHelper<templateType>.ConverModel(dt);
            if(list.Count>0 && list != null)
            {
                code = 200;
                msg = "模板类型获取成功";
            }
            return Json(new { code = code, msg = msg, data = new { total = dt.Rows.Count > 0 ? dt.Rows[0]["total"] : 0, pageIndex = pageIndex, pageSize = pageSize, list = list } }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加类型
        /// </summary>
        /// <param name="name">类型名称</param>
        /// <param name="type">所属分类</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddType(string name="",int type=-1,int status=-1)
        {
            int code = 100;
            string msg = "新增类型失败";
            if(name!=""&& type>0&& status > -1)
            {
                int res = BLL_templateType.Instance.AddType(type, name, status);
                if (res >0)
                {
                    code = 200;
                    msg = "新增类型成功";
                }
            }
            return Json(new { code = code, msg = msg }, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 编辑类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditType(int id = 0)
        {
            int code = 100;
            string msg = "获取类型失败";
            templateType type = new templateType();
            if (id > 0)
            {
                DataTable dt = BLL_templateType.Instance.FindById(id);
                if (dt.Rows.Count > 0)
                {
                     type = ModelConvertHelper<templateType>.DtReturnFirst(dt);
                     code = 200;
                     msg = "获取类型成功";
                }
            }
            return Json(new { code = code, msg = msg, data = type }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditType(int id=0,string name="",int type=-1, int status = -1)
        {
            int code = 100;
            string msg = "修改类型失败";
            if(id > 0 && name != "" && type > 0 && status > -1)
            {
                int res = BLL_templateType.Instance.EditType(id, type, status, name);
                if (res > 0)
                {
                    code = 200;
                    msg = "修改类型成功";
                }
            }
            return Json(new { code = code, msg = msg }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteType(int id=0)
        {
            int code = 100;
            string msg = "删除类型失败";
            if (id > 0)
            {
                int res = BLL_templateType.Instance.DeleteType(id);
                if (res > 0)
                {
                    code = 200;
                    msg = "删除类型成功";
                }
            }
            return Json(new { code = code, msg = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}
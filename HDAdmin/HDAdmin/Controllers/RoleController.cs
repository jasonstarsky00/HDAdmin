using HDBLL;
using HDModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using XXCommon;

namespace HDAdmin.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleController : Controller
    {
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            int code = 100;
            string msg = "获取角色列表失败";
            List<role> roleList = BLL_Role.Instance.getRoleAll();
            if(roleList.Count>0 && roleList != null)
            {
                code = 200;
                msg = "获取角色列表成功";
            }

            return Json(new { code = code, msg = msg, data = new { roleData = roleList } }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="name">角色名称</param>
        /// <param name="description">角色描述</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddRole(string name="",string description="")
        {
            int code = 100;
            string msg = "添加角色失败";
            if (name != "" && description != null)
            {
                int res = BLL_Role.Instance.AddRole(name, description);
                if (res > 0)
                {
                    code = 200;
                    msg = "添加角色成功";
                }
            }
            return Json(new { code = code, msg = msg }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 编辑角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditRole(int id = 0)
        {
            int code = 100;
            string msg = "获取角色信息失败";
            role role = new role();
            if (id > 0)
            {
                role = BLL_Role.Instance.GetRoleInfoById(id);
                if (role.id > 0)
                {
                    code = 200;
                    msg = "获取角色信息成功";
                }
            }
            return Json(new { code = code, msg = msg, data = role }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditRole(int id=0,string name="",string description = "")
        {
            int code = 100;
            string msg = "编辑角色信息失败";
            if (id > 0 && name != "" && description != "")
            {
                int res = BLL_Role.Instance.EditRoleInfo(id, name, description);
                if (res > 0)
                {
                    code = 200;
                    msg = "编辑角色信息成功";
                }
            }
            return Json(new { code = code, msg = msg }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DeleteRole(int id = 0)
        {
            int code = 100;
            string msg = "删除角色失败";
            if (id > 0)
            {
                int res = BLL_Role.Instance.DeleteRole(id);
                if (res > 0)
                {
                    code = 200;
                    msg = "删除角色成功";
                }
            }
            return Json(new { code = code, msg = msg }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 授权--获取所有菜单权限
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RoleAuthorization(int roleId)
        {
            int code = 100;
            string msg = "获取菜单权限失败";
            //获取所有权限
            List<backstageMenuUser> list_Permission = BLL_Role.Instance.GetPermission();
            //筛选一级菜单
            List<TreePerissmion> Tree = new List<TreePerissmion>();
            for (int i = 0; i < list_Permission.Count; i++)
            {
                if(list_Permission[i].parentId==0&& list_Permission[i].menuLevel == 1)
                {
                    //选出一级菜单
                    TreePerissmion one = new TreePerissmion();
                    one.id = list_Permission[i].id;
                    one.menuName = list_Permission[i].menuName;
                    one.control = list_Permission[i].control;
                    one.action = list_Permission[i].action;
                    one.str = list_Permission[i].str;
                    one.parentId = list_Permission[i].parentId;
                    one.sort = list_Permission[i].sort;
                    one.menuLevel = list_Permission[i].menuLevel;
                    one.icon = list_Permission[i].icon;
                    one.isShow = list_Permission[i].isShow;
                    //选出二级菜单
                    #region 二级菜单
                    List<TreePerissmionChildren> listTwo = new List<TreePerissmionChildren>();
                    for (int j = 0; j < list_Permission.Count; j++)
                    {
                        if (list_Permission[j].parentId == list_Permission[i].id && list_Permission[j].menuLevel == 2)
                        {
                            TreePerissmionChildren two = new TreePerissmionChildren();
                            two.id = list_Permission[j].id;
                            two.menuName = list_Permission[j].menuName;
                            two.control = list_Permission[j].control;
                            two.action = list_Permission[j].action;
                            two.str = list_Permission[j].str;
                            two.parentId = list_Permission[j].parentId;
                            two.sort = list_Permission[j].sort;
                            two.menuLevel = list_Permission[j].menuLevel;
                            two.icon = list_Permission[j].icon;
                            two.isShow = list_Permission[j].isShow;
                            #region 三级--功能菜单权限
                            List<TreePerissmionLastChildren> listThree = new List<TreePerissmionLastChildren>();
                            for (int n = 0; n < list_Permission.Count; n++)
                            {
                                if(list_Permission[n].parentId== list_Permission[j].id&& list_Permission[n].menuLevel == 3)
                                {
                                    TreePerissmionLastChildren three = new TreePerissmionLastChildren();
                                    three.id = list_Permission[n].id;
                                    three.menuName = list_Permission[n].menuName;
                                    three.control = list_Permission[n].control;
                                    three.action = list_Permission[n].action;
                                    three.str = list_Permission[n].str;
                                    three.parentId = list_Permission[n].parentId;
                                    three.sort = list_Permission[n].sort;
                                    three.menuLevel = list_Permission[n].menuLevel;
                                    three.icon = list_Permission[n].icon;
                                    three.isShow = list_Permission[n].isShow;
                                    listThree.Add(three);
                                }
                            }
                            #endregion
                            two.children = listThree;
                            listTwo.Add(two);
                        }
                    }
                    one.children = listTwo;
                    #endregion

                    Tree.Add(one);
                }
            }
            if (Tree.Count > 0)
            {
                code = 200;
                msg = "获取菜单权限成功";
            }
            List<RoleHaveId> haveMP = BLL_Role.Instance.GetRoleHavePermission(roleId);
            int[] haveArr = new int[haveMP.Count];
            if (haveMP.Count > 0)
            {
                for (int i = 0; i < haveMP.Count; i++)
                {
                    haveArr[i] = haveMP[i].bsMenuId;
                }
            }
            //角色id--获取对应的权限
            return Json(new {code=code,msg=msg, data = Tree, haveArr = haveArr }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RoleAuthorization(int roleId=0,string str = "")
        {
            int code = 100;
            string msg = "授权失败";
            if (roleId > 0)
            {
                List<string> pidList = str.Split(',').ToList();
                StringBuilder sb = new StringBuilder();
                //先删除角色保存权限
                SqlParameter[] delesqlParArr = { new SqlParameter("@sqld", $"delete from hd_bsRole where rid={roleId}") };
                object delval = DBhelper.ExecStoreProcedureSql("upMethodFforWindSQL", delesqlParArr);
                //再保存
                object val = new object();
                int count = 0;
                for (int i = 0; i < pidList.Count; i++)
                {
                    sb.Append($" insert into hd_bsRole(bsMenuId,rid)values({Convert.ToInt32(pidList[i])},{roleId})");
                    count += 1;
                    if (count == 20)
                    {
                        SqlParameter[] sqlParArr = { new SqlParameter("@sqld", sb.ToString()) };
                        val = DBhelper.ExecStoreProcedureSql("upMethodFforWindSQL", sqlParArr);
                        //重置
                        count = 0;
                        sb = new StringBuilder();
                    }
                }
                SqlParameter[] sqlParArr2 = { new SqlParameter("@sqld", sb.ToString()) };
                val = DBhelper.ExecStoreProcedureSql("upMethodFforWindSQL", sqlParArr2);
                if (Convert.ToInt32(val) >= 1)
                {
                    code = 200;
                    msg = "添加授权成功";
                }
            }
            

            
            return Json(new { code = code, msg = msg }, JsonRequestBehavior.AllowGet);

        }
    }
}
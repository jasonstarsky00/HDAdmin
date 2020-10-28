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
    public class MenuController : ConBase
    {
        /// <summary>
        /// 根据用户id获取对应菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetMenus(int id)
        {
            int code = 100;
            string msg = "获取菜单失败";
            List<BsMenus> listMenus = new List<BsMenus>();
            if (id > 0)
            {
                List<backstageMenuUser> getmenus = BLL_backstageMenuUser.Instance.GetUserMenusByUid(id);
                if (getmenus.Count > 0 && getmenus != null)
                {
                    for (int i = 0; i < getmenus.Count; i++)
                    {
                        # region 1级菜单
                        if ((getmenus[i].menuLevel == 1 && getmenus[i].parentId == 0 && getmenus[i].type == 1) ||(getmenus[i].menuLevel == 1 && getmenus[i].parentId == 0 && getmenus[i].type == 3))
                        {
                            BsMenus menus1 = new BsMenus();
                            menus1.id = getmenus[i].id;
                            menus1.menuName = getmenus[i].menuName;
                            menus1.control = getmenus[i].control;
                            menus1.action = getmenus[i].action;
                            menus1.str = getmenus[i].str;
                            menus1.parentId = getmenus[i].parentId;
                            menus1.sort = getmenus[i].sort;
                            menus1.menuLevel = getmenus[i].menuLevel;
                            menus1.icon = getmenus[i].icon;
                            menus1.type = getmenus[i].type;
                            menus1.isShow = getmenus[i].isShow;
                            menus1.createTime = getmenus[i].createTime;
                            listMenus.Add(menus1);
                        }
                        #endregion
                    }
                    #region 2级菜单
                    for (int i = 0; i < listMenus.Count; i++)
                    {
                        List<backstageMenuUser> menus2 = getmenus.Where(x => x.parentId == listMenus[i].id).ToList();
                        listMenus[i].child = menus2;
                    }
                    #endregion

                    code = 200;
                    msg = "获取菜单成功";
                }
            }
            return Json(new { code = code, msg = msg, data = listMenus }, JsonRequestBehavior.AllowGet);
        }
    }
}
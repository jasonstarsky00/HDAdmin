using HDModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXCommon;

namespace HDBLL
{
    /// <summary>
    /// BLL-角色列表
    /// </summary>
    public class BLL_Role
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_Role Instance { get; private set; }
        //私有构造函数
        private BLL_Role()
        {
        }
        //静态构造函数
        static BLL_Role()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_Role();
                }
            }
        }
        private HDData.DAL_Role bll = new HDData.DAL_Role();

        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public List<role> getRoleAll()
        {
            DataTable dt = bll.getRoleAll();
            return ModelConvertHelper<role>.ConverModel(dt);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="name">角色名称</param>
        /// <param name="description">角色描述</param>
        /// <returns></returns>
        public int AddRole(string name, string description)
        {
            return bll.AddRole(name, description);
        }

        /// <summary>
        /// 获取单个角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public role GetRoleInfoById(int id)
        {
            DataTable dt = bll.GetRoleInfoById(id);
            return ModelConvertHelper<role>.DtReturnFirst(dt);
        }
        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public int EditRoleInfo(int id, string name, string description)
        {
            return bll.EditRoleInfo(id, name, description);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteRole(int id)
        {
            return bll.DeleteRole(id);
        }
        /// <summary>
        /// 获取所有菜单及权限
        /// </summary>
        /// <returns></returns>
        public List<backstageMenuUser> GetPermission()
        {
            DataTable dt = bll.GetPermission();
            return ModelConvertHelper<backstageMenuUser>.ConverModel(dt);
        }

        /// <summary>
        /// 获取角色拥有菜单权限Id
        /// </summary>
        /// <returns></returns>
        public List<RoleHaveId> GetRoleHavePermission(int rid)
        {
            DataTable dt = bll.GetRoleHavePermission(rid);
            return ModelConvertHelper<RoleHaveId>.ConverModel(dt);
        }
    }
}

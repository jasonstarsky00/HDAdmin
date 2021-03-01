using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXCommon;

namespace HDData
{
    /// <summary>
    /// DAL-角色列表
    /// </summary>
    public class DAL_Role
    {
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public DataTable getRoleAll()
        {
            string sql = "select * from hd_role";
            return  DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="name">角色名称</param>
        /// <param name="description">角色描述</param>
        /// <returns></returns>
        public int AddRole(string name,string description)
        {
            string sql = $"  insert into hd_role (name,description) values('{name}','{description}')";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 获取单个角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetRoleInfoById(int id)
        {
            string sql = $"  select * from hd_role where id = {id}";
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public int EditRoleInfo(int id,string name,string description)
        {
            string sql = $"update hd_role set name = '{name}', description='{description}' where id = {id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteRole(int id)
        {
            string sql = $" delete from hd_role where id = {id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 获取所有菜单及权限
        /// </summary>
        /// <returns></returns>
        public DataTable GetPermission()
        {
            string sql = "select * from hd_backstageMenu";
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获取角色拥有菜单权限Id
        /// </summary>
        /// <returns></returns>
        public DataTable GetRoleHavePermission(int rid)
        {
            string sql = $"    select bsMenuId from hd_bsRole where rid={rid}";
            return DBhelper.ExecuteDataTable(sql);
        }
        
    }
}

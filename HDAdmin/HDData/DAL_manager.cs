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
    /// DAL-管理员信息表
    /// </summary>
    public class DAL_manager
    {
        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetManagerList()
        {
            string sql = "select r.name,r.description,ru.id,u.userName,ru.isFreeze from hd_role r left join hd_roleUser ru on ru.rid = r.id left join hd_user u on u.id = ru.uid  where u.userName is not null";
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获取角色列表信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetRoleList()
        {
            string sql = "  select * from hd_role";
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="rId">角色id</param>
        /// <param name="uId">用户id</param>
        /// <param name="isFreeze">管理员状态</param>
        /// <returns></returns>
        public int AddManager(int rId,int uId,int isFreeze)
        {
            string sql = $"insert into hd_roleUser(rid,uid,isFreeze)values({rId},{uId},{isFreeze})";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 该管理员是否已存在
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool IsHaveManager(int uid)
        {
            string sql = $"  select count(*)as count from hd_roleUser where uid ={uid}";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return Convert.ToInt32(dt.Rows[0]["count"]) > 0 ? true :false ;
        }
        /// <summary>
        /// 根据管理id获取管理员信息
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public DataTable GetManagerById(int mid)
        {
            string sql = $"  select * from hd_roleUser where id = {mid}";
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 修改管理信息
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="uid"></param>
        /// <param name="isFreeze"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EditManager(int rid,int uid,int isFreeze,int id)
        {
            string sql = $"update hd_roleUser set rid ={rid},uid={uid},isFreeze = {isFreeze} where id = {id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
    }
}

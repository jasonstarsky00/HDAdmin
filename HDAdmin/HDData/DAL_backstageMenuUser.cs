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
    /// DAL-后台菜单用户关联表
    /// </summary>
    public class DAL_backstageMenuUser
    {
        /// <summary>
        /// 根据用户id、路径获取对应的后台菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable FindByUidStr(int id,string str)
        {
            string sql = $"select count(*) as count from hd_user u left join hd_roleUser ru on ru.uid = u.id left join hd_bsRole br on br.rid = ru.rid left join hd_backstageMenu m on m.id = br.bsMenuId where m.str = '{str}' and m.isShow = 1 and u.id = {id} and ru.isFreeze=1 and u.isFreeze=1";
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 根据用户id获取对应菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetUserMenusByUid(int id)
        {
            string sql = $"select distinct m.* from hd_backstageMenu m left join  hd_bsRole bsr  on bsr.bsMenuId = m.id left join  hd_roleUser ru  on ru.rid = bsr.rid where ru.uid = {id} and m.type = 1 or m.type = 3 and m.isShow = 1 and ru.isFreeze = 1 order by m.sort";
            return DBhelper.ExecuteDataTable(sql);
        }
    }
}

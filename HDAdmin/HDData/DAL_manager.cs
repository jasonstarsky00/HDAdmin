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
            string sql = "select r.*,u.userName from hd_role r left join hd_roleUser ru on ru.rid = r.id left join hd_user u on u.id = ru.uid";
            return DBhelper.ExecuteDataTable(sql);
        }
    }
}

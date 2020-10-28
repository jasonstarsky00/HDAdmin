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
    /// DAL-token表
    /// </summary>
    public class DAL_token
    {
        /// <summary>
        /// 根据token值获取token信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public DataTable FindByToken(string token)
        {
            //需要增加范围，前后十二小时或者之类的，否则可能存在重复的问题
            string sql = $"  select * from hd_token where value = '{token}'";
            return DBhelper.ExecuteDataTable(sql);
        }
    }
}

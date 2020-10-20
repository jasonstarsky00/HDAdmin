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
    /// DAL-用户表
    /// </summary>
    public  class DAL_user
    {
        public DataTable TestGetUers()
        {
            string sql = "select * from hd_user";
            return  DBhelper.ExecuteDataTable(sql);
        }
    }
}

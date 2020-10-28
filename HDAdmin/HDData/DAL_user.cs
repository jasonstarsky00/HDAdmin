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
        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable FindById(int id)
        {
            string sql = $"select * from hd_user where id={id}";
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获取用户列表信息
        /// </summary>
        /// <param name="queryStr">查询条件</param>
        /// <param name="pageSize">显示数量</param>
        /// <param name="pageIndex">显示页码</param>
        /// <returns></returns>
        public DataTable GetUserList(string queryStr = "", int pageSize = 10, int pageIndex = 1)
        {
            string sql = @"select top {0} 
                        (select count(*) from hd_user u where 1=1 {1} )as total,* from 
                        (select ROW_NUMBER()over (order by id) as Row,u.* from hd_user u where 1=1 {2} )
                         hd_user where Row between  {3} and {4}";
            sql = string.Format(sql, pageSize, queryStr, queryStr, (pageSize * (pageIndex - 1)), pageSize * pageIndex);
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name">昵称</param>
        /// <param name="integral">积分</param>
        /// <param name="haveDownloads">剩余下载次数</param>
        /// <param name="isManager">是否管理</param>
        /// <param name="isVip">vip级别</param>
        /// <returns></returns>
        public int EditUserInfo(int id, string name, int integral, int haveDownloads, int isManager, int isVip)
        {
            string sql = $"update  hd_user set name='{name}',integral={integral},haveDownloads={haveDownloads},isManager={isManager},isVip={isVip} where id ={id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
    }
}

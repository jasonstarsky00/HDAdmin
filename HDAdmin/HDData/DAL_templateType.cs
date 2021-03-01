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
    /// DAL-模板类型表
    /// </summary>
    public class DAL_templateType
    {
        /// <summary>
        /// 获取模板分类列表
        /// </summary>
        /// <param name="queryStr">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">当前页码</param>
        /// <returns></returns>
        public DataTable GetTemplateTypeList(string queryStr = "", int pageSize = 10, int pageIndex = 1)
        {
            string sql = @"select top  {0} 
            (select count(*) from hd_templateType t where 1=1 {1}) as total,
             * from 
             (select ROW_NUMBER() over (order by id) as Row,t.* from hd_templateType t where 1=1 {2})
             hd_templateType where Row between {3} and {4}";
            sql = string.Format(sql, pageSize, queryStr, queryStr, (pageSize * (pageIndex - 1)), pageSize * pageIndex);
            return DBhelper.ExecuteDataTable(sql);

        }
        /// <summary>
        /// 增加类型
        /// </summary>
        /// <param name="type">所属分类</param>
        /// <param name="name">类型名称</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int AddType(int type,string name,int status)
        {
            string sql = $" insert into hd_templateType(type,typeName,status)values({type},'{name}',{status})";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 根据id查找类型信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable FindById(int id)
        {
            string sql = $"  select * from hd_templateType where id = {id}";
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int EditType(int id,int type,int status,string name)
        {
            string sql = $"update hd_templateType set type = {type},typeName = '{name}',status={status} where id = {id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 删除类型
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public int DeleteType(int id)
        {
            string sql = $"  delete from hd_templateType where id = {id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 获取所有分类名称和id
        /// </summary>
        /// <returns></returns>
        public DataTable GetPptTypes()
        {
            string sql = " select id,typeName from hd_templateType";
            return DBhelper.ExecuteDataTable(sql);
        }
    }
}

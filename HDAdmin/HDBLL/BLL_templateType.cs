using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDBLL
{
    /// <summary>
    /// BLL-模板类型表
    /// </summary>
    public class BLL_templateType
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_templateType Instance { get; private set; }
        //私有构造函数
        private BLL_templateType()
        {
        }
        //静态构造函数
        static BLL_templateType()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_templateType();
                }
            }
        }
        private HDData.DAL_templateType bll = new HDData.DAL_templateType();

        /// <summary>
        /// 获取模板分类列表
        /// </summary>
        /// <param name="queryStr">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">当前页码</param>
        /// <returns></returns>
        public DataTable GetTemplateTypeList(string queryStr = "", int pageSize = 10, int pageIndex = 1)
        {
            return bll.GetTemplateTypeList(queryStr, pageSize, pageIndex);
        }
        /// <summary>
        /// 增加类型
        /// </summary>
        /// <param name="type">所属分类</param>
        /// <param name="name">类型名称</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public int AddType(int type, string name, int status)
        {
            return bll.AddType(type, name, status);
        }

        /// <summary>
        /// 根据id查找类型信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable FindById(int id)
        {
            return bll.FindById(id);
        }

        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int EditType(int id, int type, int status, string name)
        {
            return bll.EditType(id, type, status, name);
        }
        /// <summary>
        /// 删除类型
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public int DeleteType(int id)
        {
            return bll.DeleteType(id);
        }
    }
}

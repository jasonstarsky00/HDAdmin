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
    /// BLL-模板类
    /// </summary>
    public class BLL_ppt
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_ppt Instance { get; private set; }
        //私有构造函数
        private BLL_ppt()
        {
        }
        //静态构造函数
        static BLL_ppt()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_ppt();
                }
            }
        }
        private HDData.DAL_ppt bll = new HDData.DAL_ppt();

        /// <summary>
        /// 获取模板列表信息
        /// </summary>
        /// <param name="queryStr">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">当前页码</param>
        /// <returns></returns>
        public DataTable GetPptList(string queryStr = "", int pageSize = 10, int pageIndex = 1)
        {
            return bll.GetPptList(queryStr, pageSize, pageIndex);
        }
        /// <summary>
        /// 添加模板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPpt(ppt model)
        {
            return bll.AddPpt(model);
        }
        /// <summary>
        /// 根据id获取模板信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable findById(int id)
        {
            return bll.findById(id);
        }

        /// <summary>
        /// ppt初次审核
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reId"></param>
        /// <param name="reMsg"></param>
        /// <returns></returns>
        public int pptFistReView(int id, int reId, string reMsg, int uid)
        {
            return bll.pptFistReView(id, reId, reMsg, uid);
        }
        /// <summary>
        /// ppt最终审核
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reId"></param>
        /// <param name="reMsg"></param>
        /// <returns></returns>
        public int pptLastReView(int id, int reId, string reMsg, int uid, int pptStatus)
        {
            return bll.pptLastReView(id, reId, reMsg, uid, pptStatus);
        }
    }
}

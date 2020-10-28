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
    /// BLL-管理员信息表
    /// </summary>
    public class BLL_manager
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_manager Instance { get; private set; }
        //私有构造函数
        private BLL_manager()
        {
        }
        //静态构造函数
        static BLL_manager()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_manager();
                }
            }
        }
        private HDData.DAL_manager bll = new HDData.DAL_manager();

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <returns></returns>
        public List<manager> GetManagerList()
        {
            DataTable dt = bll.GetManagerList();
            return ModelConvertHelper<manager>.ConverModel(dt);
        }
    }
}

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
    /// BLL-用户表
    /// </summary>
    public class BLL_user
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_user Instance { get; private set; }
        //私有构造函数
        private BLL_user()
        {
        }
        //静态构造函数
        static BLL_user()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_user();
                }
            }
        }
        private HDData.DAL_user bll = new HDData.DAL_user();

        public user TestGetusers()
        {
            DataTable dt = bll.TestGetUers();
            return ModelConvertHelper<user>.DtReturnFirst(dt);
        }
    }
}

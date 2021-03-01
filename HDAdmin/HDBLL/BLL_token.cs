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
    /// BLL-token表
    /// </summary>
    public class BLL_token
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_token Instance { get; private set; }
        //私有构造函数
        private BLL_token()
        {
        }
        //静态构造函数
        static BLL_token()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_token();
                }
            }
        }
        private HDData.DAL_token bll = new HDData.DAL_token();

        /// <summary>
        /// 根据token值获取token信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public token FindByToken(string token)
        {
            DataTable dt = bll.FindByToken(token);
            return ModelConvertHelper<token>.DtReturnFirst(dt);
        }

    }
}

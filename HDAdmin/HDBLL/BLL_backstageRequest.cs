using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDBLL
{
    /// <summary>
    /// BLL-后台访问表
    /// </summary>
    public class BLL_backstageRequest
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_backstageRequest Instance { get; private set; }
        //私有构造函数
        private BLL_backstageRequest()
        {
        }
        //静态构造函数
        static BLL_backstageRequest()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_backstageRequest();
                }
            }
        }
        private HDData.DAL_backstageRequest bll = new HDData.DAL_backstageRequest();

        /// <summary>
        /// 保存后台访问请求
        /// </summary>
        /// <param name="ip">ip</param>
        /// <param name="borwser">浏览器</param>
        /// <param name="url">请求地址</param>
        /// <param name="type">请求类型</param>
        public void SaveBsRequest(string ip = "", string borwser = "", string url = "", string type = "")
        {
            bll.SaveBsRequest(ip, borwser, url, type);
        }
    }
}

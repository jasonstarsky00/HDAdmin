using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDModels
{
    /// <summary>
    /// 后台访问表
    /// </summary>
    public class backstageRequest
    {
        public int id { get; set; }
        /// <summary>
        /// 请求时间
        /// </summary>
        public DateTime time { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string ip { get; set; }
        /// <summary>
        /// 浏览器
        /// </summary>
        public string browser { get; set; }
        /// <summary>
        /// 请求路径
        /// </summary>
        public string requestUrl { get; set; }
        /// <summary>
        /// 请求类型
        /// </summary>
        public string requestType { get; set; }
    }
}

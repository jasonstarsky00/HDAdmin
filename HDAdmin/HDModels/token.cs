using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDModels
{
    /// <summary>
    /// token表
    /// </summary>
    public class token
    {
        public int id { get; set; }
        /// <summary>
        /// token值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// 有效时间
        /// </summary>
        public DateTime effectiveTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDModels
{
    /// <summary>
    /// 管理员信息表
    /// </summary>
    public class manager
    {
        public int id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 是否冻结
        /// </summary>
        public int isFreeze { get; set; }

    }
}

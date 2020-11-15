using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDModels
{
    /// <summary>
    /// 角色表
    /// </summary>
    public class role
    {
        public int id { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 角色描述
        /// </summary>
        public string description { get; set; }
    }
}

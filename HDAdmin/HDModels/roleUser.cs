using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDModels
{
    /// <summary>
    /// 角色关联用户表
    /// </summary>
    public class roleUser
    {
        public int id { get; set; }
        public int rid { get; set; }
        public int uid { get; set; }
        public int isFreeze { get; set; }
    }
}

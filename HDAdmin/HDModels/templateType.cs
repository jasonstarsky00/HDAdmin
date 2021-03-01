using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDModels
{
    /// <summary>
    /// 模板类型表
    /// </summary>
    public class templateType
    {
        public int id { get; set; }
        /// <summary>
        /// 所属大类：1类型；2行业；3用途
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string typeName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }
    }
    /// <summary>
    /// 后台需用分类
    /// </summary>
    public class pptTypes
    {
        public int id { get; set; }
        public string typeName { get; set; }
    }
} 

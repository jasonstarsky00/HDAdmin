using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDModels
{
    /// <summary>
    /// 后台菜单用户关联表
    /// </summary>
    public class backstageMenuUser
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string menuName { get; set; }
        /// <summary>
        /// 控制器/第一路径
        /// </summary>
        public string control { get; set; }
        /// <summary>
        /// 方法/第二路径
        /// </summary>
        public string action { get; set; }
        /// <summary>
        /// 组合路径
        /// </summary>
        public string str { get; set; }
        /// <summary>
        /// 菜单父级id
        /// </summary>
        public int parentId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 菜单等级
        /// </summary>
        public int menuLevel { get; set; }
        /// <summary>
        /// icon
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 类型：1菜单；2功能；3菜单和功能
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 菜单是否显示
        /// </summary>
        public int isShow { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }
    }
    /// <summary>
    /// 返回菜单
    /// </summary>
    public class BsMenus
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string menuName { get; set; }
        /// <summary>
        /// 控制器/第一路径
        /// </summary>
        public string control { get; set; }
        /// <summary>
        /// 方法/第二路径
        /// </summary>
        public string action { get; set; }
        /// <summary>
        /// 组合路径
        /// </summary>
        public string str { get; set; }
        /// <summary>
        /// 菜单父级id
        /// </summary>
        public int parentId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int sort { get; set; }
        /// <summary>
        /// 菜单等级
        /// </summary>
        public int menuLevel { get; set; }
        /// <summary>
        /// icon
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 类型：1菜单；2功能；3菜单和功能
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 菜单是否显示
        /// </summary>
        public int isShow { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }
        public List<backstageMenuUser> child { get; set; }
    }
  
}

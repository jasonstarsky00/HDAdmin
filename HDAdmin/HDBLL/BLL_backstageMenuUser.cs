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
    /// BLL-后台菜单用户关联表
    /// </summary>
    public class BLL_backstageMenuUser
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_backstageMenuUser Instance { get; private set; }
        //私有构造函数
        private BLL_backstageMenuUser()
        {
        }
        //静态构造函数
        static BLL_backstageMenuUser()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_backstageMenuUser();
                }
            }
        }
        private HDData.DAL_backstageMenuUser bll = new HDData.DAL_backstageMenuUser();

        /// <summary>
        /// 根据用户id、路径获取对应的后台菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int FindByUidStr(int id,string str)
        {
            DataTable dt = bll.FindByUidStr(id, str);
            return Convert.ToInt32(dt.Rows[0]["count"]);
        }

        /// <summary>
        /// 根据用户id获取对应菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<backstageMenuUser> GetUserMenusByUid(int id)
        {
            DataTable dt = bll.GetUserMenusByUid(id);
            return ModelConvertHelper<backstageMenuUser>.ConverModel(dt);
        }
    }
}

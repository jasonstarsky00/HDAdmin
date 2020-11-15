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
    /// BLL-管理员信息表
    /// </summary>
    public class BLL_manager
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_manager Instance { get; private set; }
        //私有构造函数
        private BLL_manager()
        {
        }
        //静态构造函数
        static BLL_manager()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_manager();
                }
            }
        }
        private HDData.DAL_manager bll = new HDData.DAL_manager();

        /// <summary>
        /// 获取管理员信息
        /// </summary>
        /// <returns></returns>
        public List<manager> GetManagerList()
        {
            DataTable dt = bll.GetManagerList();
            return ModelConvertHelper<manager>.ConverModel(dt);
        }
        /// <summary>
        /// 获取角色列表信息
        /// </summary>
        /// <returns></returns>
        public List<role> GetRoleList()
        {
            DataTable dt = bll.GetRoleList();
            return ModelConvertHelper<role>.ConverModel(dt);
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="rId">角色id</param>
        /// <param name="uId">用户id</param>
        /// <param name="isFreeze">管理员状态</param>
        /// <returns></returns>
        public int AddManager(int rId, int uId, int isFreeze)
        {
            return bll.AddManager(rId, uId, isFreeze);
        }

        /// <summary>
        /// 该管理员是否已存在
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public bool IsHaveManager(int uid)
        {
            return bll.IsHaveManager(uid);
        }

        /// <summary>
        /// 根据管理id获取管理员信息
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public roleUser GetManagerById(int mid)
        {
            DataTable dt = bll.GetManagerById(mid);
            return ModelConvertHelper<roleUser>.DtReturnFirst(dt);
        }
        /// <summary>
        /// 修改管理信息
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="uid"></param>
        /// <param name="isFreeze"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EditManager(int rid, int uid, int isFreeze, int id)
        {
            return bll.EditManager(rid, uid, isFreeze, id);
        }
    }
}

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
    /// BLL-用户表
    /// </summary>
    public class BLL_user
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_user Instance { get; private set; }
        //私有构造函数
        private BLL_user()
        {
        }
        //静态构造函数
        static BLL_user()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_user();
                }
            }
        }
        private HDData.DAL_user bll = new HDData.DAL_user();

        public user TestGetusers()
        {
            DataTable dt = bll.TestGetUers();
            return ModelConvertHelper<user>.DtReturnFirst(dt);
        }

        /// <summary>
        /// 根据id获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public user FindById(int id)
        {
            DataTable dt = bll.FindById(id);
            return ModelConvertHelper<user>.DtReturnFirst(dt);
        }

        /// <summary>
        /// 获取用户列表信息
        /// </summary>
        /// <param name="queryStr">查询条件</param>
        /// <param name="pageSize">显示数量</param>
        /// <param name="pageIndex">显示页码</param>
        /// <returns></returns>
        public DataTable GetUserList(string queryStr = "", int pageSize = 10, int pageIndex = 1)
        {
            return bll.GetUserList(queryStr, pageSize, pageIndex);
        }

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name">昵称</param>
        /// <param name="integral">积分</param>
        /// <param name="haveDownloads">剩余下载次数</param>
        /// <param name="isManager">是否管理</param>
        /// <param name="isVip">vip级别</param>
        /// <returns></returns>
        public int EditUserInfo(int id, string name, int integral, int haveDownloads, int isManager, int isVip)
        {
            return bll.EditUserInfo(id, name, integral, haveDownloads, isManager, isVip);
        }

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public user FindByUserName(string userName)
        {
            DataTable dt = bll.FindByUserName(userName);
            return ModelConvertHelper<user>.DtReturnFirst(dt);
        }
    }
}

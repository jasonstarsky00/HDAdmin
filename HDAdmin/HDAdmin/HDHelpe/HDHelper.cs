using HDBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HDAdmin.HDHelpe
{
    /// <summary>
    /// HD-帮助类
    /// </summary>
    public class HDHelper
    {
        /// <summary>
        /// 保存后台访问请求
        /// </summary>
        /// <param name="ip">ip</param>
        /// <param name="borwser">浏览器</param>
        /// <param name="url">请求地址</param>
        /// <param name="type">请求类型</param>
        public static  void SaveBsRequest(string ip = "", string borwser = "", string url = "", string type = "")
        {
            BLL_backstageRequest.Instance.SaveBsRequest(ip, borwser, url, type);
        }
    }
}
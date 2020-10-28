using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXCommon;

namespace HDData
{
    /// <summary>
    /// DAL-后台访问表
    /// </summary>
    public class DAL_backstageRequest
    {
        /// <summary>
        /// 保存后台访问请求
        /// </summary>
        /// <param name="ip">ip</param>
        /// <param name="borwser">浏览器</param>
        /// <param name="url">请求地址</param>
        /// <param name="type">请求类型</param>
        public void SaveBsRequest(string ip="",string borwser = "", string url = "", string type = "")
        {
            string sql = $"insert into hd_backstageRequest(ip,browser,requestUrl,requestType)values('{ip}','{borwser}','{url}','{type}')";
            DBhelper.ExecuteNonQuery(sql);
        }
    }
}

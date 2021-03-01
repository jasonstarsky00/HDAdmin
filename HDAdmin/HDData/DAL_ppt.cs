using HDModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXCommon;

namespace HDData
{
    /// <summary>
    /// DAL-模板表
    /// </summary>
    public class DAL_ppt
    {
        /// <summary>
        /// 获取模板列表信息
        /// </summary>
        /// <param name="queryStr">查询条件</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="pageIndex">当前页码</param>
        /// <returns></returns>
        public DataTable GetPptList(string queryStr = "", int pageSize = 10, int pageIndex = 1)
        {
            string sql = @"select top {0}
                        (select count(*) from hd_ppt u where 1=1 {1})as total,* from
                        (select ROW_NUMBER() over (order by id) as Row,p.* from hd_ppt p where 1 =1{2})
                        hd_ppt where Row between {3} and {4}";
            sql = string.Format(sql, pageSize, queryStr, queryStr, (pageSize * (pageIndex - 1)), pageSize * pageIndex);
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 添加模板
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddPpt(ppt model)
        {
            string sql = $"insert into hd_ppt(pptTitle,pptTemplateType,pptPrice,pptDownloadSrc,pptVideoSrc,pptImgSrc,pptColor,pptLookNumber,pptDownloadNumber,pptFavoeitesNumber,pptProportion,pptUploadUid,pptStatus,pptIsShow)values('{model.pptTitle}', {model.pptTemplateType}, {model.pptPrice}, '{model.pptDownloadSrc}', '{model.pptVideoSrc}', '{model.pptImgSrc}', '{model.pptColor}', {model.pptLookNumber}, {model.pptDownloadNumber}, {model.pptFavoeitesNumber}, '{model.pptProportion}', {model.pptUploadUid}, {model.pptStatus}, {model.pptIsShow})";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 根据id获取模板信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable findById(int id)
        {
            string sql = $"select * from hd_ppt where id ={id}";
            return DBhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// ppt初次审核
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reId"></param>
        /// <param name="reMsg"></param>
        /// <returns></returns>
        public int pptFistReView(int id,int reId,string reMsg,int uid)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
            string sql = $"  update hd_ppt set pptFirstReviewInfo = '{reMsg}',pptStatus = {reId},pptFirstReviewUid ={uid},pptFirstReviewTime='{time}' where id ={id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// ppt最终审核
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reId"></param>
        /// <param name="reMsg"></param>
        /// <returns></returns>
        public int pptLastReView(int id, int reId, string reMsg, int uid,int pptStatus)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
            string sql = $"  update hd_ppt set pptLastReviewInfo = '{reMsg}',pptStatus = {reId},pptLastReviewUid ={uid},pptLastReviewTime='{time}',pptIsShow ={pptStatus} where id ={id}";
            return DBhelper.ExecuteNonQuery(sql);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDModels
{
    /// <summary>
    /// 模板类
    /// </summary>
    public class ppt
    {
        public int id { get; set; }
        /// <summary>
        /// 模板标题
        /// </summary>
        public string pptTitle { get; set; }
        /// <summary>
        /// 所属模板类型
        /// </summary>
        public int pptTemplateType { get; set; }
        /// <summary>
        /// 模板价格
        /// </summary>
        public decimal pptPrice { get; set; }
        /// <summary>
        /// 模板视频路径
        /// </summary>
        public string pptVideoSrc { get; set; }
        /// <summary>
        /// 模板图片路径
        /// </summary>
        public string pptImgSrc { get; set; }
        /// <summary>
        /// 模板下载地址
        /// </summary>
        public string pptDownloadSrc { get; set; }
        /// <summary>
        /// 模板观看次数
        /// </summary>
        public int pptLookNumber { get; set; }
        /// <summary>
        /// 模板下载次数
        /// </summary>
        public int pptDownloadNumber { get; set; }
        /// <summary>
        /// 模板收藏次数
        /// </summary>
        public int pptFavoeitesNumber { get; set; }
        /// <summary>
        /// 模板类型：例如：16:9
        /// </summary>
        public string pptProportion { get; set; }
        /// <summary>
        /// 模板主要颜色
        /// </summary>
        public string pptColor { get; set; }
        /// <summary>
        /// 模板上传时间
        /// </summary>
        public DateTime pptUploadTime { get; set; }
        /// <summary>
        /// 模板上传用户id
        /// </summary>
        public int pptUploadUid { get; set; }
        /// <summary>
        /// 初审信息
        /// </summary>
        public string pptFirstReviewInfo { get; set; }
        /// <summary>
        /// 模板第一次审核用户id
        /// </summary>
        public int pptFirstReviewUid { get; set; }
        /// <summary>
        /// 模板第一次审核时间
        /// </summary>
        public DateTime pptFirstReviewTime { get; set; }
        /// <summary>
        /// 终审信息
        /// </summary>
        public string pptLastReviewInfo { get; set; }
        /// <summary>
        /// 模板最终审核用户id
        /// </summary>
        public int pptLastReviewUid { get; set; }
        /// <summary>
        /// 模板最终审核时间
        /// </summary>
        public DateTime pptLastReviewTime { get; set; }
        /// <summary>
        /// 模板状态：1：上传；2：初次审核；3初审失败；4最终审核；5终审失败
        /// </summary>
        public int pptStatus { get; set; }
        /// <summary>
        /// 模板是否展示：0否；1是
        /// </summary>
        public int pptIsShow { get; set; }

    }
}

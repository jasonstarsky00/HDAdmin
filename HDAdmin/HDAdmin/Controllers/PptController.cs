using HDAdmin.HDBase;
using HDBLL;
using HDModels;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using XXCommon;
namespace HDAdmin.Controllers
{
    public class PptController : ConBase
    {
        /// <summary>
        /// 模板列表
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult List(string title="", int pageSize = 30, int pageIndex = 1)
        {
            int code = 100;
            string msg = "获取模板数据失败";
            StringBuilder sb = new StringBuilder();
            if(title != "")
            {
                sb.Append($"and  pptTitle LIKE '%{title}%'");

            }
            DataTable dt = BLL_ppt.Instance.GetPptList(sb.ToString(), pageSize, pageIndex);
            List<ppt> pptList = ModelConvertHelper<ppt>.ConverModel(dt);
            if (pptList.Count > 0)
            {
                code = 200;
                msg = "获取模板数据成功";
            }
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            string sResult = Newtonsoft.Json.JsonConvert.SerializeObject(new { code = code, msg = msg, data = new { total = dt.Rows.Count > 0 ? dt.Rows[0]["total"] : 0, title = title, pageIndex = pageIndex, pageSize = pageSize, pptList = pptList } }, timeConverter);
            return Json(sResult, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 上传PPT
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadPpt(HttpPostedFileBase file)
        {
            int code = 100;
            string msg = "ppt上传失败";
            string pptSrc = "";
            string res = SavePpt(file);
            

            if (res != "")
            {
                code = 200;
                msg = "ppt上传成功";
                pptSrc = res;
            }
            return Json(new { code = code,msg=msg, pptSrc = pptSrc }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 上传视频
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadVideo(HttpPostedFileBase file)
        {
            int code = 100;
            string msg = "视频上传失败";
            string videoSrc = "";
            string res = SaveVideo(file);


            if (res != "")
            {
                code = 200;
                msg = "视频上传成功";
                videoSrc = res;
            }
            return Json(new { code = code, msg = msg, videoSrc = videoSrc }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 上传视频
        /// </summary>
        /// <returns></returns>
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            int code = 100;
            string msg = "图片上传失败";
            string imageSrc = "";
            string res = SaveImage(file);


            if (res != "")
            {
                code = 200;
                msg = "图片上传成功";
                imageSrc = res;
            }
            return Json(new { code = code, msg = msg, imageSrc = imageSrc }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SavePptInfo(string pptTitle="",int pptType=0,decimal pptPrice=0,string pptDownloadSrc="", string pptVideoSrc="",string pptImgSrc="",string pptColor="")
        {
            int code = 100;
            string msg = "";
            #region 基本判断
            if (pptTitle == "")
            {
                msg = "标题不能为空";
                return Json(new { code = code, msg = msg });
            }
            if (pptDownloadSrc == "")
            {
                msg = "模板路径不能为空";
                return Json(new { code = code, msg = msg });
            }
            if (pptVideoSrc == "")
            {
                msg = "视频路径不能为空";
                return Json(new { code = code, msg = msg });
            }
            if (pptImgSrc == "")
            {
                msg = "图片路径不能为空";
                return Json(new { code = code, msg = msg });
            }
            if (pptColor == "")
            {
                msg = "模板主颜色不能为空";
                return Json(new { code = code, msg = msg });
            }
            #endregion

            token token = BLL_token.Instance.FindByToken(Request.Headers["Authorization"]);
            ppt ppt = new ppt();
            ppt.pptTitle = pptTitle;
            ppt.pptTemplateType = pptType;
            ppt.pptPrice = pptPrice;
            ppt.pptDownloadSrc = pptDownloadSrc;
            ppt.pptVideoSrc = pptVideoSrc;
            ppt.pptImgSrc = pptImgSrc;
            ppt.pptColor = pptColor;
            ppt.pptLookNumber = 0;
            ppt.pptDownloadNumber = 0;
            ppt.pptFavoeitesNumber = 0;
            ppt.pptProportion = "16:9";
            ppt.pptUploadUid = token.uid;
            ppt.pptStatus = 1;
            ppt.pptIsShow = 0;

            int res = BLL_ppt.Instance.AddPpt(ppt);
            if (res > 0)
            {
                code = 200;
                msg = "新增成功";
            }
            return Json(new { code = code, msg = msg }, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 保存上传的ppt模板，返回路径
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public string SavePpt(HttpPostedFileBase file)
        {
            string filesrc = "";
            try
            {
                //如果文件不为空
                if (file != null)
                {
                    string fileName = "HD-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pptx";
                    string path = Server.MapPath(string.Format("~/ppt/ppt/"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(Path.Combine(path, fileName));
                    filesrc = path + fileName;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
            
            return filesrc;
        }

        /// <summary>
        /// 保存上传的视频模板，返回路径
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public string SaveVideo(HttpPostedFileBase file)
        {
            string filesrc = "";
            try
            {
                //如果文件不为空
                if (file != null)
                {
                    string fileName = "HD-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".mp4";
                    string path = Server.MapPath(string.Format("~/ppt/video/"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(Path.Combine(path, fileName));
                    filesrc = path + fileName;
                }
            }
            catch (Exception)
            {

                throw;
            }


            return filesrc;
        }

        /// <summary>
        /// 保存上传的视频模板，返回路径
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public string SaveImage(HttpPostedFileBase file)
        {
            string filesrc = "";
            try
            {
                //如果文件不为空
                if (file != null)
                {
                    string fileName = "HD-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                    string path = Server.MapPath(string.Format("~/ppt/images/"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    file.SaveAs(Path.Combine(path, fileName));
                    filesrc = path + fileName;
                }
            }
            catch (Exception)
            {

                throw;
            }


            return filesrc;
        }
        public string save(HttpPostedFileBase file)
        {
            string res = "";
            if (file != null)
            {
                try
                {
                    //文件名
                    string fileName = "HD-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pptx";
                    //文件大小，单位字节
                    int fileContentLength = file.ContentLength;
                    //上传文件路径
                    string path = Server.MapPath(string.Format("~/ppt/ppt/"));

                    //二进制数组
                    byte[] fileBytes = null;
                    fileBytes = new byte[fileContentLength];
                    //创建Stream对象，并指向上传文件
                    Stream fileStream = file.InputStream;
                    //从当前流中读取字节，读入字节数组中
                    fileStream.Read(fileBytes, 0, fileContentLength);
                    //全路径（路劲+文件名）
                    string fullPath = path + fileName;
                    //保存到磁盘
                    SaveToDisk(fileBytes, fullPath);
                    res = fullPath;
                }
                catch (Exception ex)
                {
                    res = ex.Message;
                    throw;
                }
            }
            return res;
        }
        /// <summary>
        /// 保存到磁盘
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <param name="saveFullPath">全路径</param>
        /// <returns></returns>
        public void SaveToDisk(byte[] bytes, string saveFullPath)
        {
            var fullPath = Path.GetDirectoryName(saveFullPath);
            //如果没有此文件夹，则新建
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            
            //创建文件，返回一个 FileStream，它提供对 path 中指定的文件的读/写访问。
            using (FileStream stream = System.IO.File.Create(saveFullPath))
            {
                //将字节数组写入流
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }
        }
        /// <summary>
        /// 模板审核---获取模板信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Review(int id)
        {
            int code = 100;
            string msg = "获取模板失败";
            ppt ppt = new ppt();
            DataTable dt = BLL_ppt.Instance.findById(id);
            if (dt.Rows.Count > 0)
            {
                ppt = ModelConvertHelper<ppt>.DtReturnFirst(dt);
                code = 200;
                msg = "获取成功";
            }
            return Json(new { code = code, msg = msg, data = ppt }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reId"></param>
        /// <param name="reMsg"></param>
        /// <param name="status">1初审，2终审</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Review(int id=0,int reId=0,string reMsg="",int status=0)
        {
            int code = 100;
            string msg = "审核失败";
            if (id>0&& reId>0&& reMsg != "")
            {
                //获取模板状态
                DataTable dt = BLL_ppt.Instance.findById(id);
                ppt ppt = ModelConvertHelper<ppt>.DtReturnFirst(dt);
                token token = BLL_token.Instance.FindByToken(Request.Headers["Authorization"]);
                //初审
                if (status == 1){
                    //初审-只有上传状态
                    if (ppt.pptStatus == 1)
                    {
                        int res = BLL_ppt.Instance.pptFistReView(id, reId, reMsg, token.uid);
                        //审核成功
                        if (res > 0)
                        {
                            code = 200;
                            msg = "初审成功";
                        }
                    }
                }else if (status == 2)
                {
                    //未初审
                    if (ppt.pptStatus == 1)
                    {
                        msg = "模板未初审";
                    }else
                    {
                        int pptStatus = 0;
                        if (reId == 4)
                        {
                            pptStatus = 1;
                        }
                        //终审决定显示展示
                        int res = BLL_ppt.Instance.pptLastReView(id, reId, reMsg, token.uid, pptStatus);
                        //审核成功
                        if (res > 0)
                        {
                            code = 200;
                            msg = "终审成功";
                        }
                    }
                }
            }
            return Json(new { code = code, msg = msg }, JsonRequestBehavior.AllowGet);
        }
    }
}
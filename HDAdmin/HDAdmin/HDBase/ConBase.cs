using HDAdmin.HDHelpe;
using HDBLL;
using HDModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HDAdmin.HDBase
{
    /// <summary>
    /// 过滤器
    /// </summary>
    public class ConBase: Controller
    {
        /// <summary>
        /// 方法加载之前
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            //获取请求详情，保存到数据库中
            HttpRequestBase Request = HttpContext.Request;
            //记录请求的内容
            HDHelper.SaveBsRequest(Request.UserHostAddress, Request.Browser.Browser, Request.Url.AbsolutePath, Request.RequestType);

            //如果是请求登录
            if (Request.Url.AbsolutePath == "/home/login")
            {
                 base.OnActionExecuting(filterContext);
            }
            else
            {
                
                //首先判断是否有token
                if (Request.Headers["Authorization"] == null)
                {
                    //无，返回错误信息
                    filterContext.Result = BaseHelper.ResultJson(100, "token不能为空，请重新登录");
                }
                else
                {
                    //有，下一步
                    //token有效期
                    token tokenInfo = BLL_token.Instance.FindByToken(Request.Headers["Authorization"]);

                    //获取当前时间
                    DateTime nowTime = Convert.ToDateTime(DateTime.Now.ToString());
                    if (nowTime > tokenInfo.effectiveTime)
                    {
                        //无效
                        filterContext.Result = BaseHelper.ResultJson(100, "登录过期，请重新登录");
                        

                    }
                    else
                    {
                        //有效期，下一步
                        //判断是否拥有权限
                        int isHaveMenu = BLL_backstageMenuUser.Instance.FindByUidStr(tokenInfo.uid, Request.Url.AbsolutePath.ToLower());
                        if (isHaveMenu ==0)
                        {
                            filterContext.Result = BaseHelper.ResultJson(100, "无权限操作");
                        }
                    }


                }





            }


        }
    }
}
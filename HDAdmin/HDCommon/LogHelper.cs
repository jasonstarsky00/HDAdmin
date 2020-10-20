using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXCommon
{
    /// <summary>
    /// 日志类
    /// </summary>
    public class LogHelper
    {
        //默认路径
        private static string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Logs\";

        /// <summary>
        /// 生成日志
        /// </summary>
        /// <param name="pathFileNameStr">路径文件名及格式，如：Sql\</param>
        /// <param name="txt"></param>
        public static void WriteLogs(string txt, string pathStr = "")
        {
            try
            {
                //如果不存在目录
                if (!Directory.Exists(path + pathStr))
                {
                    Directory.CreateDirectory(path + pathStr);
                }
                //如果不存在该文件
                if (!File.Exists(path + pathStr + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"))
                {
                    using (FileStream fs = File.Create(path + pathStr + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt"))
                    {
                    }
                }
                //写入内容
                using (StreamWriter sw = new StreamWriter(path + pathStr + @"\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true, Encoding.Default))
                {
                    sw.WriteLine($"{DateTime.Now.ToString("\r\n  yyyy-MM-dd HH:mm:ss fff")}   :   {txt}");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("经过进一步包装的异常", ex);
            }
        }

    }
}

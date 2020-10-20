using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XXCommon
{
    /// <summary>
    /// Model帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ModelConvertHelper<T> where T : new()
    {
        /// <summary>
        /// datatable转list
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ConverModel(DataTable dt)
        {
            // 定义集合   
            List<T> ts = new List<T>();
            //获得此模型的类型
            Type type = typeof(T);
            string tempName = "";
            foreach (DataRow dr in dt.Rows)
            {
                //定义一个实体类对象
                T t = new T();
                //获取该实体对象所有属性
                PropertyInfo[] propertyInfos = t.GetType().GetProperties();
                //遍历该实体对象所有属性
                foreach (PropertyInfo pi in propertyInfos)
                {
                    //将属性名赋给临时变量
                    tempName = pi.Name;
                    //检查是否包含此列   '检查datatable 是否包含此列（列名==对象的属性名）
                    if (dt.Columns.Contains(tempName))
                    {
                        //判断是否setter 如果不可写，跳过
                        if (!pi.CanWrite) continue;
                        object value = dr[tempName];
                        if (value != DBNull.Value) //如果非空，则赋给对象的属性
                        {
                            //写入
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                //添加到集合中
                ts.Add(t);
            }
            //返回实体集合
            return ts;
        }
        /// <summary>
        /// datatable返回第一行内容
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T DtReturnFirst(DataTable dt)
        {
            T t = new T();
            Type type = typeof(T);
            string tempName = "";
            foreach (DataRow dr in dt.Rows)
            {
                PropertyInfo[] propertyInfos = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertyInfos)
                {
                    tempName = pi.Name;
                    if (dt.Columns.Contains(tempName))
                    {
                        if (!pi.CanRead) continue;
                        object value = dr[tempName];
                        if (value != DBNull.Value)
                            pi.SetValue(t, value, null);
                    }
                }
            }
            return t;
        }
    }
}

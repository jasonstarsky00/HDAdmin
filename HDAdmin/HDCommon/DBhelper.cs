using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XXCommon
{
    /// <summary>
    /// 数据库帮助类
    /// </summary>
    public partial class DBhelper
    {


        private static string connectStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;


        /// <summary>
        ///  1.执行增、删、改的方法：ExecuteNonQuery
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="pms"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(connectStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    LogHelper.WriteLogs( cmd.CommandText,"Sql");
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        //2.封装一个执行返回单个对象的方法：ExecuteScalar()
        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(connectStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    LogHelper.WriteLogs(cmd.CommandText, "Sql");
                    return cmd.ExecuteScalar();
                }
            }
        }


        //3.执行查询多行多列的数据的方法：ExecuteReader
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(connectStr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    LogHelper.WriteLogs(cmd.CommandText, "Sql");
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }


        //4.执行返回DataTable的方法
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connectStr))
            {


                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                LogHelper.WriteLogs(sql, "Sql");
                adapter.Fill(dt);
            }
            return dt;

        }

        /// <summary>
        /// 返回第一行第一列内容
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static string ExecScalar(string sql, SqlParameter[] sqlParameter = null)
        {
            string value = "";
            using (SqlConnection sqlConn = new SqlConnection(connectStr))
            {
                sqlConn.Open();
                if (sqlConn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = new SqlCommand(sql, sqlConn))
                    {
                        LogHelper.WriteLogs(cmd.CommandText, "Sql");
                        if (sqlParameter != null && sqlParameter.Length > 0)
                            cmd.Parameters.AddRange(sqlParameter);
                        value = cmd.ExecuteScalar().ToString();
                    }
                }
            }
            return value;
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="sql">存储过程名称</param>
        /// <param name="sqlParameter">定义的sql语句 不超过4000字</param>
        /// <returns></returns>
        public static object ExecStoreProcedureSql(string sql, SqlParameter[] sqlParameter = null)
        {
            
            object val = "";
            using (SqlConnection sqlCon = new SqlConnection(connectStr))
            {
                sqlCon.Open();
                if (sqlCon.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = new SqlCommand(sql, sqlCon))
                    {
                        LogHelper.WriteLogs(cmd.CommandText, "Sql");
                        if (sqlParameter != null && sqlParameter.Length > 0)
                        {
                            try
                            {
                                cmd.Parameters.AddRange(sqlParameter);
                                cmd.CommandType = CommandType.StoredProcedure;
                                val = cmd.ExecuteNonQuery();
                                return val;
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("经过进一步包装的异常", ex);
                            }

                        }


                    }
                }
            }
            return val;

        }
    }
}

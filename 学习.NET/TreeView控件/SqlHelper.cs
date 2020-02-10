using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeView控件
{
    public static class SqlHelper
    {
        //拿App.config的configuration中ConnectionStrings数组name=mssqlserver，再转字符串
        private static readonly string constr = ConfigurationManager.ConnectionStrings["mssqlserver"].ConnectionString;
        
        //增删改
        public static int ExecuteNonQuery(string sql,params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        com.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return com.ExecuteNonQuery();
                }
            }
        }
        
        //查询一个结果
        public static Object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        com.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return com.ExecuteScalar();
                }
            }
        }
       
        //查询多行结果
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(constr);
            using (SqlCommand com = new SqlCommand(sql, con))
            {
                if (pms != null)
                {
                    com.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    return com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }

        }

        //查询返回dataTable
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }

    }
}

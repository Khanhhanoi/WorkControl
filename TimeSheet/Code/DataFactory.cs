using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace TimeSheet
{
    public class DataFactory
    {
        private static string strConn = "";
        public static void GetConnection()
        {
            strConn = WebConfigurationManager.AppSettings["SiteSqlServer"];
            //strConn = DotNetNuke.Common.Utilities.Config.GetConnectionString();
        }

        public static string ConnString
        {
            get
            {
                GetConnection();
                return strConn;
            }
        }

        #region execute querry command
        public static int Execute(string strSQL)
        {
            int val = 0;

            GetConnection();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            val = cmd.ExecuteNonQuery();
            conn.Close();

            return val;
        }
        public static int Execute(string strSQL, SqlParameter param)
        {
            int val = 0;

            GetConnection();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            cmd.Parameters.Add(param);
            val = cmd.ExecuteNonQuery();
            conn.Close();

            return val;
        }
        public static int Execute(string strSQL, SqlParameter[] param)
        {
            int val = 0;

            GetConnection();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            for (int i = 0; i < param.Length; i++)
                cmd.Parameters.Add(param[i]);
            val = cmd.ExecuteNonQuery();
            conn.Close();

            return val;
        }
        public static int Execute(string strSQL, ArrayList param)
        {
            int val = 0;

            GetConnection();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            for (int i = 0; i < param.Count; i++)
                cmd.Parameters.Add((SqlParameter)param[i]);
            val = cmd.ExecuteNonQuery();
            conn.Close();

            return val;
        }
        #endregion

        #region execute Scalar
        public static object ExecuteScalar(string strSQL)
        {
            object val = null;
            GetConnection();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            val = cmd.ExecuteScalar();
            conn.Close();

            return val;
        }
        public static object ExecuteScalar(string strSQL, SqlParameter param)
        {
            object val = null;
            GetConnection();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            cmd.Parameters.Add(param);
            val = cmd.ExecuteScalar();
            conn.Close();

            return val;
        }
        public static object ExecuteScalar(string strSQL, SqlParameter[] param)
        {
            object val = null;
            GetConnection();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            for (int i = 0; i < param.Length; i++)
                cmd.Parameters.Add(param[i]);
            val = cmd.ExecuteScalar();
            conn.Close();

            return val;
        }
        public static object ExecuteScalar(string strSQL, ArrayList param)
        {
            object val = null;
            GetConnection();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            for (int i = 0; i < param.Count; i++)
                cmd.Parameters.Add((SqlParameter)param[i]);
            val = cmd.ExecuteScalar();
            conn.Close();

            return val;
        }
        #endregion

        #region Select table
        public static DataTable SelectTable(string strSQL)
        {
            GetConnection();
            DataTable val = new DataTable();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(val);
            conn.Close();

            return val;
        }
        public static DataTable SelectTable(string strSQL, SqlParameter param)
        {
            GetConnection();
            DataTable val = new DataTable();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            cmd.Parameters.Add(param);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(val);
            conn.Close();

            return val;
        }
        public static DataTable SelectTable(string strSQL, SqlParameter[] param)
        {
            GetConnection();
            DataTable val = new DataTable();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            for (int i = 0; i < param.Length; i++)
                cmd.Parameters.Add(param[i]);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(val);
            conn.Close();

            return val;
        }
        public static DataTable SelectTable(string strSQL, ArrayList param)
        {
            GetConnection();
            DataTable val = new DataTable();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            for (int i = 0; i < param.Count; i++)
                cmd.Parameters.Add((SqlParameter)param[i]);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(val);
            conn.Close();

            return val;
        }
        #endregion

        #region load Page
        public static DataTable LoadPage(string strSQL, int startRecord, int pageSize)
        {
            DataSet ds = new DataSet();
            GetConnection();
            DataTable val = new DataTable();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, startRecord, pageSize, "TblPAGE");
            conn.Close();

            return ds.Tables[0];
        }

        public static DataTable LoadPage(string strSQL, int startRecord, int pageSize, SqlParameter p)
        {
            DataSet ds = new DataSet();
            GetConnection();
            DataTable val = new DataTable();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            cmd.Parameters.Add(p);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, startRecord, pageSize, "TblPAGE");
            conn.Close();
            return ds.Tables[0];
        }

        public static DataTable LoadPage(string strSQL, int startRecord, int pageSize, SqlParameter[] p)
        {
            DataSet ds = new DataSet();
            GetConnection();
            DataTable val = new DataTable();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            for (int i = 0; i < p.Length; i++)
                cmd.Parameters.Add(p[i]);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, startRecord, pageSize, "TblPAGE");
            conn.Close();

            return ds.Tables[0];
        }

        public static DataTable LoadPage(string strSQL, int startRecord, int pageSize, ArrayList p)
        {
            DataSet ds = new DataSet();
            GetConnection();
            DataTable val = new DataTable();
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = strSQL;
            cmd.Connection = conn;
            for (int i = 0; i < p.Count; i++)
                cmd.Parameters.Add((SqlParameter)p[i]);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, startRecord, pageSize, "TblPAGE");
            conn.Close();

            return ds.Tables[0];
        }

        #endregion

        public static string RemoveHack(string sql)
        {
            sql = sql.Replace("'", "''");
            sql = sql.Replace("[", "[[]");
            sql = sql.Replace("%", "[%]");
            sql = sql.Replace("_", "[_]");
            return sql;
        }
    }
}

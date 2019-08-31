using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient; 

namespace TP_DSYNC.Models.DataAccess
{
    public class MySqlAccess
    {
        #region DataTable
        /// <summary>
        /// 查詢資料表
        /// </summary>
        /// <param name="SqlStr">SQL語法</param>
        /// <param name="ConnStr">資料庫連線字串</param>
        /// <returns>DataTable</returns>
        public static DataTable SelectDataTable(string SqlStr, string ConnStr)
        {
            try
            {
                MySqlConnection MySqlConn = new MySqlConnection(ConnStr);
                MySqlCommand MySqlCmd = new MySqlCommand(SqlStr, MySqlConn);
                return SelectDataTable(MySqlCmd, MySqlConn);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 查詢資料表
        /// </summary>
        /// <param name="SqlStr">SQL語法</param>
        /// <param name="SqlPara">語法參數</param>
        /// <param name="ConnStr">資料庫連線字串</param>
        /// <returns>DataTable</returns>
        public static DataTable SelectDataTable(string SqlStr, Hashtable SqlPara, string ConnStr)
        {
            try
            {
                MySqlConnection MySqlConn = new MySqlConnection(ConnStr);

                MySqlCommand MySqlCmd = new MySqlCommand(SqlStr, MySqlConn);

                if (SqlPara != null)
                {
                    foreach (string K in SqlPara.Keys)
                        MySqlCmd.Parameters.AddWithValue(K, SqlPara[K]);
                }

                return SelectDataTable(MySqlCmd, MySqlConn);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 查詢資料表
        /// </summary>
        /// <param name="SqlStr">SQL語法</param>
        /// <param name="SqlPara">語法參數</param>
        /// <param name="ConnStr">資料庫連線字串</param>
        /// <returns>DataTable</returns>
        public static DataTable SelectDataTable(string SqlStr, List<MySqlParameter> SqlPara, string ConnStr)
        {
            try
            {
                MySqlConnection MySqlConn = new MySqlConnection(ConnStr);

                MySqlCommand MySqlCmd = new MySqlCommand(SqlStr, MySqlConn);

                if (SqlPara != null && SqlPara.Count > 0)
                {
                    MySqlCmd.Parameters.AddRange(SqlPara.ToArray<MySqlParameter>());
                }

                return SelectDataTable(MySqlCmd, MySqlConn);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 查詢資料表
        /// </summary>
        /// <param name="SqlCmd">SQL命令物件</param>
        /// <param name="SqlConn">資料庫連線物件</param>
        /// <returns>DataTable</returns>
        public static DataTable SelectDataTable(MySqlCommand MySqlCmd, MySqlConnection MySqlConn)
        {
            MySqlDataAdapter MySqlAda = null;
            try
            {
                DataTable dt = new DataTable();

                MySqlCmd.Connection = MySqlConn;
                
                //MySqlCmd.CommandTimeout = 180;
                //SqlCmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["SqlCmdTimeout"].ToString());
                MySqlAda = new MySqlDataAdapter(MySqlCmd);
                MySqlConn.Open();
                MySqlAda.Fill(dt);

                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                MySqlAda.Dispose();
                MySqlCmd.Dispose();
                MySqlConn.Close();
                MySqlConn.Dispose();
            }
        }
        #endregion

        #region Execute

        public static int ExecuteSql(string SqlStr, string ConnStr, string DBName)
        {
            MySqlConnection SqlConn = null;
            MySqlCommand SqlCmd = null;
            try
            {
                SqlConn = new MySqlConnection(ConnStr);
                SqlCmd = new MySqlCommand();
                SqlConn.Open();
                if (!string.IsNullOrEmpty(DBName))
                {
                    SqlConn.ChangeDatabase(DBName);
                }
                SqlCmd.Connection = SqlConn;
                SqlCmd.Transaction = SqlConn.BeginTransaction();
                SqlCmd.CommandText = SqlStr;

                int i = SqlCmd.ExecuteNonQuery();
                SqlCmd.Transaction.Commit();
                return i;
            }
            catch
            {
                SqlCmd.Transaction.Rollback();
                throw;
            }
            finally
            {
                SqlCmd.Dispose();
                SqlConn.Close();
            }
        }

        public static int ExecuteSql(string SqlStr, List<MySqlParameter> SqlPara, string ConnStr)
        {
            MySqlConnection SqlConn = null;
            MySqlCommand SqlCmd = null;
            try
            {
                SqlConn = new MySqlConnection(ConnStr);
                SqlCmd = new MySqlCommand();
                SqlConn.Open();

                SqlCmd.Connection = SqlConn;
                SqlCmd.Transaction = SqlConn.BeginTransaction();
                SqlCmd.CommandText = SqlStr;

                if (SqlPara != null)
                {
                    SqlCmd.Parameters.AddRange(SqlPara.ToArray<MySqlParameter>());
                }

                int i = SqlCmd.ExecuteNonQuery();
                SqlCmd.Transaction.Commit();
                return i;

            }
            catch
            {
                SqlCmd.Transaction.Rollback();
                throw;
            }
            finally
            {
                SqlPara = null;
                SqlCmd.Dispose();
                SqlConn.Close();
            }
        }

        public static int ExecuteSql(string SqlStr, string ConnStr)
        {
            MySqlConnection SqlConn = null;
            MySqlCommand SqlCmd = null;
            try
            {
                SqlConn = new MySqlConnection(ConnStr);
                SqlCmd = new MySqlCommand();
                SqlConn.Open();

                SqlCmd.Connection = SqlConn;
                SqlCmd.Transaction = SqlConn.BeginTransaction();
                SqlCmd.CommandText = SqlStr;

                int i = SqlCmd.ExecuteNonQuery();
                SqlCmd.Transaction.Commit();
                return i;
            }
            catch
            {
                SqlCmd.Transaction.Rollback();
                throw;
            }
            finally
            {
                SqlCmd.Dispose();
                SqlConn.Close();
            }
        }


        public static int ExecuteSql(string SqlStr, List<MySqlParameter> SqlPara, string ConnStr, int Timeout)
        {
            MySqlConnection SqlConn = null;
            MySqlCommand SqlCmd = null;
            try
            {
                SqlConn = new MySqlConnection(ConnStr);
                SqlCmd = new MySqlCommand();
                SqlConn.Open();

                SqlCmd.Connection = SqlConn;
                SqlCmd.Transaction = SqlConn.BeginTransaction();
                SqlCmd.CommandText = SqlStr;
                SqlCmd.CommandTimeout = Timeout;

                if (SqlPara != null)
                {
                    SqlCmd.Parameters.AddRange(SqlPara.ToArray<MySqlParameter>());
                }

                int i = SqlCmd.ExecuteNonQuery();
                SqlCmd.Transaction.Commit();
                return i;

            }
            catch
            {
                SqlCmd.Transaction.Rollback();
                throw;
            }
            finally
            {
                SqlPara = null;
                SqlCmd.Dispose();
                SqlConn.Close();
            }
        }

        public static int ExecuteSqlCmds(string SqlStr, List<MySqlCommand> SqlCmds, string ConnStr)
        {
            int EffectRows = 0;
            MySqlConnection SqlConn = null;
            MySqlTransaction SqlTran = null;
            try
            {
                SqlConn = new MySqlConnection(ConnStr);
                SqlConn.Open();
                SqlTran = SqlConn.BeginTransaction();

                foreach (MySqlCommand SqlCmd in SqlCmds)
                {
                    SqlCmd.Connection = SqlConn;
                    SqlCmd.Transaction = SqlTran;
                    int i = SqlCmd.ExecuteNonQuery();
                    EffectRows += i;
                }

                SqlTran.Commit();
                return EffectRows;

            }
            catch
            {
                SqlTran.Rollback();
                throw;
            }
            finally
            {
                //SqlPara = null;
                //SqlCmd.Dispose();
            }
        }

        public static DataTable ExecuteSp(string SqlStr, List<MySqlParameter> SqlPara, List<MySqlParameter> SqlPara_Out, string ConnStr)
        {
            MySqlConnection SqlConn = null;
            MySqlCommand SqlCmd = null;
            MySqlDataReader SqlReader = null;
            try
            {
                SqlConn = new MySqlConnection(ConnStr);
                SqlCmd = new MySqlCommand();
                SqlConn.Open();

                SqlCmd.Connection = SqlConn;
                SqlCmd.CommandText = SqlStr;
                SqlCmd.CommandType = CommandType.StoredProcedure;

                if (SqlPara != null)
                {
                    SqlCmd.Parameters.AddRange(SqlPara.ToArray<MySqlParameter>());
                    //foreach (SqlParameter para in SqlPara)
                    //{
                    //    para.IsNullable = true;
                    //    para.SourceColumnNullMapping = true;
                    //    SqlCmd.Parameters.Add(para);
                    //}
                }

                MySqlParameter Order_No = SqlCmd.Parameters.Add("@Order_No",MySqlDbType.Int32);
                Order_No.Direction = ParameterDirection.Output;


                SqlReader = SqlCmd.ExecuteReader();
                //SqlReader.Read();

                DataTable dt = new DataTable();
                dt.Load(SqlReader);

                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {
                if (SqlReader != null)
                    SqlReader.Close();
                SqlPara = null;
                SqlCmd.Dispose();
                SqlConn.Close();
            }
        }


        //特定使用SP 取得序號
        public static DataTable ExecuteSp_Get_OrderNO(string SqlStr, string ConnStr)
        {
            MySqlConnection SqlConn = null;
            MySqlCommand SqlCmd = null;
            MySqlDataReader SqlReader = null;
            try
            {
                SqlConn = new MySqlConnection(ConnStr);
                SqlCmd = new MySqlCommand();
                SqlConn.Open();

                SqlCmd.Connection = SqlConn;
                SqlCmd.CommandText = SqlStr;
                SqlCmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter Order_No = SqlCmd.Parameters.Add("@Order_No", MySqlDbType.Int32);
                Order_No.Direction = ParameterDirection.Output;
                SqlReader = SqlCmd.ExecuteReader();
                //SqlReader.Read();

                DataTable dt = new DataTable();
                dt.Load(SqlReader);

                return dt;

            }
            catch
            {
                throw;
            }
            finally
            {
                if (SqlReader != null)
                    SqlReader.Close();
                SqlCmd.Dispose();
                SqlConn.Close();
            }
        }

        //DataSet ExecuteSp
        public static DataSet ExecuteSpDataSet(string SqlStr, List<SqlParameter> SqlPara, string ConnStr)
        {
            SqlConnection SqlConn = null;
            SqlCommand SqlCmd = null;
            SqlDataAdapter SqlAda = null;
            try
            {
                DataSet ds = new DataSet();
                SqlConn = new SqlConnection(ConnStr);
                SqlCmd = new SqlCommand();
                SqlConn.Open();

                SqlCmd.Connection = SqlConn;
                SqlCmd.CommandText = SqlStr;
                SqlCmd.CommandType = CommandType.StoredProcedure;

                if (SqlPara != null)
                {
                    SqlCmd.Parameters.AddRange(SqlPara.ToArray<SqlParameter>());
                    //foreach (SqlParameter para in SqlPara)
                    //{
                    //    para.IsNullable = true;
                    //    para.SourceColumnNullMapping = true;
                    //    SqlCmd.Parameters.Add(para);
                    //}
                }

                SqlAda = new SqlDataAdapter(SqlCmd);
                SqlAda.Fill(ds);
                return ds;

            }
            catch
            {
                throw;
            }
            finally
            {
                SqlAda.Dispose();
                SqlPara = null;
                SqlCmd.Dispose();
                SqlConn.Close();
                SqlConn.Dispose();
            }
        }

        #endregion

    }
}
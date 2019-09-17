using System;
using TP_DSYNC.Models.DataAccess;
using TP_DSYNC.Models.DataDefine.B3;
using System.Data;
using System.Data.Common;

namespace TP_DSYNC.Models.Implement
{
    public class AHU_WriteImplement : DatabaseAccess
    {
        public AHU_WriteImplement(string connectionStringName) : base(connectionStringName) { }

        public int WriteDataForAHU_004F(AHU_004F AHU_004F)
        {
            int affected = 0;
            DbConnection conn = null;
            DbTransaction trans = null;
            DbCommand cmd = null;
            string sql = null;
            try
            {
                conn = Db.CreateConnection();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                sql = @"
INSERT INTO AHU (AUTOID,DATETIME,LOCATION,DEVICE_ID,AHU01,AHU02,AHU03,AHU04,AHU05,AHU06,AHU07,AHU08,AHU09,AHU10,AHU11)     
    VALUES (@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                cmd.CommandText = sql;
                Db.AddInParameter(cmd, "AUTOID", DbType.Int32);
                Db.AddInParameter(cmd, "DATETIME", DbType.DateTime);
                Db.AddInParameter(cmd, "LOCATION", DbType.String);
                Db.AddInParameter(cmd, "DEVICE_ID", DbType.String);
                Db.AddInParameter(cmd, "AHU01", DbType.Single);
                Db.AddInParameter(cmd, "AHU02", DbType.Single);
                Db.AddInParameter(cmd, "AHU03", DbType.Single);
                Db.AddInParameter(cmd, "AHU04", DbType.Single);
                Db.AddInParameter(cmd, "AHU05", DbType.Single);
                Db.AddInParameter(cmd, "AHU06", DbType.Single);
                Db.AddInParameter(cmd, "AHU07", DbType.Single);
                Db.AddInParameter(cmd, "AHU08", DbType.Single);
                Db.AddInParameter(cmd, "AHU09", DbType.Single);
                Db.AddInParameter(cmd, "AHU10", DbType.Single);
                Db.AddInParameter(cmd, "AHU11", DbType.Single);

                Db.SetParameterValue(cmd, "AUTOID", AHU_004F.AUTOID);
                Db.SetParameterValue(cmd, "DATETIME", AHU_004F.DATETIME);
                Db.SetParameterValue(cmd, "LOCATION", "004F");

                #region 004F01
                Db.SetParameterValue(cmd, "DEVICE_ID", "01");
                Db.SetParameterValue(cmd, "AHU01", AHU_004F.AHU01_004F01);
                Db.SetParameterValue(cmd, "AHU02", AHU_004F.AHU02_004F01);
                Db.SetParameterValue(cmd, "AHU03", AHU_004F.AHU03_004F01);
                Db.SetParameterValue(cmd, "AHU04", AHU_004F.AHU04_004F01);
                Db.SetParameterValue(cmd, "AHU05", AHU_004F.AHU05_004F01);
                Db.SetParameterValue(cmd, "AHU06", AHU_004F.AHU06_004F01);
                Db.SetParameterValue(cmd, "AHU07", AHU_004F.AHU07_004F01);
                Db.SetParameterValue(cmd, "AHU08", AHU_004F.AHU08_004F01);
                Db.SetParameterValue(cmd, "AHU09", AHU_004F.AHU09_004F01);
                Db.SetParameterValue(cmd, "AHU10", AHU_004F.AHU10_004F01);
                Db.SetParameterValue(cmd, "AHU11", AHU_004F.AHU11_004F01);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 004F02
                Db.SetParameterValue(cmd, "DEVICE_ID", "02");
                Db.SetParameterValue(cmd, "AHU01", AHU_004F.AHU01_004F02);
                Db.SetParameterValue(cmd, "AHU02", AHU_004F.AHU02_004F02);
                Db.SetParameterValue(cmd, "AHU03", AHU_004F.AHU03_004F02);
                Db.SetParameterValue(cmd, "AHU04", AHU_004F.AHU04_004F02);
                Db.SetParameterValue(cmd, "AHU05", AHU_004F.AHU05_004F02);
                Db.SetParameterValue(cmd, "AHU06", AHU_004F.AHU06_004F02);
                Db.SetParameterValue(cmd, "AHU07", AHU_004F.AHU07_004F02);
                Db.SetParameterValue(cmd, "AHU08", AHU_004F.AHU08_004F02);
                Db.SetParameterValue(cmd, "AHU09", AHU_004F.AHU09_004F02);
                Db.SetParameterValue(cmd, "AHU10", AHU_004F.AHU10_004F02);
                Db.SetParameterValue(cmd, "AHU11", AHU_004F.AHU11_004F02);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 004F03
                Db.SetParameterValue(cmd, "DEVICE_ID", "03");
                Db.SetParameterValue(cmd, "AHU01", AHU_004F.AHU01_004F03);
                Db.SetParameterValue(cmd, "AHU02", AHU_004F.AHU02_004F03);
                Db.SetParameterValue(cmd, "AHU03", AHU_004F.AHU03_004F03);
                Db.SetParameterValue(cmd, "AHU04", AHU_004F.AHU04_004F03);
                Db.SetParameterValue(cmd, "AHU05", AHU_004F.AHU05_004F03);
                Db.SetParameterValue(cmd, "AHU06", AHU_004F.AHU06_004F03);
                Db.SetParameterValue(cmd, "AHU07", AHU_004F.AHU07_004F03);
                Db.SetParameterValue(cmd, "AHU08", AHU_004F.AHU08_004F03);
                Db.SetParameterValue(cmd, "AHU09", AHU_004F.AHU09_004F03);
                Db.SetParameterValue(cmd, "AHU10", AHU_004F.AHU10_004F03);
                Db.SetParameterValue(cmd, "AHU11", AHU_004F.AHU11_004F03);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 004F04
                Db.SetParameterValue(cmd, "DEVICE_ID", "04");
                Db.SetParameterValue(cmd, "AHU01", AHU_004F.AHU01_004F04);
                Db.SetParameterValue(cmd, "AHU02", AHU_004F.AHU02_004F04);
                Db.SetParameterValue(cmd, "AHU03", AHU_004F.AHU03_004F04);
                Db.SetParameterValue(cmd, "AHU04", AHU_004F.AHU04_004F04);
                Db.SetParameterValue(cmd, "AHU05", AHU_004F.AHU05_004F04);
                Db.SetParameterValue(cmd, "AHU06", AHU_004F.AHU06_004F04);
                Db.SetParameterValue(cmd, "AHU07", AHU_004F.AHU07_004F04);
                Db.SetParameterValue(cmd, "AHU08", AHU_004F.AHU08_004F04);
                Db.SetParameterValue(cmd, "AHU09", AHU_004F.AHU09_004F04);
                Db.SetParameterValue(cmd, "AHU10", AHU_004F.AHU10_004F04);
                Db.SetParameterValue(cmd, "AHU11", AHU_004F.AHU11_004F04);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion

                trans.Commit();

            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return affected;
        }

        public int WriteDataForAHU_0B1F(AHU_0B1F AHU_0B1F)
        {
            int affected = 0;
            DbConnection conn = null;
            DbTransaction trans = null;
            DbCommand cmd = null;
            string sql = null;
            try
            {
                conn = Db.CreateConnection();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                sql = @"
INSERT INTO AHU (AUTOID,DATETIME,LOCATION,DEVICE_ID,AHU01,AHU02,AHU03,AHU04,AHU05,AHU06,AHU07,AHU08,AHU09,AHU10,AHU11)     
    VALUES (@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                cmd.CommandText = sql;
                Db.AddInParameter(cmd, "AUTOID", DbType.Int32);
                Db.AddInParameter(cmd, "DATETIME", DbType.DateTime);
                Db.AddInParameter(cmd, "LOCATION", DbType.String);
                Db.AddInParameter(cmd, "DEVICE_ID", DbType.String);
                Db.AddInParameter(cmd, "AHU01", DbType.Single);
                Db.AddInParameter(cmd, "AHU02", DbType.Single);
                Db.AddInParameter(cmd, "AHU03", DbType.Single);
                Db.AddInParameter(cmd, "AHU04", DbType.Single);
                Db.AddInParameter(cmd, "AHU05", DbType.Single);
                Db.AddInParameter(cmd, "AHU06", DbType.Single);
                Db.AddInParameter(cmd, "AHU07", DbType.Single);
                Db.AddInParameter(cmd, "AHU08", DbType.Single);
                Db.AddInParameter(cmd, "AHU09", DbType.Single);
                Db.AddInParameter(cmd, "AHU10", DbType.Single);
                Db.AddInParameter(cmd, "AHU11", DbType.Single);

                Db.SetParameterValue(cmd, "AUTOID", AHU_0B1F.AUTOID);
                Db.SetParameterValue(cmd, "DATETIME", AHU_0B1F.DATETIME);
                Db.SetParameterValue(cmd, "LOCATION", "0B1F");

                #region 0B1F01
                Db.SetParameterValue(cmd, "DEVICE_ID", "01");
                Db.SetParameterValue(cmd, "AHU01", AHU_0B1F.AHU01_0B1F01);
                Db.SetParameterValue(cmd, "AHU02", AHU_0B1F.AHU02_0B1F01);
                Db.SetParameterValue(cmd, "AHU03", AHU_0B1F.AHU03_0B1F01);
                Db.SetParameterValue(cmd, "AHU04", AHU_0B1F.AHU04_0B1F01);
                Db.SetParameterValue(cmd, "AHU05", AHU_0B1F.AHU05_0B1F01);
                Db.SetParameterValue(cmd, "AHU06", AHU_0B1F.AHU06_0B1F01);
                Db.SetParameterValue(cmd, "AHU07", AHU_0B1F.AHU07_0B1F01);
                Db.SetParameterValue(cmd, "AHU08", AHU_0B1F.AHU08_0B1F01);
                Db.SetParameterValue(cmd, "AHU09", AHU_0B1F.AHU09_0B1F01);
                Db.SetParameterValue(cmd, "AHU10", AHU_0B1F.AHU10_0B1F01);
                Db.SetParameterValue(cmd, "AHU11", AHU_0B1F.AHU11_0B1F01);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 0B1F02
                Db.SetParameterValue(cmd, "DEVICE_ID", "02");
                Db.SetParameterValue(cmd, "AHU01", AHU_0B1F.AHU01_0B1F02);
                Db.SetParameterValue(cmd, "AHU02", AHU_0B1F.AHU02_0B1F02);
                Db.SetParameterValue(cmd, "AHU03", AHU_0B1F.AHU03_0B1F02);
                Db.SetParameterValue(cmd, "AHU04", AHU_0B1F.AHU04_0B1F02);
                Db.SetParameterValue(cmd, "AHU05", AHU_0B1F.AHU05_0B1F02);
                Db.SetParameterValue(cmd, "AHU06", AHU_0B1F.AHU06_0B1F02);
                Db.SetParameterValue(cmd, "AHU07", AHU_0B1F.AHU07_0B1F02);
                Db.SetParameterValue(cmd, "AHU08", AHU_0B1F.AHU08_0B1F02);
                Db.SetParameterValue(cmd, "AHU09", AHU_0B1F.AHU09_0B1F02);
                Db.SetParameterValue(cmd, "AHU10", AHU_0B1F.AHU10_0B1F02);
                Db.SetParameterValue(cmd, "AHU11", AHU_0B1F.AHU11_0B1F02);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 0B1F03
                Db.SetParameterValue(cmd, "DEVICE_ID", "03");
                Db.SetParameterValue(cmd, "AHU01", AHU_0B1F.AHU01_0B1F03);
                Db.SetParameterValue(cmd, "AHU02", AHU_0B1F.AHU02_0B1F03);
                Db.SetParameterValue(cmd, "AHU03", AHU_0B1F.AHU03_0B1F03);
                Db.SetParameterValue(cmd, "AHU04", AHU_0B1F.AHU04_0B1F03);
                Db.SetParameterValue(cmd, "AHU05", AHU_0B1F.AHU05_0B1F03);
                Db.SetParameterValue(cmd, "AHU06", AHU_0B1F.AHU06_0B1F03);
                Db.SetParameterValue(cmd, "AHU07", AHU_0B1F.AHU07_0B1F03);
                Db.SetParameterValue(cmd, "AHU08", AHU_0B1F.AHU08_0B1F03);
                Db.SetParameterValue(cmd, "AHU09", AHU_0B1F.AHU09_0B1F03);
                Db.SetParameterValue(cmd, "AHU10", AHU_0B1F.AHU10_0B1F03);
                Db.SetParameterValue(cmd, "AHU11", AHU_0B1F.AHU11_0B1F03);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 0B1F04
                Db.SetParameterValue(cmd, "DEVICE_ID", "04");
                Db.SetParameterValue(cmd, "AHU01", AHU_0B1F.AHU01_0B1F04);
                Db.SetParameterValue(cmd, "AHU02", AHU_0B1F.AHU02_0B1F04);
                Db.SetParameterValue(cmd, "AHU03", AHU_0B1F.AHU03_0B1F04);
                Db.SetParameterValue(cmd, "AHU04", AHU_0B1F.AHU04_0B1F04);
                Db.SetParameterValue(cmd, "AHU05", AHU_0B1F.AHU05_0B1F04);
                Db.SetParameterValue(cmd, "AHU06", AHU_0B1F.AHU06_0B1F04);
                Db.SetParameterValue(cmd, "AHU07", AHU_0B1F.AHU07_0B1F04);
                Db.SetParameterValue(cmd, "AHU08", AHU_0B1F.AHU08_0B1F04);
                Db.SetParameterValue(cmd, "AHU09", AHU_0B1F.AHU09_0B1F04);
                Db.SetParameterValue(cmd, "AHU10", AHU_0B1F.AHU10_0B1F04);
                Db.SetParameterValue(cmd, "AHU11", AHU_0B1F.AHU11_0B1F04);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion

                trans.Commit();

            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return affected;
        }

        public int WriteDataForAHU_00RF(AHU_00RF AHU_00RF)
        {
            int affected = 0;
            DbConnection conn = null;
            DbTransaction trans = null;
            DbCommand cmd = null;
            string sql = null;
            try
            {
                conn = Db.CreateConnection();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                sql = @"
INSERT INTO AHU (AUTOID,DATETIME,LOCATION,DEVICE_ID,AHU01,AHU02,AHU03,AHU04,AHU05,AHU06,AHU07,AHU08,AHU09,AHU10,AHU11)     
    VALUES (@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                cmd.CommandText = sql;
                Db.AddInParameter(cmd, "AUTOID", DbType.Int32);
                Db.AddInParameter(cmd, "DATETIME", DbType.DateTime);
                Db.AddInParameter(cmd, "LOCATION", DbType.String);
                Db.AddInParameter(cmd, "DEVICE_ID", DbType.String);
                Db.AddInParameter(cmd, "AHU01", DbType.Single);
                Db.AddInParameter(cmd, "AHU02", DbType.Single);
                Db.AddInParameter(cmd, "AHU03", DbType.Single);
                Db.AddInParameter(cmd, "AHU04", DbType.Single);
                Db.AddInParameter(cmd, "AHU05", DbType.Single);
                Db.AddInParameter(cmd, "AHU06", DbType.Single);
                Db.AddInParameter(cmd, "AHU07", DbType.Single);
                Db.AddInParameter(cmd, "AHU08", DbType.Single);
                Db.AddInParameter(cmd, "AHU09", DbType.Single);
                Db.AddInParameter(cmd, "AHU10", DbType.Single);
                Db.AddInParameter(cmd, "AHU11", DbType.Single);

                Db.SetParameterValue(cmd, "AUTOID", AHU_00RF.AUTOID);
                Db.SetParameterValue(cmd, "DATETIME", AHU_00RF.DATETIME);
                Db.SetParameterValue(cmd, "LOCATION", "00RF");

                #region 00RF01
                Db.SetParameterValue(cmd, "DEVICE_ID", "01");
                Db.SetParameterValue(cmd, "AHU01", AHU_00RF.AHU01_00RF01);
                Db.SetParameterValue(cmd, "AHU02", AHU_00RF.AHU02_00RF01);
                Db.SetParameterValue(cmd, "AHU03", AHU_00RF.AHU03_00RF01);
                Db.SetParameterValue(cmd, "AHU04", AHU_00RF.AHU04_00RF01);
                Db.SetParameterValue(cmd, "AHU05", AHU_00RF.AHU05_00RF01);
                Db.SetParameterValue(cmd, "AHU06", AHU_00RF.AHU06_00RF01);
                Db.SetParameterValue(cmd, "AHU07", AHU_00RF.AHU07_00RF01);
                Db.SetParameterValue(cmd, "AHU08", AHU_00RF.AHU08_00RF01);
                Db.SetParameterValue(cmd, "AHU09", AHU_00RF.AHU09_00RF01);
                Db.SetParameterValue(cmd, "AHU10", AHU_00RF.AHU10_00RF01);
                Db.SetParameterValue(cmd, "AHU11", AHU_00RF.AHU11_00RF01);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 00RF02
                Db.SetParameterValue(cmd, "DEVICE_ID", "02");
                Db.SetParameterValue(cmd, "AHU01", AHU_00RF.AHU01_00RF02);
                Db.SetParameterValue(cmd, "AHU02", AHU_00RF.AHU02_00RF02);
                Db.SetParameterValue(cmd, "AHU03", AHU_00RF.AHU03_00RF02);
                Db.SetParameterValue(cmd, "AHU04", AHU_00RF.AHU04_00RF02);
                Db.SetParameterValue(cmd, "AHU05", AHU_00RF.AHU05_00RF02);
                Db.SetParameterValue(cmd, "AHU06", AHU_00RF.AHU06_00RF02);
                Db.SetParameterValue(cmd, "AHU07", AHU_00RF.AHU07_00RF02);
                Db.SetParameterValue(cmd, "AHU08", AHU_00RF.AHU08_00RF02);
                Db.SetParameterValue(cmd, "AHU09", AHU_00RF.AHU09_00RF02);
                Db.SetParameterValue(cmd, "AHU10", AHU_00RF.AHU10_00RF02);
                Db.SetParameterValue(cmd, "AHU11", AHU_00RF.AHU11_00RF02);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 00RF03
                Db.SetParameterValue(cmd, "DEVICE_ID", "03");
                Db.SetParameterValue(cmd, "AHU01", AHU_00RF.AHU01_00RF03);
                Db.SetParameterValue(cmd, "AHU02", AHU_00RF.AHU02_00RF03);
                Db.SetParameterValue(cmd, "AHU03", AHU_00RF.AHU03_00RF03);
                Db.SetParameterValue(cmd, "AHU04", AHU_00RF.AHU04_00RF03);
                Db.SetParameterValue(cmd, "AHU05", AHU_00RF.AHU05_00RF03);
                Db.SetParameterValue(cmd, "AHU06", AHU_00RF.AHU06_00RF03);
                Db.SetParameterValue(cmd, "AHU07", AHU_00RF.AHU07_00RF03);
                Db.SetParameterValue(cmd, "AHU08", AHU_00RF.AHU08_00RF03);
                Db.SetParameterValue(cmd, "AHU09", AHU_00RF.AHU09_00RF03);
                Db.SetParameterValue(cmd, "AHU10", AHU_00RF.AHU10_00RF03);
                Db.SetParameterValue(cmd, "AHU11", AHU_00RF.AHU11_00RF03);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 00RF04
                Db.SetParameterValue(cmd, "DEVICE_ID", "04");
                Db.SetParameterValue(cmd, "AHU01", AHU_00RF.AHU01_00RF04);
                Db.SetParameterValue(cmd, "AHU02", AHU_00RF.AHU02_00RF04);
                Db.SetParameterValue(cmd, "AHU03", AHU_00RF.AHU03_00RF04);
                Db.SetParameterValue(cmd, "AHU04", AHU_00RF.AHU04_00RF04);
                Db.SetParameterValue(cmd, "AHU05", AHU_00RF.AHU05_00RF04);
                Db.SetParameterValue(cmd, "AHU06", AHU_00RF.AHU06_00RF04);
                Db.SetParameterValue(cmd, "AHU07", AHU_00RF.AHU07_00RF04);
                Db.SetParameterValue(cmd, "AHU08", AHU_00RF.AHU08_00RF04);
                Db.SetParameterValue(cmd, "AHU09", AHU_00RF.AHU09_00RF04);
                Db.SetParameterValue(cmd, "AHU10", AHU_00RF.AHU10_00RF04);
                Db.SetParameterValue(cmd, "AHU11", AHU_00RF.AHU11_00RF04);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 00RF05
                Db.SetParameterValue(cmd, "DEVICE_ID", "05");
                Db.SetParameterValue(cmd, "AHU01", AHU_00RF.AHU01_00RF05);
                Db.SetParameterValue(cmd, "AHU02", AHU_00RF.AHU02_00RF05);
                Db.SetParameterValue(cmd, "AHU03", AHU_00RF.AHU03_00RF05);
                Db.SetParameterValue(cmd, "AHU04", AHU_00RF.AHU04_00RF05);
                Db.SetParameterValue(cmd, "AHU05", AHU_00RF.AHU05_00RF05);
                Db.SetParameterValue(cmd, "AHU06", AHU_00RF.AHU06_00RF05);
                Db.SetParameterValue(cmd, "AHU07", AHU_00RF.AHU07_00RF05);
                Db.SetParameterValue(cmd, "AHU08", AHU_00RF.AHU08_00RF05);
                Db.SetParameterValue(cmd, "AHU09", AHU_00RF.AHU09_00RF05);
                Db.SetParameterValue(cmd, "AHU10", AHU_00RF.AHU10_00RF05);
                Db.SetParameterValue(cmd, "AHU11", AHU_00RF.AHU11_00RF05);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 00RF06
                Db.SetParameterValue(cmd, "DEVICE_ID", "06");
                Db.SetParameterValue(cmd, "AHU01", AHU_00RF.AHU01_00RF06);
                Db.SetParameterValue(cmd, "AHU02", AHU_00RF.AHU02_00RF06);
                Db.SetParameterValue(cmd, "AHU03", AHU_00RF.AHU03_00RF06);
                Db.SetParameterValue(cmd, "AHU04", AHU_00RF.AHU04_00RF06);
                Db.SetParameterValue(cmd, "AHU05", AHU_00RF.AHU05_00RF06);
                Db.SetParameterValue(cmd, "AHU06", AHU_00RF.AHU06_00RF06);
                Db.SetParameterValue(cmd, "AHU07", AHU_00RF.AHU07_00RF06);
                Db.SetParameterValue(cmd, "AHU08", AHU_00RF.AHU08_00RF06);
                Db.SetParameterValue(cmd, "AHU09", AHU_00RF.AHU09_00RF06);
                Db.SetParameterValue(cmd, "AHU10", AHU_00RF.AHU10_00RF06);
                Db.SetParameterValue(cmd, "AHU11", AHU_00RF.AHU11_00RF06);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion                          
                #region 00RF07
                Db.SetParameterValue(cmd, "DEVICE_ID", "07");
                Db.SetParameterValue(cmd, "AHU01", AHU_00RF.AHU01_00RF07);
                Db.SetParameterValue(cmd, "AHU02", AHU_00RF.AHU02_00RF07);
                Db.SetParameterValue(cmd, "AHU03", AHU_00RF.AHU03_00RF07);
                Db.SetParameterValue(cmd, "AHU04", AHU_00RF.AHU04_00RF07);
                Db.SetParameterValue(cmd, "AHU05", AHU_00RF.AHU05_00RF07);
                Db.SetParameterValue(cmd, "AHU06", AHU_00RF.AHU06_00RF07);
                Db.SetParameterValue(cmd, "AHU07", AHU_00RF.AHU07_00RF07);
                Db.SetParameterValue(cmd, "AHU08", AHU_00RF.AHU08_00RF07);
                Db.SetParameterValue(cmd, "AHU09", AHU_00RF.AHU09_00RF07);
                Db.SetParameterValue(cmd, "AHU10", AHU_00RF.AHU10_00RF07);
                Db.SetParameterValue(cmd, "AHU11", AHU_00RF.AHU11_00RF07);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion                          
                #region 00RF08
                Db.SetParameterValue(cmd, "DEVICE_ID", "08");
                Db.SetParameterValue(cmd, "AHU01", AHU_00RF.AHU01_00RF08);
                Db.SetParameterValue(cmd, "AHU02", AHU_00RF.AHU02_00RF08);
                Db.SetParameterValue(cmd, "AHU03", AHU_00RF.AHU03_00RF08);
                Db.SetParameterValue(cmd, "AHU04", AHU_00RF.AHU04_00RF08);
                Db.SetParameterValue(cmd, "AHU05", AHU_00RF.AHU05_00RF08);
                Db.SetParameterValue(cmd, "AHU06", AHU_00RF.AHU06_00RF08);
                Db.SetParameterValue(cmd, "AHU07", AHU_00RF.AHU07_00RF08);
                Db.SetParameterValue(cmd, "AHU08", AHU_00RF.AHU08_00RF08);
                Db.SetParameterValue(cmd, "AHU09", AHU_00RF.AHU09_00RF08);
                Db.SetParameterValue(cmd, "AHU10", AHU_00RF.AHU10_00RF08);
                Db.SetParameterValue(cmd, "AHU11", AHU_00RF.AHU11_00RF08);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 00RF09
                Db.SetParameterValue(cmd, "DEVICE_ID", "01");
                Db.SetParameterValue(cmd, "AHU01", AHU_00RF.AHU01_00RF09);
                Db.SetParameterValue(cmd, "AHU02", AHU_00RF.AHU02_00RF09);
                Db.SetParameterValue(cmd, "AHU03", AHU_00RF.AHU03_00RF09);
                Db.SetParameterValue(cmd, "AHU04", AHU_00RF.AHU04_00RF09);
                Db.SetParameterValue(cmd, "AHU05", AHU_00RF.AHU05_00RF09);
                Db.SetParameterValue(cmd, "AHU06", AHU_00RF.AHU06_00RF09);
                Db.SetParameterValue(cmd, "AHU07", AHU_00RF.AHU07_00RF09);
                Db.SetParameterValue(cmd, "AHU08", AHU_00RF.AHU08_00RF09);
                Db.SetParameterValue(cmd, "AHU09", AHU_00RF.AHU09_00RF09);
                Db.SetParameterValue(cmd, "AHU10", AHU_00RF.AHU10_00RF09);
                Db.SetParameterValue(cmd, "AHU11", AHU_00RF.AHU11_00RF09);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion

                trans.Commit();

            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return affected;
        }

        public int WriteDataForAHU_014F(AHU_014F AHU_014F)
        {
            int affected = 0;
            DbConnection conn = null;
            DbTransaction trans = null;
            DbCommand cmd = null;
            string sql = null;
            try
            {
                conn = Db.CreateConnection();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                sql = @"
INSERT INTO AHU (AUTOID,DATETIME,LOCATION,DEVICE_ID,AHU01,AHU02,AHU03,AHU04,AHU05,AHU06,AHU07,AHU08,AHU09,AHU10,AHU11)     
    VALUES (@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                cmd.CommandText = sql;
                Db.AddInParameter(cmd, "AUTOID", DbType.Int32);
                Db.AddInParameter(cmd, "DATETIME", DbType.DateTime);
                Db.AddInParameter(cmd, "LOCATION", DbType.String);
                Db.AddInParameter(cmd, "DEVICE_ID", DbType.String);
                Db.AddInParameter(cmd, "AHU01", DbType.Single);
                Db.AddInParameter(cmd, "AHU02", DbType.Single);
                Db.AddInParameter(cmd, "AHU03", DbType.Single);
                Db.AddInParameter(cmd, "AHU04", DbType.Single);
                Db.AddInParameter(cmd, "AHU05", DbType.Single);
                Db.AddInParameter(cmd, "AHU06", DbType.Single);
                Db.AddInParameter(cmd, "AHU07", DbType.Single);
                Db.AddInParameter(cmd, "AHU08", DbType.Single);
                Db.AddInParameter(cmd, "AHU09", DbType.Single);
                Db.AddInParameter(cmd, "AHU10", DbType.Single);
                Db.AddInParameter(cmd, "AHU11", DbType.Single);

                Db.SetParameterValue(cmd, "AUTOID", AHU_014F.AUTOID);
                Db.SetParameterValue(cmd, "DATETIME", AHU_014F.DATETIME);
                Db.SetParameterValue(cmd, "LOCATION", "014F");

                #region 014F01
                Db.SetParameterValue(cmd, "DEVICE_ID", "01");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F01);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F01);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F01);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F01);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F01);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F01);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F01);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F01);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F01);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F01);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F01);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 014F02
                Db.SetParameterValue(cmd, "DEVICE_ID", "02");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F02);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F02);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F02);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F02);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F02);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F02);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F02);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F02);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F02);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F02);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F02);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 014F03
                Db.SetParameterValue(cmd, "DEVICE_ID", "03");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F03);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F03);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F03);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F03);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F03);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F03);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F03);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F03);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F03);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F03);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F03);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 014F04
                Db.SetParameterValue(cmd, "DEVICE_ID", "04");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F04);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F04);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F04);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F04);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F04);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F04);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F04);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F04);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F04);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F04);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F04);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 014F05
                Db.SetParameterValue(cmd, "DEVICE_ID", "05");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F05);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F05);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F05);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F05);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F05);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F05);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F05);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F05);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F05);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F05);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F05);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 014F06
                Db.SetParameterValue(cmd, "DEVICE_ID", "06");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F06);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F06);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F06);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F06);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F06);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F06);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F06);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F06);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F06);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F06);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F06);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion                          
                #region 014F07
                Db.SetParameterValue(cmd, "DEVICE_ID", "07");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F07);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F07);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F07);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F07);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F07);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F07);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F07);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F07);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F07);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F07);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F07);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion                          
                #region 014F08
                Db.SetParameterValue(cmd, "DEVICE_ID", "08");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F08);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F08);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F08);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F08);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F08);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F08);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F08);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F08);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F08);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F08);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F08);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 014F09
                Db.SetParameterValue(cmd, "DEVICE_ID", "01");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F09);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F09);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F09);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F09);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F09);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F09);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F09);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F09);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F09);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F09);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F09);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 014F10
                Db.SetParameterValue(cmd, "DEVICE_ID", "02");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F10);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F10);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F10);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F10);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F10);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F10);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F10);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F10);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F10);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F10);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F10);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 014F11
                Db.SetParameterValue(cmd, "DEVICE_ID", "03");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F11);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F11);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F11);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F11);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F11);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F11);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F11);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F11);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F11);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F11);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F11);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 014F12
                Db.SetParameterValue(cmd, "DEVICE_ID", "04");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F12);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F12);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F12);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F12);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F12);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F12);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F12);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F12);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F12);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F12);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F12);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 014F13
                Db.SetParameterValue(cmd, "DEVICE_ID", "05");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F13);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F13);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F13);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F13);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F13);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F13);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F13);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F13);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F13);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F13);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F13);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 014F14
                Db.SetParameterValue(cmd, "DEVICE_ID", "06");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F14);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F14);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F14);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F14);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F14);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F14);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F14);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F14);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F14);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F14);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F14);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion                          
                #region 014F15
                Db.SetParameterValue(cmd, "DEVICE_ID", "07");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F15);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F15);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F15);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F15);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F15);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F15);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F15);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F15);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F15);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F15);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F15);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion                          
                #region 014F16
                Db.SetParameterValue(cmd, "DEVICE_ID", "08");
                Db.SetParameterValue(cmd, "AHU01", AHU_014F.AHU01_014F16);
                Db.SetParameterValue(cmd, "AHU02", AHU_014F.AHU02_014F16);
                Db.SetParameterValue(cmd, "AHU03", AHU_014F.AHU03_014F16);
                Db.SetParameterValue(cmd, "AHU04", AHU_014F.AHU04_014F16);
                Db.SetParameterValue(cmd, "AHU05", AHU_014F.AHU05_014F16);
                Db.SetParameterValue(cmd, "AHU06", AHU_014F.AHU06_014F16);
                Db.SetParameterValue(cmd, "AHU07", AHU_014F.AHU07_014F16);
                Db.SetParameterValue(cmd, "AHU08", AHU_014F.AHU08_014F16);
                Db.SetParameterValue(cmd, "AHU09", AHU_014F.AHU09_014F16);
                Db.SetParameterValue(cmd, "AHU10", AHU_014F.AHU10_014F16);
                Db.SetParameterValue(cmd, "AHU11", AHU_014F.AHU11_014F16);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion

                trans.Commit();

            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return affected;
        }

        public int WriteDataForAHU_S03F(AHU_S03F AHU_S03F)
        {
            int affected = 0;
            DbConnection conn = null;
            DbTransaction trans = null;
            DbCommand cmd = null;
            string sql = null;
            try
            {
                conn = Db.CreateConnection();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                sql = @"
INSERT INTO AHU (AUTOID,DATETIME,LOCATION,DEVICE_ID,AHU01,AHU02,AHU03,AHU04,AHU05,AHU06,AHU07,AHU08,AHU09,AHU10,AHU11)     
    VALUES (@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                cmd.CommandText = sql;
                Db.AddInParameter(cmd, "AUTOID", DbType.Int32);
                Db.AddInParameter(cmd, "DATETIME", DbType.DateTime);
                Db.AddInParameter(cmd, "LOCATION", DbType.String);
                Db.AddInParameter(cmd, "DEVICE_ID", DbType.String);
                Db.AddInParameter(cmd, "AHU01", DbType.Single);
                Db.AddInParameter(cmd, "AHU02", DbType.Single);
                Db.AddInParameter(cmd, "AHU03", DbType.Single);
                Db.AddInParameter(cmd, "AHU04", DbType.Single);
                Db.AddInParameter(cmd, "AHU05", DbType.Single);
                Db.AddInParameter(cmd, "AHU06", DbType.Single);
                Db.AddInParameter(cmd, "AHU07", DbType.Single);
                Db.AddInParameter(cmd, "AHU08", DbType.Single);
                Db.AddInParameter(cmd, "AHU09", DbType.Single);
                Db.AddInParameter(cmd, "AHU10", DbType.Single);
                Db.AddInParameter(cmd, "AHU11", DbType.Single);

                Db.SetParameterValue(cmd, "AUTOID", AHU_S03F.AUTOID);
                Db.SetParameterValue(cmd, "DATETIME", AHU_S03F.DATETIME);
                Db.SetParameterValue(cmd, "LOCATION", "S03F");

                #region S03F01
                Db.SetParameterValue(cmd, "DEVICE_ID", "01");
                Db.SetParameterValue(cmd, "AHU01", AHU_S03F.AHU01_S03F01);
                Db.SetParameterValue(cmd, "AHU02", AHU_S03F.AHU02_S03F01);
                Db.SetParameterValue(cmd, "AHU03", AHU_S03F.AHU03_S03F01);
                Db.SetParameterValue(cmd, "AHU04", AHU_S03F.AHU04_S03F01);
                Db.SetParameterValue(cmd, "AHU05", AHU_S03F.AHU05_S03F01);
                Db.SetParameterValue(cmd, "AHU06", AHU_S03F.AHU06_S03F01);
                Db.SetParameterValue(cmd, "AHU07", AHU_S03F.AHU07_S03F01);
                Db.SetParameterValue(cmd, "AHU08", AHU_S03F.AHU08_S03F01);
                Db.SetParameterValue(cmd, "AHU09", AHU_S03F.AHU09_S03F01);
                Db.SetParameterValue(cmd, "AHU10", AHU_S03F.AHU10_S03F01);
                Db.SetParameterValue(cmd, "AHU11", AHU_S03F.AHU11_S03F01);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion

                trans.Commit();

            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return affected;
        }

        public int WriteDataForAHU_SB1F(AHU_SB1F AHU_SB1F)
        {
            int affected = 0;
            DbConnection conn = null;
            DbTransaction trans = null;
            DbCommand cmd = null;
            string sql = null;
            try
            {
                conn = Db.CreateConnection();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;

                sql = @"
INSERT INTO AHU (AUTOID,DATETIME,LOCATION,DEVICE_ID,AHU01,AHU02,AHU03,AHU04,AHU05,AHU06,AHU07,AHU08,AHU09,AHU10,AHU11)     
    VALUES (@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                cmd.CommandText = sql;
                Db.AddInParameter(cmd, "AUTOID", DbType.Int32);
                Db.AddInParameter(cmd, "DATETIME", DbType.DateTime);
                Db.AddInParameter(cmd, "LOCATION", DbType.String);
                Db.AddInParameter(cmd, "DEVICE_ID", DbType.String);
                Db.AddInParameter(cmd, "AHU01", DbType.Single);
                Db.AddInParameter(cmd, "AHU02", DbType.Single);
                Db.AddInParameter(cmd, "AHU03", DbType.Single);
                Db.AddInParameter(cmd, "AHU04", DbType.Single);
                Db.AddInParameter(cmd, "AHU05", DbType.Single);
                Db.AddInParameter(cmd, "AHU06", DbType.Single);
                Db.AddInParameter(cmd, "AHU07", DbType.Single);
                Db.AddInParameter(cmd, "AHU08", DbType.Single);
                Db.AddInParameter(cmd, "AHU09", DbType.Single);
                Db.AddInParameter(cmd, "AHU10", DbType.Single);
                Db.AddInParameter(cmd, "AHU11", DbType.Single);

                Db.SetParameterValue(cmd, "AUTOID", AHU_SB1F.AUTOID);
                Db.SetParameterValue(cmd, "DATETIME", AHU_SB1F.DATETIME);
                Db.SetParameterValue(cmd, "LOCATION", "SB1F");

                #region SB1F01
                Db.SetParameterValue(cmd, "DEVICE_ID", "01");
                Db.SetParameterValue(cmd, "AHU01", AHU_SB1F.AHU01_SB1F01);
                Db.SetParameterValue(cmd, "AHU02", AHU_SB1F.AHU02_SB1F01);
                Db.SetParameterValue(cmd, "AHU03", AHU_SB1F.AHU03_SB1F01);
                Db.SetParameterValue(cmd, "AHU04", AHU_SB1F.AHU04_SB1F01);
                Db.SetParameterValue(cmd, "AHU05", AHU_SB1F.AHU05_SB1F01);
                Db.SetParameterValue(cmd, "AHU06", AHU_SB1F.AHU06_SB1F01);
                Db.SetParameterValue(cmd, "AHU07", AHU_SB1F.AHU07_SB1F01);
                Db.SetParameterValue(cmd, "AHU08", AHU_SB1F.AHU08_SB1F01);
                Db.SetParameterValue(cmd, "AHU09", AHU_SB1F.AHU09_SB1F01);
                Db.SetParameterValue(cmd, "AHU10", AHU_SB1F.AHU10_SB1F01);
                Db.SetParameterValue(cmd, "AHU11", AHU_SB1F.AHU11_SB1F01);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region SB1F02
                Db.SetParameterValue(cmd, "DEVICE_ID", "02");
                Db.SetParameterValue(cmd, "AHU01", AHU_SB1F.AHU01_SB1F02);
                Db.SetParameterValue(cmd, "AHU02", AHU_SB1F.AHU02_SB1F02);
                Db.SetParameterValue(cmd, "AHU03", AHU_SB1F.AHU03_SB1F02);
                Db.SetParameterValue(cmd, "AHU04", AHU_SB1F.AHU04_SB1F02);
                Db.SetParameterValue(cmd, "AHU05", AHU_SB1F.AHU05_SB1F02);
                Db.SetParameterValue(cmd, "AHU06", AHU_SB1F.AHU06_SB1F02);
                Db.SetParameterValue(cmd, "AHU07", AHU_SB1F.AHU07_SB1F02);
                Db.SetParameterValue(cmd, "AHU08", AHU_SB1F.AHU08_SB1F02);
                Db.SetParameterValue(cmd, "AHU09", AHU_SB1F.AHU09_SB1F02);
                Db.SetParameterValue(cmd, "AHU10", AHU_SB1F.AHU10_SB1F02);
                Db.SetParameterValue(cmd, "AHU11", AHU_SB1F.AHU11_SB1F02);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion

                trans.Commit();

            }
            catch
            {
                trans.Rollback();
                throw;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return affected;
        }
    }
}

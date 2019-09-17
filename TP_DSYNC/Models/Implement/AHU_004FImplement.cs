using System;
using TP_DSYNC.Models.DataAccess;
using TP_DSYNC.Models.DataDefine.B3;
using System.Data;
using System.Data.Common;

namespace TP_DSYNC.Models.Implement
{
    public class AHU_004FImplement : DatabaseAccess
    {
        public AHU_004FImplement(string connectionStringName) : base(connectionStringName) { }

        public AHU_004F ReadData()
        {
            AHU_004F AHU_004 = null;
            try
            {
                string sql = @"
SELECT TOP 1 AUTOID, DATETIME
    ,AHU01_004F01,AHU02_004F01,AHU03_004F01,AHU04_004F01,AHU05_004F01,AHU06_004F01,AHU07_004F01,AHU08_004F01,AHU09_004F01,AHU10_004F01,AHU11_004F01
    ,AHU01_004F02,AHU02_004F02,AHU03_004F02,AHU04_004F02,AHU05_004F02,AHU06_004F02,AHU07_004F02,AHU08_004F02,AHU09_004F02,AHU10_004F02,AHU11_004F02
    ,AHU01_004F03,AHU02_004F03,AHU03_004F03,AHU04_004F03,AHU05_004F03,AHU06_004F03,AHU07_004F03,AHU08_004F03,AHU09_004F03,AHU10_004F03,AHU11_004F03
    ,AHU01_004F04,AHU02_004F04,AHU03_004F04,AHU04_004F04,AHU05_004F04,AHU06_004F04,AHU07_004F04,AHU08_004F04,AHU09_004F04,AHU10_004F04,AHU11_004F04
	FROM AHU_004
    ORDER BY AUTOID DESC
";
                using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                {
                    //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                    using (IDataReader reader = this.Db.ExecuteReader(cmd))
                    {
                        if (reader.Read())
                        {
                            AHU_004 = new AHU_004F()
                            {
                                AUTOID = (int)reader["AUTOID"],
                                DATETIME = reader["DATETIME"] as DateTime? ?? null,
                                AHU01_004F01 = reader["AHU01_004F01"] as Single? ?? null,
                                AHU02_004F01 = reader["AHU02_004F01"] as Single? ?? null,
                                AHU03_004F01 = reader["AHU03_004F01"] as Single? ?? null,
                                AHU04_004F01 = reader["AHU04_004F01"] as Single? ?? null,
                                AHU05_004F01 = reader["AHU05_004F01"] as Single? ?? null,
                                AHU06_004F01 = reader["AHU06_004F01"] as Single? ?? null,
                                AHU07_004F01 = reader["AHU07_004F01"] as Single? ?? null,
                                AHU08_004F01 = reader["AHU08_004F01"] as Single? ?? null,
                                AHU09_004F01 = reader["AHU09_004F01"] as Single? ?? null,
                                AHU10_004F01 = reader["AHU10_004F01"] as Single? ?? null,
                                AHU11_004F01 = reader["AHU11_004F01"] as Single? ?? null,
                                AHU01_004F02 = reader["AHU01_004F02"] as Single? ?? null,
                                AHU02_004F02 = reader["AHU02_004F02"] as Single? ?? null,
                                AHU03_004F02 = reader["AHU03_004F02"] as Single? ?? null,
                                AHU04_004F02 = reader["AHU04_004F02"] as Single? ?? null,
                                AHU05_004F02 = reader["AHU05_004F02"] as Single? ?? null,
                                AHU06_004F02 = reader["AHU06_004F02"] as Single? ?? null,
                                AHU07_004F02 = reader["AHU07_004F02"] as Single? ?? null,
                                AHU08_004F02 = reader["AHU08_004F02"] as Single? ?? null,
                                AHU09_004F02 = reader["AHU09_004F02"] as Single? ?? null,
                                AHU10_004F02 = reader["AHU10_004F02"] as Single? ?? null,
                                AHU11_004F02 = reader["AHU11_004F02"] as Single? ?? null,
                                AHU01_004F03 = reader["AHU01_004F03"] as Single? ?? null,
                                AHU02_004F03 = reader["AHU02_004F03"] as Single? ?? null,
                                AHU03_004F03 = reader["AHU03_004F03"] as Single? ?? null,
                                AHU04_004F03 = reader["AHU04_004F03"] as Single? ?? null,
                                AHU05_004F03 = reader["AHU05_004F03"] as Single? ?? null,
                                AHU06_004F03 = reader["AHU06_004F03"] as Single? ?? null,
                                AHU07_004F03 = reader["AHU07_004F03"] as Single? ?? null,
                                AHU08_004F03 = reader["AHU08_004F03"] as Single? ?? null,
                                AHU09_004F03 = reader["AHU09_004F03"] as Single? ?? null,
                                AHU10_004F03 = reader["AHU10_004F03"] as Single? ?? null,
                                AHU11_004F03 = reader["AHU11_004F03"] as Single? ?? null,
                                AHU01_004F04 = reader["AHU01_004F04"] as Single? ?? null,
                                AHU02_004F04 = reader["AHU02_004F04"] as Single? ?? null,
                                AHU03_004F04 = reader["AHU03_004F04"] as Single? ?? null,
                                AHU04_004F04 = reader["AHU04_004F04"] as Single? ?? null,
                                AHU05_004F04 = reader["AHU05_004F04"] as Single? ?? null,
                                AHU06_004F04 = reader["AHU06_004F04"] as Single? ?? null,
                                AHU07_004F04 = reader["AHU07_004F04"] as Single? ?? null,
                                AHU08_004F04 = reader["AHU08_004F04"] as Single? ?? null,
                                AHU09_004F04 = reader["AHU09_004F04"] as Single? ?? null,
                                AHU10_004F04 = reader["AHU10_004F04"] as Single? ?? null,
                                AHU11_004F04 = reader["AHU11_004F04"] as Single? ?? null
                            };
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return AHU_004;
        }

        public int WriteDate(AHU_004F AHU_004)
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

                Db.SetParameterValue(cmd, "AUTOID", AHU_004.AUTOID);
                Db.SetParameterValue(cmd, "DATETIME", AHU_004.DATETIME);
                Db.SetParameterValue(cmd, "LOCATION", "004F");

                #region 004F01
                Db.SetParameterValue(cmd, "DEVICE_ID", "01");
                Db.SetParameterValue(cmd, "AHU01", AHU_004.AHU01_004F01);
                Db.SetParameterValue(cmd, "AHU02", AHU_004.AHU02_004F01);
                Db.SetParameterValue(cmd, "AHU03", AHU_004.AHU03_004F01);
                Db.SetParameterValue(cmd, "AHU04", AHU_004.AHU04_004F01);
                Db.SetParameterValue(cmd, "AHU05", AHU_004.AHU05_004F01);
                Db.SetParameterValue(cmd, "AHU06", AHU_004.AHU06_004F01);
                Db.SetParameterValue(cmd, "AHU07", AHU_004.AHU07_004F01);
                Db.SetParameterValue(cmd, "AHU08", AHU_004.AHU08_004F01);
                Db.SetParameterValue(cmd, "AHU09", AHU_004.AHU09_004F01);
                Db.SetParameterValue(cmd, "AHU10", AHU_004.AHU10_004F01);
                Db.SetParameterValue(cmd, "AHU11", AHU_004.AHU11_004F01);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 004F02
                Db.SetParameterValue(cmd, "DEVICE_ID", "02");
                Db.SetParameterValue(cmd, "AHU01", AHU_004.AHU01_004F02);
                Db.SetParameterValue(cmd, "AHU02", AHU_004.AHU02_004F02);
                Db.SetParameterValue(cmd, "AHU03", AHU_004.AHU03_004F02);
                Db.SetParameterValue(cmd, "AHU04", AHU_004.AHU04_004F02);
                Db.SetParameterValue(cmd, "AHU05", AHU_004.AHU05_004F02);
                Db.SetParameterValue(cmd, "AHU06", AHU_004.AHU06_004F02);
                Db.SetParameterValue(cmd, "AHU07", AHU_004.AHU07_004F02);
                Db.SetParameterValue(cmd, "AHU08", AHU_004.AHU08_004F02);
                Db.SetParameterValue(cmd, "AHU09", AHU_004.AHU09_004F02);
                Db.SetParameterValue(cmd, "AHU10", AHU_004.AHU10_004F02);
                Db.SetParameterValue(cmd, "AHU11", AHU_004.AHU11_004F02);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 004F03
                Db.SetParameterValue(cmd, "DEVICE_ID", "03");
                Db.SetParameterValue(cmd, "AHU01", AHU_004.AHU01_004F03);
                Db.SetParameterValue(cmd, "AHU02", AHU_004.AHU02_004F03);
                Db.SetParameterValue(cmd, "AHU03", AHU_004.AHU03_004F03);
                Db.SetParameterValue(cmd, "AHU04", AHU_004.AHU04_004F03);
                Db.SetParameterValue(cmd, "AHU05", AHU_004.AHU05_004F03);
                Db.SetParameterValue(cmd, "AHU06", AHU_004.AHU06_004F03);
                Db.SetParameterValue(cmd, "AHU07", AHU_004.AHU07_004F03);
                Db.SetParameterValue(cmd, "AHU08", AHU_004.AHU08_004F03);
                Db.SetParameterValue(cmd, "AHU09", AHU_004.AHU09_004F03);
                Db.SetParameterValue(cmd, "AHU10", AHU_004.AHU10_004F03);
                Db.SetParameterValue(cmd, "AHU11", AHU_004.AHU11_004F03);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 004F04
                Db.SetParameterValue(cmd, "DEVICE_ID", "04");
                Db.SetParameterValue(cmd, "AHU01", AHU_004.AHU01_004F04);
                Db.SetParameterValue(cmd, "AHU02", AHU_004.AHU02_004F04);
                Db.SetParameterValue(cmd, "AHU03", AHU_004.AHU03_004F04);
                Db.SetParameterValue(cmd, "AHU04", AHU_004.AHU04_004F04);
                Db.SetParameterValue(cmd, "AHU05", AHU_004.AHU05_004F04);
                Db.SetParameterValue(cmd, "AHU06", AHU_004.AHU06_004F04);
                Db.SetParameterValue(cmd, "AHU07", AHU_004.AHU07_004F04);
                Db.SetParameterValue(cmd, "AHU08", AHU_004.AHU08_004F04);
                Db.SetParameterValue(cmd, "AHU09", AHU_004.AHU09_004F04);
                Db.SetParameterValue(cmd, "AHU10", AHU_004.AHU10_004F04);
                Db.SetParameterValue(cmd, "AHU11", AHU_004.AHU11_004F04);
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
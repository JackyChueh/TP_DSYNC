using System;
using TP_DSYNC.Models.DataAccess;
using TP_DSYNC.Models.DataDefine.B3;
using System.Data;
using System.Data.Common;

namespace TP_DSYNC.Models.Implement
{
    public class AHU_0B1FImplement : DatabaseAccess
    {
        public AHU_0B1FImplement(string connectionStringName) : base(connectionStringName) { }

        public AHU_0B1F ReadData()
        {
            AHU_0B1F AHU_0B1 = null;
            try
            {
                string sql = @"
SELECT TOP 1 AUTOID, DATETIME
    ,AHU01_0B1F01,AHU02_0B1F01,AHU03_0B1F01,AHU04_0B1F01,AHU05_0B1F01,AHU06_0B1F01,AHU07_0B1F01,AHU08_0B1F01,AHU09_0B1F01,AHU10_0B1F01,AHU11_0B1F01
    ,AHU01_0B1F02,AHU02_0B1F02,AHU03_0B1F02,AHU04_0B1F02,AHU05_0B1F02,AHU06_0B1F02,AHU07_0B1F02,AHU08_0B1F02,AHU09_0B1F02,AHU10_0B1F02,AHU11_0B1F02
    ,AHU01_0B1F03,AHU02_0B1F03,AHU03_0B1F03,AHU04_0B1F03,AHU05_0B1F03,AHU06_0B1F03,AHU07_0B1F03,AHU08_0B1F03,AHU09_0B1F03,AHU10_0B1F03,AHU11_0B1F03
    ,AHU01_0B1F04,AHU02_0B1F04,AHU03_0B1F04,AHU04_0B1F04,AHU05_0B1F04,AHU06_0B1F04,AHU07_0B1F04,AHU08_0B1F04,AHU09_0B1F04,AHU10_0B1F04,AHU11_0B1F04
    ,AHU01_0B1F05,AHU02_0B1F05,AHU03_0B1F05,AHU04_0B1F05,AHU05_0B1F05,AHU06_0B1F05,AHU07_0B1F05,AHU08_0B1F05,AHU09_0B1F05,AHU10_0B1F05,AHU11_0B1F05
    ,AHU01_0B1F06,AHU02_0B1F06,AHU03_0B1F06,AHU04_0B1F06,AHU05_0B1F06,AHU06_0B1F06,AHU07_0B1F06,AHU08_0B1F06,AHU09_0B1F06,AHU10_0B1F06,AHU11_0B1F06
    ,AHU01_0B1F07,AHU02_0B1F07,AHU03_0B1F07,AHU04_0B1F07,AHU05_0B1F07,AHU06_0B1F07,AHU07_0B1F07,AHU08_0B1F07,AHU09_0B1F07,AHU10_0B1F07,AHU11_0B1F07
    ,AHU01_0B1F08,AHU02_0B1F08,AHU03_0B1F08,AHU04_0B1F08,AHU05_0B1F08,AHU06_0B1F08,AHU07_0B1F08,AHU08_0B1F08,AHU09_0B1F08,AHU10_0B1F08,AHU11_0B1F08
	FROM AHU_0B1
    ORDER BY AUTOID DESC
";
                using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                {
                    //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                    using (IDataReader reader = this.Db.ExecuteReader(cmd))
                    {
                        if (reader.Read())
                        {
                            AHU_0B1 = new AHU_0B1F()
                            {
                                AUTOID = (int)reader["AUTOID"],
                                DATETIME = reader["DATETIME"] as DateTime? ?? null,
                                AHU01_0B1F01 = reader["AHU01_0B1F01"] as Single? ?? null,
                                AHU02_0B1F01 = reader["AHU02_0B1F01"] as Single? ?? null,
                                AHU03_0B1F01 = reader["AHU03_0B1F01"] as Single? ?? null,
                                AHU04_0B1F01 = reader["AHU04_0B1F01"] as Single? ?? null,
                                AHU05_0B1F01 = reader["AHU05_0B1F01"] as Single? ?? null,
                                AHU06_0B1F01 = reader["AHU06_0B1F01"] as Single? ?? null,
                                AHU07_0B1F01 = reader["AHU07_0B1F01"] as Single? ?? null,
                                AHU08_0B1F01 = reader["AHU08_0B1F01"] as Single? ?? null,
                                AHU09_0B1F01 = reader["AHU09_0B1F01"] as Single? ?? null,
                                AHU10_0B1F01 = reader["AHU10_0B1F01"] as Single? ?? null,
                                AHU11_0B1F01 = reader["AHU11_0B1F01"] as Single? ?? null,
                                AHU01_0B1F02 = reader["AHU01_0B1F02"] as Single? ?? null,
                                AHU02_0B1F02 = reader["AHU02_0B1F02"] as Single? ?? null,
                                AHU03_0B1F02 = reader["AHU03_0B1F02"] as Single? ?? null,
                                AHU04_0B1F02 = reader["AHU04_0B1F02"] as Single? ?? null,
                                AHU05_0B1F02 = reader["AHU05_0B1F02"] as Single? ?? null,
                                AHU06_0B1F02 = reader["AHU06_0B1F02"] as Single? ?? null,
                                AHU07_0B1F02 = reader["AHU07_0B1F02"] as Single? ?? null,
                                AHU08_0B1F02 = reader["AHU08_0B1F02"] as Single? ?? null,
                                AHU09_0B1F02 = reader["AHU09_0B1F02"] as Single? ?? null,
                                AHU10_0B1F02 = reader["AHU10_0B1F02"] as Single? ?? null,
                                AHU11_0B1F02 = reader["AHU11_0B1F02"] as Single? ?? null,
                                AHU01_0B1F03 = reader["AHU01_0B1F03"] as Single? ?? null,
                                AHU02_0B1F03 = reader["AHU02_0B1F03"] as Single? ?? null,
                                AHU03_0B1F03 = reader["AHU03_0B1F03"] as Single? ?? null,
                                AHU04_0B1F03 = reader["AHU04_0B1F03"] as Single? ?? null,
                                AHU05_0B1F03 = reader["AHU05_0B1F03"] as Single? ?? null,
                                AHU06_0B1F03 = reader["AHU06_0B1F03"] as Single? ?? null,
                                AHU07_0B1F03 = reader["AHU07_0B1F03"] as Single? ?? null,
                                AHU08_0B1F03 = reader["AHU08_0B1F03"] as Single? ?? null,
                                AHU09_0B1F03 = reader["AHU09_0B1F03"] as Single? ?? null,
                                AHU10_0B1F03 = reader["AHU10_0B1F03"] as Single? ?? null,
                                AHU11_0B1F03 = reader["AHU11_0B1F03"] as Single? ?? null,
                                AHU01_0B1F04 = reader["AHU01_0B1F04"] as Single? ?? null,
                                AHU02_0B1F04 = reader["AHU02_0B1F04"] as Single? ?? null,
                                AHU03_0B1F04 = reader["AHU03_0B1F04"] as Single? ?? null,
                                AHU04_0B1F04 = reader["AHU04_0B1F04"] as Single? ?? null,
                                AHU05_0B1F04 = reader["AHU05_0B1F04"] as Single? ?? null,
                                AHU06_0B1F04 = reader["AHU06_0B1F04"] as Single? ?? null,
                                AHU07_0B1F04 = reader["AHU07_0B1F04"] as Single? ?? null,
                                AHU08_0B1F04 = reader["AHU08_0B1F04"] as Single? ?? null,
                                AHU09_0B1F04 = reader["AHU09_0B1F04"] as Single? ?? null,
                                AHU10_0B1F04 = reader["AHU10_0B1F04"] as Single? ?? null,
                                AHU11_0B1F04 = reader["AHU11_0B1F04"] as Single? ?? null,
                                AHU01_0B1F05 = reader["AHU01_0B1F05"] as Single? ?? null,
                                AHU02_0B1F05 = reader["AHU02_0B1F05"] as Single? ?? null,
                                AHU03_0B1F05 = reader["AHU03_0B1F05"] as Single? ?? null,
                                AHU04_0B1F05 = reader["AHU04_0B1F05"] as Single? ?? null,
                                AHU05_0B1F05 = reader["AHU05_0B1F05"] as Single? ?? null,
                                AHU06_0B1F05 = reader["AHU06_0B1F05"] as Single? ?? null,
                                AHU07_0B1F05 = reader["AHU07_0B1F05"] as Single? ?? null,
                                AHU08_0B1F05 = reader["AHU08_0B1F05"] as Single? ?? null,
                                AHU09_0B1F05 = reader["AHU09_0B1F05"] as Single? ?? null,
                                AHU10_0B1F05 = reader["AHU10_0B1F05"] as Single? ?? null,
                                AHU11_0B1F05 = reader["AHU11_0B1F05"] as Single? ?? null,
                                AHU01_0B1F06 = reader["AHU01_0B1F06"] as Single? ?? null,
                                AHU02_0B1F06 = reader["AHU02_0B1F06"] as Single? ?? null,
                                AHU03_0B1F06 = reader["AHU03_0B1F06"] as Single? ?? null,
                                AHU04_0B1F06 = reader["AHU04_0B1F06"] as Single? ?? null,
                                AHU05_0B1F06 = reader["AHU05_0B1F06"] as Single? ?? null,
                                AHU06_0B1F06 = reader["AHU06_0B1F06"] as Single? ?? null,
                                AHU07_0B1F06 = reader["AHU07_0B1F06"] as Single? ?? null,
                                AHU08_0B1F06 = reader["AHU08_0B1F06"] as Single? ?? null,
                                AHU09_0B1F06 = reader["AHU09_0B1F06"] as Single? ?? null,
                                AHU10_0B1F06 = reader["AHU10_0B1F06"] as Single? ?? null,
                                AHU11_0B1F06 = reader["AHU11_0B1F06"] as Single? ?? null,
                                AHU01_0B1F07 = reader["AHU01_0B1F07"] as Single? ?? null,
                                AHU02_0B1F07 = reader["AHU02_0B1F07"] as Single? ?? null,
                                AHU03_0B1F07 = reader["AHU03_0B1F07"] as Single? ?? null,
                                AHU04_0B1F07 = reader["AHU04_0B1F07"] as Single? ?? null,
                                AHU05_0B1F07 = reader["AHU05_0B1F07"] as Single? ?? null,
                                AHU06_0B1F07 = reader["AHU06_0B1F07"] as Single? ?? null,
                                AHU07_0B1F07 = reader["AHU07_0B1F07"] as Single? ?? null,
                                AHU08_0B1F07 = reader["AHU08_0B1F07"] as Single? ?? null,
                                AHU09_0B1F07 = reader["AHU09_0B1F07"] as Single? ?? null,
                                AHU10_0B1F07 = reader["AHU10_0B1F07"] as Single? ?? null,
                                AHU11_0B1F07 = reader["AHU11_0B1F07"] as Single? ?? null,
                                AHU01_0B1F08 = reader["AHU01_0B1F08"] as Single? ?? null,
                                AHU02_0B1F08 = reader["AHU02_0B1F08"] as Single? ?? null,
                                AHU03_0B1F08 = reader["AHU03_0B1F08"] as Single? ?? null,
                                AHU04_0B1F08 = reader["AHU04_0B1F08"] as Single? ?? null,
                                AHU05_0B1F08 = reader["AHU05_0B1F08"] as Single? ?? null,
                                AHU06_0B1F08 = reader["AHU06_0B1F08"] as Single? ?? null,
                                AHU07_0B1F08 = reader["AHU07_0B1F08"] as Single? ?? null,
                                AHU08_0B1F08 = reader["AHU08_0B1F08"] as Single? ?? null,
                                AHU09_0B1F08 = reader["AHU09_0B1F08"] as Single? ?? null,
                                AHU10_0B1F08 = reader["AHU10_0B1F08"] as Single? ?? null,
                                AHU11_0B1F08 = reader["AHU11_0B1F08"] as Single? ?? null
                            };
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return AHU_0B1;
        }

        public int WriteDate(AHU_0B1F AHU_0B1F)
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
                #region 0B1F05
                Db.SetParameterValue(cmd, "DEVICE_ID", "05");
                Db.SetParameterValue(cmd, "AHU01", AHU_0B1F.AHU01_0B1F05);
                Db.SetParameterValue(cmd, "AHU02", AHU_0B1F.AHU02_0B1F05);
                Db.SetParameterValue(cmd, "AHU03", AHU_0B1F.AHU03_0B1F05);
                Db.SetParameterValue(cmd, "AHU04", AHU_0B1F.AHU04_0B1F05);
                Db.SetParameterValue(cmd, "AHU05", AHU_0B1F.AHU05_0B1F05);
                Db.SetParameterValue(cmd, "AHU06", AHU_0B1F.AHU06_0B1F05);
                Db.SetParameterValue(cmd, "AHU07", AHU_0B1F.AHU07_0B1F05);
                Db.SetParameterValue(cmd, "AHU08", AHU_0B1F.AHU08_0B1F05);
                Db.SetParameterValue(cmd, "AHU09", AHU_0B1F.AHU09_0B1F05);
                Db.SetParameterValue(cmd, "AHU10", AHU_0B1F.AHU10_0B1F05);
                Db.SetParameterValue(cmd, "AHU11", AHU_0B1F.AHU11_0B1F05);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion
                #region 0B1F06
                Db.SetParameterValue(cmd, "DEVICE_ID", "06");
                Db.SetParameterValue(cmd, "AHU01", AHU_0B1F.AHU01_0B1F06);
                Db.SetParameterValue(cmd, "AHU02", AHU_0B1F.AHU02_0B1F06);
                Db.SetParameterValue(cmd, "AHU03", AHU_0B1F.AHU03_0B1F06);
                Db.SetParameterValue(cmd, "AHU04", AHU_0B1F.AHU04_0B1F06);
                Db.SetParameterValue(cmd, "AHU05", AHU_0B1F.AHU05_0B1F06);
                Db.SetParameterValue(cmd, "AHU06", AHU_0B1F.AHU06_0B1F06);
                Db.SetParameterValue(cmd, "AHU07", AHU_0B1F.AHU07_0B1F06);
                Db.SetParameterValue(cmd, "AHU08", AHU_0B1F.AHU08_0B1F06);
                Db.SetParameterValue(cmd, "AHU09", AHU_0B1F.AHU09_0B1F06);
                Db.SetParameterValue(cmd, "AHU10", AHU_0B1F.AHU10_0B1F06);
                Db.SetParameterValue(cmd, "AHU11", AHU_0B1F.AHU11_0B1F06);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion                          
                #region 0B1F07
                Db.SetParameterValue(cmd, "DEVICE_ID", "07");
                Db.SetParameterValue(cmd, "AHU01", AHU_0B1F.AHU01_0B1F07);
                Db.SetParameterValue(cmd, "AHU02", AHU_0B1F.AHU02_0B1F07);
                Db.SetParameterValue(cmd, "AHU03", AHU_0B1F.AHU03_0B1F07);
                Db.SetParameterValue(cmd, "AHU04", AHU_0B1F.AHU04_0B1F07);
                Db.SetParameterValue(cmd, "AHU05", AHU_0B1F.AHU05_0B1F07);
                Db.SetParameterValue(cmd, "AHU06", AHU_0B1F.AHU06_0B1F07);
                Db.SetParameterValue(cmd, "AHU07", AHU_0B1F.AHU07_0B1F07);
                Db.SetParameterValue(cmd, "AHU08", AHU_0B1F.AHU08_0B1F07);
                Db.SetParameterValue(cmd, "AHU09", AHU_0B1F.AHU09_0B1F07);
                Db.SetParameterValue(cmd, "AHU10", AHU_0B1F.AHU10_0B1F07);
                Db.SetParameterValue(cmd, "AHU11", AHU_0B1F.AHU11_0B1F07);
                affected += Db.ExecuteNonQuery(cmd);
                #endregion                          
                #region 0B1F08
                Db.SetParameterValue(cmd, "DEVICE_ID", "08");
                Db.SetParameterValue(cmd, "AHU01", AHU_0B1F.AHU01_0B1F08);
                Db.SetParameterValue(cmd, "AHU02", AHU_0B1F.AHU02_0B1F08);
                Db.SetParameterValue(cmd, "AHU03", AHU_0B1F.AHU03_0B1F08);
                Db.SetParameterValue(cmd, "AHU04", AHU_0B1F.AHU04_0B1F08);
                Db.SetParameterValue(cmd, "AHU05", AHU_0B1F.AHU05_0B1F08);
                Db.SetParameterValue(cmd, "AHU06", AHU_0B1F.AHU06_0B1F08);
                Db.SetParameterValue(cmd, "AHU07", AHU_0B1F.AHU07_0B1F08);
                Db.SetParameterValue(cmd, "AHU08", AHU_0B1F.AHU08_0B1F08);
                Db.SetParameterValue(cmd, "AHU09", AHU_0B1F.AHU09_0B1F08);
                Db.SetParameterValue(cmd, "AHU10", AHU_0B1F.AHU10_0B1F08);
                Db.SetParameterValue(cmd, "AHU11", AHU_0B1F.AHU11_0B1F08);
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
using System;
using TP_DSYNC.Models.DataAccess;
using TP_DSYNC.Models.DataDefine.B3;
using System.Data;
using System.Data.Common;

namespace TP_DSYNC.Models.Implement
{
    public class AHU_014FImplement : DatabaseAccess
    {
        public AHU_014FImplement(string connectionStringName) : base(connectionStringName) { }

        public AHU_014F ReadData()
        {
            AHU_014F AHU_014 = null;
            try
            {
                string sql = @"
SELECT TOP 1 AUTOID, DATETIME
    ,AHU01_014F01,AHU02_014F01,AHU03_014F01,AHU04_014F01,AHU05_014F01,AHU06_014F01,AHU07_014F01,AHU08_014F01,AHU09_014F01,AHU10_014F01,AHU11_014F01
    ,AHU01_014F02,AHU02_014F02,AHU03_014F02,AHU04_014F02,AHU05_014F02,AHU06_014F02,AHU07_014F02,AHU08_014F02,AHU09_014F02,AHU10_014F02,AHU11_014F02
    ,AHU01_014F03,AHU02_014F03,AHU03_014F03,AHU04_014F03,AHU05_014F03,AHU06_014F03,AHU07_014F03,AHU08_014F03,AHU09_014F03,AHU10_014F03,AHU11_014F03
    ,AHU01_014F04,AHU02_014F04,AHU03_014F04,AHU04_014F04,AHU05_014F04,AHU06_014F04,AHU07_014F04,AHU08_014F04,AHU09_014F04,AHU10_014F04,AHU11_014F04
    ,AHU01_014F05,AHU02_014F05,AHU03_014F05,AHU04_014F05,AHU05_014F05,AHU06_014F05,AHU07_014F05,AHU08_014F05,AHU09_014F05,AHU10_014F05,AHU11_014F05
    ,AHU01_014F06,AHU02_014F06,AHU03_014F06,AHU04_014F06,AHU05_014F06,AHU06_014F06,AHU07_014F06,AHU08_014F06,AHU09_014F06,AHU10_014F06,AHU11_014F06
    ,AHU01_014F07,AHU02_014F07,AHU03_014F07,AHU04_014F07,AHU05_014F07,AHU06_014F07,AHU07_014F07,AHU08_014F07,AHU09_014F07,AHU10_014F07,AHU11_014F07
    ,AHU01_014F08,AHU02_014F08,AHU03_014F08,AHU04_014F08,AHU05_014F08,AHU06_014F08,AHU07_014F08,AHU08_014F08,AHU09_014F08,AHU10_014F08,AHU11_014F08
	FROM AHU_014
    ORDER BY AUTOID DESC
";
                using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                {
                    //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                    using (IDataReader reader = this.Db.ExecuteReader(cmd))
                    {
                        if (reader.Read())
                        {
                            AHU_014 = new AHU_014F()
                            {
                                AUTOID = (int)reader["AUTOID"],
                                DATETIME = reader["DATETIME"] as DateTime? ?? null,
                                AHU01_014F01 = reader["AHU01_014F01"] as Single? ?? null,
                                AHU02_014F01 = reader["AHU02_014F01"] as Single? ?? null,
                                AHU03_014F01 = reader["AHU03_014F01"] as Single? ?? null,
                                AHU04_014F01 = reader["AHU04_014F01"] as Single? ?? null,
                                AHU05_014F01 = reader["AHU05_014F01"] as Single? ?? null,
                                AHU06_014F01 = reader["AHU06_014F01"] as Single? ?? null,
                                AHU07_014F01 = reader["AHU07_014F01"] as Single? ?? null,
                                AHU08_014F01 = reader["AHU08_014F01"] as Single? ?? null,
                                AHU09_014F01 = reader["AHU09_014F01"] as Single? ?? null,
                                AHU10_014F01 = reader["AHU10_014F01"] as Single? ?? null,
                                AHU11_014F01 = reader["AHU11_014F01"] as Single? ?? null,
                                AHU01_014F02 = reader["AHU01_014F02"] as Single? ?? null,
                                AHU02_014F02 = reader["AHU02_014F02"] as Single? ?? null,
                                AHU03_014F02 = reader["AHU03_014F02"] as Single? ?? null,
                                AHU04_014F02 = reader["AHU04_014F02"] as Single? ?? null,
                                AHU05_014F02 = reader["AHU05_014F02"] as Single? ?? null,
                                AHU06_014F02 = reader["AHU06_014F02"] as Single? ?? null,
                                AHU07_014F02 = reader["AHU07_014F02"] as Single? ?? null,
                                AHU08_014F02 = reader["AHU08_014F02"] as Single? ?? null,
                                AHU09_014F02 = reader["AHU09_014F02"] as Single? ?? null,
                                AHU10_014F02 = reader["AHU10_014F02"] as Single? ?? null,
                                AHU11_014F02 = reader["AHU11_014F02"] as Single? ?? null,
                                AHU01_014F03 = reader["AHU01_014F03"] as Single? ?? null,
                                AHU02_014F03 = reader["AHU02_014F03"] as Single? ?? null,
                                AHU03_014F03 = reader["AHU03_014F03"] as Single? ?? null,
                                AHU04_014F03 = reader["AHU04_014F03"] as Single? ?? null,
                                AHU05_014F03 = reader["AHU05_014F03"] as Single? ?? null,
                                AHU06_014F03 = reader["AHU06_014F03"] as Single? ?? null,
                                AHU07_014F03 = reader["AHU07_014F03"] as Single? ?? null,
                                AHU08_014F03 = reader["AHU08_014F03"] as Single? ?? null,
                                AHU09_014F03 = reader["AHU09_014F03"] as Single? ?? null,
                                AHU10_014F03 = reader["AHU10_014F03"] as Single? ?? null,
                                AHU11_014F03 = reader["AHU11_014F03"] as Single? ?? null,
                                AHU01_014F04 = reader["AHU01_014F04"] as Single? ?? null,
                                AHU02_014F04 = reader["AHU02_014F04"] as Single? ?? null,
                                AHU03_014F04 = reader["AHU03_014F04"] as Single? ?? null,
                                AHU04_014F04 = reader["AHU04_014F04"] as Single? ?? null,
                                AHU05_014F04 = reader["AHU05_014F04"] as Single? ?? null,
                                AHU06_014F04 = reader["AHU06_014F04"] as Single? ?? null,
                                AHU07_014F04 = reader["AHU07_014F04"] as Single? ?? null,
                                AHU08_014F04 = reader["AHU08_014F04"] as Single? ?? null,
                                AHU09_014F04 = reader["AHU09_014F04"] as Single? ?? null,
                                AHU10_014F04 = reader["AHU10_014F04"] as Single? ?? null,
                                AHU11_014F04 = reader["AHU11_014F04"] as Single? ?? null,
                                AHU01_014F05 = reader["AHU01_014F05"] as Single? ?? null,
                                AHU02_014F05 = reader["AHU02_014F05"] as Single? ?? null,
                                AHU03_014F05 = reader["AHU03_014F05"] as Single? ?? null,
                                AHU04_014F05 = reader["AHU04_014F05"] as Single? ?? null,
                                AHU05_014F05 = reader["AHU05_014F05"] as Single? ?? null,
                                AHU06_014F05 = reader["AHU06_014F05"] as Single? ?? null,
                                AHU07_014F05 = reader["AHU07_014F05"] as Single? ?? null,
                                AHU08_014F05 = reader["AHU08_014F05"] as Single? ?? null,
                                AHU09_014F05 = reader["AHU09_014F05"] as Single? ?? null,
                                AHU10_014F05 = reader["AHU10_014F05"] as Single? ?? null,
                                AHU11_014F05 = reader["AHU11_014F05"] as Single? ?? null,
                                AHU01_014F06 = reader["AHU01_014F06"] as Single? ?? null,
                                AHU02_014F06 = reader["AHU02_014F06"] as Single? ?? null,
                                AHU03_014F06 = reader["AHU03_014F06"] as Single? ?? null,
                                AHU04_014F06 = reader["AHU04_014F06"] as Single? ?? null,
                                AHU05_014F06 = reader["AHU05_014F06"] as Single? ?? null,
                                AHU06_014F06 = reader["AHU06_014F06"] as Single? ?? null,
                                AHU07_014F06 = reader["AHU07_014F06"] as Single? ?? null,
                                AHU08_014F06 = reader["AHU08_014F06"] as Single? ?? null,
                                AHU09_014F06 = reader["AHU09_014F06"] as Single? ?? null,
                                AHU10_014F06 = reader["AHU10_014F06"] as Single? ?? null,
                                AHU11_014F06 = reader["AHU11_014F06"] as Single? ?? null,
                                AHU01_014F07 = reader["AHU01_014F07"] as Single? ?? null,
                                AHU02_014F07 = reader["AHU02_014F07"] as Single? ?? null,
                                AHU03_014F07 = reader["AHU03_014F07"] as Single? ?? null,
                                AHU04_014F07 = reader["AHU04_014F07"] as Single? ?? null,
                                AHU05_014F07 = reader["AHU05_014F07"] as Single? ?? null,
                                AHU06_014F07 = reader["AHU06_014F07"] as Single? ?? null,
                                AHU07_014F07 = reader["AHU07_014F07"] as Single? ?? null,
                                AHU08_014F07 = reader["AHU08_014F07"] as Single? ?? null,
                                AHU09_014F07 = reader["AHU09_014F07"] as Single? ?? null,
                                AHU10_014F07 = reader["AHU10_014F07"] as Single? ?? null,
                                AHU11_014F07 = reader["AHU11_014F07"] as Single? ?? null,
                                AHU01_014F08 = reader["AHU01_014F08"] as Single? ?? null,
                                AHU02_014F08 = reader["AHU02_014F08"] as Single? ?? null,
                                AHU03_014F08 = reader["AHU03_014F08"] as Single? ?? null,
                                AHU04_014F08 = reader["AHU04_014F08"] as Single? ?? null,
                                AHU05_014F08 = reader["AHU05_014F08"] as Single? ?? null,
                                AHU06_014F08 = reader["AHU06_014F08"] as Single? ?? null,
                                AHU07_014F08 = reader["AHU07_014F08"] as Single? ?? null,
                                AHU08_014F08 = reader["AHU08_014F08"] as Single? ?? null,
                                AHU09_014F08 = reader["AHU09_014F08"] as Single? ?? null,
                                AHU10_014F08 = reader["AHU10_014F08"] as Single? ?? null,
                                AHU11_014F08 = reader["AHU11_014F08"] as Single? ?? null,
                                AHU01_014F09 = reader["AHU01_014F09"] as Single? ?? null,
                                AHU02_014F09 = reader["AHU02_014F09"] as Single? ?? null,
                                AHU03_014F09 = reader["AHU03_014F09"] as Single? ?? null,
                                AHU04_014F09 = reader["AHU04_014F09"] as Single? ?? null,
                                AHU05_014F09 = reader["AHU05_014F09"] as Single? ?? null,
                                AHU06_014F09 = reader["AHU06_014F09"] as Single? ?? null,
                                AHU07_014F09 = reader["AHU07_014F09"] as Single? ?? null,
                                AHU08_014F09 = reader["AHU08_014F09"] as Single? ?? null,
                                AHU09_014F09 = reader["AHU09_014F09"] as Single? ?? null,
                                AHU10_014F09 = reader["AHU10_014F09"] as Single? ?? null,
                                AHU11_014F09 = reader["AHU11_014F09"] as Single? ?? null,
                                AHU01_014F10 = reader["AHU01_014F10"] as Single? ?? null,
                                AHU02_014F10 = reader["AHU02_014F10"] as Single? ?? null,
                                AHU03_014F10 = reader["AHU03_014F10"] as Single? ?? null,
                                AHU04_014F10 = reader["AHU04_014F10"] as Single? ?? null,
                                AHU05_014F10 = reader["AHU05_014F10"] as Single? ?? null,
                                AHU06_014F10 = reader["AHU06_014F10"] as Single? ?? null,
                                AHU07_014F10 = reader["AHU07_014F10"] as Single? ?? null,
                                AHU08_014F10 = reader["AHU08_014F10"] as Single? ?? null,
                                AHU09_014F10 = reader["AHU09_014F10"] as Single? ?? null,
                                AHU10_014F10 = reader["AHU10_014F10"] as Single? ?? null,
                                AHU11_014F10 = reader["AHU11_014F10"] as Single? ?? null,
                                AHU01_014F11 = reader["AHU01_014F11"] as Single? ?? null,
                                AHU02_014F11 = reader["AHU02_014F11"] as Single? ?? null,
                                AHU03_014F11 = reader["AHU03_014F11"] as Single? ?? null,
                                AHU04_014F11 = reader["AHU04_014F11"] as Single? ?? null,
                                AHU05_014F11 = reader["AHU05_014F11"] as Single? ?? null,
                                AHU06_014F11 = reader["AHU06_014F11"] as Single? ?? null,
                                AHU07_014F11 = reader["AHU07_014F11"] as Single? ?? null,
                                AHU08_014F11 = reader["AHU08_014F11"] as Single? ?? null,
                                AHU09_014F11 = reader["AHU09_014F11"] as Single? ?? null,
                                AHU10_014F11 = reader["AHU10_014F11"] as Single? ?? null,
                                AHU11_014F11 = reader["AHU11_014F11"] as Single? ?? null,
                                AHU01_014F12 = reader["AHU01_014F12"] as Single? ?? null,
                                AHU02_014F12 = reader["AHU02_014F12"] as Single? ?? null,
                                AHU03_014F12 = reader["AHU03_014F12"] as Single? ?? null,
                                AHU04_014F12 = reader["AHU04_014F12"] as Single? ?? null,
                                AHU05_014F12 = reader["AHU05_014F12"] as Single? ?? null,
                                AHU06_014F12 = reader["AHU06_014F12"] as Single? ?? null,
                                AHU07_014F12 = reader["AHU07_014F12"] as Single? ?? null,
                                AHU08_014F12 = reader["AHU08_014F12"] as Single? ?? null,
                                AHU09_014F12 = reader["AHU09_014F12"] as Single? ?? null,
                                AHU10_014F12 = reader["AHU10_014F12"] as Single? ?? null,
                                AHU11_014F12 = reader["AHU11_014F12"] as Single? ?? null,
                                AHU01_014F13 = reader["AHU01_014F13"] as Single? ?? null,
                                AHU02_014F13 = reader["AHU02_014F13"] as Single? ?? null,
                                AHU03_014F13 = reader["AHU03_014F13"] as Single? ?? null,
                                AHU04_014F13 = reader["AHU04_014F13"] as Single? ?? null,
                                AHU05_014F13 = reader["AHU05_014F13"] as Single? ?? null,
                                AHU06_014F13 = reader["AHU06_014F13"] as Single? ?? null,
                                AHU07_014F13 = reader["AHU07_014F13"] as Single? ?? null,
                                AHU08_014F13 = reader["AHU08_014F13"] as Single? ?? null,
                                AHU09_014F13 = reader["AHU09_014F13"] as Single? ?? null,
                                AHU10_014F13 = reader["AHU10_014F13"] as Single? ?? null,
                                AHU11_014F13 = reader["AHU11_014F13"] as Single? ?? null,
                                AHU01_014F14 = reader["AHU01_014F14"] as Single? ?? null,
                                AHU02_014F14 = reader["AHU02_014F14"] as Single? ?? null,
                                AHU03_014F14 = reader["AHU03_014F14"] as Single? ?? null,
                                AHU04_014F14 = reader["AHU04_014F14"] as Single? ?? null,
                                AHU05_014F14 = reader["AHU05_014F14"] as Single? ?? null,
                                AHU06_014F14 = reader["AHU06_014F14"] as Single? ?? null,
                                AHU07_014F14 = reader["AHU07_014F14"] as Single? ?? null,
                                AHU08_014F14 = reader["AHU08_014F14"] as Single? ?? null,
                                AHU09_014F14 = reader["AHU09_014F14"] as Single? ?? null,
                                AHU10_014F14 = reader["AHU10_014F14"] as Single? ?? null,
                                AHU11_014F14 = reader["AHU11_014F14"] as Single? ?? null,
                                AHU01_014F15 = reader["AHU01_014F15"] as Single? ?? null,
                                AHU02_014F15 = reader["AHU02_014F15"] as Single? ?? null,
                                AHU03_014F15 = reader["AHU03_014F15"] as Single? ?? null,
                                AHU04_014F15 = reader["AHU04_014F15"] as Single? ?? null,
                                AHU05_014F15 = reader["AHU05_014F15"] as Single? ?? null,
                                AHU06_014F15 = reader["AHU06_014F15"] as Single? ?? null,
                                AHU07_014F15 = reader["AHU07_014F15"] as Single? ?? null,
                                AHU08_014F15 = reader["AHU08_014F15"] as Single? ?? null,
                                AHU09_014F15 = reader["AHU09_014F15"] as Single? ?? null,
                                AHU10_014F15 = reader["AHU10_014F15"] as Single? ?? null,
                                AHU11_014F15 = reader["AHU11_014F15"] as Single? ?? null,
                                AHU01_014F16 = reader["AHU01_014F16"] as Single? ?? null,
                                AHU02_014F16 = reader["AHU02_014F16"] as Single? ?? null,
                                AHU03_014F16 = reader["AHU03_014F16"] as Single? ?? null,
                                AHU04_014F16 = reader["AHU04_014F16"] as Single? ?? null,
                                AHU05_014F16 = reader["AHU05_014F16"] as Single? ?? null,
                                AHU06_014F16 = reader["AHU06_014F16"] as Single? ?? null,
                                AHU07_014F16 = reader["AHU07_014F16"] as Single? ?? null,
                                AHU08_014F16 = reader["AHU08_014F16"] as Single? ?? null,
                                AHU09_014F16 = reader["AHU09_014F16"] as Single? ?? null,
                                AHU10_014F16 = reader["AHU10_014F16"] as Single? ?? null,
                                AHU11_014F16 = reader["AHU11_014F16"] as Single? ?? null
                            };
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return AHU_014;
        }

        public int WriteDate(AHU_014F AHU_014F)
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

    }
}
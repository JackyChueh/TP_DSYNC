using System;
using System.Diagnostics;
using TP_DSYNC.Models.DataAccess;
using TP_DSYNC.Models.DataDefine.B3;
using System.Data;
using System.Data.Common;

namespace TP_DSYNC.Models.Implement
{
    public class ReadImplement : DatabaseAccess
    {
        public ReadImplement(string connectionStringName) : base(connectionStringName) { }

        public AHU_004F ReadDataFromAHU_004F()
        {
            AHU_004F AHU_004 = null;

            string sql = @"
SELECT TOP 1 AUTOID, DATETIME
    ,AHU01_004F01,AHU02_004F01,AHU03_004F01,AHU04_004F01,AHU05_004F01,AHU06_004F01,AHU07_004F01,AHU08_004F01,AHU09_004F01,AHU10_004F01,AHU11_004F01
    ,AHU01_004F02,AHU02_004F02,AHU03_004F02,AHU04_004F02,AHU05_004F02,AHU06_004F02,AHU07_004F02,AHU08_004F02,AHU09_004F02,AHU10_004F02,AHU11_004F02
    ,AHU01_004F03,AHU02_004F03,AHU03_004F03,AHU04_004F03,AHU05_004F03,AHU06_004F03,AHU07_004F03,AHU08_004F03,AHU09_004F03,AHU10_004F03,AHU11_004F03
    ,AHU01_004F04,AHU02_004F04,AHU03_004F04,AHU04_004F04,AHU05_004F04,AHU06_004F04,AHU07_004F04,AHU08_004F04,AHU09_004F04,AHU10_004F04,AHU11_004F04
	FROM AHU_04F
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

            return AHU_004;
        }

        public AHU_0B1F ReadDataFromAHU_0B1F()
        {
            AHU_0B1F AHU_0B1 = null;

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

            return AHU_0B1;
        }

        public AHU_00RF ReadDataFromAHU_00RF()
        {
            AHU_00RF AHU_00R = null;

            string sql = @"
SELECT TOP 1 AUTOID, DATETIME
    ,AHU01_00RF01,AHU02_00RF01,AHU03_00RF01,AHU04_00RF01,AHU05_00RF01,AHU06_00RF01,AHU07_00RF01,AHU08_00RF01,AHU09_00RF01,AHU10_00RF01,AHU11_00RF01
    ,AHU01_00RF02,AHU02_00RF02,AHU03_00RF02,AHU04_00RF02,AHU05_00RF02,AHU06_00RF02,AHU07_00RF02,AHU08_00RF02,AHU09_00RF02,AHU10_00RF02,AHU11_00RF02
    ,AHU01_00RF03,AHU02_00RF03,AHU03_00RF03,AHU04_00RF03,AHU05_00RF03,AHU06_00RF03,AHU07_00RF03,AHU08_00RF03,AHU09_00RF03,AHU10_00RF03,AHU11_00RF03
    ,AHU01_00RF04,AHU02_00RF04,AHU03_00RF04,AHU04_00RF04,AHU05_00RF04,AHU06_00RF04,AHU07_00RF04,AHU08_00RF04,AHU09_00RF04,AHU10_00RF04,AHU11_00RF04
    ,AHU01_00RF05,AHU02_00RF05,AHU03_00RF05,AHU04_00RF05,AHU05_00RF05,AHU06_00RF05,AHU07_00RF05,AHU08_00RF05,AHU09_00RF05,AHU10_00RF05,AHU11_00RF05
    ,AHU01_00RF06,AHU02_00RF06,AHU03_00RF06,AHU04_00RF06,AHU05_00RF06,AHU06_00RF06,AHU07_00RF06,AHU08_00RF06,AHU09_00RF06,AHU10_00RF06,AHU11_00RF06
    ,AHU01_00RF07,AHU02_00RF07,AHU03_00RF07,AHU04_00RF07,AHU05_00RF07,AHU06_00RF07,AHU07_00RF07,AHU08_00RF07,AHU09_00RF07,AHU10_00RF07,AHU11_00RF07
    ,AHU01_00RF08,AHU02_00RF08,AHU03_00RF08,AHU04_00RF08,AHU05_00RF08,AHU06_00RF08,AHU07_00RF08,AHU08_00RF08,AHU09_00RF08,AHU10_00RF08,AHU11_00RF08
    ,AHU01_00RF09,AHU02_00RF09,AHU03_00RF09,AHU04_00RF09,AHU05_00RF09,AHU06_00RF09,AHU07_00RF09,AHU08_00RF09,AHU09_00RF09,AHU10_00RF09,AHU11_00RF09
	FROM AHU_0RF
    ORDER BY AUTOID DESC
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                using (IDataReader reader = this.Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        AHU_00R = new AHU_00RF()
                        {
                            AUTOID = (int)reader["AUTOID"],
                            DATETIME = reader["DATETIME"] as DateTime? ?? null,
                            AHU01_00RF01 = reader["AHU01_00RF01"] as Single? ?? null,
                            AHU02_00RF01 = reader["AHU02_00RF01"] as Single? ?? null,
                            AHU03_00RF01 = reader["AHU03_00RF01"] as Single? ?? null,
                            AHU04_00RF01 = reader["AHU04_00RF01"] as Single? ?? null,
                            AHU05_00RF01 = reader["AHU05_00RF01"] as Single? ?? null,
                            AHU06_00RF01 = reader["AHU06_00RF01"] as Single? ?? null,
                            AHU07_00RF01 = reader["AHU07_00RF01"] as Single? ?? null,
                            AHU08_00RF01 = reader["AHU08_00RF01"] as Single? ?? null,
                            AHU09_00RF01 = reader["AHU09_00RF01"] as Single? ?? null,
                            AHU10_00RF01 = reader["AHU10_00RF01"] as Single? ?? null,
                            AHU11_00RF01 = reader["AHU11_00RF01"] as Single? ?? null,
                            AHU01_00RF02 = reader["AHU01_00RF02"] as Single? ?? null,
                            AHU02_00RF02 = reader["AHU02_00RF02"] as Single? ?? null,
                            AHU03_00RF02 = reader["AHU03_00RF02"] as Single? ?? null,
                            AHU04_00RF02 = reader["AHU04_00RF02"] as Single? ?? null,
                            AHU05_00RF02 = reader["AHU05_00RF02"] as Single? ?? null,
                            AHU06_00RF02 = reader["AHU06_00RF02"] as Single? ?? null,
                            AHU07_00RF02 = reader["AHU07_00RF02"] as Single? ?? null,
                            AHU08_00RF02 = reader["AHU08_00RF02"] as Single? ?? null,
                            AHU09_00RF02 = reader["AHU09_00RF02"] as Single? ?? null,
                            AHU10_00RF02 = reader["AHU10_00RF02"] as Single? ?? null,
                            AHU11_00RF02 = reader["AHU11_00RF02"] as Single? ?? null,
                            AHU01_00RF03 = reader["AHU01_00RF03"] as Single? ?? null,
                            AHU02_00RF03 = reader["AHU02_00RF03"] as Single? ?? null,
                            AHU03_00RF03 = reader["AHU03_00RF03"] as Single? ?? null,
                            AHU04_00RF03 = reader["AHU04_00RF03"] as Single? ?? null,
                            AHU05_00RF03 = reader["AHU05_00RF03"] as Single? ?? null,
                            AHU06_00RF03 = reader["AHU06_00RF03"] as Single? ?? null,
                            AHU07_00RF03 = reader["AHU07_00RF03"] as Single? ?? null,
                            AHU08_00RF03 = reader["AHU08_00RF03"] as Single? ?? null,
                            AHU09_00RF03 = reader["AHU09_00RF03"] as Single? ?? null,
                            AHU10_00RF03 = reader["AHU10_00RF03"] as Single? ?? null,
                            AHU11_00RF03 = reader["AHU11_00RF03"] as Single? ?? null,
                            AHU01_00RF04 = reader["AHU01_00RF04"] as Single? ?? null,
                            AHU02_00RF04 = reader["AHU02_00RF04"] as Single? ?? null,
                            AHU03_00RF04 = reader["AHU03_00RF04"] as Single? ?? null,
                            AHU04_00RF04 = reader["AHU04_00RF04"] as Single? ?? null,
                            AHU05_00RF04 = reader["AHU05_00RF04"] as Single? ?? null,
                            AHU06_00RF04 = reader["AHU06_00RF04"] as Single? ?? null,
                            AHU07_00RF04 = reader["AHU07_00RF04"] as Single? ?? null,
                            AHU08_00RF04 = reader["AHU08_00RF04"] as Single? ?? null,
                            AHU09_00RF04 = reader["AHU09_00RF04"] as Single? ?? null,
                            AHU10_00RF04 = reader["AHU10_00RF04"] as Single? ?? null,
                            AHU11_00RF04 = reader["AHU11_00RF04"] as Single? ?? null,
                            AHU01_00RF05 = reader["AHU01_00RF05"] as Single? ?? null,
                            AHU02_00RF05 = reader["AHU02_00RF05"] as Single? ?? null,
                            AHU03_00RF05 = reader["AHU03_00RF05"] as Single? ?? null,
                            AHU04_00RF05 = reader["AHU04_00RF05"] as Single? ?? null,
                            AHU05_00RF05 = reader["AHU05_00RF05"] as Single? ?? null,
                            AHU06_00RF05 = reader["AHU06_00RF05"] as Single? ?? null,
                            AHU07_00RF05 = reader["AHU07_00RF05"] as Single? ?? null,
                            AHU08_00RF05 = reader["AHU08_00RF05"] as Single? ?? null,
                            AHU09_00RF05 = reader["AHU09_00RF05"] as Single? ?? null,
                            AHU10_00RF05 = reader["AHU10_00RF05"] as Single? ?? null,
                            AHU11_00RF05 = reader["AHU11_00RF05"] as Single? ?? null,
                            AHU01_00RF06 = reader["AHU01_00RF06"] as Single? ?? null,
                            AHU02_00RF06 = reader["AHU02_00RF06"] as Single? ?? null,
                            AHU03_00RF06 = reader["AHU03_00RF06"] as Single? ?? null,
                            AHU04_00RF06 = reader["AHU04_00RF06"] as Single? ?? null,
                            AHU05_00RF06 = reader["AHU05_00RF06"] as Single? ?? null,
                            AHU06_00RF06 = reader["AHU06_00RF06"] as Single? ?? null,
                            AHU07_00RF06 = reader["AHU07_00RF06"] as Single? ?? null,
                            AHU08_00RF06 = reader["AHU08_00RF06"] as Single? ?? null,
                            AHU09_00RF06 = reader["AHU09_00RF06"] as Single? ?? null,
                            AHU10_00RF06 = reader["AHU10_00RF06"] as Single? ?? null,
                            AHU11_00RF06 = reader["AHU11_00RF06"] as Single? ?? null,
                            AHU01_00RF07 = reader["AHU01_00RF07"] as Single? ?? null,
                            AHU02_00RF07 = reader["AHU02_00RF07"] as Single? ?? null,
                            AHU03_00RF07 = reader["AHU03_00RF07"] as Single? ?? null,
                            AHU04_00RF07 = reader["AHU04_00RF07"] as Single? ?? null,
                            AHU05_00RF07 = reader["AHU05_00RF07"] as Single? ?? null,
                            AHU06_00RF07 = reader["AHU06_00RF07"] as Single? ?? null,
                            AHU07_00RF07 = reader["AHU07_00RF07"] as Single? ?? null,
                            AHU08_00RF07 = reader["AHU08_00RF07"] as Single? ?? null,
                            AHU09_00RF07 = reader["AHU09_00RF07"] as Single? ?? null,
                            AHU10_00RF07 = reader["AHU10_00RF07"] as Single? ?? null,
                            AHU11_00RF07 = reader["AHU11_00RF07"] as Single? ?? null,
                            AHU01_00RF08 = reader["AHU01_00RF08"] as Single? ?? null,
                            AHU02_00RF08 = reader["AHU02_00RF08"] as Single? ?? null,
                            AHU03_00RF08 = reader["AHU03_00RF08"] as Single? ?? null,
                            AHU04_00RF08 = reader["AHU04_00RF08"] as Single? ?? null,
                            AHU05_00RF08 = reader["AHU05_00RF08"] as Single? ?? null,
                            AHU06_00RF08 = reader["AHU06_00RF08"] as Single? ?? null,
                            AHU07_00RF08 = reader["AHU07_00RF08"] as Single? ?? null,
                            AHU08_00RF08 = reader["AHU08_00RF08"] as Single? ?? null,
                            AHU09_00RF08 = reader["AHU09_00RF08"] as Single? ?? null,
                            AHU10_00RF08 = reader["AHU10_00RF08"] as Single? ?? null,
                            AHU11_00RF08 = reader["AHU11_00RF08"] as Single? ?? null,
                            AHU01_00RF09 = reader["AHU01_00RF09"] as Single? ?? null,
                            AHU02_00RF09 = reader["AHU02_00RF09"] as Single? ?? null,
                            AHU03_00RF09 = reader["AHU03_00RF09"] as Single? ?? null,
                            AHU04_00RF09 = reader["AHU04_00RF09"] as Single? ?? null,
                            AHU05_00RF09 = reader["AHU05_00RF09"] as Single? ?? null,
                            AHU06_00RF09 = reader["AHU06_00RF09"] as Single? ?? null,
                            AHU07_00RF09 = reader["AHU07_00RF09"] as Single? ?? null,
                            AHU08_00RF09 = reader["AHU08_00RF09"] as Single? ?? null,
                            AHU09_00RF09 = reader["AHU09_00RF09"] as Single? ?? null,
                            AHU10_00RF09 = reader["AHU10_00RF09"] as Single? ?? null,
                            AHU11_00RF09 = reader["AHU11_00RF09"] as Single? ?? null
                        };
                    }
                }
            }

            return AHU_00R;
        }

        public AHU_014F ReadDataFromAHU_014F()
        {
            AHU_014F AHU_014 = null;

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
    ,AHU01_014F09,AHU02_014F09,AHU03_014F09,AHU04_014F09,AHU05_014F09,AHU06_014F09,AHU07_014F09,AHU08_014F09,AHU09_014F09,AHU10_014F09,AHU11_014F09
    ,AHU01_014F10,AHU02_014F10,AHU03_014F10,AHU04_014F10,AHU05_014F10,AHU06_014F10,AHU07_014F10,AHU08_014F10,AHU09_014F10,AHU10_014F10,AHU11_014F10
    ,AHU01_014F11,AHU02_014F11,AHU03_014F11,AHU04_014F11,AHU05_014F11,AHU06_014F11,AHU07_014F11,AHU08_014F11,AHU09_014F11,AHU10_014F11,AHU11_014F11
    ,AHU01_014F12,AHU02_014F12,AHU03_014F12,AHU04_014F12,AHU05_014F12,AHU06_014F12,AHU07_014F12,AHU08_014F12,AHU09_014F12,AHU10_014F12,AHU11_014F12
    ,AHU01_014F13,AHU02_014F13,AHU03_014F13,AHU04_014F13,AHU05_014F13,AHU06_014F13,AHU07_014F13,AHU08_014F13,AHU09_014F13,AHU10_014F13,AHU11_014F13
    ,AHU01_014F14,AHU02_014F14,AHU03_014F14,AHU04_014F14,AHU05_014F14,AHU06_014F14,AHU07_014F14,AHU08_014F14,AHU09_014F14,AHU10_014F14,AHU11_014F14
    ,AHU01_014F15,AHU02_014F15,AHU03_014F15,AHU04_014F15,AHU05_014F15,AHU06_014F15,AHU07_014F15,AHU08_014F15,AHU09_014F15,AHU10_014F15,AHU11_014F15
    ,AHU01_014F16,AHU02_014F16,AHU03_014F16,AHU04_014F16,AHU05_014F16,AHU06_014F16,AHU07_014F16,AHU08_014F16,AHU09_014F16,AHU10_014F16,AHU11_014F16
	FROM AHU_14F
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

            return AHU_014;
        }

        public AHU_S03F ReadDataFromAHU_S03F()
        {
            AHU_S03F AHU_S03 = null;

            string sql = @"
SELECT TOP 1 AUTOID, DATETIME
    ,AHU01_S03F01,AHU02_S03F01,AHU03_S03F01,AHU04_S03F01,AHU05_S03F01,AHU06_S03F01,AHU07_S03F01,AHU08_S03F01,AHU09_S03F01,AHU10_S03F01,AHU11_S03F01
	FROM AHU_S03
    ORDER BY AUTOID DESC
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                using (IDataReader reader = this.Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        AHU_S03 = new AHU_S03F()
                        {
                            AUTOID = (int)reader["AUTOID"],
                            DATETIME = reader["DATETIME"] as DateTime? ?? null,
                            AHU01_S03F01 = reader["AHU01_S03F01"] as Single? ?? null,
                            AHU02_S03F01 = reader["AHU02_S03F01"] as Single? ?? null,
                            AHU03_S03F01 = reader["AHU03_S03F01"] as Single? ?? null,
                            AHU04_S03F01 = reader["AHU04_S03F01"] as Single? ?? null,
                            AHU05_S03F01 = reader["AHU05_S03F01"] as Single? ?? null,
                            AHU06_S03F01 = reader["AHU06_S03F01"] as Single? ?? null,
                            AHU07_S03F01 = reader["AHU07_S03F01"] as Single? ?? null,
                            AHU08_S03F01 = reader["AHU08_S03F01"] as Single? ?? null,
                            AHU09_S03F01 = reader["AHU09_S03F01"] as Single? ?? null,
                            AHU10_S03F01 = reader["AHU10_S03F01"] as Single? ?? null,
                            AHU11_S03F01 = reader["AHU11_S03F01"] as Single? ?? null
                        };
                    }
                }
            }

            return AHU_S03;
        }

        public AHU_SB1F ReadDataFromAHU_SB1F()
        {
            AHU_SB1F AHU_SB1 = null;

            string sql = @"
SELECT TOP 1 AUTOID, DATETIME
    ,AHU01_SB1F01,AHU02_SB1F01,AHU03_SB1F01,AHU04_SB1F01,AHU05_SB1F01,AHU06_SB1F01,AHU07_SB1F01,AHU08_SB1F01,AHU09_SB1F01,AHU10_SB1F01,AHU11_SB1F01
    ,AHU01_SB1F02,AHU02_SB1F02,AHU03_SB1F02,AHU04_SB1F02,AHU05_SB1F02,AHU06_SB1F02,AHU07_SB1F02,AHU08_SB1F02,AHU09_SB1F02,AHU10_SB1F02,AHU11_SB1F02
	FROM AHU_SB1
    ORDER BY AUTOID DESC
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                using (IDataReader reader = this.Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        AHU_SB1 = new AHU_SB1F()
                        {
                            AUTOID = (int)reader["AUTOID"],
                            DATETIME = reader["DATETIME"] as DateTime? ?? null,
                            AHU01_SB1F01 = reader["AHU01_SB1F01"] as Single? ?? null,
                            AHU02_SB1F01 = reader["AHU02_SB1F01"] as Single? ?? null,
                            AHU03_SB1F01 = reader["AHU03_SB1F01"] as Single? ?? null,
                            AHU04_SB1F01 = reader["AHU04_SB1F01"] as Single? ?? null,
                            AHU05_SB1F01 = reader["AHU05_SB1F01"] as Single? ?? null,
                            AHU06_SB1F01 = reader["AHU06_SB1F01"] as Single? ?? null,
                            AHU07_SB1F01 = reader["AHU07_SB1F01"] as Single? ?? null,
                            AHU08_SB1F01 = reader["AHU08_SB1F01"] as Single? ?? null,
                            AHU09_SB1F01 = reader["AHU09_SB1F01"] as Single? ?? null,
                            AHU10_SB1F01 = reader["AHU10_SB1F01"] as Single? ?? null,
                            AHU11_SB1F01 = reader["AHU11_SB1F01"] as Single? ?? null,
                            AHU01_SB1F02 = reader["AHU01_SB1F02"] as Single? ?? null,
                            AHU02_SB1F02 = reader["AHU02_SB1F02"] as Single? ?? null,
                            AHU03_SB1F02 = reader["AHU03_SB1F02"] as Single? ?? null,
                            AHU04_SB1F02 = reader["AHU04_SB1F02"] as Single? ?? null,
                            AHU05_SB1F02 = reader["AHU05_SB1F02"] as Single? ?? null,
                            AHU06_SB1F02 = reader["AHU06_SB1F02"] as Single? ?? null,
                            AHU07_SB1F02 = reader["AHU07_SB1F02"] as Single? ?? null,
                            AHU08_SB1F02 = reader["AHU08_SB1F02"] as Single? ?? null,
                            AHU09_SB1F02 = reader["AHU09_SB1F02"] as Single? ?? null,
                            AHU10_SB1F02 = reader["AHU10_SB1F02"] as Single? ?? null,
                            AHU11_SB1F02 = reader["AHU11_SB1F02"] as Single? ?? null
                        };
                    }
                }
            }

            return AHU_SB1;
        }

        public Chiller ReadDataFromChiller()
        {
            Chiller Chiller = null;

            string sql = @"
SELECT TOP 1 AUTOID,DATETIME
    ,Chiller01_R1,Chiller02_R1,Chiller03_R1,Chiller04_R1,Chiller05_R1,Chiller06_R1,Chiller07_R1,Chiller08_R1,Chiller09_R1,Chiller10_R1
    ,Chiller01_R2,Chiller02_R2,Chiller03_R2,Chiller04_R2,Chiller05_R2,Chiller06_R2,Chiller07_R2,Chiller08_R2,Chiller09_R2,Chiller10_R2
    ,Chiller01_R3,Chiller02_R3,Chiller03_R3,Chiller04_R3,Chiller05_R3,Chiller06_R3,Chiller07_R3,Chiller08_R3,Chiller09_R3,Chiller10_R3
    ,Chiller01_R6,Chiller02_R6,Chiller03_R6,Chiller04_R6,Chiller05_R6,Chiller06_R6,Chiller07_R6,Chiller08_R6,Chiller09_R6,Chiller10_R6
	FROM Chiller
    ORDER BY AUTOID DESC
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                using (IDataReader reader = this.Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        Chiller = new Chiller()
                        {
                            AUTOID = (int)reader["AUTOID"],
                            DATETIME = reader["DATETIME"] as DateTime? ?? null,
                            Chiller01_R1 = reader["Chiller01_R1"] as Single? ?? null,
                            Chiller02_R1 = reader["Chiller02_R1"] as Single? ?? null,
                            Chiller03_R1 = reader["Chiller03_R1"] as Single? ?? null,
                            Chiller04_R1 = reader["Chiller04_R1"] as Single? ?? null,
                            Chiller05_R1 = reader["Chiller05_R1"] as Single? ?? null,
                            Chiller06_R1 = reader["Chiller06_R1"] as Single? ?? null,
                            Chiller07_R1 = reader["Chiller07_R1"] as Single? ?? null,
                            Chiller08_R1 = reader["Chiller08_R1"] as Single? ?? null,
                            Chiller09_R1 = reader["Chiller09_R1"] as Single? ?? null,
                            Chiller10_R1 = reader["Chiller10_R1"] as Single? ?? null,
                            Chiller01_R2 = reader["Chiller01_R2"] as Single? ?? null,
                            Chiller02_R2 = reader["Chiller02_R2"] as Single? ?? null,
                            Chiller03_R2 = reader["Chiller03_R2"] as Single? ?? null,
                            Chiller04_R2 = reader["Chiller04_R2"] as Single? ?? null,
                            Chiller05_R2 = reader["Chiller05_R2"] as Single? ?? null,
                            Chiller06_R2 = reader["Chiller06_R2"] as Single? ?? null,
                            Chiller07_R2 = reader["Chiller07_R2"] as Single? ?? null,
                            Chiller08_R2 = reader["Chiller08_R2"] as Single? ?? null,
                            Chiller09_R2 = reader["Chiller09_R2"] as Single? ?? null,
                            Chiller10_R2 = reader["Chiller10_R2"] as Single? ?? null,
                            Chiller01_R3 = reader["Chiller01_R3"] as Single? ?? null,
                            Chiller02_R3 = reader["Chiller02_R3"] as Single? ?? null,
                            Chiller03_R3 = reader["Chiller03_R3"] as Single? ?? null,
                            Chiller04_R3 = reader["Chiller04_R3"] as Single? ?? null,
                            Chiller05_R3 = reader["Chiller05_R3"] as Single? ?? null,
                            Chiller06_R3 = reader["Chiller06_R3"] as Single? ?? null,
                            Chiller07_R3 = reader["Chiller07_R3"] as Single? ?? null,
                            Chiller08_R3 = reader["Chiller08_R3"] as Single? ?? null,
                            Chiller09_R3 = reader["Chiller09_R3"] as Single? ?? null,
                            Chiller10_R3 = reader["Chiller10_R3"] as Single? ?? null,
                            Chiller01_R6 = reader["Chiller01_R6"] as Single? ?? null,
                            Chiller02_R6 = reader["Chiller02_R6"] as Single? ?? null,
                            Chiller03_R6 = reader["Chiller03_R6"] as Single? ?? null,
                            Chiller04_R6 = reader["Chiller04_R6"] as Single? ?? null,
                            Chiller05_R6 = reader["Chiller05_R6"] as Single? ?? null,
                            Chiller06_R6 = reader["Chiller06_R6"] as Single? ?? null,
                            Chiller07_R6 = reader["Chiller07_R6"] as Single? ?? null,
                            Chiller08_R6 = reader["Chiller08_R6"] as Single? ?? null,
                            Chiller09_R6 = reader["Chiller09_R6"] as Single? ?? null,
                            Chiller10_R6 = reader["Chiller10_R6"] as Single? ?? null
                        };
                    }
                }
            }

            return Chiller;
        }

        public COP ReadDataFromCOP()
        {
            COP COP = null;

            string sql = @"
SELECT TOP 1 AUTOID,DATETIME
    ,COP01_001,COP02_001,COP03_001,COP04_001,COP05_001
    ,COP01_002,COP02_002,COP03_002,COP04_002,COP05_002
    ,COP01_003,COP02_003,COP03_003,COP04_003,COP05_003
    ,COP01_006,COP02_006,COP03_006,COP04_006,COP05_006
    ,COP01_12S,COP02_12S,COP03_12S,COP04_12S,COP05_12S
    ,COP01_03S,COP02_03S,COP03_03S,COP04_03S,COP05_03S
    ,COP01_06S,COP02_06S,COP03_06S,COP04_06S,COP05_06S
	FROM COP
    ORDER BY AUTOID DESC
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                using (IDataReader reader = this.Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        COP = new COP()
                        {
                            AUTOID = (int)reader["AUTOID"],
                            DATETIME = reader["DATETIME"] as DateTime? ?? null,
                            COP01_001 = reader["COP01_001"] as Single? ?? null,
                            COP02_001 = reader["COP02_001"] as Single? ?? null,
                            COP03_001 = reader["COP03_001"] as Single? ?? null,
                            COP04_001 = reader["COP04_001"] as Single? ?? null,
                            COP05_001 = reader["COP05_001"] as Single? ?? null,
                            COP01_002 = reader["COP01_002"] as Single? ?? null,
                            COP02_002 = reader["COP02_002"] as Single? ?? null,
                            COP03_002 = reader["COP03_002"] as Single? ?? null,
                            COP04_002 = reader["COP04_002"] as Single? ?? null,
                            COP05_002 = reader["COP05_002"] as Single? ?? null,
                            COP01_003 = reader["COP01_003"] as Single? ?? null,
                            COP02_003 = reader["COP02_003"] as Single? ?? null,
                            COP03_003 = reader["COP03_003"] as Single? ?? null,
                            COP04_003 = reader["COP04_003"] as Single? ?? null,
                            COP05_003 = reader["COP05_003"] as Single? ?? null,
                            COP01_006 = reader["COP01_006"] as Single? ?? null,
                            COP02_006 = reader["COP02_006"] as Single? ?? null,
                            COP03_006 = reader["COP03_006"] as Single? ?? null,
                            COP04_006 = reader["COP04_006"] as Single? ?? null,
                            COP05_006 = reader["COP05_006"] as Single? ?? null,
                            COP01_12S = reader["COP01_12S"] as Single? ?? null,
                            COP02_12S = reader["COP02_12S"] as Single? ?? null,
                            COP03_12S = reader["COP03_12S"] as Single? ?? null,
                            COP04_12S = reader["COP04_12S"] as Single? ?? null,
                            COP05_12S = reader["COP05_12S"] as Single? ?? null,
                            COP01_03S = reader["COP01_03S"] as Single? ?? null,
                            COP02_03S = reader["COP02_03S"] as Single? ?? null,
                            COP03_03S = reader["COP03_03S"] as Single? ?? null,
                            COP04_03S = reader["COP04_03S"] as Single? ?? null,
                            COP05_03S = reader["COP05_03S"] as Single? ?? null,
                            COP01_06S = reader["COP01_06S"] as Single? ?? null,
                            COP02_06S = reader["COP02_06S"] as Single? ?? null,
                            COP03_06S = reader["COP03_06S"] as Single? ?? null,
                            COP04_06S = reader["COP04_06S"] as Single? ?? null,
                            COP05_06S = reader["COP05_06S"] as Single? ?? null
                        };
                    }
                }
            }

            return COP;
        }

        public CP ReadDataFromCP()
        {
            CP CP = null;

            string sql = @"
SELECT TOP 1 AUTOID,DATETIME
    ,CP01_01,CP02_01,CP03_01,CP04_01,CP05_01,CP06_01,CP07_01
    ,CP01_02,CP02_02,CP03_02,CP04_02,CP05_02,CP06_02,CP07_02
    ,CP01_03,CP02_03,CP03_03,CP04_03,CP05_03,CP06_03,CP07_03
    ,CP01_06,CP02_06,CP03_06,CP04_06,CP05_06,CP06_06,CP07_06
    ,CP01_0S,CP02_0S,CP03_0S,CP04_0S,CP05_0S,CP06_0S,CP07_0S
	FROM CP
    ORDER BY AUTOID DESC
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                using (IDataReader reader = this.Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        CP = new CP()
                        {
                            AUTOID = (int)reader["AUTOID"],
                            DATETIME = reader["DATETIME"] as DateTime? ?? null,
                            CP01_01 = reader["CP01_01"] as Single? ?? null,
                            CP02_01 = reader["CP02_01"] as Single? ?? null,
                            CP03_01 = reader["CP03_01"] as Single? ?? null,
                            CP04_01 = reader["CP04_01"] as Single? ?? null,
                            CP05_01 = reader["CP05_01"] as Single? ?? null,
                            CP06_01 = reader["CP06_01"] as Single? ?? null,
                            CP07_01 = reader["CP07_01"] as Single? ?? null,
                            CP01_02 = reader["CP01_02"] as Single? ?? null,
                            CP02_02 = reader["CP02_02"] as Single? ?? null,
                            CP03_02 = reader["CP03_02"] as Single? ?? null,
                            CP04_02 = reader["CP04_02"] as Single? ?? null,
                            CP05_02 = reader["CP05_02"] as Single? ?? null,
                            CP06_02 = reader["CP06_02"] as Single? ?? null,
                            CP07_02 = reader["CP07_02"] as Single? ?? null,
                            CP01_03 = reader["CP01_03"] as Single? ?? null,
                            CP02_03 = reader["CP02_03"] as Single? ?? null,
                            CP03_03 = reader["CP03_03"] as Single? ?? null,
                            CP04_03 = reader["CP04_03"] as Single? ?? null,
                            CP05_03 = reader["CP05_03"] as Single? ?? null,
                            CP06_03 = reader["CP06_03"] as Single? ?? null,
                            CP07_03 = reader["CP07_03"] as Single? ?? null,
                            CP01_06 = reader["CP01_06"] as Single? ?? null,
                            CP02_06 = reader["CP02_06"] as Single? ?? null,
                            CP03_06 = reader["CP03_06"] as Single? ?? null,
                            CP04_06 = reader["CP04_06"] as Single? ?? null,
                            CP05_06 = reader["CP05_06"] as Single? ?? null,
                            CP06_06 = reader["CP06_06"] as Single? ?? null,
                            CP07_06 = reader["CP07_06"] as Single? ?? null,
                            CP01_0S = reader["CP01_0S"] as Single? ?? null,
                            CP02_0S = reader["CP02_0S"] as Single? ?? null,
                            CP03_0S = reader["CP03_0S"] as Single? ?? null,
                            CP04_0S = reader["CP04_0S"] as Single? ?? null,
                            CP05_0S = reader["CP05_0S"] as Single? ?? null,
                            CP06_0S = reader["CP06_0S"] as Single? ?? null,
                            CP07_0S = reader["CP07_0S"] as Single? ?? null
                        };
                    }
                }
            }

            return CP;
        }

        public CT ReadDataFromCT()
        {
            CT CT = null;

            //此項先取消    ,CT01_06,CT02_06,CT03_06,CT04_06,CT05_06,CT06_06,CT07_06

            string sql = @"
SELECT TOP 1 AUTOID,DATETIME
    ,CT01_01,CT02_01,CT03_01,CT04_01,CT05_01,CT06_01,CT07_01
    ,CT01_02,CT02_02,CT03_02,CT04_02,CT05_02,CT06_02,CT07_02
    ,CT01_03,CT02_03,CT03_03,CT04_03,CT05_03,CT06_03,CT07_03
    ,CT01_04,CT02_04,CT03_04,CT04_04,CT05_04,CT06_04,CT07_04
    ,CT01_05,CT02_05,CT03_05,CT04_05,CT05_05,CT06_05,CT07_05
	FROM CT
    ORDER BY AUTOID DESC
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                using (IDataReader reader = this.Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        CT = new CT()
                        {
                            AUTOID = (int)reader["AUTOID"],
                            DATETIME = reader["DATETIME"] as DateTime? ?? null,
                            CT01_01 = reader["CT01_01"] as Single? ?? null,
                            CT02_01 = reader["CT02_01"] as Single? ?? null,
                            CT03_01 = reader["CT03_01"] as Single? ?? null,
                            CT04_01 = reader["CT04_01"] as Single? ?? null,
                            CT05_01 = reader["CT05_01"] as Single? ?? null,
                            CT06_01 = reader["CT06_01"] as Single? ?? null,
                            CT07_01 = reader["CT07_01"] as Single? ?? null,
                            CT01_02 = reader["CT01_02"] as Single? ?? null,
                            CT02_02 = reader["CT02_02"] as Single? ?? null,
                            CT03_02 = reader["CT03_02"] as Single? ?? null,
                            CT04_02 = reader["CT04_02"] as Single? ?? null,
                            CT05_02 = reader["CT05_02"] as Single? ?? null,
                            CT06_02 = reader["CT06_02"] as Single? ?? null,
                            CT07_02 = reader["CT07_02"] as Single? ?? null,
                            CT01_03 = reader["CT01_03"] as Single? ?? null,
                            CT02_03 = reader["CT02_03"] as Single? ?? null,
                            CT03_03 = reader["CT03_03"] as Single? ?? null,
                            CT04_03 = reader["CT04_03"] as Single? ?? null,
                            CT05_03 = reader["CT05_03"] as Single? ?? null,
                            CT06_03 = reader["CT06_03"] as Single? ?? null,
                            CT07_03 = reader["CT07_03"] as Single? ?? null,
                            CT01_04 = reader["CT01_04"] as Single? ?? null,
                            CT02_04 = reader["CT02_04"] as Single? ?? null,
                            CT03_04 = reader["CT03_04"] as Single? ?? null,
                            CT04_04 = reader["CT04_04"] as Single? ?? null,
                            CT05_04 = reader["CT05_04"] as Single? ?? null,
                            CT06_04 = reader["CT06_04"] as Single? ?? null,
                            CT07_04 = reader["CT07_04"] as Single? ?? null,
                            CT01_05 = reader["CT01_05"] as Single? ?? null,
                            CT02_05 = reader["CT02_05"] as Single? ?? null,
                            CT03_05 = reader["CT03_05"] as Single? ?? null,
                            CT04_05 = reader["CT04_05"] as Single? ?? null,
                            CT05_05 = reader["CT05_05"] as Single? ?? null,
                            CT06_05 = reader["CT06_05"] as Single? ?? null,
                            CT07_05 = reader["CT07_05"] as Single? ?? null
                            //CT01_06 = reader["CT01_06"] as Single? ?? null,
                            //CT02_06 = reader["CT02_06"] as Single? ?? null,
                            //CT03_06 = reader["CT03_06"] as Single? ?? null,
                            //CT04_06 = reader["CT04_06"] as Single? ?? null,
                            //CT05_06 = reader["CT05_06"] as Single? ?? null,
                            //CT06_06 = reader["CT06_06"] as Single? ?? null,
                            //CT07_06 = reader["CT07_06"] as Single? ?? null
                        };
                    }
                }
            }

            return CT;
        }

        public RRS ReadDataFromRRS()
        {
            RRS RRS = null;

            string sql = @"
SELECT TOP 1 AUTOID,DATETIME
    ,RRS01_VFLH01,RRS02_VFLH01,RRS03_VFLH01,RRS04_VFLH01,RRS05_VFLH01,RRS06_VFLH01
    ,RRS01_PVOI01,RRS02_PVOI01,RRS03_PVOI01,RRS04_PVOI01,RRS05_PVOI01,RRS06_PVOI01,RRS07_PVOI01
    ,RRS01_PWLS01,RRS02_PWLS01,RRS03_PWLS01,RRS04_PWLS01,RRS05_PWLS01,RRS06_PWLS01,RRS07_PWLS01,RRS08_PWLS01,RRS09_PWLS01,RRS10_PWLS01,RRS11_PWLS01,RRS12_PWLS01,RRS13_PWLS01
	FROM RRS
    ORDER BY AUTOID DESC
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                using (IDataReader reader = this.Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        RRS = new RRS()
                        {
                            AUTOID = (int)reader["AUTOID"],
                            DATETIME = reader["DATETIME"] as DateTime? ?? null,
                            RRS01_VFLH01 = reader["RRS01_VFLH01"] as Single? ?? null,
                            RRS02_VFLH01 = reader["RRS02_VFLH01"] as Single? ?? null,
                            RRS03_VFLH01 = reader["RRS03_VFLH01"] as Single? ?? null,
                            RRS04_VFLH01 = reader["RRS04_VFLH01"] as Single? ?? null,
                            RRS05_VFLH01 = reader["RRS05_VFLH01"] as Single? ?? null,
                            RRS06_VFLH01 = reader["RRS06_VFLH01"] as Single? ?? null,

                            RRS01_PVOI01 = reader["RRS01_PVOI01"] as Single? ?? null,
                            RRS02_PVOI01 = reader["RRS02_PVOI01"] as Single? ?? null,
                            RRS03_PVOI01 = reader["RRS03_PVOI01"] as Single? ?? null,
                            RRS04_PVOI01 = reader["RRS04_PVOI01"] as Single? ?? null,
                            RRS05_PVOI01 = reader["RRS05_PVOI01"] as Single? ?? null,
                            RRS06_PVOI01 = reader["RRS06_PVOI01"] as Single? ?? null,
                            RRS07_PVOI01 = reader["RRS07_PVOI01"] as Single? ?? null,

                            RRS01_PWLS01 = reader["RRS01_PWLS01"] as Single? ?? null,
                            RRS02_PWLS01 = reader["RRS02_PWLS01"] as Single? ?? null,
                            RRS03_PWLS01 = reader["RRS03_PWLS01"] as Single? ?? null,
                            RRS04_PWLS01 = reader["RRS04_PWLS01"] as Single? ?? null,
                            RRS05_PWLS01 = reader["RRS05_PWLS01"] as Single? ?? null,
                            RRS06_PWLS01 = reader["RRS06_PWLS01"] as Single? ?? null,
                            RRS07_PWLS01 = reader["RRS07_PWLS01"] as Single? ?? null,
                            RRS08_PWLS01 = reader["RRS08_PWLS01"] as Single? ?? null,
                            RRS09_PWLS01 = reader["RRS09_PWLS01"] as Single? ?? null,
                            RRS10_PWLS01 = reader["RRS10_PWLS01"] as Single? ?? null,
                            RRS11_PWLS01 = reader["RRS11_PWLS01"] as Single? ?? null,
                            RRS12_PWLS01 = reader["RRS12_PWLS01"] as Single? ?? null,
                            RRS13_PWLS01 = reader["RRS13_PWLS01"] as Single? ?? null
                        };
                    }
                }
            }

            return RRS;
        }

        public WSDS ReadDataFromWSDS()
        {
            WSDS WSDS = null;

            string sql = @"
SELECT TOP 1 AUTOID,DATETIME
    ,WSDS01_PVOI01,WSDS02_PVOI01,WSDS03_PVOI01,WSDS04_PVOI01,WSDS05_PVOI01,WSDS06_PVOI01,WSDS07_PVOI01,WSDS08_PVOI01
    ,WSDS09_PVOI01,WSDS10_PVOI01,WSDS11_PVOI01,WSDS12_PVOI01,WSDS13_PVOI01,WSDS14_PVOI01,WSDS15_PVOI01,WSDS16_PVOI01
    ,WSDS17_PVOI01,WSDS18_PVOI01,WSDS19_PVOI01,WSDS20_PVOI01,WSDS21_PVOI01,WSDS22_PVOI01,WSDS23_PVOI01,WSDS24_PVOI01
    ,WSDS25_PVOI01,WSDS26_PVOI01
    ,WSDS01_PWLS01,WSDS02_PWLS01,WSDS03_PWLS01,WSDS04_PWLS01,WSDS05_PWLS01,WSDS06_PWLS01,WSDS07_PWLS01,WSDS08_PWLS01
    ,WSDS09_PWLS01,WSDS10_PWLS01,WSDS11_PWLS01,WSDS12_PWLS01,WSDS13_PWLS01,WSDS14_PWLS01,WSDS15_PWLS01,WSDS16_PWLS01
    ,WSDS17_PWLS01,WSDS18_PWLS01,WSDS19_PWLS01,WSDS20_PWLS01,WSDS21_PWLS01,WSDS22_PWLS01,WSDS23_PWLS01,WSDS24_PWLS01
    ,WSDS25_PWLS01,WSDS26_PWLS01,WSDS27_PWLS01,WSDS28_PWLS01,WSDS29_PWLS01,WSDS30_PWLS01,WSDS31_PWLS01,WSDS32_PWLS01
    ,WSDS33_PWLS01,WSDS34_PWLS01,WSDS35_PWLS01,WSDS36_PWLS01,WSDS37_PWLS01,WSDS38_PWLS01,WSDS39_PWLS01,WSDS40_PWLS01
    ,WSDS41_PWLS01,WSDS42_PWLS01,WSDS43_PWLS01,WSDS44_PWLS01,WSDS45_PWLS01,WSDS46_PWLS01,WSDS47_PWLS01,WSDS48_PWLS01
    ,WSDS49_PWLS01,WSDS50_PWLS01,WSDS51_PWLS01,WSDS52_PWLS01,WSDS53_PWLS01,WSDS54_PWLS01,WSDS55_PWLS01,WSDS56_PWLS01
    ,WSDS57_PWLS01,WSDS58_PWLS01
	FROM WSDS
    ORDER BY AUTOID DESC
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                using (IDataReader reader = this.Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        WSDS = new WSDS()
                        {
                            AUTOID = (int)reader["AUTOID"],
                            DATETIME = reader["DATETIME"] as DateTime? ?? null,
                            WSDS01_PVOI01 = reader["WSDS01_PVOI01"] as Single? ?? null,
                            WSDS02_PVOI01 = reader["WSDS02_PVOI01"] as Single? ?? null,
                            WSDS03_PVOI01 = reader["WSDS03_PVOI01"] as Single? ?? null,
                            WSDS04_PVOI01 = reader["WSDS04_PVOI01"] as Single? ?? null,
                            WSDS05_PVOI01 = reader["WSDS05_PVOI01"] as Single? ?? null,
                            WSDS06_PVOI01 = reader["WSDS06_PVOI01"] as Single? ?? null,
                            WSDS07_PVOI01 = reader["WSDS07_PVOI01"] as Single? ?? null,
                            WSDS08_PVOI01 = reader["WSDS08_PVOI01"] as Single? ?? null,
                            WSDS09_PVOI01 = reader["WSDS09_PVOI01"] as Single? ?? null,
                            WSDS10_PVOI01 = reader["WSDS10_PVOI01"] as Single? ?? null,
                            WSDS11_PVOI01 = reader["WSDS11_PVOI01"] as Single? ?? null,
                            WSDS12_PVOI01 = reader["WSDS12_PVOI01"] as Single? ?? null,
                            WSDS13_PVOI01 = reader["WSDS13_PVOI01"] as Single? ?? null,
                            WSDS14_PVOI01 = reader["WSDS14_PVOI01"] as Single? ?? null,
                            WSDS15_PVOI01 = reader["WSDS15_PVOI01"] as Single? ?? null,
                            WSDS16_PVOI01 = reader["WSDS16_PVOI01"] as Single? ?? null,
                            WSDS17_PVOI01 = reader["WSDS17_PVOI01"] as Single? ?? null,
                            WSDS18_PVOI01 = reader["WSDS18_PVOI01"] as Single? ?? null,
                            WSDS19_PVOI01 = reader["WSDS19_PVOI01"] as Single? ?? null,
                            WSDS20_PVOI01 = reader["WSDS20_PVOI01"] as Single? ?? null,
                            WSDS21_PVOI01 = reader["WSDS21_PVOI01"] as Single? ?? null,
                            WSDS22_PVOI01 = reader["WSDS22_PVOI01"] as Single? ?? null,
                            WSDS23_PVOI01 = reader["WSDS23_PVOI01"] as Single? ?? null,
                            WSDS24_PVOI01 = reader["WSDS24_PVOI01"] as Single? ?? null,
                            WSDS25_PVOI01 = reader["WSDS25_PVOI01"] as Single? ?? null,
                            WSDS26_PVOI01 = reader["WSDS26_PVOI01"] as Single? ?? null,

                            WSDS01_PWLS01 = reader["WSDS01_PWLS01"] as Single? ?? null,
                            WSDS02_PWLS01 = reader["WSDS02_PWLS01"] as Single? ?? null,
                            WSDS03_PWLS01 = reader["WSDS03_PWLS01"] as Single? ?? null,
                            WSDS04_PWLS01 = reader["WSDS04_PWLS01"] as Single? ?? null,
                            WSDS05_PWLS01 = reader["WSDS05_PWLS01"] as Single? ?? null,
                            WSDS06_PWLS01 = reader["WSDS06_PWLS01"] as Single? ?? null,
                            WSDS07_PWLS01 = reader["WSDS07_PWLS01"] as Single? ?? null,
                            WSDS08_PWLS01 = reader["WSDS08_PWLS01"] as Single? ?? null,
                            WSDS09_PWLS01 = reader["WSDS09_PWLS01"] as Single? ?? null,
                            WSDS10_PWLS01 = reader["WSDS10_PWLS01"] as Single? ?? null,
                            WSDS11_PWLS01 = reader["WSDS11_PWLS01"] as Single? ?? null,
                            WSDS12_PWLS01 = reader["WSDS12_PWLS01"] as Single? ?? null,
                            WSDS13_PWLS01 = reader["WSDS13_PWLS01"] as Single? ?? null,
                            WSDS14_PWLS01 = reader["WSDS14_PWLS01"] as Single? ?? null,
                            WSDS15_PWLS01 = reader["WSDS15_PWLS01"] as Single? ?? null,
                            WSDS16_PWLS01 = reader["WSDS16_PWLS01"] as Single? ?? null,
                            WSDS17_PWLS01 = reader["WSDS17_PWLS01"] as Single? ?? null,
                            WSDS18_PWLS01 = reader["WSDS18_PWLS01"] as Single? ?? null,
                            WSDS19_PWLS01 = reader["WSDS19_PWLS01"] as Single? ?? null,
                            WSDS20_PWLS01 = reader["WSDS20_PWLS01"] as Single? ?? null,
                            WSDS21_PWLS01 = reader["WSDS21_PWLS01"] as Single? ?? null,
                            WSDS22_PWLS01 = reader["WSDS22_PWLS01"] as Single? ?? null,
                            WSDS23_PWLS01 = reader["WSDS23_PWLS01"] as Single? ?? null,
                            WSDS24_PWLS01 = reader["WSDS24_PWLS01"] as Single? ?? null,
                            WSDS25_PWLS01 = reader["WSDS25_PWLS01"] as Single? ?? null,
                            WSDS26_PWLS01 = reader["WSDS26_PWLS01"] as Single? ?? null,
                            WSDS27_PWLS01 = reader["WSDS27_PWLS01"] as Single? ?? null,
                            WSDS28_PWLS01 = reader["WSDS28_PWLS01"] as Single? ?? null,
                            WSDS29_PWLS01 = reader["WSDS29_PWLS01"] as Single? ?? null,
                            WSDS30_PWLS01 = reader["WSDS30_PWLS01"] as Single? ?? null,
                            WSDS31_PWLS01 = reader["WSDS31_PWLS01"] as Single? ?? null,
                            WSDS32_PWLS01 = reader["WSDS32_PWLS01"] as Single? ?? null,
                            WSDS33_PWLS01 = reader["WSDS33_PWLS01"] as Single? ?? null,
                            WSDS34_PWLS01 = reader["WSDS34_PWLS01"] as Single? ?? null,
                            WSDS35_PWLS01 = reader["WSDS35_PWLS01"] as Single? ?? null,
                            WSDS36_PWLS01 = reader["WSDS36_PWLS01"] as Single? ?? null,
                            WSDS37_PWLS01 = reader["WSDS37_PWLS01"] as Single? ?? null,
                            WSDS38_PWLS01 = reader["WSDS38_PWLS01"] as Single? ?? null,
                            WSDS39_PWLS01 = reader["WSDS39_PWLS01"] as Single? ?? null,
                            WSDS40_PWLS01 = reader["WSDS40_PWLS01"] as Single? ?? null,
                            WSDS41_PWLS01 = reader["WSDS41_PWLS01"] as Single? ?? null,
                            WSDS42_PWLS01 = reader["WSDS42_PWLS01"] as Single? ?? null,
                            WSDS43_PWLS01 = reader["WSDS43_PWLS01"] as Single? ?? null,
                            WSDS44_PWLS01 = reader["WSDS44_PWLS01"] as Single? ?? null,
                            WSDS45_PWLS01 = reader["WSDS45_PWLS01"] as Single? ?? null,
                            WSDS46_PWLS01 = reader["WSDS46_PWLS01"] as Single? ?? null,
                            WSDS47_PWLS01 = reader["WSDS47_PWLS01"] as Single? ?? null,
                            WSDS48_PWLS01 = reader["WSDS48_PWLS01"] as Single? ?? null,
                            WSDS49_PWLS01 = reader["WSDS49_PWLS01"] as Single? ?? null,
                            WSDS50_PWLS01 = reader["WSDS50_PWLS01"] as Single? ?? null,
                            WSDS51_PWLS01 = reader["WSDS51_PWLS01"] as Single? ?? null,
                            WSDS52_PWLS01 = reader["WSDS52_PWLS01"] as Single? ?? null,
                            WSDS53_PWLS01 = reader["WSDS53_PWLS01"] as Single? ?? null,
                            WSDS54_PWLS01 = reader["WSDS54_PWLS01"] as Single? ?? null,
                            WSDS55_PWLS01 = reader["WSDS55_PWLS01"] as Single? ?? null,
                            WSDS56_PWLS01 = reader["WSDS56_PWLS01"] as Single? ?? null,
                            WSDS57_PWLS01 = reader["WSDS57_PWLS01"] as Single? ?? null,
                            WSDS58_PWLS01 = reader["WSDS58_PWLS01"] as Single? ?? null
                        };
                    }
                }
            }

            return WSDS;
        }

        public ZP1 ReadDataFromZP1()
        {
            ZP1 ZP1 = null;

            string sql = @"
SELECT TOP 1 AUTOID,DATETIME
    ,ZP101_00,ZP102_00,ZP104_00,ZP105_00,ZP106_00,ZP107_00,ZP108_00,ZP109_00,ZP110_00,ZP111_00
    ,ZP101_01,ZP102_01,ZP104_01,ZP105_01,ZP106_01,ZP107_01,ZP108_01,ZP109_01,ZP110_01,ZP111_01
	FROM ZP1
    ORDER BY AUTOID DESC
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                using (IDataReader reader = this.Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        ZP1 = new ZP1()
                        {
                            AUTOID = (int)reader["AUTOID"],
                            DATETIME = reader["DATETIME"] as DateTime? ?? null,
                            ZP101_00 = reader["ZP101_00"] as Single? ?? null,
                            ZP102_00 = reader["ZP102_00"] as Single? ?? null,
                            ZP104_00 = reader["ZP104_00"] as Single? ?? null,
                            ZP105_00 = reader["ZP105_00"] as Single? ?? null,
                            ZP106_00 = reader["ZP106_00"] as Single? ?? null,
                            ZP107_00 = reader["ZP107_00"] as Single? ?? null,
                            ZP108_00 = reader["ZP108_00"] as Single? ?? null,
                            ZP109_00 = reader["ZP109_00"] as Single? ?? null,
                            ZP110_00 = reader["ZP110_00"] as Single? ?? null,
                            ZP111_00 = reader["ZP111_00"] as Single? ?? null,
                            ZP101_01 = reader["ZP101_01"] as Single? ?? null,
                            ZP102_01 = reader["ZP102_01"] as Single? ?? null,
                            ZP104_01 = reader["ZP104_01"] as Single? ?? null,
                            ZP105_01 = reader["ZP105_01"] as Single? ?? null,
                            ZP106_01 = reader["ZP106_01"] as Single? ?? null,
                            ZP107_01 = reader["ZP107_01"] as Single? ?? null,
                            ZP108_01 = reader["ZP108_01"] as Single? ?? null,
                            ZP109_01 = reader["ZP109_01"] as Single? ?? null,
                            ZP110_01 = reader["ZP110_01"] as Single? ?? null,
                            ZP111_01 = reader["ZP111_01"] as Single? ?? null
                        };
                    }
                }
            }

            return ZP1;
        }

        public MSPCSTATS ReadDataFromMSPCSTATS()
        {
            MSPCSTATS MSPCSTATS = null;

            string sql = @"
SELECT TOP 1 AUTOID,DATETIME
    ,ASEF04_PAAC04,ASEF04_PAAC05,ASEF04_PAAC06,ASEF04_PAAC07,ASEF08_PAAC09,ASEF08_PAAC10,ASEF08_PAAC11,ASEF08_PAAC12,ASEF08_PAAC13
    ,ASEF05_PAAC18,ASEF04_PAAC19,ASEF06_PAAC20,ASEF05_PAAC23,ASEF05_PAAC24,ASEF01_PAAC28,ASEF04_PAAC33,ASEF06_PAAC34,ASEF07_PAAC34
    ,ASEF06_PAAC35,ASEF07_PAAC35,ASEF05_PAAC36,ASEF06_PAAC37,ASEF07_PAAC37,ASEF06_PAAC38,ASEF07_PAAC38,ASEF04_PAAC39,ASEF04_PAAC40
    ,ASEF05_PAAC41,ASEF06_PAAC42,ASEF07_PAAC42,ASEF04_PAAC43,ASEF05_PAAC45,ASEF05_PAAC46,BSEF03_PBAC01,BSEF05_PBAC01,BSEF03_PBAC02
    ,BSEF05_PBAC02,BSEF03_PBAC03,BSEF05_PBAC03,BSEF03_PBAC04,BSEF05_PBAC04,BSEF03_PBAC05,BSEF05_PBAC05,BSEF03_PBAC06,BSEF05_PBAC06
    ,BSEF03_PBAC07,BSEF05_PBAC07,BSEF03_PBAC08,BSEF05_PBAC08,BSEF03_PBAC09,BSEF05_PBAC09,BSEF03_PBAC10,BSEF05_PBAC10,BSEF03_PBAC11
    ,BSEF05_PBAC11,BSEF03_PBAC12,BSEF05_PBAC12,BSEF01_PBAC14,BSEF05_PBAC15,BSEF01_PBAC19,BSEF05_PBAC19
	FROM MSPCSTATS
    ORDER BY AUTOID DESC
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                using (IDataReader reader = this.Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        MSPCSTATS = new MSPCSTATS()
                        {
                            AUTOID = (int)reader["AUTOID"],
                            DATETIME = reader["DATETIME"] as DateTime? ?? null,
                            ASEF04_PAAC04 = reader["ASEF04_PAAC04"] as Single? ?? null,
                            ASEF04_PAAC05 = reader["ASEF04_PAAC05"] as Single? ?? null,
                            ASEF04_PAAC06 = reader["ASEF04_PAAC06"] as Single? ?? null,
                            ASEF04_PAAC07 = reader["ASEF04_PAAC07"] as Single? ?? null,
                            ASEF08_PAAC09 = reader["ASEF08_PAAC09"] as Single? ?? null,
                            ASEF08_PAAC10 = reader["ASEF08_PAAC10"] as Single? ?? null,
                            ASEF08_PAAC11 = reader["ASEF08_PAAC11"] as Single? ?? null,
                            ASEF08_PAAC12 = reader["ASEF08_PAAC12"] as Single? ?? null,
                            ASEF08_PAAC13 = reader["ASEF08_PAAC13"] as Single? ?? null,
                            ASEF05_PAAC18 = reader["ASEF05_PAAC18"] as Single? ?? null,
                            ASEF04_PAAC19 = reader["ASEF04_PAAC19"] as Single? ?? null,
                            //ASEF06_PAAC20 = reader["ASEF06_PAAC20"] as Single? ?? null,// 
                            ASEF05_PAAC23 = reader["ASEF05_PAAC23"] as Single? ?? null,
                            ASEF05_PAAC24 = reader["ASEF05_PAAC24"] as Single? ?? null,
                            ASEF01_PAAC28 = reader["ASEF01_PAAC28"] as Single? ?? null,
                            ASEF04_PAAC33 = reader["ASEF04_PAAC33"] as Single? ?? null,
                            ASEF06_PAAC34 = reader["ASEF06_PAAC34"] as Single? ?? null,
                            ASEF07_PAAC34 = reader["ASEF07_PAAC34"] as Single? ?? null,
                            ASEF06_PAAC35 = reader["ASEF06_PAAC35"] as Single? ?? null,
                            ASEF07_PAAC35 = reader["ASEF07_PAAC35"] as Single? ?? null,
                            ASEF05_PAAC36 = reader["ASEF05_PAAC36"] as Single? ?? null,
                            ASEF06_PAAC37 = reader["ASEF06_PAAC37"] as Single? ?? null,
                            ASEF07_PAAC37 = reader["ASEF07_PAAC37"] as Single? ?? null,
                            ASEF06_PAAC38 = reader["ASEF06_PAAC38"] as Single? ?? null,
                            ASEF07_PAAC38 = reader["ASEF07_PAAC38"] as Single? ?? null,
                            ASEF04_PAAC39 = reader["ASEF04_PAAC39"] as Single? ?? null,
                            ASEF04_PAAC40 = reader["ASEF04_PAAC40"] as Single? ?? null,
                            ASEF05_PAAC41 = reader["ASEF05_PAAC41"] as Single? ?? null,
                            ASEF06_PAAC42 = reader["ASEF06_PAAC42"] as Single? ?? null,
                            ASEF07_PAAC42 = reader["ASEF07_PAAC42"] as Single? ?? null,
                            ASEF04_PAAC43 = reader["ASEF04_PAAC43"] as Single? ?? null,
                            ASEF05_PAAC45 = reader["ASEF05_PAAC45"] as Single? ?? null,
                            ASEF05_PAAC46 = reader["ASEF05_PAAC46"] as Single? ?? null,
                            BSEF03_PBAC01 = reader["BSEF03_PBAC01"] as Single? ?? null,
                            BSEF05_PBAC01 = reader["BSEF05_PBAC01"] as Single? ?? null,
                            BSEF03_PBAC02 = reader["BSEF03_PBAC02"] as Single? ?? null,
                            BSEF05_PBAC02 = reader["BSEF05_PBAC02"] as Single? ?? null,
                            BSEF03_PBAC03 = reader["BSEF03_PBAC03"] as Single? ?? null,
                            BSEF05_PBAC03 = reader["BSEF05_PBAC03"] as Single? ?? null,
                            BSEF03_PBAC04 = reader["BSEF03_PBAC04"] as Single? ?? null,
                            BSEF05_PBAC04 = reader["BSEF05_PBAC04"] as Single? ?? null,
                            BSEF03_PBAC05 = reader["BSEF03_PBAC05"] as Single? ?? null,
                            BSEF05_PBAC05 = reader["BSEF05_PBAC05"] as Single? ?? null,
                            BSEF03_PBAC06 = reader["BSEF03_PBAC06"] as Single? ?? null,
                            BSEF05_PBAC06 = reader["BSEF05_PBAC06"] as Single? ?? null,
                            BSEF03_PBAC07 = reader["BSEF03_PBAC07"] as Single? ?? null,
                            BSEF05_PBAC07 = reader["BSEF05_PBAC07"] as Single? ?? null,
                            BSEF03_PBAC08 = reader["BSEF03_PBAC08"] as Single? ?? null,
                            BSEF05_PBAC08 = reader["BSEF05_PBAC08"] as Single? ?? null,
                            BSEF03_PBAC09 = reader["BSEF03_PBAC09"] as Single? ?? null,
                            BSEF05_PBAC09 = reader["BSEF05_PBAC09"] as Single? ?? null,
                            BSEF03_PBAC10 = reader["BSEF03_PBAC10"] as Single? ?? null,
                            BSEF05_PBAC10 = reader["BSEF05_PBAC10"] as Single? ?? null,
                            BSEF03_PBAC11 = reader["BSEF03_PBAC11"] as Single? ?? null,
                            BSEF05_PBAC11 = reader["BSEF05_PBAC11"] as Single? ?? null,
                            BSEF03_PBAC12 = reader["BSEF03_PBAC12"] as Single? ?? null,
                            BSEF05_PBAC12 = reader["BSEF05_PBAC12"] as Single? ?? null,
                            BSEF01_PBAC14 = reader["BSEF01_PBAC14"] as Single? ?? null,
                            BSEF05_PBAC15 = reader["BSEF05_PBAC15"] as Single? ?? null,
                            BSEF01_PBAC19 = reader["BSEF01_PBAC19"] as Single? ?? null,
                            BSEF05_PBAC19 = reader["BSEF05_PBAC19"] as Single? ?? null
                        };
                    }
                }
            }

            return MSPCSTATS;
        }

        public MSPCALARS ReadDataFromMSPCALARS()
        {
            MSPCALARS MSPCALARS = null;

            string sql = @"
SELECT TOP 1 AUTOID,DATETIME
    ,ASEF11_PAAC01,ASEF14_PAAC01,ASEF10_PAAC02,ASEF11_PAAC02,ASEF14_PAAC02,ASEF15_PAAC02,ASEF11_PAAC03,ASEF14_PAAC03,ASEF11_PAAC04
    ,ASEF12_PAAC04,ASEF13_PAAC04,ASEF11_PAAC05,ASEF12_PAAC05,ASEF11_PAAC06,ASEF12_PAAC06,ASEF11_PAAC07,ASEF12_PAAC07,ASEF13_PAAC08
    ,ASEF09_PAAC09,ASEF11_PAAC09,ASEF13_PAAC09,ASEF09_PAAC10,ASEF11_PAAC10,ASEF13_PAAC10,ASEF09_PAAC11,ASEF11_PAAC11,ASEF13_PAAC11
    ,ASEF09_PAAC12,ASEF11_PAAC12,ASEF13_PAAC12,ASEF09_PAAC13,ASEF11_PAAC13,ASEF13_PAAC13,ASEF11_PAAC14,ASEF12_PAAC14,ASEF14_PAAC14
    ,ASEF15_PAAC14,ASEF11_PAAC15,ASEF12_PAAC15,ASEF11_PAAC16,ASEF12_PAAC16,ASEF13_PAAC16,ASEF16_PBAC16,ASEF17_PBAC16,ASEF14_PAAC16
    ,ASEF15_PAAC16,ASEF11_PAAC17,ASEF12_PAAC17,ASEF13_PAAC17,ASEF11_PAAC18,ASEF13_PAAC18,ASEF14_PAAC18,ASEF15_PAAC18,ASEF11_PAAC19
    ,ASEF13_PAAC19,ASEF11_PAAC20,ASEF11_PAAC21,ASEF14_PAAC21,ASEF15_PAAC21,ASEF11_PAAC22,ASEF14_PAAC22,ASEF15_PAAC22,ASEF11_PAAC23
    ,ASEF11_PAAC24,ASEF14_PAAC24,ASEF15_PAAC24,ASEF10_PAAC25,ASEF11_PAAC25,ASEF14_PAAC25,ASEF10_PAAC26,ASEF10_PAAC27,ASEF11_PAAC27
    ,ASEF14_PAAC27,ASEF15_PAAC27,ASEF11_PAAC29,ASEF14_PAAC29,ASEF15_PAAC29,ASEF11_PAAC30,ASEF14_PAAC30,ASEF15_PAAC30,ASEF11_PAAC31
    ,ASEF14_PAAC31,ASEF15_PAAC31,ASEF11_PAAC32,ASEF14_PAAC32,ASEF15_PAAC32,ASEF11_PAAC33,ASEF14_PAAC33,ASEF15_PAAC33,ASEF11_PAAC34
    ,ASEF11_PAAC35,ASEF11_PAAC36,ASEF11_PAAC37,ASEF11_PAAC38,ASEF11_PAAC39,ASEF11_PAAC40,ASEF11_PAAC41,ASEF11_PAAC42,ASEF11_PAAC43
    ,ASEF11_PAAC44,ASEF11_PAAC45,ASEF12_PAAC45,ASEF13_PAAC45,ASEF11_PAAC46,ASEF12_PAAC46,ASEF11_PAAC47,ASEF10_PAAC48,ASEF11_PAAC48
    ,ASEF10_PAAC49,ASEF11_PAAC49,ASEF10_PAAC50,ASEF11_PAAC50,BSEF11_PBAC01,BSEF11_PBAC02,BSEF11_PBAC03,BSEF11_PBAC04,BSEF11_PBAC05
    ,BSEF11_PBAC06,BSEF11_PBAC07,BSEF11_PBAC08,BSEF11_PBAC09,BSEF11_PBAC10,BSEF11_PBAC11,BSEF11_PBAC12,BSEF11_PBAC13,BSEF11_PBAC14
    ,BSEF11_PBAC15,BSEF11_PBAC16,BSEF11_PBAC17,BSEF14_PBAC17,BSEF11_PBAC18,BSEF14_PBAC18,BSEF11_PBAC19	
    FROM MSPCALARS
    ORDER BY AUTOID DESC
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                using (IDataReader reader = this.Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        MSPCALARS = new MSPCALARS()
                        {
                            AUTOID = (int)reader["AUTOID"],
                            DATETIME = reader["DATETIME"] as DateTime? ?? null,
                            ASEF11_PAAC01 = reader["ASEF11_PAAC01"] as Single? ?? null,
                            ASEF14_PAAC01 = reader["ASEF14_PAAC01"] as Single? ?? null,
                            ASEF10_PAAC02 = reader["ASEF10_PAAC02"] as Single? ?? null,
                            ASEF11_PAAC02 = reader["ASEF11_PAAC02"] as Single? ?? null,
                            ASEF14_PAAC02 = reader["ASEF14_PAAC02"] as Single? ?? null,
                            ASEF15_PAAC02 = reader["ASEF15_PAAC02"] as Single? ?? null,
                            ASEF11_PAAC03 = reader["ASEF11_PAAC03"] as Single? ?? null,
                            ASEF14_PAAC03 = reader["ASEF14_PAAC03"] as Single? ?? null,
                            ASEF11_PAAC04 = reader["ASEF11_PAAC04"] as Single? ?? null,
                            ASEF12_PAAC04 = reader["ASEF12_PAAC04"] as Single? ?? null,
                            ASEF13_PAAC04 = reader["ASEF13_PAAC04"] as Single? ?? null,
                            ASEF11_PAAC05 = reader["ASEF11_PAAC05"] as Single? ?? null,
                            ASEF12_PAAC05 = reader["ASEF12_PAAC05"] as Single? ?? null,
                            ASEF11_PAAC06 = reader["ASEF11_PAAC06"] as Single? ?? null,
                            ASEF12_PAAC06 = reader["ASEF12_PAAC06"] as Single? ?? null,
                            ASEF11_PAAC07 = reader["ASEF11_PAAC07"] as Single? ?? null,
                            ASEF12_PAAC07 = reader["ASEF12_PAAC07"] as Single? ?? null,
                            ASEF13_PAAC08 = reader["ASEF13_PAAC08"] as Single? ?? null,
                            ASEF09_PAAC09 = reader["ASEF09_PAAC09"] as Single? ?? null,
                            ASEF11_PAAC09 = reader["ASEF11_PAAC09"] as Single? ?? null,
                            ASEF13_PAAC09 = reader["ASEF13_PAAC09"] as Single? ?? null,
                            ASEF09_PAAC10 = reader["ASEF09_PAAC10"] as Single? ?? null,
                            ASEF11_PAAC10 = reader["ASEF11_PAAC10"] as Single? ?? null,
                            ASEF13_PAAC10 = reader["ASEF13_PAAC10"] as Single? ?? null,
                            ASEF09_PAAC11 = reader["ASEF09_PAAC11"] as Single? ?? null,
                            ASEF11_PAAC11 = reader["ASEF11_PAAC11"] as Single? ?? null,
                            ASEF13_PAAC11 = reader["ASEF13_PAAC11"] as Single? ?? null,
                            ASEF09_PAAC12 = reader["ASEF09_PAAC12"] as Single? ?? null,
                            ASEF11_PAAC12 = reader["ASEF11_PAAC12"] as Single? ?? null,
                            ASEF13_PAAC12 = reader["ASEF13_PAAC12"] as Single? ?? null,
                            ASEF09_PAAC13 = reader["ASEF09_PAAC13"] as Single? ?? null,
                            ASEF11_PAAC13 = reader["ASEF11_PAAC13"] as Single? ?? null,
                            ASEF13_PAAC13 = reader["ASEF13_PAAC13"] as Single? ?? null,
                            ASEF11_PAAC14 = reader["ASEF11_PAAC14"] as Single? ?? null,
                            ASEF12_PAAC14 = reader["ASEF12_PAAC14"] as Single? ?? null,
                            ASEF14_PAAC14 = reader["ASEF14_PAAC14"] as Single? ?? null,
                            ASEF15_PAAC14 = reader["ASEF15_PAAC14"] as Single? ?? null,
                            ASEF11_PAAC15 = reader["ASEF11_PAAC15"] as Single? ?? null,
                            ASEF12_PAAC15 = reader["ASEF12_PAAC15"] as Single? ?? null,
                            ASEF11_PAAC16 = reader["ASEF11_PAAC16"] as Single? ?? null,
                            ASEF12_PAAC16 = reader["ASEF12_PAAC16"] as Single? ?? null,
                            ASEF13_PAAC16 = reader["ASEF13_PAAC16"] as Single? ?? null,
                            ASEF16_PBAC16 = reader["ASEF16_PBAC16"] as Single? ?? null,//有資料來源, 資料定義不明
                            ASEF17_PBAC16 = reader["ASEF17_PBAC16"] as Single? ?? null,//有資料來源, 資料定義不明
                            ASEF14_PAAC16 = reader["ASEF14_PAAC16"] as Single? ?? null,
                            ASEF15_PAAC16 = reader["ASEF15_PAAC16"] as Single? ?? null,
                            ASEF11_PAAC17 = reader["ASEF11_PAAC17"] as Single? ?? null,
                            ASEF12_PAAC17 = reader["ASEF12_PAAC17"] as Single? ?? null,
                            ASEF13_PAAC17 = reader["ASEF13_PAAC17"] as Single? ?? null,
                            ASEF11_PAAC18 = reader["ASEF11_PAAC18"] as Single? ?? null,
                            ASEF13_PAAC18 = reader["ASEF13_PAAC18"] as Single? ?? null,
                            ASEF14_PAAC18 = reader["ASEF14_PAAC18"] as Single? ?? null,
                            ASEF15_PAAC18 = reader["ASEF15_PAAC18"] as Single? ?? null,
                            ASEF11_PAAC19 = reader["ASEF11_PAAC19"] as Single? ?? null,
                            ASEF13_PAAC19 = reader["ASEF13_PAAC19"] as Single? ?? null,
                            ASEF11_PAAC20 = reader["ASEF11_PAAC20"] as Single? ?? null,
                            ASEF11_PAAC21 = reader["ASEF11_PAAC21"] as Single? ?? null,
                            ASEF14_PAAC21 = reader["ASEF14_PAAC21"] as Single? ?? null,
                            ASEF15_PAAC21 = reader["ASEF15_PAAC21"] as Single? ?? null,
                            ASEF11_PAAC22 = reader["ASEF11_PAAC22"] as Single? ?? null,
                            ASEF14_PAAC22 = reader["ASEF14_PAAC22"] as Single? ?? null,
                            ASEF15_PAAC22 = reader["ASEF15_PAAC22"] as Single? ?? null,
                            ASEF11_PAAC23 = reader["ASEF11_PAAC23"] as Single? ?? null,
                            ASEF11_PAAC24 = reader["ASEF11_PAAC24"] as Single? ?? null,
                            ASEF14_PAAC24 = reader["ASEF14_PAAC24"] as Single? ?? null,
                            ASEF15_PAAC24 = reader["ASEF15_PAAC24"] as Single? ?? null,
                            ASEF10_PAAC25 = reader["ASEF10_PAAC25"] as Single? ?? null,
                            ASEF11_PAAC25 = reader["ASEF11_PAAC25"] as Single? ?? null,
                            ASEF14_PAAC25 = reader["ASEF14_PAAC25"] as Single? ?? null,
                            ASEF10_PAAC26 = reader["ASEF10_PAAC26"] as Single? ?? null,
                            ASEF10_PAAC27 = reader["ASEF10_PAAC27"] as Single? ?? null,
                            ASEF11_PAAC27 = reader["ASEF11_PAAC27"] as Single? ?? null,
                            ASEF14_PAAC27 = reader["ASEF14_PAAC27"] as Single? ?? null,
                            ASEF15_PAAC27 = reader["ASEF15_PAAC27"] as Single? ?? null,
                            ASEF11_PAAC29 = reader["ASEF11_PAAC29"] as Single? ?? null,
                            ASEF14_PAAC29 = reader["ASEF14_PAAC29"] as Single? ?? null,
                            ASEF15_PAAC29 = reader["ASEF15_PAAC29"] as Single? ?? null,
                            ASEF11_PAAC30 = reader["ASEF11_PAAC30"] as Single? ?? null,
                            ASEF14_PAAC30 = reader["ASEF14_PAAC30"] as Single? ?? null,
                            ASEF15_PAAC30 = reader["ASEF15_PAAC30"] as Single? ?? null,
                            ASEF11_PAAC31 = reader["ASEF11_PAAC31"] as Single? ?? null,
                            ASEF14_PAAC31 = reader["ASEF14_PAAC31"] as Single? ?? null,
                            ASEF15_PAAC31 = reader["ASEF15_PAAC31"] as Single? ?? null,
                            ASEF11_PAAC32 = reader["ASEF11_PAAC32"] as Single? ?? null,
                            ASEF14_PAAC32 = reader["ASEF14_PAAC32"] as Single? ?? null,
                            ASEF15_PAAC32 = reader["ASEF15_PAAC32"] as Single? ?? null,
                            ASEF11_PAAC33 = reader["ASEF11_PAAC33"] as Single? ?? null,
                            ASEF14_PAAC33 = reader["ASEF14_PAAC33"] as Single? ?? null,
                            ASEF15_PAAC33 = reader["ASEF15_PAAC33"] as Single? ?? null,
                            ASEF11_PAAC34 = reader["ASEF11_PAAC34"] as Single? ?? null,
                            ASEF11_PAAC35 = reader["ASEF11_PAAC35"] as Single? ?? null,
                            ASEF11_PAAC36 = reader["ASEF11_PAAC36"] as Single? ?? null,
                            ASEF11_PAAC37 = reader["ASEF11_PAAC37"] as Single? ?? null,
                            ASEF11_PAAC38 = reader["ASEF11_PAAC38"] as Single? ?? null,
                            ASEF11_PAAC39 = reader["ASEF11_PAAC39"] as Single? ?? null,
                            ASEF11_PAAC40 = reader["ASEF11_PAAC40"] as Single? ?? null,
                            ASEF11_PAAC41 = reader["ASEF11_PAAC41"] as Single? ?? null,
                            ASEF11_PAAC42 = reader["ASEF11_PAAC42"] as Single? ?? null,
                            ASEF11_PAAC43 = reader["ASEF11_PAAC43"] as Single? ?? null,
                            ASEF11_PAAC44 = reader["ASEF11_PAAC44"] as Single? ?? null,
                            ASEF11_PAAC45 = reader["ASEF11_PAAC45"] as Single? ?? null,
                            ASEF12_PAAC45 = reader["ASEF12_PAAC45"] as Single? ?? null,
                            ASEF13_PAAC45 = reader["ASEF13_PAAC45"] as Single? ?? null,
                            ASEF11_PAAC46 = reader["ASEF11_PAAC46"] as Single? ?? null,
                            ASEF12_PAAC46 = reader["ASEF12_PAAC46"] as Single? ?? null,
                            ASEF11_PAAC47 = reader["ASEF11_PAAC47"] as Single? ?? null,
                            ASEF10_PAAC48 = reader["ASEF10_PAAC48"] as Single? ?? null,
                            ASEF11_PAAC48 = reader["ASEF11_PAAC48"] as Single? ?? null,
                            ASEF10_PAAC49 = reader["ASEF10_PAAC49"] as Single? ?? null,
                            ASEF11_PAAC49 = reader["ASEF11_PAAC49"] as Single? ?? null,
                            ASEF10_PAAC50 = reader["ASEF10_PAAC50"] as Single? ?? null,
                            ASEF11_PAAC50 = reader["ASEF11_PAAC50"] as Single? ?? null,
                            BSEF11_PBAC01 = reader["BSEF11_PBAC01"] as Single? ?? null,
                            BSEF11_PBAC02 = reader["BSEF11_PBAC02"] as Single? ?? null,
                            BSEF11_PBAC03 = reader["BSEF11_PBAC03"] as Single? ?? null,
                            BSEF11_PBAC04 = reader["BSEF11_PBAC04"] as Single? ?? null,
                            BSEF11_PBAC05 = reader["BSEF11_PBAC05"] as Single? ?? null,
                            BSEF11_PBAC06 = reader["BSEF11_PBAC06"] as Single? ?? null,
                            BSEF11_PBAC07 = reader["BSEF11_PBAC07"] as Single? ?? null,
                            BSEF11_PBAC08 = reader["BSEF11_PBAC08"] as Single? ?? null,
                            BSEF11_PBAC09 = reader["BSEF11_PBAC09"] as Single? ?? null,
                            BSEF11_PBAC10 = reader["BSEF11_PBAC10"] as Single? ?? null,
                            BSEF11_PBAC11 = reader["BSEF11_PBAC11"] as Single? ?? null,
                            BSEF11_PBAC12 = reader["BSEF11_PBAC12"] as Single? ?? null,
                            BSEF11_PBAC13 = reader["BSEF11_PBAC13"] as Single? ?? null,//有資料來源, 沒資料定義
                            BSEF11_PBAC14 = reader["BSEF11_PBAC14"] as Single? ?? null,
                            BSEF11_PBAC15 = reader["BSEF11_PBAC15"] as Single? ?? null,
                            BSEF11_PBAC16 = reader["BSEF11_PBAC16"] as Single? ?? null,
                            BSEF11_PBAC17 = reader["BSEF11_PBAC17"] as Single? ?? null,
                            BSEF14_PBAC17 = reader["BSEF14_PBAC17"] as Single? ?? null,
                            BSEF11_PBAC18 = reader["BSEF11_PBAC18"] as Single? ?? null,
                            BSEF14_PBAC18 = reader["BSEF14_PBAC18"] as Single? ?? null,
                            BSEF11_PBAC19 = reader["BSEF11_PBAC19"] as Single? ?? null
                        };
                    }
                }
            }

            return MSPCALARS;
        }

        public MSPCAI ReadDataFromMSPCAI()
        {
            MSPCAI MSPCAI = null;

            string sql = @"
SELECT TOP 1 AUTOID,DATETIME
    ,ASEF16_PAAC01,ASEF16_PAAC02,ASEF17_PAAC02,ASEF16_PAAC03,ASEF16_PAAC04,ASEF17_PAAC04,ASEF16_PAAC06,ASEF17_PAAC06,ASEF16_PAAC14
    ,ASEF17_PAAC14,ASEF16_PAAC16,ASEF17_PAAC16,ASEF16_PAAC18,ASEF16_PAAC19,ASEF17_PAAC19,ASEF16_PAAC21,ASEF17_PAAC21,ASEF16_PAAC22
    ,ASEF17_PAAC22,ASEF16_PAAC24,ASEF17_PAAC24,ASEF16_PAAC25,ASEF16_PAAC27,ASEF17_PAAC27,ASEF16_PAAC28,ASEF18_PAAC28,ASEF16_PAAC29
    ,ASEF17_PAAC29,ASEF16_PAAC30,ASEF17_PAAC30,ASEF16_PAAC31,ASEF17_PAAC31,ASEF16_PAAC32,ASEF17_PAAC32,ASEF16_PAAC33,ASEF17_PAAC33
    ,ASEF16_PAAC45,ASEF17_PAAC45,ASEF16_PAAC46,ASEF17_PAAC46,ASEF16_PAAC48,ASEF17_PAAC48,BSEF16_PBAC16,BSEF17_PBAC16,BSEF16_PBAC18
    ,BSEF17_PBAC18
    FROM MSPCAI
    ORDER BY AUTOID DESC
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                //Db.AddInParameter(cmd, "ID", DbType.String, UserId);
                using (IDataReader reader = this.Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        MSPCAI = new MSPCAI()
                        {
                            AUTOID = (int)reader["AUTOID"],
                            DATETIME = reader["DATETIME"] as DateTime? ?? null,
                            ASEF16_PAAC01 = reader["ASEF16_PAAC01"] as Single? ?? null,
                            ASEF16_PAAC02 = reader["ASEF16_PAAC02"] as Single? ?? null,
                            ASEF17_PAAC02 = reader["ASEF17_PAAC02"] as Single? ?? null,
                            ASEF16_PAAC03 = reader["ASEF16_PAAC03"] as Single? ?? null,
                            ASEF16_PAAC04 = reader["ASEF16_PAAC04"] as Single? ?? null,
                            ASEF17_PAAC04 = reader["ASEF17_PAAC04"] as Single? ?? null,
                            ASEF16_PAAC06 = reader["ASEF16_PAAC06"] as Single? ?? null,
                            ASEF17_PAAC06 = reader["ASEF17_PAAC06"] as Single? ?? null,
                            ASEF16_PAAC14 = reader["ASEF16_PAAC14"] as Single? ?? null,
                            ASEF17_PAAC14 = reader["ASEF17_PAAC14"] as Single? ?? null,
                            ASEF16_PAAC16 = reader["ASEF16_PAAC16"] as Single? ?? null,
                            ASEF17_PAAC16 = reader["ASEF17_PAAC16"] as Single? ?? null,
                            ASEF16_PAAC18 = reader["ASEF16_PAAC18"] as Single? ?? null,
                            ASEF16_PAAC19 = reader["ASEF16_PAAC19"] as Single? ?? null,
                            ASEF17_PAAC19 = reader["ASEF17_PAAC19"] as Single? ?? null,
                            ASEF16_PAAC21 = reader["ASEF16_PAAC21"] as Single? ?? null,
                            ASEF17_PAAC21 = reader["ASEF17_PAAC21"] as Single? ?? null,
                            ASEF16_PAAC22 = reader["ASEF16_PAAC22"] as Single? ?? null,
                            ASEF17_PAAC22 = reader["ASEF17_PAAC22"] as Single? ?? null,
                            ASEF16_PAAC24 = reader["ASEF16_PAAC24"] as Single? ?? null,
                            ASEF17_PAAC24 = reader["ASEF17_PAAC24"] as Single? ?? null,
                            ASEF16_PAAC25 = reader["ASEF16_PAAC25"] as Single? ?? null,
                            ASEF16_PAAC27 = reader["ASEF16_PAAC27"] as Single? ?? null,
                            ASEF17_PAAC27 = reader["ASEF17_PAAC27"] as Single? ?? null,
                            ASEF16_PAAC28 = reader["ASEF16_PAAC28"] as Single? ?? null,
                            ASEF18_PAAC28 = reader["ASEF18_PAAC28"] as Single? ?? null,
                            ASEF16_PAAC29 = reader["ASEF16_PAAC29"] as Single? ?? null,
                            ASEF17_PAAC29 = reader["ASEF17_PAAC29"] as Single? ?? null,
                            ASEF16_PAAC30 = reader["ASEF16_PAAC30"] as Single? ?? null,
                            ASEF17_PAAC30 = reader["ASEF17_PAAC30"] as Single? ?? null,
                            ASEF16_PAAC31 = reader["ASEF16_PAAC31"] as Single? ?? null,
                            ASEF17_PAAC31 = reader["ASEF17_PAAC31"] as Single? ?? null,
                            ASEF16_PAAC32 = reader["ASEF16_PAAC32"] as Single? ?? null,
                            ASEF17_PAAC32 = reader["ASEF17_PAAC32"] as Single? ?? null,
                            ASEF16_PAAC33 = reader["ASEF16_PAAC33"] as Single? ?? null,
                            ASEF17_PAAC33 = reader["ASEF17_PAAC33"] as Single? ?? null,
                            ASEF16_PAAC45 = reader["ASEF16_PAAC45"] as Single? ?? null,
                            ASEF17_PAAC45 = reader["ASEF17_PAAC45"] as Single? ?? null,
                            ASEF16_PAAC46 = reader["ASEF16_PAAC46"] as Single? ?? null,
                            ASEF17_PAAC46 = reader["ASEF17_PAAC46"] as Single? ?? null,
                            ASEF16_PAAC48 = reader["ASEF16_PAAC48"] as Single? ?? null,
                            ASEF17_PAAC48 = reader["ASEF17_PAAC48"] as Single? ?? null,
                            BSEF16_PBAC16 = reader["BSEF16_PBAC16"] as Single? ?? null,
                            BSEF17_PBAC16 = reader["BSEF17_PBAC16"] as Single? ?? null,
                            BSEF16_PBAC18 = reader["BSEF16_PBAC18"] as Single? ?? null,
                            BSEF17_PBAC18 = reader["BSEF17_PBAC18"] as Single? ?? null
                        };
                    }
                }
            }

            return MSPCAI;
        }

    }
}

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
    }
}

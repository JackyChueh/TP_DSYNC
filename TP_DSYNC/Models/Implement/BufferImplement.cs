using System;
using TP_DSYNC.Models.DataAccess;
using TP_DSYNC.Models.DataDefine.B3;
using System.Data;
using System.Data.Common;
using System.Transactions;

namespace TP_DSYNC.Models.Implement
{
    public class BufferImplement : DatabaseAccess
    {
        public BufferImplement(string connectionStringName) : base(connectionStringName) { }

        public bool WriteBufferForAHU_004F(AHU_004F AHU_004F)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM AHU_04F WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO AHU_04F (AUTOID, DATETIME, ACTIVE
            ,AHU01_004F01,AHU02_004F01,AHU03_004F01,AHU04_004F01,AHU05_004F01,AHU06_004F01,AHU07_004F01,AHU08_004F01,AHU09_004F01,AHU10_004F01,AHU11_004F01
            ,AHU01_004F02,AHU02_004F02,AHU03_004F02,AHU04_004F02,AHU05_004F02,AHU06_004F02,AHU07_004F02,AHU08_004F02,AHU09_004F02,AHU10_004F02,AHU11_004F02
            ,AHU01_004F03,AHU02_004F03,AHU03_004F03,AHU04_004F03,AHU05_004F03,AHU06_004F03,AHU07_004F03,AHU08_004F03,AHU09_004F03,AHU10_004F03,AHU11_004F03
            ,AHU01_004F04,AHU02_004F04,AHU03_004F04,AHU04_004F04,AHU05_004F04,AHU06_004F04,AHU07_004F04,AHU08_004F04,AHU09_004F04,AHU10_004F04,AHU11_004F04)
        VALUES (@AUTOID,@DATETIME, @ACTIVE
            ,@AHU01_004F01,@AHU02_004F01,@AHU03_004F01,@AHU04_004F01,@AHU05_004F01,@AHU06_004F01,@AHU07_004F01,@AHU08_004F01,@AHU09_004F01,@AHU10_004F01,@AHU11_004F01
            ,@AHU01_004F02,@AHU02_004F02,@AHU03_004F02,@AHU04_004F02,@AHU05_004F02,@AHU06_004F02,@AHU07_004F02,@AHU08_004F02,@AHU09_004F02,@AHU10_004F02,@AHU11_004F02
            ,@AHU01_004F03,@AHU02_004F03,@AHU03_004F03,@AHU04_004F03,@AHU05_004F03,@AHU06_004F03,@AHU07_004F03,@AHU08_004F03,@AHU09_004F03,@AHU10_004F03,@AHU11_004F03
            ,@AHU01_004F04,@AHU02_004F04,@AHU03_004F04,@AHU04_004F04,@AHU05_004F04,@AHU06_004F04,@AHU07_004F04,@AHU08_004F04,@AHU09_004F04,@AHU10_004F04,@AHU11_004F04)
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_004F.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, AHU_004F.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "AHU01_004F01", DbType.Single, AHU_004F.AHU01_004F01);
                        Db.AddInParameter(cmd, "AHU02_004F01", DbType.Single, AHU_004F.AHU02_004F01);
                        Db.AddInParameter(cmd, "AHU03_004F01", DbType.Single, AHU_004F.AHU03_004F01);
                        Db.AddInParameter(cmd, "AHU04_004F01", DbType.Single, AHU_004F.AHU04_004F01);
                        Db.AddInParameter(cmd, "AHU05_004F01", DbType.Single, AHU_004F.AHU05_004F01);
                        Db.AddInParameter(cmd, "AHU06_004F01", DbType.Single, AHU_004F.AHU06_004F01);
                        Db.AddInParameter(cmd, "AHU07_004F01", DbType.Single, AHU_004F.AHU07_004F01);
                        Db.AddInParameter(cmd, "AHU08_004F01", DbType.Single, AHU_004F.AHU08_004F01);
                        Db.AddInParameter(cmd, "AHU09_004F01", DbType.Single, AHU_004F.AHU09_004F01);
                        Db.AddInParameter(cmd, "AHU10_004F01", DbType.Single, AHU_004F.AHU10_004F01);
                        Db.AddInParameter(cmd, "AHU11_004F01", DbType.Single, AHU_004F.AHU11_004F01);
                        Db.AddInParameter(cmd, "AHU01_004F02", DbType.Single, AHU_004F.AHU01_004F02);
                        Db.AddInParameter(cmd, "AHU02_004F02", DbType.Single, AHU_004F.AHU02_004F02);
                        Db.AddInParameter(cmd, "AHU03_004F02", DbType.Single, AHU_004F.AHU03_004F02);
                        Db.AddInParameter(cmd, "AHU04_004F02", DbType.Single, AHU_004F.AHU04_004F02);
                        Db.AddInParameter(cmd, "AHU05_004F02", DbType.Single, AHU_004F.AHU05_004F02);
                        Db.AddInParameter(cmd, "AHU06_004F02", DbType.Single, AHU_004F.AHU06_004F02);
                        Db.AddInParameter(cmd, "AHU07_004F02", DbType.Single, AHU_004F.AHU07_004F02);
                        Db.AddInParameter(cmd, "AHU08_004F02", DbType.Single, AHU_004F.AHU08_004F02);
                        Db.AddInParameter(cmd, "AHU09_004F02", DbType.Single, AHU_004F.AHU09_004F02);
                        Db.AddInParameter(cmd, "AHU10_004F02", DbType.Single, AHU_004F.AHU10_004F02);
                        Db.AddInParameter(cmd, "AHU11_004F02", DbType.Single, AHU_004F.AHU11_004F02);
                        Db.AddInParameter(cmd, "AHU01_004F03", DbType.Single, AHU_004F.AHU01_004F03);
                        Db.AddInParameter(cmd, "AHU02_004F03", DbType.Single, AHU_004F.AHU02_004F03);
                        Db.AddInParameter(cmd, "AHU03_004F03", DbType.Single, AHU_004F.AHU03_004F03);
                        Db.AddInParameter(cmd, "AHU04_004F03", DbType.Single, AHU_004F.AHU04_004F03);
                        Db.AddInParameter(cmd, "AHU05_004F03", DbType.Single, AHU_004F.AHU05_004F03);
                        Db.AddInParameter(cmd, "AHU06_004F03", DbType.Single, AHU_004F.AHU06_004F03);
                        Db.AddInParameter(cmd, "AHU07_004F03", DbType.Single, AHU_004F.AHU07_004F03);
                        Db.AddInParameter(cmd, "AHU08_004F03", DbType.Single, AHU_004F.AHU08_004F03);
                        Db.AddInParameter(cmd, "AHU09_004F03", DbType.Single, AHU_004F.AHU09_004F03);
                        Db.AddInParameter(cmd, "AHU10_004F03", DbType.Single, AHU_004F.AHU10_004F03);
                        Db.AddInParameter(cmd, "AHU11_004F03", DbType.Single, AHU_004F.AHU11_004F03);
                        Db.AddInParameter(cmd, "AHU01_004F04", DbType.Single, AHU_004F.AHU01_004F04);
                        Db.AddInParameter(cmd, "AHU02_004F04", DbType.Single, AHU_004F.AHU02_004F04);
                        Db.AddInParameter(cmd, "AHU03_004F04", DbType.Single, AHU_004F.AHU03_004F04);
                        Db.AddInParameter(cmd, "AHU04_004F04", DbType.Single, AHU_004F.AHU04_004F04);
                        Db.AddInParameter(cmd, "AHU05_004F04", DbType.Single, AHU_004F.AHU05_004F04);
                        Db.AddInParameter(cmd, "AHU06_004F04", DbType.Single, AHU_004F.AHU06_004F04);
                        Db.AddInParameter(cmd, "AHU07_004F04", DbType.Single, AHU_004F.AHU07_004F04);
                        Db.AddInParameter(cmd, "AHU08_004F04", DbType.Single, AHU_004F.AHU08_004F04);
                        Db.AddInParameter(cmd, "AHU09_004F04", DbType.Single, AHU_004F.AHU09_004F04);
                        Db.AddInParameter(cmd, "AHU10_004F04", DbType.Single, AHU_004F.AHU10_004F04);
                        Db.AddInParameter(cmd, "AHU11_004F04", DbType.Single, AHU_004F.AHU11_004F04);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForAHU_0B1F(AHU_0B1F AHU_0B1F)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM AHU_0B1 WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO AHU_0B1 (AUTOID, DATETIME, ACTIVE
            ,AHU01_0B1F01,AHU02_0B1F01,AHU03_0B1F01,AHU04_0B1F01,AHU05_0B1F01,AHU06_0B1F01,AHU07_0B1F01,AHU08_0B1F01,AHU09_0B1F01,AHU10_0B1F01,AHU11_0B1F01
            ,AHU01_0B1F02,AHU02_0B1F02,AHU03_0B1F02,AHU04_0B1F02,AHU05_0B1F02,AHU06_0B1F02,AHU07_0B1F02,AHU08_0B1F02,AHU09_0B1F02,AHU10_0B1F02,AHU11_0B1F02
            ,AHU01_0B1F03,AHU02_0B1F03,AHU03_0B1F03,AHU04_0B1F03,AHU05_0B1F03,AHU06_0B1F03,AHU07_0B1F03,AHU08_0B1F03,AHU09_0B1F03,AHU10_0B1F03,AHU11_0B1F03
            ,AHU01_0B1F04,AHU02_0B1F04,AHU03_0B1F04,AHU04_0B1F04,AHU05_0B1F04,AHU06_0B1F04,AHU07_0B1F04,AHU08_0B1F04,AHU09_0B1F04,AHU10_0B1F04,AHU11_0B1F04
            ,AHU01_0B1F05,AHU02_0B1F05,AHU03_0B1F05,AHU04_0B1F05,AHU05_0B1F05,AHU06_0B1F05,AHU07_0B1F05,AHU08_0B1F05,AHU09_0B1F05,AHU10_0B1F05,AHU11_0B1F05
            ,AHU01_0B1F06,AHU02_0B1F06,AHU03_0B1F06,AHU04_0B1F06,AHU05_0B1F06,AHU06_0B1F06,AHU07_0B1F06,AHU08_0B1F06,AHU09_0B1F06,AHU10_0B1F06,AHU11_0B1F06
            ,AHU01_0B1F07,AHU02_0B1F07,AHU03_0B1F07,AHU04_0B1F07,AHU05_0B1F07,AHU06_0B1F07,AHU07_0B1F07,AHU08_0B1F07,AHU09_0B1F07,AHU10_0B1F07,AHU11_0B1F07
            ,AHU01_0B1F08,AHU02_0B1F08,AHU03_0B1F08,AHU04_0B1F08,AHU05_0B1F08,AHU06_0B1F08,AHU07_0B1F08,AHU08_0B1F08,AHU09_0B1F08,AHU10_0B1F08,AHU11_0B1F08)
        VALUES (@AUTOID,@DATETIME, @ACTIVE
            ,@AHU01_0B1F01,@AHU02_0B1F01,@AHU03_0B1F01,@AHU04_0B1F01,@AHU05_0B1F01,@AHU06_0B1F01,@AHU07_0B1F01,@AHU08_0B1F01,@AHU09_0B1F01,@AHU10_0B1F01,@AHU11_0B1F01
            ,@AHU01_0B1F02,@AHU02_0B1F02,@AHU03_0B1F02,@AHU04_0B1F02,@AHU05_0B1F02,@AHU06_0B1F02,@AHU07_0B1F02,@AHU08_0B1F02,@AHU09_0B1F02,@AHU10_0B1F02,@AHU11_0B1F02
            ,@AHU01_0B1F03,@AHU02_0B1F03,@AHU03_0B1F03,@AHU04_0B1F03,@AHU05_0B1F03,@AHU06_0B1F03,@AHU07_0B1F03,@AHU08_0B1F03,@AHU09_0B1F03,@AHU10_0B1F03,@AHU11_0B1F03
            ,@AHU01_0B1F04,@AHU02_0B1F04,@AHU03_0B1F04,@AHU04_0B1F04,@AHU05_0B1F04,@AHU06_0B1F04,@AHU07_0B1F04,@AHU08_0B1F04,@AHU09_0B1F04,@AHU10_0B1F04,@AHU11_0B1F04
            ,@AHU01_0B1F05,@AHU02_0B1F05,@AHU03_0B1F05,@AHU04_0B1F05,@AHU05_0B1F05,@AHU06_0B1F05,@AHU07_0B1F05,@AHU08_0B1F05,@AHU09_0B1F05,@AHU10_0B1F05,@AHU11_0B1F05
            ,@AHU01_0B1F06,@AHU02_0B1F06,@AHU03_0B1F06,@AHU04_0B1F06,@AHU05_0B1F06,@AHU06_0B1F06,@AHU07_0B1F06,@AHU08_0B1F06,@AHU09_0B1F06,@AHU10_0B1F06,@AHU11_0B1F06
            ,@AHU01_0B1F07,@AHU02_0B1F07,@AHU03_0B1F07,@AHU04_0B1F07,@AHU05_0B1F07,@AHU06_0B1F07,@AHU07_0B1F07,@AHU08_0B1F07,@AHU09_0B1F07,@AHU10_0B1F07,@AHU11_0B1F07
            ,@AHU01_0B1F08,@AHU02_0B1F08,@AHU03_0B1F08,@AHU04_0B1F08,@AHU05_0B1F08,@AHU06_0B1F08,@AHU07_0B1F08,@AHU08_0B1F08,@AHU09_0B1F08,@AHU10_0B1F08,@AHU11_0B1F08)
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_0B1F.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, AHU_0B1F.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "AHU01_0B1F01", DbType.Single, AHU_0B1F.AHU01_0B1F01);
                        Db.AddInParameter(cmd, "AHU02_0B1F01", DbType.Single, AHU_0B1F.AHU02_0B1F01);
                        Db.AddInParameter(cmd, "AHU03_0B1F01", DbType.Single, AHU_0B1F.AHU03_0B1F01);
                        Db.AddInParameter(cmd, "AHU04_0B1F01", DbType.Single, AHU_0B1F.AHU04_0B1F01);
                        Db.AddInParameter(cmd, "AHU05_0B1F01", DbType.Single, AHU_0B1F.AHU05_0B1F01);
                        Db.AddInParameter(cmd, "AHU06_0B1F01", DbType.Single, AHU_0B1F.AHU06_0B1F01);
                        Db.AddInParameter(cmd, "AHU07_0B1F01", DbType.Single, AHU_0B1F.AHU07_0B1F01);
                        Db.AddInParameter(cmd, "AHU08_0B1F01", DbType.Single, AHU_0B1F.AHU08_0B1F01);
                        Db.AddInParameter(cmd, "AHU09_0B1F01", DbType.Single, AHU_0B1F.AHU09_0B1F01);
                        Db.AddInParameter(cmd, "AHU10_0B1F01", DbType.Single, AHU_0B1F.AHU10_0B1F01);
                        Db.AddInParameter(cmd, "AHU11_0B1F01", DbType.Single, AHU_0B1F.AHU11_0B1F01);
                        Db.AddInParameter(cmd, "AHU01_0B1F02", DbType.Single, AHU_0B1F.AHU01_0B1F02);
                        Db.AddInParameter(cmd, "AHU02_0B1F02", DbType.Single, AHU_0B1F.AHU02_0B1F02);
                        Db.AddInParameter(cmd, "AHU03_0B1F02", DbType.Single, AHU_0B1F.AHU03_0B1F02);
                        Db.AddInParameter(cmd, "AHU04_0B1F02", DbType.Single, AHU_0B1F.AHU04_0B1F02);
                        Db.AddInParameter(cmd, "AHU05_0B1F02", DbType.Single, AHU_0B1F.AHU05_0B1F02);
                        Db.AddInParameter(cmd, "AHU06_0B1F02", DbType.Single, AHU_0B1F.AHU06_0B1F02);
                        Db.AddInParameter(cmd, "AHU07_0B1F02", DbType.Single, AHU_0B1F.AHU07_0B1F02);
                        Db.AddInParameter(cmd, "AHU08_0B1F02", DbType.Single, AHU_0B1F.AHU08_0B1F02);
                        Db.AddInParameter(cmd, "AHU09_0B1F02", DbType.Single, AHU_0B1F.AHU09_0B1F02);
                        Db.AddInParameter(cmd, "AHU10_0B1F02", DbType.Single, AHU_0B1F.AHU10_0B1F02);
                        Db.AddInParameter(cmd, "AHU11_0B1F02", DbType.Single, AHU_0B1F.AHU11_0B1F02);
                        Db.AddInParameter(cmd, "AHU01_0B1F03", DbType.Single, AHU_0B1F.AHU01_0B1F03);
                        Db.AddInParameter(cmd, "AHU02_0B1F03", DbType.Single, AHU_0B1F.AHU02_0B1F03);
                        Db.AddInParameter(cmd, "AHU03_0B1F03", DbType.Single, AHU_0B1F.AHU03_0B1F03);
                        Db.AddInParameter(cmd, "AHU04_0B1F03", DbType.Single, AHU_0B1F.AHU04_0B1F03);
                        Db.AddInParameter(cmd, "AHU05_0B1F03", DbType.Single, AHU_0B1F.AHU05_0B1F03);
                        Db.AddInParameter(cmd, "AHU06_0B1F03", DbType.Single, AHU_0B1F.AHU06_0B1F03);
                        Db.AddInParameter(cmd, "AHU07_0B1F03", DbType.Single, AHU_0B1F.AHU07_0B1F03);
                        Db.AddInParameter(cmd, "AHU08_0B1F03", DbType.Single, AHU_0B1F.AHU08_0B1F03);
                        Db.AddInParameter(cmd, "AHU09_0B1F03", DbType.Single, AHU_0B1F.AHU09_0B1F03);
                        Db.AddInParameter(cmd, "AHU10_0B1F03", DbType.Single, AHU_0B1F.AHU10_0B1F03);
                        Db.AddInParameter(cmd, "AHU11_0B1F03", DbType.Single, AHU_0B1F.AHU11_0B1F03);
                        Db.AddInParameter(cmd, "AHU01_0B1F04", DbType.Single, AHU_0B1F.AHU01_0B1F04);
                        Db.AddInParameter(cmd, "AHU02_0B1F04", DbType.Single, AHU_0B1F.AHU02_0B1F04);
                        Db.AddInParameter(cmd, "AHU03_0B1F04", DbType.Single, AHU_0B1F.AHU03_0B1F04);
                        Db.AddInParameter(cmd, "AHU04_0B1F04", DbType.Single, AHU_0B1F.AHU04_0B1F04);
                        Db.AddInParameter(cmd, "AHU05_0B1F04", DbType.Single, AHU_0B1F.AHU05_0B1F04);
                        Db.AddInParameter(cmd, "AHU06_0B1F04", DbType.Single, AHU_0B1F.AHU06_0B1F04);
                        Db.AddInParameter(cmd, "AHU07_0B1F04", DbType.Single, AHU_0B1F.AHU07_0B1F04);
                        Db.AddInParameter(cmd, "AHU08_0B1F04", DbType.Single, AHU_0B1F.AHU08_0B1F04);
                        Db.AddInParameter(cmd, "AHU09_0B1F04", DbType.Single, AHU_0B1F.AHU09_0B1F04);
                        Db.AddInParameter(cmd, "AHU10_0B1F04", DbType.Single, AHU_0B1F.AHU10_0B1F04);
                        Db.AddInParameter(cmd, "AHU11_0B1F04", DbType.Single, AHU_0B1F.AHU11_0B1F04);
                        Db.AddInParameter(cmd, "AHU01_0B1F05", DbType.Single, AHU_0B1F.AHU01_0B1F05);
                        Db.AddInParameter(cmd, "AHU02_0B1F05", DbType.Single, AHU_0B1F.AHU02_0B1F05);
                        Db.AddInParameter(cmd, "AHU03_0B1F05", DbType.Single, AHU_0B1F.AHU03_0B1F05);
                        Db.AddInParameter(cmd, "AHU04_0B1F05", DbType.Single, AHU_0B1F.AHU04_0B1F05);
                        Db.AddInParameter(cmd, "AHU05_0B1F05", DbType.Single, AHU_0B1F.AHU05_0B1F05);
                        Db.AddInParameter(cmd, "AHU06_0B1F05", DbType.Single, AHU_0B1F.AHU06_0B1F05);
                        Db.AddInParameter(cmd, "AHU07_0B1F05", DbType.Single, AHU_0B1F.AHU07_0B1F05);
                        Db.AddInParameter(cmd, "AHU08_0B1F05", DbType.Single, AHU_0B1F.AHU08_0B1F05);
                        Db.AddInParameter(cmd, "AHU09_0B1F05", DbType.Single, AHU_0B1F.AHU09_0B1F05);
                        Db.AddInParameter(cmd, "AHU10_0B1F05", DbType.Single, AHU_0B1F.AHU10_0B1F05);
                        Db.AddInParameter(cmd, "AHU11_0B1F05", DbType.Single, AHU_0B1F.AHU11_0B1F05);
                        Db.AddInParameter(cmd, "AHU01_0B1F06", DbType.Single, AHU_0B1F.AHU01_0B1F06);
                        Db.AddInParameter(cmd, "AHU02_0B1F06", DbType.Single, AHU_0B1F.AHU02_0B1F06);
                        Db.AddInParameter(cmd, "AHU03_0B1F06", DbType.Single, AHU_0B1F.AHU03_0B1F06);
                        Db.AddInParameter(cmd, "AHU04_0B1F06", DbType.Single, AHU_0B1F.AHU04_0B1F06);
                        Db.AddInParameter(cmd, "AHU05_0B1F06", DbType.Single, AHU_0B1F.AHU05_0B1F06);
                        Db.AddInParameter(cmd, "AHU06_0B1F06", DbType.Single, AHU_0B1F.AHU06_0B1F06);
                        Db.AddInParameter(cmd, "AHU07_0B1F06", DbType.Single, AHU_0B1F.AHU07_0B1F06);
                        Db.AddInParameter(cmd, "AHU08_0B1F06", DbType.Single, AHU_0B1F.AHU08_0B1F06);
                        Db.AddInParameter(cmd, "AHU09_0B1F06", DbType.Single, AHU_0B1F.AHU09_0B1F06);
                        Db.AddInParameter(cmd, "AHU10_0B1F06", DbType.Single, AHU_0B1F.AHU10_0B1F06);
                        Db.AddInParameter(cmd, "AHU11_0B1F06", DbType.Single, AHU_0B1F.AHU11_0B1F06);
                        Db.AddInParameter(cmd, "AHU01_0B1F07", DbType.Single, AHU_0B1F.AHU01_0B1F07);
                        Db.AddInParameter(cmd, "AHU02_0B1F07", DbType.Single, AHU_0B1F.AHU02_0B1F07);
                        Db.AddInParameter(cmd, "AHU03_0B1F07", DbType.Single, AHU_0B1F.AHU03_0B1F07);
                        Db.AddInParameter(cmd, "AHU04_0B1F07", DbType.Single, AHU_0B1F.AHU04_0B1F07);
                        Db.AddInParameter(cmd, "AHU05_0B1F07", DbType.Single, AHU_0B1F.AHU05_0B1F07);
                        Db.AddInParameter(cmd, "AHU06_0B1F07", DbType.Single, AHU_0B1F.AHU06_0B1F07);
                        Db.AddInParameter(cmd, "AHU07_0B1F07", DbType.Single, AHU_0B1F.AHU07_0B1F07);
                        Db.AddInParameter(cmd, "AHU08_0B1F07", DbType.Single, AHU_0B1F.AHU08_0B1F07);
                        Db.AddInParameter(cmd, "AHU09_0B1F07", DbType.Single, AHU_0B1F.AHU09_0B1F07);
                        Db.AddInParameter(cmd, "AHU10_0B1F07", DbType.Single, AHU_0B1F.AHU10_0B1F07);
                        Db.AddInParameter(cmd, "AHU11_0B1F07", DbType.Single, AHU_0B1F.AHU11_0B1F07);
                        Db.AddInParameter(cmd, "AHU01_0B1F08", DbType.Single, AHU_0B1F.AHU01_0B1F08);
                        Db.AddInParameter(cmd, "AHU02_0B1F08", DbType.Single, AHU_0B1F.AHU02_0B1F08);
                        Db.AddInParameter(cmd, "AHU03_0B1F08", DbType.Single, AHU_0B1F.AHU03_0B1F08);
                        Db.AddInParameter(cmd, "AHU04_0B1F08", DbType.Single, AHU_0B1F.AHU04_0B1F08);
                        Db.AddInParameter(cmd, "AHU05_0B1F08", DbType.Single, AHU_0B1F.AHU05_0B1F08);
                        Db.AddInParameter(cmd, "AHU06_0B1F08", DbType.Single, AHU_0B1F.AHU06_0B1F08);
                        Db.AddInParameter(cmd, "AHU07_0B1F08", DbType.Single, AHU_0B1F.AHU07_0B1F08);
                        Db.AddInParameter(cmd, "AHU08_0B1F08", DbType.Single, AHU_0B1F.AHU08_0B1F08);
                        Db.AddInParameter(cmd, "AHU09_0B1F08", DbType.Single, AHU_0B1F.AHU09_0B1F08);
                        Db.AddInParameter(cmd, "AHU10_0B1F08", DbType.Single, AHU_0B1F.AHU10_0B1F08);
                        Db.AddInParameter(cmd, "AHU11_0B1F08", DbType.Single, AHU_0B1F.AHU11_0B1F08);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForAHU_00RF(AHU_00RF AHU_00RF)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM AHU_0RF WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO AHU_0RF (AUTOID, DATETIME, ACTIVE
            ,AHU01_00RF01,AHU02_00RF01,AHU03_00RF01,AHU04_00RF01,AHU05_00RF01,AHU06_00RF01,AHU07_00RF01,AHU08_00RF01,AHU09_00RF01,AHU10_00RF01,AHU11_00RF01
            ,AHU01_00RF02,AHU02_00RF02,AHU03_00RF02,AHU04_00RF02,AHU05_00RF02,AHU06_00RF02,AHU07_00RF02,AHU08_00RF02,AHU09_00RF02,AHU10_00RF02,AHU11_00RF02
            ,AHU01_00RF03,AHU02_00RF03,AHU03_00RF03,AHU04_00RF03,AHU05_00RF03,AHU06_00RF03,AHU07_00RF03,AHU08_00RF03,AHU09_00RF03,AHU10_00RF03,AHU11_00RF03
            ,AHU01_00RF04,AHU02_00RF04,AHU03_00RF04,AHU04_00RF04,AHU05_00RF04,AHU06_00RF04,AHU07_00RF04,AHU08_00RF04,AHU09_00RF04,AHU10_00RF04,AHU11_00RF04
            ,AHU01_00RF05,AHU02_00RF05,AHU03_00RF05,AHU04_00RF05,AHU05_00RF05,AHU06_00RF05,AHU07_00RF05,AHU08_00RF05,AHU09_00RF05,AHU10_00RF05,AHU11_00RF05
            ,AHU01_00RF06,AHU02_00RF06,AHU03_00RF06,AHU04_00RF06,AHU05_00RF06,AHU06_00RF06,AHU07_00RF06,AHU08_00RF06,AHU09_00RF06,AHU10_00RF06,AHU11_00RF06
            ,AHU01_00RF07,AHU02_00RF07,AHU03_00RF07,AHU04_00RF07,AHU05_00RF07,AHU06_00RF07,AHU07_00RF07,AHU08_00RF07,AHU09_00RF07,AHU10_00RF07,AHU11_00RF07
            ,AHU01_00RF08,AHU02_00RF08,AHU03_00RF08,AHU04_00RF08,AHU05_00RF08,AHU06_00RF08,AHU07_00RF08,AHU08_00RF08,AHU09_00RF08,AHU10_00RF08,AHU11_00RF08
            ,AHU01_00RF09,AHU02_00RF09,AHU03_00RF09,AHU04_00RF09,AHU05_00RF09,AHU06_00RF09,AHU07_00RF09,AHU08_00RF09,AHU09_00RF09,AHU10_00RF09,AHU11_00RF09)
        VALUES (@AUTOID,@DATETIME, @ACTIVE
            ,@AHU01_00RF01,@AHU02_00RF01,@AHU03_00RF01,@AHU04_00RF01,@AHU05_00RF01,@AHU06_00RF01,@AHU07_00RF01,@AHU08_00RF01,@AHU09_00RF01,@AHU10_00RF01,@AHU11_00RF01
            ,@AHU01_00RF02,@AHU02_00RF02,@AHU03_00RF02,@AHU04_00RF02,@AHU05_00RF02,@AHU06_00RF02,@AHU07_00RF02,@AHU08_00RF02,@AHU09_00RF02,@AHU10_00RF02,@AHU11_00RF02
            ,@AHU01_00RF03,@AHU02_00RF03,@AHU03_00RF03,@AHU04_00RF03,@AHU05_00RF03,@AHU06_00RF03,@AHU07_00RF03,@AHU08_00RF03,@AHU09_00RF03,@AHU10_00RF03,@AHU11_00RF03
            ,@AHU01_00RF04,@AHU02_00RF04,@AHU03_00RF04,@AHU04_00RF04,@AHU05_00RF04,@AHU06_00RF04,@AHU07_00RF04,@AHU08_00RF04,@AHU09_00RF04,@AHU10_00RF04,@AHU11_00RF04
            ,@AHU01_00RF05,@AHU02_00RF05,@AHU03_00RF05,@AHU04_00RF05,@AHU05_00RF05,@AHU06_00RF05,@AHU07_00RF05,@AHU08_00RF05,@AHU09_00RF05,@AHU10_00RF05,@AHU11_00RF05
            ,@AHU01_00RF06,@AHU02_00RF06,@AHU03_00RF06,@AHU04_00RF06,@AHU05_00RF06,@AHU06_00RF06,@AHU07_00RF06,@AHU08_00RF06,@AHU09_00RF06,@AHU10_00RF06,@AHU11_00RF06
            ,@AHU01_00RF07,@AHU02_00RF07,@AHU03_00RF07,@AHU04_00RF07,@AHU05_00RF07,@AHU06_00RF07,@AHU07_00RF07,@AHU08_00RF07,@AHU09_00RF07,@AHU10_00RF07,@AHU11_00RF07
            ,@AHU01_00RF08,@AHU02_00RF08,@AHU03_00RF08,@AHU04_00RF08,@AHU05_00RF08,@AHU06_00RF08,@AHU07_00RF08,@AHU08_00RF08,@AHU09_00RF08,@AHU10_00RF08,@AHU11_00RF08
            ,@AHU01_00RF09,@AHU02_00RF09,@AHU03_00RF09,@AHU04_00RF09,@AHU05_00RF09,@AHU06_00RF09,@AHU07_00RF09,@AHU08_00RF09,@AHU09_00RF09,@AHU10_00RF09,@AHU11_00RF09)
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_00RF.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, AHU_00RF.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "AHU01_00RF01", DbType.Single, AHU_00RF.AHU01_00RF01);
                        Db.AddInParameter(cmd, "AHU02_00RF01", DbType.Single, AHU_00RF.AHU02_00RF01);
                        Db.AddInParameter(cmd, "AHU03_00RF01", DbType.Single, AHU_00RF.AHU03_00RF01);
                        Db.AddInParameter(cmd, "AHU04_00RF01", DbType.Single, AHU_00RF.AHU04_00RF01);
                        Db.AddInParameter(cmd, "AHU05_00RF01", DbType.Single, AHU_00RF.AHU05_00RF01);
                        Db.AddInParameter(cmd, "AHU06_00RF01", DbType.Single, AHU_00RF.AHU06_00RF01);
                        Db.AddInParameter(cmd, "AHU07_00RF01", DbType.Single, AHU_00RF.AHU07_00RF01);
                        Db.AddInParameter(cmd, "AHU08_00RF01", DbType.Single, AHU_00RF.AHU08_00RF01);
                        Db.AddInParameter(cmd, "AHU09_00RF01", DbType.Single, AHU_00RF.AHU09_00RF01);
                        Db.AddInParameter(cmd, "AHU10_00RF01", DbType.Single, AHU_00RF.AHU10_00RF01);
                        Db.AddInParameter(cmd, "AHU11_00RF01", DbType.Single, AHU_00RF.AHU11_00RF01);
                        Db.AddInParameter(cmd, "AHU01_00RF02", DbType.Single, AHU_00RF.AHU01_00RF02);
                        Db.AddInParameter(cmd, "AHU02_00RF02", DbType.Single, AHU_00RF.AHU02_00RF02);
                        Db.AddInParameter(cmd, "AHU03_00RF02", DbType.Single, AHU_00RF.AHU03_00RF02);
                        Db.AddInParameter(cmd, "AHU04_00RF02", DbType.Single, AHU_00RF.AHU04_00RF02);
                        Db.AddInParameter(cmd, "AHU05_00RF02", DbType.Single, AHU_00RF.AHU05_00RF02);
                        Db.AddInParameter(cmd, "AHU06_00RF02", DbType.Single, AHU_00RF.AHU06_00RF02);
                        Db.AddInParameter(cmd, "AHU07_00RF02", DbType.Single, AHU_00RF.AHU07_00RF02);
                        Db.AddInParameter(cmd, "AHU08_00RF02", DbType.Single, AHU_00RF.AHU08_00RF02);
                        Db.AddInParameter(cmd, "AHU09_00RF02", DbType.Single, AHU_00RF.AHU09_00RF02);
                        Db.AddInParameter(cmd, "AHU10_00RF02", DbType.Single, AHU_00RF.AHU10_00RF02);
                        Db.AddInParameter(cmd, "AHU11_00RF02", DbType.Single, AHU_00RF.AHU11_00RF02);
                        Db.AddInParameter(cmd, "AHU01_00RF03", DbType.Single, AHU_00RF.AHU01_00RF03);
                        Db.AddInParameter(cmd, "AHU02_00RF03", DbType.Single, AHU_00RF.AHU02_00RF03);
                        Db.AddInParameter(cmd, "AHU03_00RF03", DbType.Single, AHU_00RF.AHU03_00RF03);
                        Db.AddInParameter(cmd, "AHU04_00RF03", DbType.Single, AHU_00RF.AHU04_00RF03);
                        Db.AddInParameter(cmd, "AHU05_00RF03", DbType.Single, AHU_00RF.AHU05_00RF03);
                        Db.AddInParameter(cmd, "AHU06_00RF03", DbType.Single, AHU_00RF.AHU06_00RF03);
                        Db.AddInParameter(cmd, "AHU07_00RF03", DbType.Single, AHU_00RF.AHU07_00RF03);
                        Db.AddInParameter(cmd, "AHU08_00RF03", DbType.Single, AHU_00RF.AHU08_00RF03);
                        Db.AddInParameter(cmd, "AHU09_00RF03", DbType.Single, AHU_00RF.AHU09_00RF03);
                        Db.AddInParameter(cmd, "AHU10_00RF03", DbType.Single, AHU_00RF.AHU10_00RF03);
                        Db.AddInParameter(cmd, "AHU11_00RF03", DbType.Single, AHU_00RF.AHU11_00RF03);
                        Db.AddInParameter(cmd, "AHU01_00RF04", DbType.Single, AHU_00RF.AHU01_00RF04);
                        Db.AddInParameter(cmd, "AHU02_00RF04", DbType.Single, AHU_00RF.AHU02_00RF04);
                        Db.AddInParameter(cmd, "AHU03_00RF04", DbType.Single, AHU_00RF.AHU03_00RF04);
                        Db.AddInParameter(cmd, "AHU04_00RF04", DbType.Single, AHU_00RF.AHU04_00RF04);
                        Db.AddInParameter(cmd, "AHU05_00RF04", DbType.Single, AHU_00RF.AHU05_00RF04);
                        Db.AddInParameter(cmd, "AHU06_00RF04", DbType.Single, AHU_00RF.AHU06_00RF04);
                        Db.AddInParameter(cmd, "AHU07_00RF04", DbType.Single, AHU_00RF.AHU07_00RF04);
                        Db.AddInParameter(cmd, "AHU08_00RF04", DbType.Single, AHU_00RF.AHU08_00RF04);
                        Db.AddInParameter(cmd, "AHU09_00RF04", DbType.Single, AHU_00RF.AHU09_00RF04);
                        Db.AddInParameter(cmd, "AHU10_00RF04", DbType.Single, AHU_00RF.AHU10_00RF04);
                        Db.AddInParameter(cmd, "AHU11_00RF04", DbType.Single, AHU_00RF.AHU11_00RF04);
                        Db.AddInParameter(cmd, "AHU01_00RF05", DbType.Single, AHU_00RF.AHU01_00RF05);
                        Db.AddInParameter(cmd, "AHU02_00RF05", DbType.Single, AHU_00RF.AHU02_00RF05);
                        Db.AddInParameter(cmd, "AHU03_00RF05", DbType.Single, AHU_00RF.AHU03_00RF05);
                        Db.AddInParameter(cmd, "AHU04_00RF05", DbType.Single, AHU_00RF.AHU04_00RF05);
                        Db.AddInParameter(cmd, "AHU05_00RF05", DbType.Single, AHU_00RF.AHU05_00RF05);
                        Db.AddInParameter(cmd, "AHU06_00RF05", DbType.Single, AHU_00RF.AHU06_00RF05);
                        Db.AddInParameter(cmd, "AHU07_00RF05", DbType.Single, AHU_00RF.AHU07_00RF05);
                        Db.AddInParameter(cmd, "AHU08_00RF05", DbType.Single, AHU_00RF.AHU08_00RF05);
                        Db.AddInParameter(cmd, "AHU09_00RF05", DbType.Single, AHU_00RF.AHU09_00RF05);
                        Db.AddInParameter(cmd, "AHU10_00RF05", DbType.Single, AHU_00RF.AHU10_00RF05);
                        Db.AddInParameter(cmd, "AHU11_00RF05", DbType.Single, AHU_00RF.AHU11_00RF05);
                        Db.AddInParameter(cmd, "AHU01_00RF06", DbType.Single, AHU_00RF.AHU01_00RF06);
                        Db.AddInParameter(cmd, "AHU02_00RF06", DbType.Single, AHU_00RF.AHU02_00RF06);
                        Db.AddInParameter(cmd, "AHU03_00RF06", DbType.Single, AHU_00RF.AHU03_00RF06);
                        Db.AddInParameter(cmd, "AHU04_00RF06", DbType.Single, AHU_00RF.AHU04_00RF06);
                        Db.AddInParameter(cmd, "AHU05_00RF06", DbType.Single, AHU_00RF.AHU05_00RF06);
                        Db.AddInParameter(cmd, "AHU06_00RF06", DbType.Single, AHU_00RF.AHU06_00RF06);
                        Db.AddInParameter(cmd, "AHU07_00RF06", DbType.Single, AHU_00RF.AHU07_00RF06);
                        Db.AddInParameter(cmd, "AHU08_00RF06", DbType.Single, AHU_00RF.AHU08_00RF06);
                        Db.AddInParameter(cmd, "AHU09_00RF06", DbType.Single, AHU_00RF.AHU09_00RF06);
                        Db.AddInParameter(cmd, "AHU10_00RF06", DbType.Single, AHU_00RF.AHU10_00RF06);
                        Db.AddInParameter(cmd, "AHU11_00RF06", DbType.Single, AHU_00RF.AHU11_00RF06);
                        Db.AddInParameter(cmd, "AHU01_00RF07", DbType.Single, AHU_00RF.AHU01_00RF07);
                        Db.AddInParameter(cmd, "AHU02_00RF07", DbType.Single, AHU_00RF.AHU02_00RF07);
                        Db.AddInParameter(cmd, "AHU03_00RF07", DbType.Single, AHU_00RF.AHU03_00RF07);
                        Db.AddInParameter(cmd, "AHU04_00RF07", DbType.Single, AHU_00RF.AHU04_00RF07);
                        Db.AddInParameter(cmd, "AHU05_00RF07", DbType.Single, AHU_00RF.AHU05_00RF07);
                        Db.AddInParameter(cmd, "AHU06_00RF07", DbType.Single, AHU_00RF.AHU06_00RF07);
                        Db.AddInParameter(cmd, "AHU07_00RF07", DbType.Single, AHU_00RF.AHU07_00RF07);
                        Db.AddInParameter(cmd, "AHU08_00RF07", DbType.Single, AHU_00RF.AHU08_00RF07);
                        Db.AddInParameter(cmd, "AHU09_00RF07", DbType.Single, AHU_00RF.AHU09_00RF07);
                        Db.AddInParameter(cmd, "AHU10_00RF07", DbType.Single, AHU_00RF.AHU10_00RF07);
                        Db.AddInParameter(cmd, "AHU11_00RF07", DbType.Single, AHU_00RF.AHU11_00RF07);
                        Db.AddInParameter(cmd, "AHU01_00RF08", DbType.Single, AHU_00RF.AHU01_00RF08);
                        Db.AddInParameter(cmd, "AHU02_00RF08", DbType.Single, AHU_00RF.AHU02_00RF08);
                        Db.AddInParameter(cmd, "AHU03_00RF08", DbType.Single, AHU_00RF.AHU03_00RF08);
                        Db.AddInParameter(cmd, "AHU04_00RF08", DbType.Single, AHU_00RF.AHU04_00RF08);
                        Db.AddInParameter(cmd, "AHU05_00RF08", DbType.Single, AHU_00RF.AHU05_00RF08);
                        Db.AddInParameter(cmd, "AHU06_00RF08", DbType.Single, AHU_00RF.AHU06_00RF08);
                        Db.AddInParameter(cmd, "AHU07_00RF08", DbType.Single, AHU_00RF.AHU07_00RF08);
                        Db.AddInParameter(cmd, "AHU08_00RF08", DbType.Single, AHU_00RF.AHU08_00RF08);
                        Db.AddInParameter(cmd, "AHU09_00RF08", DbType.Single, AHU_00RF.AHU09_00RF08);
                        Db.AddInParameter(cmd, "AHU10_00RF08", DbType.Single, AHU_00RF.AHU10_00RF08);
                        Db.AddInParameter(cmd, "AHU11_00RF08", DbType.Single, AHU_00RF.AHU11_00RF08);
                        Db.AddInParameter(cmd, "AHU01_00RF09", DbType.Single, AHU_00RF.AHU01_00RF09);
                        Db.AddInParameter(cmd, "AHU02_00RF09", DbType.Single, AHU_00RF.AHU02_00RF09);
                        Db.AddInParameter(cmd, "AHU03_00RF09", DbType.Single, AHU_00RF.AHU03_00RF09);
                        Db.AddInParameter(cmd, "AHU04_00RF09", DbType.Single, AHU_00RF.AHU04_00RF09);
                        Db.AddInParameter(cmd, "AHU05_00RF09", DbType.Single, AHU_00RF.AHU05_00RF09);
                        Db.AddInParameter(cmd, "AHU06_00RF09", DbType.Single, AHU_00RF.AHU06_00RF09);
                        Db.AddInParameter(cmd, "AHU07_00RF09", DbType.Single, AHU_00RF.AHU07_00RF09);
                        Db.AddInParameter(cmd, "AHU08_00RF09", DbType.Single, AHU_00RF.AHU08_00RF09);
                        Db.AddInParameter(cmd, "AHU09_00RF09", DbType.Single, AHU_00RF.AHU09_00RF09);
                        Db.AddInParameter(cmd, "AHU10_00RF09", DbType.Single, AHU_00RF.AHU10_00RF09);
                        Db.AddInParameter(cmd, "AHU11_00RF09", DbType.Single, AHU_00RF.AHU11_00RF09);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForAHU_014F(AHU_014F AHU_014F)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();
                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM AHU_14F WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO AHU_14F (AUTOID, DATETIME, ACTIVE
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
            ,AHU01_014F16,AHU02_014F16,AHU03_014F16,AHU04_014F16,AHU05_014F16,AHU06_014F16,AHU07_014F16,AHU08_014F16,AHU09_014F16,AHU10_014F16,AHU11_014F16)
        VALUES (@AUTOID,@DATETIME, @ACTIVE
            ,@AHU01_014F01,@AHU02_014F01,@AHU03_014F01,@AHU04_014F01,@AHU05_014F01,@AHU06_014F01,@AHU07_014F01,@AHU08_014F01,@AHU09_014F01,@AHU10_014F01,@AHU11_014F01
            ,@AHU01_014F02,@AHU02_014F02,@AHU03_014F02,@AHU04_014F02,@AHU05_014F02,@AHU06_014F02,@AHU07_014F02,@AHU08_014F02,@AHU09_014F02,@AHU10_014F02,@AHU11_014F02
            ,@AHU01_014F03,@AHU02_014F03,@AHU03_014F03,@AHU04_014F03,@AHU05_014F03,@AHU06_014F03,@AHU07_014F03,@AHU08_014F03,@AHU09_014F03,@AHU10_014F03,@AHU11_014F03
            ,@AHU01_014F04,@AHU02_014F04,@AHU03_014F04,@AHU04_014F04,@AHU05_014F04,@AHU06_014F04,@AHU07_014F04,@AHU08_014F04,@AHU09_014F04,@AHU10_014F04,@AHU11_014F04
            ,@AHU01_014F05,@AHU02_014F05,@AHU03_014F05,@AHU04_014F05,@AHU05_014F05,@AHU06_014F05,@AHU07_014F05,@AHU08_014F05,@AHU09_014F05,@AHU10_014F05,@AHU11_014F05
            ,@AHU01_014F06,@AHU02_014F06,@AHU03_014F06,@AHU04_014F06,@AHU05_014F06,@AHU06_014F06,@AHU07_014F06,@AHU08_014F06,@AHU09_014F06,@AHU10_014F06,@AHU11_014F06
            ,@AHU01_014F07,@AHU02_014F07,@AHU03_014F07,@AHU04_014F07,@AHU05_014F07,@AHU06_014F07,@AHU07_014F07,@AHU08_014F07,@AHU09_014F07,@AHU10_014F07,@AHU11_014F07
            ,@AHU01_014F08,@AHU02_014F08,@AHU03_014F08,@AHU04_014F08,@AHU05_014F08,@AHU06_014F08,@AHU07_014F08,@AHU08_014F08,@AHU09_014F08,@AHU10_014F08,@AHU11_014F08
            ,@AHU01_014F09,@AHU02_014F09,@AHU03_014F09,@AHU04_014F09,@AHU05_014F09,@AHU06_014F09,@AHU07_014F09,@AHU08_014F09,@AHU09_014F09,@AHU10_014F09,@AHU11_014F09
            ,@AHU01_014F10,@AHU02_014F10,@AHU03_014F10,@AHU04_014F10,@AHU05_014F10,@AHU06_014F10,@AHU07_014F10,@AHU08_014F10,@AHU09_014F10,@AHU10_014F10,@AHU11_014F10
            ,@AHU01_014F11,@AHU02_014F11,@AHU03_014F11,@AHU04_014F11,@AHU05_014F11,@AHU06_014F11,@AHU07_014F11,@AHU08_014F11,@AHU09_014F11,@AHU10_014F11,@AHU11_014F11
            ,@AHU01_014F12,@AHU02_014F12,@AHU03_014F12,@AHU04_014F12,@AHU05_014F12,@AHU06_014F12,@AHU07_014F12,@AHU08_014F12,@AHU09_014F12,@AHU10_014F12,@AHU11_014F12
            ,@AHU01_014F13,@AHU02_014F13,@AHU03_014F13,@AHU04_014F13,@AHU05_014F13,@AHU06_014F13,@AHU07_014F13,@AHU08_014F13,@AHU09_014F13,@AHU10_014F13,@AHU11_014F13
            ,@AHU01_014F14,@AHU02_014F14,@AHU03_014F14,@AHU04_014F14,@AHU05_014F14,@AHU06_014F14,@AHU07_014F14,@AHU08_014F14,@AHU09_014F14,@AHU10_014F14,@AHU11_014F14
            ,@AHU01_014F15,@AHU02_014F15,@AHU03_014F15,@AHU04_014F15,@AHU05_014F15,@AHU06_014F15,@AHU07_014F15,@AHU08_014F15,@AHU09_014F15,@AHU10_014F15,@AHU11_014F15
            ,@AHU01_014F16,@AHU02_014F16,@AHU03_014F16,@AHU04_014F16,@AHU05_014F16,@AHU06_014F16,@AHU07_014F16,@AHU08_014F16,@AHU09_014F16,@AHU10_014F16,@AHU11_014F16)
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_014F.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, AHU_014F.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "AHU01_014F01", DbType.Single, AHU_014F.AHU01_014F01);
                        Db.AddInParameter(cmd, "AHU02_014F01", DbType.Single, AHU_014F.AHU02_014F01);
                        Db.AddInParameter(cmd, "AHU03_014F01", DbType.Single, AHU_014F.AHU03_014F01);
                        Db.AddInParameter(cmd, "AHU04_014F01", DbType.Single, AHU_014F.AHU04_014F01);
                        Db.AddInParameter(cmd, "AHU05_014F01", DbType.Single, AHU_014F.AHU05_014F01);
                        Db.AddInParameter(cmd, "AHU06_014F01", DbType.Single, AHU_014F.AHU06_014F01);
                        Db.AddInParameter(cmd, "AHU07_014F01", DbType.Single, AHU_014F.AHU07_014F01);
                        Db.AddInParameter(cmd, "AHU08_014F01", DbType.Single, AHU_014F.AHU08_014F01);
                        Db.AddInParameter(cmd, "AHU09_014F01", DbType.Single, AHU_014F.AHU09_014F01);
                        Db.AddInParameter(cmd, "AHU10_014F01", DbType.Single, AHU_014F.AHU10_014F01);
                        Db.AddInParameter(cmd, "AHU11_014F01", DbType.Single, AHU_014F.AHU11_014F01);
                        Db.AddInParameter(cmd, "AHU01_014F02", DbType.Single, AHU_014F.AHU01_014F02);
                        Db.AddInParameter(cmd, "AHU02_014F02", DbType.Single, AHU_014F.AHU02_014F02);
                        Db.AddInParameter(cmd, "AHU03_014F02", DbType.Single, AHU_014F.AHU03_014F02);
                        Db.AddInParameter(cmd, "AHU04_014F02", DbType.Single, AHU_014F.AHU04_014F02);
                        Db.AddInParameter(cmd, "AHU05_014F02", DbType.Single, AHU_014F.AHU05_014F02);
                        Db.AddInParameter(cmd, "AHU06_014F02", DbType.Single, AHU_014F.AHU06_014F02);
                        Db.AddInParameter(cmd, "AHU07_014F02", DbType.Single, AHU_014F.AHU07_014F02);
                        Db.AddInParameter(cmd, "AHU08_014F02", DbType.Single, AHU_014F.AHU08_014F02);
                        Db.AddInParameter(cmd, "AHU09_014F02", DbType.Single, AHU_014F.AHU09_014F02);
                        Db.AddInParameter(cmd, "AHU10_014F02", DbType.Single, AHU_014F.AHU10_014F02);
                        Db.AddInParameter(cmd, "AHU11_014F02", DbType.Single, AHU_014F.AHU11_014F02);
                        Db.AddInParameter(cmd, "AHU01_014F03", DbType.Single, AHU_014F.AHU01_014F03);
                        Db.AddInParameter(cmd, "AHU02_014F03", DbType.Single, AHU_014F.AHU02_014F03);
                        Db.AddInParameter(cmd, "AHU03_014F03", DbType.Single, AHU_014F.AHU03_014F03);
                        Db.AddInParameter(cmd, "AHU04_014F03", DbType.Single, AHU_014F.AHU04_014F03);
                        Db.AddInParameter(cmd, "AHU05_014F03", DbType.Single, AHU_014F.AHU05_014F03);
                        Db.AddInParameter(cmd, "AHU06_014F03", DbType.Single, AHU_014F.AHU06_014F03);
                        Db.AddInParameter(cmd, "AHU07_014F03", DbType.Single, AHU_014F.AHU07_014F03);
                        Db.AddInParameter(cmd, "AHU08_014F03", DbType.Single, AHU_014F.AHU08_014F03);
                        Db.AddInParameter(cmd, "AHU09_014F03", DbType.Single, AHU_014F.AHU09_014F03);
                        Db.AddInParameter(cmd, "AHU10_014F03", DbType.Single, AHU_014F.AHU10_014F03);
                        Db.AddInParameter(cmd, "AHU11_014F03", DbType.Single, AHU_014F.AHU11_014F03);
                        Db.AddInParameter(cmd, "AHU01_014F04", DbType.Single, AHU_014F.AHU01_014F04);
                        Db.AddInParameter(cmd, "AHU02_014F04", DbType.Single, AHU_014F.AHU02_014F04);
                        Db.AddInParameter(cmd, "AHU03_014F04", DbType.Single, AHU_014F.AHU03_014F04);
                        Db.AddInParameter(cmd, "AHU04_014F04", DbType.Single, AHU_014F.AHU04_014F04);
                        Db.AddInParameter(cmd, "AHU05_014F04", DbType.Single, AHU_014F.AHU05_014F04);
                        Db.AddInParameter(cmd, "AHU06_014F04", DbType.Single, AHU_014F.AHU06_014F04);
                        Db.AddInParameter(cmd, "AHU07_014F04", DbType.Single, AHU_014F.AHU07_014F04);
                        Db.AddInParameter(cmd, "AHU08_014F04", DbType.Single, AHU_014F.AHU08_014F04);
                        Db.AddInParameter(cmd, "AHU09_014F04", DbType.Single, AHU_014F.AHU09_014F04);
                        Db.AddInParameter(cmd, "AHU10_014F04", DbType.Single, AHU_014F.AHU10_014F04);
                        Db.AddInParameter(cmd, "AHU11_014F04", DbType.Single, AHU_014F.AHU11_014F04);
                        Db.AddInParameter(cmd, "AHU01_014F05", DbType.Single, AHU_014F.AHU01_014F05);
                        Db.AddInParameter(cmd, "AHU02_014F05", DbType.Single, AHU_014F.AHU02_014F05);
                        Db.AddInParameter(cmd, "AHU03_014F05", DbType.Single, AHU_014F.AHU03_014F05);
                        Db.AddInParameter(cmd, "AHU04_014F05", DbType.Single, AHU_014F.AHU04_014F05);
                        Db.AddInParameter(cmd, "AHU05_014F05", DbType.Single, AHU_014F.AHU05_014F05);
                        Db.AddInParameter(cmd, "AHU06_014F05", DbType.Single, AHU_014F.AHU06_014F05);
                        Db.AddInParameter(cmd, "AHU07_014F05", DbType.Single, AHU_014F.AHU07_014F05);
                        Db.AddInParameter(cmd, "AHU08_014F05", DbType.Single, AHU_014F.AHU08_014F05);
                        Db.AddInParameter(cmd, "AHU09_014F05", DbType.Single, AHU_014F.AHU09_014F05);
                        Db.AddInParameter(cmd, "AHU10_014F05", DbType.Single, AHU_014F.AHU10_014F05);
                        Db.AddInParameter(cmd, "AHU11_014F05", DbType.Single, AHU_014F.AHU11_014F05);
                        Db.AddInParameter(cmd, "AHU01_014F06", DbType.Single, AHU_014F.AHU01_014F06);
                        Db.AddInParameter(cmd, "AHU02_014F06", DbType.Single, AHU_014F.AHU02_014F06);
                        Db.AddInParameter(cmd, "AHU03_014F06", DbType.Single, AHU_014F.AHU03_014F06);
                        Db.AddInParameter(cmd, "AHU04_014F06", DbType.Single, AHU_014F.AHU04_014F06);
                        Db.AddInParameter(cmd, "AHU05_014F06", DbType.Single, AHU_014F.AHU05_014F06);
                        Db.AddInParameter(cmd, "AHU06_014F06", DbType.Single, AHU_014F.AHU06_014F06);
                        Db.AddInParameter(cmd, "AHU07_014F06", DbType.Single, AHU_014F.AHU07_014F06);
                        Db.AddInParameter(cmd, "AHU08_014F06", DbType.Single, AHU_014F.AHU08_014F06);
                        Db.AddInParameter(cmd, "AHU09_014F06", DbType.Single, AHU_014F.AHU09_014F06);
                        Db.AddInParameter(cmd, "AHU10_014F06", DbType.Single, AHU_014F.AHU10_014F06);
                        Db.AddInParameter(cmd, "AHU11_014F06", DbType.Single, AHU_014F.AHU11_014F06);
                        Db.AddInParameter(cmd, "AHU01_014F07", DbType.Single, AHU_014F.AHU01_014F07);
                        Db.AddInParameter(cmd, "AHU02_014F07", DbType.Single, AHU_014F.AHU02_014F07);
                        Db.AddInParameter(cmd, "AHU03_014F07", DbType.Single, AHU_014F.AHU03_014F07);
                        Db.AddInParameter(cmd, "AHU04_014F07", DbType.Single, AHU_014F.AHU04_014F07);
                        Db.AddInParameter(cmd, "AHU05_014F07", DbType.Single, AHU_014F.AHU05_014F07);
                        Db.AddInParameter(cmd, "AHU06_014F07", DbType.Single, AHU_014F.AHU06_014F07);
                        Db.AddInParameter(cmd, "AHU07_014F07", DbType.Single, AHU_014F.AHU07_014F07);
                        Db.AddInParameter(cmd, "AHU08_014F07", DbType.Single, AHU_014F.AHU08_014F07);
                        Db.AddInParameter(cmd, "AHU09_014F07", DbType.Single, AHU_014F.AHU09_014F07);
                        Db.AddInParameter(cmd, "AHU10_014F07", DbType.Single, AHU_014F.AHU10_014F07);
                        Db.AddInParameter(cmd, "AHU11_014F07", DbType.Single, AHU_014F.AHU11_014F07);
                        Db.AddInParameter(cmd, "AHU01_014F08", DbType.Single, AHU_014F.AHU01_014F08);
                        Db.AddInParameter(cmd, "AHU02_014F08", DbType.Single, AHU_014F.AHU02_014F08);
                        Db.AddInParameter(cmd, "AHU03_014F08", DbType.Single, AHU_014F.AHU03_014F08);
                        Db.AddInParameter(cmd, "AHU04_014F08", DbType.Single, AHU_014F.AHU04_014F08);
                        Db.AddInParameter(cmd, "AHU05_014F08", DbType.Single, AHU_014F.AHU05_014F08);
                        Db.AddInParameter(cmd, "AHU06_014F08", DbType.Single, AHU_014F.AHU06_014F08);
                        Db.AddInParameter(cmd, "AHU07_014F08", DbType.Single, AHU_014F.AHU07_014F08);
                        Db.AddInParameter(cmd, "AHU08_014F08", DbType.Single, AHU_014F.AHU08_014F08);
                        Db.AddInParameter(cmd, "AHU09_014F08", DbType.Single, AHU_014F.AHU09_014F08);
                        Db.AddInParameter(cmd, "AHU10_014F08", DbType.Single, AHU_014F.AHU10_014F08);
                        Db.AddInParameter(cmd, "AHU11_014F08", DbType.Single, AHU_014F.AHU11_014F08);
                        Db.AddInParameter(cmd, "AHU01_014F09", DbType.Single, AHU_014F.AHU01_014F09);
                        Db.AddInParameter(cmd, "AHU02_014F09", DbType.Single, AHU_014F.AHU02_014F09);
                        Db.AddInParameter(cmd, "AHU03_014F09", DbType.Single, AHU_014F.AHU03_014F09);
                        Db.AddInParameter(cmd, "AHU04_014F09", DbType.Single, AHU_014F.AHU04_014F09);
                        Db.AddInParameter(cmd, "AHU05_014F09", DbType.Single, AHU_014F.AHU05_014F09);
                        Db.AddInParameter(cmd, "AHU06_014F09", DbType.Single, AHU_014F.AHU06_014F09);
                        Db.AddInParameter(cmd, "AHU07_014F09", DbType.Single, AHU_014F.AHU07_014F09);
                        Db.AddInParameter(cmd, "AHU08_014F09", DbType.Single, AHU_014F.AHU08_014F09);
                        Db.AddInParameter(cmd, "AHU09_014F09", DbType.Single, AHU_014F.AHU09_014F09);
                        Db.AddInParameter(cmd, "AHU10_014F09", DbType.Single, AHU_014F.AHU10_014F09);
                        Db.AddInParameter(cmd, "AHU11_014F09", DbType.Single, AHU_014F.AHU11_014F09);
                        Db.AddInParameter(cmd, "AHU01_014F10", DbType.Single, AHU_014F.AHU01_014F10);
                        Db.AddInParameter(cmd, "AHU02_014F10", DbType.Single, AHU_014F.AHU02_014F10);
                        Db.AddInParameter(cmd, "AHU03_014F10", DbType.Single, AHU_014F.AHU03_014F10);
                        Db.AddInParameter(cmd, "AHU04_014F10", DbType.Single, AHU_014F.AHU04_014F10);
                        Db.AddInParameter(cmd, "AHU05_014F10", DbType.Single, AHU_014F.AHU05_014F10);
                        Db.AddInParameter(cmd, "AHU06_014F10", DbType.Single, AHU_014F.AHU06_014F10);
                        Db.AddInParameter(cmd, "AHU07_014F10", DbType.Single, AHU_014F.AHU07_014F10);
                        Db.AddInParameter(cmd, "AHU08_014F10", DbType.Single, AHU_014F.AHU08_014F10);
                        Db.AddInParameter(cmd, "AHU09_014F10", DbType.Single, AHU_014F.AHU09_014F10);
                        Db.AddInParameter(cmd, "AHU10_014F10", DbType.Single, AHU_014F.AHU10_014F10);
                        Db.AddInParameter(cmd, "AHU11_014F10", DbType.Single, AHU_014F.AHU11_014F10);
                        Db.AddInParameter(cmd, "AHU01_014F11", DbType.Single, AHU_014F.AHU01_014F11);
                        Db.AddInParameter(cmd, "AHU02_014F11", DbType.Single, AHU_014F.AHU02_014F11);
                        Db.AddInParameter(cmd, "AHU03_014F11", DbType.Single, AHU_014F.AHU03_014F11);
                        Db.AddInParameter(cmd, "AHU04_014F11", DbType.Single, AHU_014F.AHU04_014F11);
                        Db.AddInParameter(cmd, "AHU05_014F11", DbType.Single, AHU_014F.AHU05_014F11);
                        Db.AddInParameter(cmd, "AHU06_014F11", DbType.Single, AHU_014F.AHU06_014F11);
                        Db.AddInParameter(cmd, "AHU07_014F11", DbType.Single, AHU_014F.AHU07_014F11);
                        Db.AddInParameter(cmd, "AHU08_014F11", DbType.Single, AHU_014F.AHU08_014F11);
                        Db.AddInParameter(cmd, "AHU09_014F11", DbType.Single, AHU_014F.AHU09_014F11);
                        Db.AddInParameter(cmd, "AHU10_014F11", DbType.Single, AHU_014F.AHU10_014F11);
                        Db.AddInParameter(cmd, "AHU11_014F11", DbType.Single, AHU_014F.AHU11_014F11);
                        Db.AddInParameter(cmd, "AHU01_014F12", DbType.Single, AHU_014F.AHU01_014F12);
                        Db.AddInParameter(cmd, "AHU02_014F12", DbType.Single, AHU_014F.AHU02_014F12);
                        Db.AddInParameter(cmd, "AHU03_014F12", DbType.Single, AHU_014F.AHU03_014F12);
                        Db.AddInParameter(cmd, "AHU04_014F12", DbType.Single, AHU_014F.AHU04_014F12);
                        Db.AddInParameter(cmd, "AHU05_014F12", DbType.Single, AHU_014F.AHU05_014F12);
                        Db.AddInParameter(cmd, "AHU06_014F12", DbType.Single, AHU_014F.AHU06_014F12);
                        Db.AddInParameter(cmd, "AHU07_014F12", DbType.Single, AHU_014F.AHU07_014F12);
                        Db.AddInParameter(cmd, "AHU08_014F12", DbType.Single, AHU_014F.AHU08_014F12);
                        Db.AddInParameter(cmd, "AHU09_014F12", DbType.Single, AHU_014F.AHU09_014F12);
                        Db.AddInParameter(cmd, "AHU10_014F12", DbType.Single, AHU_014F.AHU10_014F12);
                        Db.AddInParameter(cmd, "AHU11_014F12", DbType.Single, AHU_014F.AHU11_014F12);
                        Db.AddInParameter(cmd, "AHU01_014F13", DbType.Single, AHU_014F.AHU01_014F13);
                        Db.AddInParameter(cmd, "AHU02_014F13", DbType.Single, AHU_014F.AHU02_014F13);
                        Db.AddInParameter(cmd, "AHU03_014F13", DbType.Single, AHU_014F.AHU03_014F13);
                        Db.AddInParameter(cmd, "AHU04_014F13", DbType.Single, AHU_014F.AHU04_014F13);
                        Db.AddInParameter(cmd, "AHU05_014F13", DbType.Single, AHU_014F.AHU05_014F13);
                        Db.AddInParameter(cmd, "AHU06_014F13", DbType.Single, AHU_014F.AHU06_014F13);
                        Db.AddInParameter(cmd, "AHU07_014F13", DbType.Single, AHU_014F.AHU07_014F13);
                        Db.AddInParameter(cmd, "AHU08_014F13", DbType.Single, AHU_014F.AHU08_014F13);
                        Db.AddInParameter(cmd, "AHU09_014F13", DbType.Single, AHU_014F.AHU09_014F13);
                        Db.AddInParameter(cmd, "AHU10_014F13", DbType.Single, AHU_014F.AHU10_014F13);
                        Db.AddInParameter(cmd, "AHU11_014F13", DbType.Single, AHU_014F.AHU11_014F13);
                        Db.AddInParameter(cmd, "AHU01_014F14", DbType.Single, AHU_014F.AHU01_014F14);
                        Db.AddInParameter(cmd, "AHU02_014F14", DbType.Single, AHU_014F.AHU02_014F14);
                        Db.AddInParameter(cmd, "AHU03_014F14", DbType.Single, AHU_014F.AHU03_014F14);
                        Db.AddInParameter(cmd, "AHU04_014F14", DbType.Single, AHU_014F.AHU04_014F14);
                        Db.AddInParameter(cmd, "AHU05_014F14", DbType.Single, AHU_014F.AHU05_014F14);
                        Db.AddInParameter(cmd, "AHU06_014F14", DbType.Single, AHU_014F.AHU06_014F14);
                        Db.AddInParameter(cmd, "AHU07_014F14", DbType.Single, AHU_014F.AHU07_014F14);
                        Db.AddInParameter(cmd, "AHU08_014F14", DbType.Single, AHU_014F.AHU08_014F14);
                        Db.AddInParameter(cmd, "AHU09_014F14", DbType.Single, AHU_014F.AHU09_014F14);
                        Db.AddInParameter(cmd, "AHU10_014F14", DbType.Single, AHU_014F.AHU10_014F14);
                        Db.AddInParameter(cmd, "AHU11_014F14", DbType.Single, AHU_014F.AHU11_014F14);
                        Db.AddInParameter(cmd, "AHU01_014F15", DbType.Single, AHU_014F.AHU01_014F15);
                        Db.AddInParameter(cmd, "AHU02_014F15", DbType.Single, AHU_014F.AHU02_014F15);
                        Db.AddInParameter(cmd, "AHU03_014F15", DbType.Single, AHU_014F.AHU03_014F15);
                        Db.AddInParameter(cmd, "AHU04_014F15", DbType.Single, AHU_014F.AHU04_014F15);
                        Db.AddInParameter(cmd, "AHU05_014F15", DbType.Single, AHU_014F.AHU05_014F15);
                        Db.AddInParameter(cmd, "AHU06_014F15", DbType.Single, AHU_014F.AHU06_014F15);
                        Db.AddInParameter(cmd, "AHU07_014F15", DbType.Single, AHU_014F.AHU07_014F15);
                        Db.AddInParameter(cmd, "AHU08_014F15", DbType.Single, AHU_014F.AHU08_014F15);
                        Db.AddInParameter(cmd, "AHU09_014F15", DbType.Single, AHU_014F.AHU09_014F15);
                        Db.AddInParameter(cmd, "AHU10_014F15", DbType.Single, AHU_014F.AHU10_014F15);
                        Db.AddInParameter(cmd, "AHU11_014F15", DbType.Single, AHU_014F.AHU11_014F15);
                        Db.AddInParameter(cmd, "AHU01_014F16", DbType.Single, AHU_014F.AHU01_014F16);
                        Db.AddInParameter(cmd, "AHU02_014F16", DbType.Single, AHU_014F.AHU02_014F16);
                        Db.AddInParameter(cmd, "AHU03_014F16", DbType.Single, AHU_014F.AHU03_014F16);
                        Db.AddInParameter(cmd, "AHU04_014F16", DbType.Single, AHU_014F.AHU04_014F16);
                        Db.AddInParameter(cmd, "AHU05_014F16", DbType.Single, AHU_014F.AHU05_014F16);
                        Db.AddInParameter(cmd, "AHU06_014F16", DbType.Single, AHU_014F.AHU06_014F16);
                        Db.AddInParameter(cmd, "AHU07_014F16", DbType.Single, AHU_014F.AHU07_014F16);
                        Db.AddInParameter(cmd, "AHU08_014F16", DbType.Single, AHU_014F.AHU08_014F16);
                        Db.AddInParameter(cmd, "AHU09_014F16", DbType.Single, AHU_014F.AHU09_014F16);
                        Db.AddInParameter(cmd, "AHU10_014F16", DbType.Single, AHU_014F.AHU10_014F16);
                        Db.AddInParameter(cmd, "AHU11_014F16", DbType.Single, AHU_014F.AHU11_014F16);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForAHU_S03F(AHU_S03F AHU_S03F)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM AHU_S03 WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO AHU_S03 (AUTOID,DATETIME,ACTIVE
            ,AHU01_S03F01,AHU02_S03F01,AHU03_S03F01,AHU04_S03F01,AHU05_S03F01,AHU06_S03F01,AHU07_S03F01,AHU08_S03F01,AHU09_S03F01,AHU10_S03F01,AHU11_S03F01)
        VALUES (@AUTOID,@DATETIME,@ACTIVE
            ,@AHU01_S03F01,@AHU02_S03F01,@AHU03_S03F01,@AHU04_S03F01,@AHU05_S03F01,@AHU06_S03F01,@AHU07_S03F01,@AHU08_S03F01,@AHU09_S03F01,@AHU10_S03F01,@AHU11_S03F01)
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_S03F.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, AHU_S03F.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "AHU01_S03F01", DbType.Single, AHU_S03F.AHU01_S03F01);
                        Db.AddInParameter(cmd, "AHU02_S03F01", DbType.Single, AHU_S03F.AHU02_S03F01);
                        Db.AddInParameter(cmd, "AHU03_S03F01", DbType.Single, AHU_S03F.AHU03_S03F01);
                        Db.AddInParameter(cmd, "AHU04_S03F01", DbType.Single, AHU_S03F.AHU04_S03F01);
                        Db.AddInParameter(cmd, "AHU05_S03F01", DbType.Single, AHU_S03F.AHU05_S03F01);
                        Db.AddInParameter(cmd, "AHU06_S03F01", DbType.Single, AHU_S03F.AHU06_S03F01);
                        Db.AddInParameter(cmd, "AHU07_S03F01", DbType.Single, AHU_S03F.AHU07_S03F01);
                        Db.AddInParameter(cmd, "AHU08_S03F01", DbType.Single, AHU_S03F.AHU08_S03F01);
                        Db.AddInParameter(cmd, "AHU09_S03F01", DbType.Single, AHU_S03F.AHU09_S03F01);
                        Db.AddInParameter(cmd, "AHU10_S03F01", DbType.Single, AHU_S03F.AHU10_S03F01);
                        Db.AddInParameter(cmd, "AHU11_S03F01", DbType.Single, AHU_S03F.AHU11_S03F01);

                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForAHU_SB1F(AHU_SB1F AHU_SB1F)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM AHU_SB1 WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO AHU_SB1 (AUTOID,DATETIME,ACTIVE
            ,AHU01_SB1F01,AHU02_SB1F01,AHU03_SB1F01,AHU04_SB1F01,AHU05_SB1F01,AHU06_SB1F01,AHU07_SB1F01,AHU08_SB1F01,AHU09_SB1F01,AHU10_SB1F01,AHU11_SB1F01
            ,AHU01_SB1F02,AHU02_SB1F02,AHU03_SB1F02,AHU04_SB1F02,AHU05_SB1F02,AHU06_SB1F02,AHU07_SB1F02,AHU08_SB1F02,AHU09_SB1F02,AHU10_SB1F02,AHU11_SB1F02)
        VALUES (@AUTOID,@DATETIME,@ACTIVE
            ,@AHU01_SB1F01,@AHU02_SB1F01,@AHU03_SB1F01,@AHU04_SB1F01,@AHU05_SB1F01,@AHU06_SB1F01,@AHU07_SB1F01,@AHU08_SB1F01,@AHU09_SB1F01,@AHU10_SB1F01,@AHU11_SB1F01
            ,@AHU01_SB1F02,@AHU02_SB1F02,@AHU03_SB1F02,@AHU04_SB1F02,@AHU05_SB1F02,@AHU06_SB1F02,@AHU07_SB1F02,@AHU08_SB1F02,@AHU09_SB1F02,@AHU10_SB1F02,@AHU11_SB1F02)
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_SB1F.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, AHU_SB1F.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "AHU01_SB1F01", DbType.Single, AHU_SB1F.AHU01_SB1F01);
                        Db.AddInParameter(cmd, "AHU02_SB1F01", DbType.Single, AHU_SB1F.AHU02_SB1F01);
                        Db.AddInParameter(cmd, "AHU03_SB1F01", DbType.Single, AHU_SB1F.AHU03_SB1F01);
                        Db.AddInParameter(cmd, "AHU04_SB1F01", DbType.Single, AHU_SB1F.AHU04_SB1F01);
                        Db.AddInParameter(cmd, "AHU05_SB1F01", DbType.Single, AHU_SB1F.AHU05_SB1F01);
                        Db.AddInParameter(cmd, "AHU06_SB1F01", DbType.Single, AHU_SB1F.AHU06_SB1F01);
                        Db.AddInParameter(cmd, "AHU07_SB1F01", DbType.Single, AHU_SB1F.AHU07_SB1F01);
                        Db.AddInParameter(cmd, "AHU08_SB1F01", DbType.Single, AHU_SB1F.AHU08_SB1F01);
                        Db.AddInParameter(cmd, "AHU09_SB1F01", DbType.Single, AHU_SB1F.AHU09_SB1F01);
                        Db.AddInParameter(cmd, "AHU10_SB1F01", DbType.Single, AHU_SB1F.AHU10_SB1F01);
                        Db.AddInParameter(cmd, "AHU11_SB1F01", DbType.Single, AHU_SB1F.AHU11_SB1F01);
                        Db.AddInParameter(cmd, "AHU01_SB1F02", DbType.Single, AHU_SB1F.AHU01_SB1F02);
                        Db.AddInParameter(cmd, "AHU02_SB1F02", DbType.Single, AHU_SB1F.AHU02_SB1F02);
                        Db.AddInParameter(cmd, "AHU03_SB1F02", DbType.Single, AHU_SB1F.AHU03_SB1F02);
                        Db.AddInParameter(cmd, "AHU04_SB1F02", DbType.Single, AHU_SB1F.AHU04_SB1F02);
                        Db.AddInParameter(cmd, "AHU05_SB1F02", DbType.Single, AHU_SB1F.AHU05_SB1F02);
                        Db.AddInParameter(cmd, "AHU06_SB1F02", DbType.Single, AHU_SB1F.AHU06_SB1F02);
                        Db.AddInParameter(cmd, "AHU07_SB1F02", DbType.Single, AHU_SB1F.AHU07_SB1F02);
                        Db.AddInParameter(cmd, "AHU08_SB1F02", DbType.Single, AHU_SB1F.AHU08_SB1F02);
                        Db.AddInParameter(cmd, "AHU09_SB1F02", DbType.Single, AHU_SB1F.AHU09_SB1F02);
                        Db.AddInParameter(cmd, "AHU10_SB1F02", DbType.Single, AHU_SB1F.AHU10_SB1F02);
                        Db.AddInParameter(cmd, "AHU11_SB1F02", DbType.Single, AHU_SB1F.AHU11_SB1F02);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForChiller(Chiller Chiller)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM Chiller WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO Chiller (AUTOID,DATETIME,ACTIVE
            ,Chiller01_R1,Chiller02_R1,Chiller03_R1,Chiller04_R1,Chiller05_R1,Chiller06_R1,Chiller07_R1,Chiller08_R1,Chiller09_R1,Chiller10_R1
            ,Chiller01_R2,Chiller02_R2,Chiller03_R2,Chiller04_R2,Chiller05_R2,Chiller06_R2,Chiller07_R2,Chiller08_R2,Chiller09_R2,Chiller10_R2
            ,Chiller01_R3,Chiller02_R3,Chiller03_R3,Chiller04_R3,Chiller05_R3,Chiller06_R3,Chiller07_R3,Chiller08_R3,Chiller09_R3,Chiller10_R3
            ,Chiller01_R6,Chiller02_R6,Chiller03_R6,Chiller04_R6,Chiller05_R6,Chiller06_R6,Chiller07_R6,Chiller08_R6,Chiller09_R6,Chiller10_R6)
        VALUES (@AUTOID,@DATETIME,@ACTIVE
            ,@Chiller01_R1,@Chiller02_R1,@Chiller03_R1,@Chiller04_R1,@Chiller05_R1,@Chiller06_R1,@Chiller07_R1,@Chiller08_R1,@Chiller09_R1,@Chiller10_R1
            ,@Chiller01_R2,@Chiller02_R2,@Chiller03_R2,@Chiller04_R2,@Chiller05_R2,@Chiller06_R2,@Chiller07_R2,@Chiller08_R2,@Chiller09_R2,@Chiller10_R2
            ,@Chiller01_R3,@Chiller02_R3,@Chiller03_R3,@Chiller04_R3,@Chiller05_R3,@Chiller06_R3,@Chiller07_R3,@Chiller08_R3,@Chiller09_R3,@Chiller10_R3
            ,@Chiller01_R6,@Chiller02_R6,@Chiller03_R6,@Chiller04_R6,@Chiller05_R6,@Chiller06_R6,@Chiller07_R6,@Chiller08_R6,@Chiller09_R6,@Chiller10_R6)
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, Chiller.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, Chiller.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "Chiller01_R1", DbType.Single, Chiller.Chiller01_R1);
                        Db.AddInParameter(cmd, "Chiller02_R1", DbType.Single, Chiller.Chiller02_R1);
                        Db.AddInParameter(cmd, "Chiller03_R1", DbType.Single, Chiller.Chiller03_R1);
                        Db.AddInParameter(cmd, "Chiller04_R1", DbType.Single, Chiller.Chiller04_R1);
                        Db.AddInParameter(cmd, "Chiller05_R1", DbType.Single, Chiller.Chiller05_R1);
                        Db.AddInParameter(cmd, "Chiller06_R1", DbType.Single, Chiller.Chiller06_R1);
                        Db.AddInParameter(cmd, "Chiller07_R1", DbType.Single, Chiller.Chiller07_R1);
                        Db.AddInParameter(cmd, "Chiller08_R1", DbType.Single, Chiller.Chiller08_R1);
                        Db.AddInParameter(cmd, "Chiller09_R1", DbType.Single, Chiller.Chiller09_R1);
                        Db.AddInParameter(cmd, "Chiller10_R1", DbType.Single, Chiller.Chiller10_R1);
                        Db.AddInParameter(cmd, "Chiller01_R2", DbType.Single, Chiller.Chiller01_R2);
                        Db.AddInParameter(cmd, "Chiller02_R2", DbType.Single, Chiller.Chiller02_R2);
                        Db.AddInParameter(cmd, "Chiller03_R2", DbType.Single, Chiller.Chiller03_R2);
                        Db.AddInParameter(cmd, "Chiller04_R2", DbType.Single, Chiller.Chiller04_R2);
                        Db.AddInParameter(cmd, "Chiller05_R2", DbType.Single, Chiller.Chiller05_R2);
                        Db.AddInParameter(cmd, "Chiller06_R2", DbType.Single, Chiller.Chiller06_R2);
                        Db.AddInParameter(cmd, "Chiller07_R2", DbType.Single, Chiller.Chiller07_R2);
                        Db.AddInParameter(cmd, "Chiller08_R2", DbType.Single, Chiller.Chiller08_R2);
                        Db.AddInParameter(cmd, "Chiller09_R2", DbType.Single, Chiller.Chiller09_R2);
                        Db.AddInParameter(cmd, "Chiller10_R2", DbType.Single, Chiller.Chiller10_R2);
                        Db.AddInParameter(cmd, "Chiller01_R3", DbType.Single, Chiller.Chiller01_R3);
                        Db.AddInParameter(cmd, "Chiller02_R3", DbType.Single, Chiller.Chiller02_R3);
                        Db.AddInParameter(cmd, "Chiller03_R3", DbType.Single, Chiller.Chiller03_R3);
                        Db.AddInParameter(cmd, "Chiller04_R3", DbType.Single, Chiller.Chiller04_R3);
                        Db.AddInParameter(cmd, "Chiller05_R3", DbType.Single, Chiller.Chiller05_R3);
                        Db.AddInParameter(cmd, "Chiller06_R3", DbType.Single, Chiller.Chiller06_R3);
                        Db.AddInParameter(cmd, "Chiller07_R3", DbType.Single, Chiller.Chiller07_R3);
                        Db.AddInParameter(cmd, "Chiller08_R3", DbType.Single, Chiller.Chiller08_R3);
                        Db.AddInParameter(cmd, "Chiller09_R3", DbType.Single, Chiller.Chiller09_R3);
                        Db.AddInParameter(cmd, "Chiller10_R3", DbType.Single, Chiller.Chiller10_R3);
                        Db.AddInParameter(cmd, "Chiller01_R6", DbType.Single, Chiller.Chiller01_R6);
                        Db.AddInParameter(cmd, "Chiller02_R6", DbType.Single, Chiller.Chiller02_R6);
                        Db.AddInParameter(cmd, "Chiller03_R6", DbType.Single, Chiller.Chiller03_R6);
                        Db.AddInParameter(cmd, "Chiller04_R6", DbType.Single, Chiller.Chiller04_R6);
                        Db.AddInParameter(cmd, "Chiller05_R6", DbType.Single, Chiller.Chiller05_R6);
                        Db.AddInParameter(cmd, "Chiller06_R6", DbType.Single, Chiller.Chiller06_R6);
                        Db.AddInParameter(cmd, "Chiller07_R6", DbType.Single, Chiller.Chiller07_R6);
                        Db.AddInParameter(cmd, "Chiller08_R6", DbType.Single, Chiller.Chiller08_R6);
                        Db.AddInParameter(cmd, "Chiller09_R6", DbType.Single, Chiller.Chiller09_R6);
                        Db.AddInParameter(cmd, "Chiller10_R6", DbType.Single, Chiller.Chiller10_R6);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForCOP(COP COP)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM COP WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO COP (AUTOID,DATETIME,ACTIVE
            ,COP01_001,COP02_001,COP03_001,COP04_001,COP05_001
            ,COP01_002,COP02_002,COP03_002,COP04_002,COP05_002
            ,COP01_003,COP02_003,COP03_003,COP04_003,COP05_003
            ,COP01_006,COP02_006,COP03_006,COP04_006,COP05_006
            ,COP01_12S,COP02_12S,COP03_12S,COP04_12S,COP05_12S
            ,COP01_03S,COP02_03S,COP03_03S,COP04_03S,COP05_03S
            ,COP01_06S,COP02_06S,COP03_06S,COP04_06S,COP05_06S)
        VALUES (@AUTOID,@DATETIME,@ACTIVE
            ,@COP01_001,@COP02_001,@COP03_001,@COP04_001,@COP05_001
            ,@COP01_002,@COP02_002,@COP03_002,@COP04_002,@COP05_002
            ,@COP01_003,@COP02_003,@COP03_003,@COP04_003,@COP05_003
            ,@COP01_006,@COP02_006,@COP03_006,@COP04_006,@COP05_006
            ,@COP01_12S,@COP02_12S,@COP03_12S,@COP04_12S,@COP05_12S
            ,@COP01_03S,@COP02_03S,@COP03_03S,@COP04_03S,@COP05_03S
            ,@COP01_06S,@COP02_06S,@COP03_06S,@COP04_06S,@COP05_06S)
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, COP.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, COP.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "COP01_001", DbType.Single, COP.COP01_001);
                        Db.AddInParameter(cmd, "COP02_001", DbType.Single, COP.COP02_001);
                        Db.AddInParameter(cmd, "COP03_001", DbType.Single, COP.COP03_001);
                        Db.AddInParameter(cmd, "COP04_001", DbType.Single, COP.COP04_001);
                        Db.AddInParameter(cmd, "COP05_001", DbType.Single, COP.COP05_001);
                        Db.AddInParameter(cmd, "COP01_002", DbType.Single, COP.COP01_002);
                        Db.AddInParameter(cmd, "COP02_002", DbType.Single, COP.COP02_002);
                        Db.AddInParameter(cmd, "COP03_002", DbType.Single, COP.COP03_002);
                        Db.AddInParameter(cmd, "COP04_002", DbType.Single, COP.COP04_002);
                        Db.AddInParameter(cmd, "COP05_002", DbType.Single, COP.COP05_002);
                        Db.AddInParameter(cmd, "COP01_003", DbType.Single, COP.COP01_003);
                        Db.AddInParameter(cmd, "COP02_003", DbType.Single, COP.COP02_003);
                        Db.AddInParameter(cmd, "COP03_003", DbType.Single, COP.COP03_003);
                        Db.AddInParameter(cmd, "COP04_003", DbType.Single, COP.COP04_003);
                        Db.AddInParameter(cmd, "COP05_003", DbType.Single, COP.COP05_003);
                        Db.AddInParameter(cmd, "COP01_006", DbType.Single, COP.COP01_006);
                        Db.AddInParameter(cmd, "COP02_006", DbType.Single, COP.COP02_006);
                        Db.AddInParameter(cmd, "COP03_006", DbType.Single, COP.COP03_006);
                        Db.AddInParameter(cmd, "COP04_006", DbType.Single, COP.COP04_006);
                        Db.AddInParameter(cmd, "COP05_006", DbType.Single, COP.COP05_006);
                        Db.AddInParameter(cmd, "COP01_12S", DbType.Single, COP.COP01_12S);
                        Db.AddInParameter(cmd, "COP02_12S", DbType.Single, COP.COP02_12S);
                        Db.AddInParameter(cmd, "COP03_12S", DbType.Single, COP.COP03_12S);
                        Db.AddInParameter(cmd, "COP04_12S", DbType.Single, COP.COP04_12S);
                        Db.AddInParameter(cmd, "COP05_12S", DbType.Single, COP.COP05_12S);
                        Db.AddInParameter(cmd, "COP01_03S", DbType.Single, COP.COP01_03S);
                        Db.AddInParameter(cmd, "COP02_03S", DbType.Single, COP.COP02_03S);
                        Db.AddInParameter(cmd, "COP03_03S", DbType.Single, COP.COP03_03S);
                        Db.AddInParameter(cmd, "COP04_03S", DbType.Single, COP.COP04_03S);
                        Db.AddInParameter(cmd, "COP05_03S", DbType.Single, COP.COP05_03S);
                        Db.AddInParameter(cmd, "COP01_06S", DbType.Single, COP.COP01_06S);
                        Db.AddInParameter(cmd, "COP02_06S", DbType.Single, COP.COP02_06S);
                        Db.AddInParameter(cmd, "COP03_06S", DbType.Single, COP.COP03_06S);
                        Db.AddInParameter(cmd, "COP04_06S", DbType.Single, COP.COP04_06S);
                        Db.AddInParameter(cmd, "COP05_06S", DbType.Single, COP.COP05_06S);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForCP(CP CP)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM CP WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO CP (AUTOID,DATETIME,ACTIVE
            ,CP01_01,CP02_01,CP03_01,CP04_01,CP05_01,CP06_01,CP07_01
            ,CP01_02,CP02_02,CP03_02,CP04_02,CP05_02,CP06_02,CP07_02
            ,CP01_03,CP02_03,CP03_03,CP04_03,CP05_03,CP06_03,CP07_03
            ,CP01_06,CP02_06,CP03_06,CP04_06,CP05_06,CP06_06,CP07_06
            ,CP01_0S,CP02_0S,CP03_0S,CP04_0S,CP05_0S,CP06_0S,CP07_0S)
        VALUES (@AUTOID,@DATETIME,@ACTIVE
            ,@CP01_01,@CP02_01,@CP03_01,@CP04_01,@CP05_01,@CP06_01,@CP07_01
            ,@CP01_02,@CP02_02,@CP03_02,@CP04_02,@CP05_02,@CP06_02,@CP07_02
            ,@CP01_03,@CP02_03,@CP03_03,@CP04_03,@CP05_03,@CP06_03,@CP07_03
            ,@CP01_06,@CP02_06,@CP03_06,@CP04_06,@CP05_06,@CP06_06,@CP07_06
            ,@CP01_0S,@CP02_0S,@CP03_0S,@CP04_0S,@CP05_0S,@CP06_0S,@CP07_0S)
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, CP.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, CP.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "CP01_01", DbType.Single, CP.CP01_01);
                        Db.AddInParameter(cmd, "CP02_01", DbType.Single, CP.CP02_01);
                        Db.AddInParameter(cmd, "CP03_01", DbType.Single, CP.CP03_01);
                        Db.AddInParameter(cmd, "CP04_01", DbType.Single, CP.CP04_01);
                        Db.AddInParameter(cmd, "CP05_01", DbType.Single, CP.CP05_01);
                        Db.AddInParameter(cmd, "CP06_01", DbType.Single, CP.CP06_01);
                        Db.AddInParameter(cmd, "CP07_01", DbType.Single, CP.CP07_01);
                        Db.AddInParameter(cmd, "CP01_02", DbType.Single, CP.CP01_02);
                        Db.AddInParameter(cmd, "CP02_02", DbType.Single, CP.CP02_02);
                        Db.AddInParameter(cmd, "CP03_02", DbType.Single, CP.CP03_02);
                        Db.AddInParameter(cmd, "CP04_02", DbType.Single, CP.CP04_02);
                        Db.AddInParameter(cmd, "CP05_02", DbType.Single, CP.CP05_02);
                        Db.AddInParameter(cmd, "CP06_02", DbType.Single, CP.CP06_02);
                        Db.AddInParameter(cmd, "CP07_02", DbType.Single, CP.CP07_02);
                        Db.AddInParameter(cmd, "CP01_03", DbType.Single, CP.CP01_03);
                        Db.AddInParameter(cmd, "CP02_03", DbType.Single, CP.CP02_03);
                        Db.AddInParameter(cmd, "CP03_03", DbType.Single, CP.CP03_03);
                        Db.AddInParameter(cmd, "CP04_03", DbType.Single, CP.CP04_03);
                        Db.AddInParameter(cmd, "CP05_03", DbType.Single, CP.CP05_03);
                        Db.AddInParameter(cmd, "CP06_03", DbType.Single, CP.CP06_03);
                        Db.AddInParameter(cmd, "CP07_03", DbType.Single, CP.CP07_03);
                        Db.AddInParameter(cmd, "CP01_06", DbType.Single, CP.CP01_06);
                        Db.AddInParameter(cmd, "CP02_06", DbType.Single, CP.CP02_06);
                        Db.AddInParameter(cmd, "CP03_06", DbType.Single, CP.CP03_06);
                        Db.AddInParameter(cmd, "CP04_06", DbType.Single, CP.CP04_06);
                        Db.AddInParameter(cmd, "CP05_06", DbType.Single, CP.CP05_06);
                        Db.AddInParameter(cmd, "CP06_06", DbType.Single, CP.CP06_06);
                        Db.AddInParameter(cmd, "CP07_06", DbType.Single, CP.CP07_06);
                        Db.AddInParameter(cmd, "CP01_0S", DbType.Single, CP.CP01_0S);
                        Db.AddInParameter(cmd, "CP02_0S", DbType.Single, CP.CP02_0S);
                        Db.AddInParameter(cmd, "CP03_0S", DbType.Single, CP.CP03_0S);
                        Db.AddInParameter(cmd, "CP04_0S", DbType.Single, CP.CP04_0S);
                        Db.AddInParameter(cmd, "CP05_0S", DbType.Single, CP.CP05_0S);
                        Db.AddInParameter(cmd, "CP06_0S", DbType.Single, CP.CP06_0S);
                        Db.AddInParameter(cmd, "CP07_0S", DbType.Single, CP.CP07_0S);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForCT(CT CT)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();
                    //此項先取消,CT01_06,CT02_06,CT03_06,CT04_06,CT05_06,CT06_06,CT07_06 
                    //,@CT01_06,@CT02_06,@CT03_06,@CT04_06,@CT05_06,@CT06_06,@CT07_06
                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM CT WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO CT (AUTOID,DATETIME,ACTIVE
            ,CT01_01,CT02_01,CT03_01,CT04_01,CT05_01,CT06_01,CT07_01
            ,CT01_02,CT02_02,CT03_02,CT04_02,CT05_02,CT06_02,CT07_02
            ,CT01_03,CT02_03,CT03_03,CT04_03,CT05_03,CT06_03,CT07_03
            ,CT01_04,CT02_04,CT03_04,CT04_04,CT05_04,CT06_04,CT07_04
            ,CT01_05,CT02_05,CT03_05,CT04_05,CT05_05,CT06_05,CT07_05)
            
        VALUES (@AUTOID,@DATETIME,@ACTIVE
            ,@CT01_01,@CT02_01,@CT03_01,@CT04_01,@CT05_01,@CT06_01,@CT07_01
            ,@CT01_02,@CT02_02,@CT03_02,@CT04_02,@CT05_02,@CT06_02,@CT07_02
            ,@CT01_03,@CT02_03,@CT03_03,@CT04_03,@CT05_03,@CT06_03,@CT07_03
            ,@CT01_04,@CT02_04,@CT03_04,@CT04_04,@CT05_04,@CT06_04,@CT07_04
            ,@CT01_05,@CT02_05,@CT03_05,@CT04_05,@CT05_05,@CT06_05,@CT07_05)
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, CT.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, CT.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "CT01_01", DbType.Single, CT.CT01_01);
                        Db.AddInParameter(cmd, "CT02_01", DbType.Single, CT.CT02_01);
                        Db.AddInParameter(cmd, "CT03_01", DbType.Single, CT.CT03_01);
                        Db.AddInParameter(cmd, "CT04_01", DbType.Single, CT.CT04_01);
                        Db.AddInParameter(cmd, "CT05_01", DbType.Single, CT.CT05_01);
                        Db.AddInParameter(cmd, "CT06_01", DbType.Single, CT.CT06_01);
                        Db.AddInParameter(cmd, "CT07_01", DbType.Single, CT.CT07_01);
                        Db.AddInParameter(cmd, "CT01_02", DbType.Single, CT.CT01_02);
                        Db.AddInParameter(cmd, "CT02_02", DbType.Single, CT.CT02_02);
                        Db.AddInParameter(cmd, "CT03_02", DbType.Single, CT.CT03_02);
                        Db.AddInParameter(cmd, "CT04_02", DbType.Single, CT.CT04_02);
                        Db.AddInParameter(cmd, "CT05_02", DbType.Single, CT.CT05_02);
                        Db.AddInParameter(cmd, "CT06_02", DbType.Single, CT.CT06_02);
                        Db.AddInParameter(cmd, "CT07_02", DbType.Single, CT.CT07_02);
                        Db.AddInParameter(cmd, "CT01_03", DbType.Single, CT.CT01_03);
                        Db.AddInParameter(cmd, "CT02_03", DbType.Single, CT.CT02_03);
                        Db.AddInParameter(cmd, "CT03_03", DbType.Single, CT.CT03_03);
                        Db.AddInParameter(cmd, "CT04_03", DbType.Single, CT.CT04_03);
                        Db.AddInParameter(cmd, "CT05_03", DbType.Single, CT.CT05_03);
                        Db.AddInParameter(cmd, "CT06_03", DbType.Single, CT.CT06_03);
                        Db.AddInParameter(cmd, "CT07_03", DbType.Single, CT.CT07_03);
                        Db.AddInParameter(cmd, "CT01_04", DbType.Single, CT.CT01_04);
                        Db.AddInParameter(cmd, "CT02_04", DbType.Single, CT.CT02_04);
                        Db.AddInParameter(cmd, "CT03_04", DbType.Single, CT.CT03_04);
                        Db.AddInParameter(cmd, "CT04_04", DbType.Single, CT.CT04_04);
                        Db.AddInParameter(cmd, "CT05_04", DbType.Single, CT.CT05_04);
                        Db.AddInParameter(cmd, "CT06_04", DbType.Single, CT.CT06_04);
                        Db.AddInParameter(cmd, "CT07_04", DbType.Single, CT.CT07_04);
                        Db.AddInParameter(cmd, "CT01_05", DbType.Single, CT.CT01_05);
                        Db.AddInParameter(cmd, "CT02_05", DbType.Single, CT.CT02_05);
                        Db.AddInParameter(cmd, "CT03_05", DbType.Single, CT.CT03_05);
                        Db.AddInParameter(cmd, "CT04_05", DbType.Single, CT.CT04_05);
                        Db.AddInParameter(cmd, "CT05_05", DbType.Single, CT.CT05_05);
                        Db.AddInParameter(cmd, "CT06_05", DbType.Single, CT.CT06_05);
                        Db.AddInParameter(cmd, "CT07_05", DbType.Single, CT.CT07_05);
                        //Db.AddInParameter(cmd, "CT01_06", DbType.Single, CT.CT01_06);
                        //Db.AddInParameter(cmd, "CT02_06", DbType.Single, CT.CT02_06);
                        //Db.AddInParameter(cmd, "CT03_06", DbType.Single, CT.CT03_06);
                        //Db.AddInParameter(cmd, "CT04_06", DbType.Single, CT.CT04_06);
                        //Db.AddInParameter(cmd, "CT05_06", DbType.Single, CT.CT05_06);
                        //Db.AddInParameter(cmd, "CT06_06", DbType.Single, CT.CT06_06);
                        //Db.AddInParameter(cmd, "CT07_06", DbType.Single, CT.CT07_06);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForRRS(RRS RRS)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM RRS WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO RRS (AUTOID,DATETIME,ACTIVE
            ,RRS01_VFLH01,RRS02_VFLH01,RRS03_VFLH01,RRS04_VFLH01,RRS05_VFLH01,RRS06_VFLH01
            ,RRS01_PVOI01,RRS02_PVOI01,RRS03_PVOI01,RRS04_PVOI01,RRS05_PVOI01,RRS06_PVOI01,RRS07_PVOI01
            ,RRS01_PWLS01,RRS02_PWLS01,RRS03_PWLS01,RRS04_PWLS01,RRS05_PWLS01,RRS06_PWLS01,RRS07_PWLS01,RRS08_PWLS01,RRS09_PWLS01,RRS10_PWLS01,RRS11_PWLS01,RRS12_PWLS01,RRS13_PWLS01)
        VALUES (@AUTOID,@DATETIME,@ACTIVE
            ,@RRS01_VFLH01,@RRS02_VFLH01,@RRS03_VFLH01,@RRS04_VFLH01,@RRS05_VFLH01,@RRS06_VFLH01
            ,@RRS01_PVOI01,@RRS02_PVOI01,@RRS03_PVOI01,@RRS04_PVOI01,@RRS05_PVOI01,@RRS06_PVOI01,@RRS07_PVOI01
            ,@RRS01_PWLS01,@RRS02_PWLS01,@RRS03_PWLS01,@RRS04_PWLS01,@RRS05_PWLS01,@RRS06_PWLS01,@RRS07_PWLS01,@RRS08_PWLS01,@RRS09_PWLS01,@RRS10_PWLS01,@RRS11_PWLS01,@RRS12_PWLS01,@RRS13_PWLS01)
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, RRS.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, RRS.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");

                        Db.AddInParameter(cmd, "RRS01_VFLH01", DbType.Single, RRS.RRS01_VFLH01);
                        Db.AddInParameter(cmd, "RRS02_VFLH01", DbType.Single, RRS.RRS02_VFLH01);
                        Db.AddInParameter(cmd, "RRS03_VFLH01", DbType.Single, RRS.RRS03_VFLH01);
                        Db.AddInParameter(cmd, "RRS04_VFLH01", DbType.Single, RRS.RRS04_VFLH01);
                        Db.AddInParameter(cmd, "RRS05_VFLH01", DbType.Single, RRS.RRS05_VFLH01);
                        Db.AddInParameter(cmd, "RRS06_VFLH01", DbType.Single, RRS.RRS06_VFLH01);

                        Db.AddInParameter(cmd, "RRS01_PVOI01", DbType.Single, RRS.RRS01_PVOI01);
                        Db.AddInParameter(cmd, "RRS02_PVOI01", DbType.Single, RRS.RRS02_PVOI01);
                        Db.AddInParameter(cmd, "RRS03_PVOI01", DbType.Single, RRS.RRS03_PVOI01);
                        Db.AddInParameter(cmd, "RRS04_PVOI01", DbType.Single, RRS.RRS04_PVOI01);
                        Db.AddInParameter(cmd, "RRS05_PVOI01", DbType.Single, RRS.RRS05_PVOI01);
                        Db.AddInParameter(cmd, "RRS06_PVOI01", DbType.Single, RRS.RRS06_PVOI01);
                        Db.AddInParameter(cmd, "RRS07_PVOI01", DbType.Single, RRS.RRS07_PVOI01);

                        Db.AddInParameter(cmd, "RRS01_PWLS01", DbType.Single, RRS.RRS01_PWLS01);
                        Db.AddInParameter(cmd, "RRS02_PWLS01", DbType.Single, RRS.RRS02_PWLS01);
                        Db.AddInParameter(cmd, "RRS03_PWLS01", DbType.Single, RRS.RRS03_PWLS01);
                        Db.AddInParameter(cmd, "RRS04_PWLS01", DbType.Single, RRS.RRS04_PWLS01);
                        Db.AddInParameter(cmd, "RRS05_PWLS01", DbType.Single, RRS.RRS05_PWLS01);
                        Db.AddInParameter(cmd, "RRS06_PWLS01", DbType.Single, RRS.RRS06_PWLS01);
                        Db.AddInParameter(cmd, "RRS07_PWLS01", DbType.Single, RRS.RRS07_PWLS01);
                        Db.AddInParameter(cmd, "RRS08_PWLS01", DbType.Single, RRS.RRS08_PWLS01);
                        Db.AddInParameter(cmd, "RRS09_PWLS01", DbType.Single, RRS.RRS09_PWLS01);
                        Db.AddInParameter(cmd, "RRS10_PWLS01", DbType.Single, RRS.RRS10_PWLS01);
                        Db.AddInParameter(cmd, "RRS11_PWLS01", DbType.Single, RRS.RRS11_PWLS01);
                        Db.AddInParameter(cmd, "RRS12_PWLS01", DbType.Single, RRS.RRS12_PWLS01);
                        Db.AddInParameter(cmd, "RRS13_PWLS01", DbType.Single, RRS.RRS13_PWLS01);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForWSDS(WSDS WSDS)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM WSDS WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO WSDS (AUTOID,DATETIME,ACTIVE
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
            ,WSDS57_PWLS01,WSDS58_PWLS01)
        VALUES (@AUTOID,@DATETIME,@ACTIVE
            ,@WSDS01_PVOI01,@WSDS02_PVOI01,@WSDS03_PVOI01,@WSDS04_PVOI01,@WSDS05_PVOI01,@WSDS06_PVOI01,@WSDS07_PVOI01,@WSDS08_PVOI01
            ,@WSDS09_PVOI01,@WSDS10_PVOI01,@WSDS11_PVOI01,@WSDS12_PVOI01,@WSDS13_PVOI01,@WSDS14_PVOI01,@WSDS15_PVOI01,@WSDS16_PVOI01
            ,@WSDS17_PVOI01,@WSDS18_PVOI01,@WSDS19_PVOI01,@WSDS20_PVOI01,@WSDS21_PVOI01,@WSDS22_PVOI01,@WSDS23_PVOI01,@WSDS24_PVOI01
            ,@WSDS25_PVOI01,@WSDS26_PVOI01
            ,@WSDS01_PWLS01,@WSDS02_PWLS01,@WSDS03_PWLS01,@WSDS04_PWLS01,@WSDS05_PWLS01,@WSDS06_PWLS01,@WSDS07_PWLS01,@WSDS08_PWLS01
            ,@WSDS09_PWLS01,@WSDS10_PWLS01,@WSDS11_PWLS01,@WSDS12_PWLS01,@WSDS13_PWLS01,@WSDS14_PWLS01,@WSDS15_PWLS01,@WSDS16_PWLS01
            ,@WSDS17_PWLS01,@WSDS18_PWLS01,@WSDS19_PWLS01,@WSDS20_PWLS01,@WSDS21_PWLS01,@WSDS22_PWLS01,@WSDS23_PWLS01,@WSDS24_PWLS01
            ,@WSDS25_PWLS01,@WSDS26_PWLS01,@WSDS27_PWLS01,@WSDS28_PWLS01,@WSDS29_PWLS01,@WSDS30_PWLS01,@WSDS31_PWLS01,@WSDS32_PWLS01
            ,@WSDS33_PWLS01,@WSDS34_PWLS01,@WSDS35_PWLS01,@WSDS36_PWLS01,@WSDS37_PWLS01,@WSDS38_PWLS01,@WSDS39_PWLS01,@WSDS40_PWLS01
            ,@WSDS41_PWLS01,@WSDS42_PWLS01,@WSDS43_PWLS01,@WSDS44_PWLS01,@WSDS45_PWLS01,@WSDS46_PWLS01,@WSDS47_PWLS01,@WSDS48_PWLS01
            ,@WSDS49_PWLS01,@WSDS50_PWLS01,@WSDS51_PWLS01,@WSDS52_PWLS01,@WSDS53_PWLS01,@WSDS54_PWLS01,@WSDS55_PWLS01,@WSDS56_PWLS01
            ,@WSDS57_PWLS01,@WSDS58_PWLS01)
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, WSDS.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, WSDS.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");

                        Db.AddInParameter(cmd, "WSDS01_PVOI01", DbType.Single, WSDS.WSDS01_PVOI01);
                        Db.AddInParameter(cmd, "WSDS02_PVOI01", DbType.Single, WSDS.WSDS02_PVOI01);
                        Db.AddInParameter(cmd, "WSDS03_PVOI01", DbType.Single, WSDS.WSDS03_PVOI01);
                        Db.AddInParameter(cmd, "WSDS04_PVOI01", DbType.Single, WSDS.WSDS04_PVOI01);
                        Db.AddInParameter(cmd, "WSDS05_PVOI01", DbType.Single, WSDS.WSDS05_PVOI01);
                        Db.AddInParameter(cmd, "WSDS06_PVOI01", DbType.Single, WSDS.WSDS06_PVOI01);
                        Db.AddInParameter(cmd, "WSDS07_PVOI01", DbType.Single, WSDS.WSDS07_PVOI01);
                        Db.AddInParameter(cmd, "WSDS08_PVOI01", DbType.Single, WSDS.WSDS08_PVOI01);
                        Db.AddInParameter(cmd, "WSDS09_PVOI01", DbType.Single, WSDS.WSDS09_PVOI01);
                        Db.AddInParameter(cmd, "WSDS10_PVOI01", DbType.Single, WSDS.WSDS10_PVOI01);
                        Db.AddInParameter(cmd, "WSDS11_PVOI01", DbType.Single, WSDS.WSDS11_PVOI01);
                        Db.AddInParameter(cmd, "WSDS12_PVOI01", DbType.Single, WSDS.WSDS12_PVOI01);
                        Db.AddInParameter(cmd, "WSDS13_PVOI01", DbType.Single, WSDS.WSDS13_PVOI01);
                        Db.AddInParameter(cmd, "WSDS14_PVOI01", DbType.Single, WSDS.WSDS14_PVOI01);
                        Db.AddInParameter(cmd, "WSDS15_PVOI01", DbType.Single, WSDS.WSDS15_PVOI01);
                        Db.AddInParameter(cmd, "WSDS16_PVOI01", DbType.Single, WSDS.WSDS16_PVOI01);
                        Db.AddInParameter(cmd, "WSDS17_PVOI01", DbType.Single, WSDS.WSDS17_PVOI01);
                        Db.AddInParameter(cmd, "WSDS18_PVOI01", DbType.Single, WSDS.WSDS18_PVOI01);
                        Db.AddInParameter(cmd, "WSDS19_PVOI01", DbType.Single, WSDS.WSDS19_PVOI01);
                        Db.AddInParameter(cmd, "WSDS20_PVOI01", DbType.Single, WSDS.WSDS20_PVOI01);
                        Db.AddInParameter(cmd, "WSDS21_PVOI01", DbType.Single, WSDS.WSDS21_PVOI01);
                        Db.AddInParameter(cmd, "WSDS22_PVOI01", DbType.Single, WSDS.WSDS22_PVOI01);
                        Db.AddInParameter(cmd, "WSDS23_PVOI01", DbType.Single, WSDS.WSDS23_PVOI01);
                        Db.AddInParameter(cmd, "WSDS24_PVOI01", DbType.Single, WSDS.WSDS24_PVOI01);
                        Db.AddInParameter(cmd, "WSDS25_PVOI01", DbType.Single, WSDS.WSDS25_PVOI01);
                        Db.AddInParameter(cmd, "WSDS26_PVOI01", DbType.Single, WSDS.WSDS26_PVOI01);

                        Db.AddInParameter(cmd, "WSDS01_PWLS01", DbType.Single, WSDS.WSDS01_PWLS01);
                        Db.AddInParameter(cmd, "WSDS02_PWLS01", DbType.Single, WSDS.WSDS02_PWLS01);
                        Db.AddInParameter(cmd, "WSDS03_PWLS01", DbType.Single, WSDS.WSDS03_PWLS01);
                        Db.AddInParameter(cmd, "WSDS04_PWLS01", DbType.Single, WSDS.WSDS04_PWLS01);
                        Db.AddInParameter(cmd, "WSDS05_PWLS01", DbType.Single, WSDS.WSDS05_PWLS01);
                        Db.AddInParameter(cmd, "WSDS06_PWLS01", DbType.Single, WSDS.WSDS06_PWLS01);
                        Db.AddInParameter(cmd, "WSDS07_PWLS01", DbType.Single, WSDS.WSDS07_PWLS01);
                        Db.AddInParameter(cmd, "WSDS08_PWLS01", DbType.Single, WSDS.WSDS08_PWLS01);
                        Db.AddInParameter(cmd, "WSDS09_PWLS01", DbType.Single, WSDS.WSDS09_PWLS01);
                        Db.AddInParameter(cmd, "WSDS10_PWLS01", DbType.Single, WSDS.WSDS10_PWLS01);
                        Db.AddInParameter(cmd, "WSDS11_PWLS01", DbType.Single, WSDS.WSDS11_PWLS01);
                        Db.AddInParameter(cmd, "WSDS12_PWLS01", DbType.Single, WSDS.WSDS12_PWLS01);
                        Db.AddInParameter(cmd, "WSDS13_PWLS01", DbType.Single, WSDS.WSDS13_PWLS01);
                        Db.AddInParameter(cmd, "WSDS14_PWLS01", DbType.Single, WSDS.WSDS14_PWLS01);
                        Db.AddInParameter(cmd, "WSDS15_PWLS01", DbType.Single, WSDS.WSDS15_PWLS01);
                        Db.AddInParameter(cmd, "WSDS16_PWLS01", DbType.Single, WSDS.WSDS16_PWLS01);
                        Db.AddInParameter(cmd, "WSDS17_PWLS01", DbType.Single, WSDS.WSDS17_PWLS01);
                        Db.AddInParameter(cmd, "WSDS18_PWLS01", DbType.Single, WSDS.WSDS18_PWLS01);
                        Db.AddInParameter(cmd, "WSDS19_PWLS01", DbType.Single, WSDS.WSDS19_PWLS01);
                        Db.AddInParameter(cmd, "WSDS20_PWLS01", DbType.Single, WSDS.WSDS20_PWLS01);
                        Db.AddInParameter(cmd, "WSDS21_PWLS01", DbType.Single, WSDS.WSDS21_PWLS01);
                        Db.AddInParameter(cmd, "WSDS22_PWLS01", DbType.Single, WSDS.WSDS22_PWLS01);
                        Db.AddInParameter(cmd, "WSDS23_PWLS01", DbType.Single, WSDS.WSDS23_PWLS01);
                        Db.AddInParameter(cmd, "WSDS24_PWLS01", DbType.Single, WSDS.WSDS24_PWLS01);
                        Db.AddInParameter(cmd, "WSDS25_PWLS01", DbType.Single, WSDS.WSDS25_PWLS01);
                        Db.AddInParameter(cmd, "WSDS26_PWLS01", DbType.Single, WSDS.WSDS26_PWLS01);
                        Db.AddInParameter(cmd, "WSDS27_PWLS01", DbType.Single, WSDS.WSDS27_PWLS01);
                        Db.AddInParameter(cmd, "WSDS28_PWLS01", DbType.Single, WSDS.WSDS28_PWLS01);
                        Db.AddInParameter(cmd, "WSDS29_PWLS01", DbType.Single, WSDS.WSDS29_PWLS01);
                        Db.AddInParameter(cmd, "WSDS30_PWLS01", DbType.Single, WSDS.WSDS30_PWLS01);
                        Db.AddInParameter(cmd, "WSDS31_PWLS01", DbType.Single, WSDS.WSDS31_PWLS01);
                        Db.AddInParameter(cmd, "WSDS32_PWLS01", DbType.Single, WSDS.WSDS32_PWLS01);
                        Db.AddInParameter(cmd, "WSDS33_PWLS01", DbType.Single, WSDS.WSDS33_PWLS01);
                        Db.AddInParameter(cmd, "WSDS34_PWLS01", DbType.Single, WSDS.WSDS34_PWLS01);
                        Db.AddInParameter(cmd, "WSDS35_PWLS01", DbType.Single, WSDS.WSDS35_PWLS01);
                        Db.AddInParameter(cmd, "WSDS36_PWLS01", DbType.Single, WSDS.WSDS36_PWLS01);
                        Db.AddInParameter(cmd, "WSDS37_PWLS01", DbType.Single, WSDS.WSDS37_PWLS01);
                        Db.AddInParameter(cmd, "WSDS38_PWLS01", DbType.Single, WSDS.WSDS38_PWLS01);
                        Db.AddInParameter(cmd, "WSDS39_PWLS01", DbType.Single, WSDS.WSDS39_PWLS01);
                        Db.AddInParameter(cmd, "WSDS40_PWLS01", DbType.Single, WSDS.WSDS40_PWLS01);
                        Db.AddInParameter(cmd, "WSDS41_PWLS01", DbType.Single, WSDS.WSDS41_PWLS01);
                        Db.AddInParameter(cmd, "WSDS42_PWLS01", DbType.Single, WSDS.WSDS42_PWLS01);
                        Db.AddInParameter(cmd, "WSDS43_PWLS01", DbType.Single, WSDS.WSDS43_PWLS01);
                        Db.AddInParameter(cmd, "WSDS44_PWLS01", DbType.Single, WSDS.WSDS44_PWLS01);
                        Db.AddInParameter(cmd, "WSDS45_PWLS01", DbType.Single, WSDS.WSDS45_PWLS01);
                        Db.AddInParameter(cmd, "WSDS46_PWLS01", DbType.Single, WSDS.WSDS46_PWLS01);
                        Db.AddInParameter(cmd, "WSDS47_PWLS01", DbType.Single, WSDS.WSDS47_PWLS01);
                        Db.AddInParameter(cmd, "WSDS48_PWLS01", DbType.Single, WSDS.WSDS48_PWLS01);
                        Db.AddInParameter(cmd, "WSDS49_PWLS01", DbType.Single, WSDS.WSDS49_PWLS01);
                        Db.AddInParameter(cmd, "WSDS50_PWLS01", DbType.Single, WSDS.WSDS50_PWLS01);
                        Db.AddInParameter(cmd, "WSDS51_PWLS01", DbType.Single, WSDS.WSDS51_PWLS01);
                        Db.AddInParameter(cmd, "WSDS52_PWLS01", DbType.Single, WSDS.WSDS52_PWLS01);
                        Db.AddInParameter(cmd, "WSDS53_PWLS01", DbType.Single, WSDS.WSDS53_PWLS01);
                        Db.AddInParameter(cmd, "WSDS54_PWLS01", DbType.Single, WSDS.WSDS54_PWLS01);
                        Db.AddInParameter(cmd, "WSDS55_PWLS01", DbType.Single, WSDS.WSDS55_PWLS01);
                        Db.AddInParameter(cmd, "WSDS56_PWLS01", DbType.Single, WSDS.WSDS56_PWLS01);
                        Db.AddInParameter(cmd, "WSDS57_PWLS01", DbType.Single, WSDS.WSDS57_PWLS01);
                        Db.AddInParameter(cmd, "WSDS58_PWLS01", DbType.Single, WSDS.WSDS58_PWLS01);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForZP1(ZP1 ZP1)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM ZP1 WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO ZP1 (AUTOID,DATETIME,ACTIVE
            ,ZP101_00,ZP102_00,ZP104_00,ZP105_00,ZP106_00,ZP107_00,ZP108_00,ZP109_00,ZP110_00,ZP111_00
            ,ZP101_01,ZP102_01,ZP104_01,ZP105_01,ZP106_01,ZP107_01,ZP108_01,ZP109_01,ZP110_01,ZP111_01)
        VALUES (@AUTOID,@DATETIME,@ACTIVE
            ,@ZP101_00,@ZP102_00,@ZP104_00,@ZP105_00,@ZP106_00,@ZP107_00,@ZP108_00,@ZP109_00,@ZP110_00,@ZP111_00
            ,@ZP101_01,@ZP102_01,@ZP104_01,@ZP105_01,@ZP106_01,@ZP107_01,@ZP108_01,@ZP109_01,@ZP110_01,@ZP111_01)
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, ZP1.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, ZP1.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "ZP101_00", DbType.Single, ZP1.ZP101_00);
                        Db.AddInParameter(cmd, "ZP102_00", DbType.Single, ZP1.ZP102_00);
                        Db.AddInParameter(cmd, "ZP104_00", DbType.Single, ZP1.ZP104_00);
                        Db.AddInParameter(cmd, "ZP105_00", DbType.Single, ZP1.ZP105_00);
                        Db.AddInParameter(cmd, "ZP106_00", DbType.Single, ZP1.ZP106_00);
                        Db.AddInParameter(cmd, "ZP107_00", DbType.Single, ZP1.ZP107_00);
                        Db.AddInParameter(cmd, "ZP108_00", DbType.Single, ZP1.ZP108_00);
                        Db.AddInParameter(cmd, "ZP109_00", DbType.Single, ZP1.ZP109_00);
                        Db.AddInParameter(cmd, "ZP110_00", DbType.Single, ZP1.ZP110_00);
                        Db.AddInParameter(cmd, "ZP111_00", DbType.Single, ZP1.ZP111_00);
                        Db.AddInParameter(cmd, "ZP101_01", DbType.Single, ZP1.ZP101_01);
                        Db.AddInParameter(cmd, "ZP102_01", DbType.Single, ZP1.ZP102_01);
                        Db.AddInParameter(cmd, "ZP104_01", DbType.Single, ZP1.ZP104_01);
                        Db.AddInParameter(cmd, "ZP105_01", DbType.Single, ZP1.ZP105_01);
                        Db.AddInParameter(cmd, "ZP106_01", DbType.Single, ZP1.ZP106_01);
                        Db.AddInParameter(cmd, "ZP107_01", DbType.Single, ZP1.ZP107_01);
                        Db.AddInParameter(cmd, "ZP108_01", DbType.Single, ZP1.ZP108_01);
                        Db.AddInParameter(cmd, "ZP109_01", DbType.Single, ZP1.ZP109_01);
                        Db.AddInParameter(cmd, "ZP110_01", DbType.Single, ZP1.ZP110_01);
                        Db.AddInParameter(cmd, "ZP111_01", DbType.Single, ZP1.ZP111_01);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForMSPCSTATS(MSPCSTATS MSPCSTATS)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM MSPCSTATS WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO MSPCSTATS (AUTOID,DATETIME,ACTIVE
            ,ASEF04_PAAC04,ASEF04_PAAC05,ASEF04_PAAC06,ASEF04_PAAC07,ASEF08_PAAC09,ASEF08_PAAC10,ASEF08_PAAC11,ASEF08_PAAC12,ASEF08_PAAC13
            ,ASEF05_PAAC18,ASEF04_PAAC19,ASEF05_PAAC20,ASEF05_PAAC23,ASEF05_PAAC24,ASEF01_PAAC28,ASEF04_PAAC33,ASEF06_PAAC34,ASEF07_PAAC34
            ,ASEF06_PAAC35,ASEF07_PAAC35,ASEF05_PAAC36,ASEF06_PAAC37,ASEF07_PAAC37,ASEF06_PAAC38,ASEF07_PAAC38,ASEF04_PAAC39,ASEF04_PAAC40
            ,ASEF05_PAAC41,ASEF06_PAAC42,ASEF07_PAAC42,ASEF04_PAAC43,ASEF05_PAAC45,ASEF05_PAAC46,BSEF03_PBAC01,BSEF05_PBAC01,BSEF03_PBAC02
            ,BSEF05_PBAC02,BSEF03_PBAC03,BSEF05_PBAC03,BSEF03_PBAC04,BSEF05_PBAC04,BSEF03_PBAC05,BSEF05_PBAC05,BSEF03_PBAC06,BSEF05_PBAC06
            ,BSEF03_PBAC07,BSEF05_PBAC07,BSEF03_PBAC08,BSEF05_PBAC08,BSEF03_PBAC09,BSEF05_PBAC09,BSEF03_PBAC10,BSEF05_PBAC10,BSEF03_PBAC11
            ,BSEF05_PBAC11,BSEF03_PBAC12,BSEF05_PBAC12,BSEF01_PBAC14,BSEF05_PBAC15,BSEF01_PBAC19,BSEF05_PBAC19
            )
        VALUES (@AUTOID,@DATETIME,@ACTIVE
            ,@ASEF04_PAAC04,@ASEF04_PAAC05,@ASEF04_PAAC06,@ASEF04_PAAC07,@ASEF08_PAAC09,@ASEF08_PAAC10,@ASEF08_PAAC11,@ASEF08_PAAC12,@ASEF08_PAAC13
            ,@ASEF05_PAAC18,@ASEF04_PAAC19,@ASEF05_PAAC20,@ASEF05_PAAC23,@ASEF05_PAAC24,@ASEF01_PAAC28,@ASEF04_PAAC33,@ASEF06_PAAC34,@ASEF07_PAAC34
            ,@ASEF06_PAAC35,@ASEF07_PAAC35,@ASEF05_PAAC36,@ASEF06_PAAC37,@ASEF07_PAAC37,@ASEF06_PAAC38,@ASEF07_PAAC38,@ASEF04_PAAC39,@ASEF04_PAAC40
            ,@ASEF05_PAAC41,@ASEF06_PAAC42,@ASEF07_PAAC42,@ASEF04_PAAC43,@ASEF05_PAAC45,@ASEF05_PAAC46,@BSEF03_PBAC01,@BSEF05_PBAC01,@BSEF03_PBAC02
            ,@BSEF05_PBAC02,@BSEF03_PBAC03,@BSEF05_PBAC03,@BSEF03_PBAC04,@BSEF05_PBAC04,@BSEF03_PBAC05,@BSEF05_PBAC05,@BSEF03_PBAC06,@BSEF05_PBAC06
            ,@BSEF03_PBAC07,@BSEF05_PBAC07,@BSEF03_PBAC08,@BSEF05_PBAC08,@BSEF03_PBAC09,@BSEF05_PBAC09,@BSEF03_PBAC10,@BSEF05_PBAC10,@BSEF03_PBAC11
            ,@BSEF05_PBAC11,@BSEF03_PBAC12,@BSEF05_PBAC12,@BSEF01_PBAC14,@BSEF05_PBAC15,@BSEF01_PBAC19,@BSEF05_PBAC19
            )
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, MSPCSTATS.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, MSPCSTATS.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "ASEF04_PAAC04", DbType.Single, MSPCSTATS.ASEF04_PAAC04);
                        Db.AddInParameter(cmd, "ASEF04_PAAC05", DbType.Single, MSPCSTATS.ASEF04_PAAC05);
                        Db.AddInParameter(cmd, "ASEF04_PAAC06", DbType.Single, MSPCSTATS.ASEF04_PAAC06);
                        Db.AddInParameter(cmd, "ASEF04_PAAC07", DbType.Single, MSPCSTATS.ASEF04_PAAC07);
                        Db.AddInParameter(cmd, "ASEF08_PAAC09", DbType.Single, MSPCSTATS.ASEF08_PAAC09);
                        Db.AddInParameter(cmd, "ASEF08_PAAC10", DbType.Single, MSPCSTATS.ASEF08_PAAC10);
                        Db.AddInParameter(cmd, "ASEF08_PAAC11", DbType.Single, MSPCSTATS.ASEF08_PAAC11);
                        Db.AddInParameter(cmd, "ASEF08_PAAC12", DbType.Single, MSPCSTATS.ASEF08_PAAC12);
                        Db.AddInParameter(cmd, "ASEF08_PAAC13", DbType.Single, MSPCSTATS.ASEF08_PAAC13);
                        Db.AddInParameter(cmd, "ASEF05_PAAC18", DbType.Single, MSPCSTATS.ASEF05_PAAC18);
                        Db.AddInParameter(cmd, "ASEF04_PAAC19", DbType.Single, MSPCSTATS.ASEF04_PAAC19);
                        Db.AddInParameter(cmd, "ASEF05_PAAC20", DbType.Single, MSPCSTATS.ASEF05_PAAC20);
                        Db.AddInParameter(cmd, "ASEF05_PAAC23", DbType.Single, MSPCSTATS.ASEF05_PAAC23);
                        Db.AddInParameter(cmd, "ASEF05_PAAC24", DbType.Single, MSPCSTATS.ASEF05_PAAC24);
                        Db.AddInParameter(cmd, "ASEF01_PAAC28", DbType.Single, MSPCSTATS.ASEF01_PAAC28);
                        Db.AddInParameter(cmd, "ASEF04_PAAC33", DbType.Single, MSPCSTATS.ASEF04_PAAC33);
                        Db.AddInParameter(cmd, "ASEF06_PAAC34", DbType.Single, MSPCSTATS.ASEF06_PAAC34);
                        Db.AddInParameter(cmd, "ASEF07_PAAC34", DbType.Single, MSPCSTATS.ASEF07_PAAC34);
                        Db.AddInParameter(cmd, "ASEF06_PAAC35", DbType.Single, MSPCSTATS.ASEF06_PAAC35);
                        Db.AddInParameter(cmd, "ASEF07_PAAC35", DbType.Single, MSPCSTATS.ASEF07_PAAC35);
                        Db.AddInParameter(cmd, "ASEF05_PAAC36", DbType.Single, MSPCSTATS.ASEF05_PAAC36);
                        Db.AddInParameter(cmd, "ASEF06_PAAC37", DbType.Single, MSPCSTATS.ASEF06_PAAC37);
                        Db.AddInParameter(cmd, "ASEF07_PAAC37", DbType.Single, MSPCSTATS.ASEF07_PAAC37);
                        Db.AddInParameter(cmd, "ASEF06_PAAC38", DbType.Single, MSPCSTATS.ASEF06_PAAC38);
                        Db.AddInParameter(cmd, "ASEF07_PAAC38", DbType.Single, MSPCSTATS.ASEF07_PAAC38);
                        Db.AddInParameter(cmd, "ASEF04_PAAC39", DbType.Single, MSPCSTATS.ASEF04_PAAC39);
                        Db.AddInParameter(cmd, "ASEF04_PAAC40", DbType.Single, MSPCSTATS.ASEF04_PAAC40);
                        Db.AddInParameter(cmd, "ASEF05_PAAC41", DbType.Single, MSPCSTATS.ASEF05_PAAC41);
                        Db.AddInParameter(cmd, "ASEF06_PAAC42", DbType.Single, MSPCSTATS.ASEF06_PAAC42);
                        Db.AddInParameter(cmd, "ASEF07_PAAC42", DbType.Single, MSPCSTATS.ASEF07_PAAC42);
                        Db.AddInParameter(cmd, "ASEF04_PAAC43", DbType.Single, MSPCSTATS.ASEF04_PAAC43);
                        Db.AddInParameter(cmd, "ASEF05_PAAC45", DbType.Single, MSPCSTATS.ASEF05_PAAC45);
                        Db.AddInParameter(cmd, "ASEF05_PAAC46", DbType.Single, MSPCSTATS.ASEF05_PAAC46);
                        Db.AddInParameter(cmd, "BSEF03_PBAC01", DbType.Single, MSPCSTATS.BSEF03_PBAC01);
                        Db.AddInParameter(cmd, "BSEF05_PBAC01", DbType.Single, MSPCSTATS.BSEF05_PBAC01);
                        Db.AddInParameter(cmd, "BSEF03_PBAC02", DbType.Single, MSPCSTATS.BSEF03_PBAC02);
                        Db.AddInParameter(cmd, "BSEF05_PBAC02", DbType.Single, MSPCSTATS.BSEF05_PBAC02);
                        Db.AddInParameter(cmd, "BSEF03_PBAC03", DbType.Single, MSPCSTATS.BSEF03_PBAC03);
                        Db.AddInParameter(cmd, "BSEF05_PBAC03", DbType.Single, MSPCSTATS.BSEF05_PBAC03);
                        Db.AddInParameter(cmd, "BSEF03_PBAC04", DbType.Single, MSPCSTATS.BSEF03_PBAC04);
                        Db.AddInParameter(cmd, "BSEF05_PBAC04", DbType.Single, MSPCSTATS.BSEF05_PBAC04);
                        Db.AddInParameter(cmd, "BSEF03_PBAC05", DbType.Single, MSPCSTATS.BSEF03_PBAC05);
                        Db.AddInParameter(cmd, "BSEF05_PBAC05", DbType.Single, MSPCSTATS.BSEF05_PBAC05);
                        Db.AddInParameter(cmd, "BSEF03_PBAC06", DbType.Single, MSPCSTATS.BSEF03_PBAC06);
                        Db.AddInParameter(cmd, "BSEF05_PBAC06", DbType.Single, MSPCSTATS.BSEF05_PBAC06);
                        Db.AddInParameter(cmd, "BSEF03_PBAC07", DbType.Single, MSPCSTATS.BSEF03_PBAC07);
                        Db.AddInParameter(cmd, "BSEF05_PBAC07", DbType.Single, MSPCSTATS.BSEF05_PBAC07);
                        Db.AddInParameter(cmd, "BSEF03_PBAC08", DbType.Single, MSPCSTATS.BSEF03_PBAC08);
                        Db.AddInParameter(cmd, "BSEF05_PBAC08", DbType.Single, MSPCSTATS.BSEF05_PBAC08);
                        Db.AddInParameter(cmd, "BSEF03_PBAC09", DbType.Single, MSPCSTATS.BSEF03_PBAC09);
                        Db.AddInParameter(cmd, "BSEF05_PBAC09", DbType.Single, MSPCSTATS.BSEF05_PBAC09);
                        Db.AddInParameter(cmd, "BSEF03_PBAC10", DbType.Single, MSPCSTATS.BSEF03_PBAC10);
                        Db.AddInParameter(cmd, "BSEF05_PBAC10", DbType.Single, MSPCSTATS.BSEF05_PBAC10);
                        Db.AddInParameter(cmd, "BSEF03_PBAC11", DbType.Single, MSPCSTATS.BSEF03_PBAC11);
                        Db.AddInParameter(cmd, "BSEF05_PBAC11", DbType.Single, MSPCSTATS.BSEF05_PBAC11);
                        Db.AddInParameter(cmd, "BSEF03_PBAC12", DbType.Single, MSPCSTATS.BSEF03_PBAC12);
                        Db.AddInParameter(cmd, "BSEF05_PBAC12", DbType.Single, MSPCSTATS.BSEF05_PBAC12);
                        Db.AddInParameter(cmd, "BSEF01_PBAC14", DbType.Single, MSPCSTATS.BSEF01_PBAC14);
                        Db.AddInParameter(cmd, "BSEF05_PBAC15", DbType.Single, MSPCSTATS.BSEF05_PBAC15);
                        Db.AddInParameter(cmd, "BSEF01_PBAC19", DbType.Single, MSPCSTATS.BSEF01_PBAC19);
                        Db.AddInParameter(cmd, "BSEF05_PBAC19", DbType.Single, MSPCSTATS.BSEF05_PBAC19);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForMSPCALARS(MSPCALARS MSPCALARS)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM MSPCALARS WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO MSPCALARS (AUTOID,DATETIME,ACTIVE
            ,ASEF11_PAAC01,ASEF14_PAAC01,ASEF10_PAAC02,ASEF11_PAAC02,ASEF14_PAAC02,ASEF15_PAAC02,ASEF11_PAAC03,ASEF14_PAAC03
            ,ASEF11_PAAC04,ASEF12_PAAC04,ASEF13_PAAC04,ASEF11_PAAC05,ASEF12_PAAC05,ASEF11_PAAC06,ASEF12_PAAC06,ASEF11_PAAC07
            ,ASEF12_PAAC07,ASEF13_PAAC08,ASEF09_PAAC09,ASEF11_PAAC09,ASEF13_PAAC09,ASEF09_PAAC10,ASEF11_PAAC10,ASEF13_PAAC10
            ,ASEF09_PAAC11,ASEF11_PAAC11,ASEF13_PAAC11,ASEF09_PAAC12,ASEF11_PAAC12,ASEF13_PAAC12,ASEF09_PAAC13,ASEF11_PAAC13
            ,ASEF13_PAAC13,ASEF11_PAAC14,ASEF12_PAAC14,ASEF14_PAAC14,ASEF15_PAAC14,ASEF11_PAAC15,ASEF12_PAAC15,ASEF11_PAAC16
            ,ASEF12_PAAC16,ASEF13_PAAC16,ASEF14_PAAC16,ASEF15_PAAC16,ASEF11_PAAC17,ASEF12_PAAC17
            ,ASEF13_PAAC17,ASEF11_PAAC18,ASEF13_PAAC18,ASEF14_PAAC18,ASEF15_PAAC18,ASEF11_PAAC19,ASEF13_PAAC19,ASEF11_PAAC20
            ,ASEF11_PAAC21,ASEF14_PAAC21,ASEF15_PAAC21,ASEF11_PAAC22,ASEF14_PAAC22,ASEF15_PAAC22,ASEF11_PAAC23,ASEF11_PAAC24
            ,ASEF14_PAAC24,ASEF15_PAAC24,ASEF10_PAAC25,ASEF11_PAAC25,ASEF14_PAAC25,ASEF10_PAAC26,ASEF10_PAAC27,ASEF11_PAAC27
            ,ASEF14_PAAC27,ASEF15_PAAC27,ASEF11_PAAC29,ASEF14_PAAC29,ASEF15_PAAC29,ASEF11_PAAC30,ASEF14_PAAC30,ASEF15_PAAC30
            ,ASEF11_PAAC31,ASEF14_PAAC31,ASEF15_PAAC31,ASEF11_PAAC32,ASEF14_PAAC32,ASEF15_PAAC32,ASEF11_PAAC33,ASEF14_PAAC33
            ,ASEF15_PAAC33,ASEF11_PAAC34,ASEF11_PAAC35,ASEF11_PAAC36,ASEF11_PAAC37,ASEF11_PAAC38,ASEF11_PAAC39,ASEF11_PAAC40
            ,ASEF11_PAAC41,ASEF11_PAAC42,ASEF11_PAAC43,ASEF11_PAAC44,ASEF11_PAAC45,ASEF12_PAAC45,ASEF13_PAAC45,ASEF11_PAAC46
            ,ASEF12_PAAC46,ASEF11_PAAC47,ASEF10_PAAC48,ASEF11_PAAC48,ASEF10_PAAC49,ASEF11_PAAC49,ASEF10_PAAC50,ASEF11_PAAC50
            ,BSEF11_PBAC01,BSEF11_PBAC02,BSEF11_PBAC03,BSEF11_PBAC04,BSEF11_PBAC05,BSEF11_PBAC06,BSEF11_PBAC07,BSEF11_PBAC08
            ,BSEF11_PBAC09,BSEF11_PBAC10,BSEF11_PBAC11,BSEF11_PBAC12,BSEF11_PBAC14,BSEF11_PBAC15,BSEF11_PBAC16
            ,BSEF11_PBAC17,BSEF14_PBAC17,BSEF11_PBAC18,BSEF14_PBAC18,BSEF11_PBAC19
            )
        VALUES (@AUTOID,@DATETIME,@ACTIVE
            ,@ASEF11_PAAC01,@ASEF14_PAAC01,@ASEF10_PAAC02,@ASEF11_PAAC02,@ASEF14_PAAC02,@ASEF15_PAAC02,@ASEF11_PAAC03,@ASEF14_PAAC03
            ,@ASEF11_PAAC04,@ASEF12_PAAC04,@ASEF13_PAAC04,@ASEF11_PAAC05,@ASEF12_PAAC05,@ASEF11_PAAC06,@ASEF12_PAAC06,@ASEF11_PAAC07
            ,@ASEF12_PAAC07,@ASEF13_PAAC08,@ASEF09_PAAC09,@ASEF11_PAAC09,@ASEF13_PAAC09,@ASEF09_PAAC10,@ASEF11_PAAC10,@ASEF13_PAAC10
            ,@ASEF09_PAAC11,@ASEF11_PAAC11,@ASEF13_PAAC11,@ASEF09_PAAC12,@ASEF11_PAAC12,@ASEF13_PAAC12,@ASEF09_PAAC13,@ASEF11_PAAC13
            ,@ASEF13_PAAC13,@ASEF11_PAAC14,@ASEF12_PAAC14,@ASEF14_PAAC14,@ASEF15_PAAC14,@ASEF11_PAAC15,@ASEF12_PAAC15,@ASEF11_PAAC16
            ,@ASEF12_PAAC16,@ASEF13_PAAC16,@ASEF14_PAAC16,@ASEF15_PAAC16,@ASEF11_PAAC17,@ASEF12_PAAC17
            ,@ASEF13_PAAC17,@ASEF11_PAAC18,@ASEF13_PAAC18,@ASEF14_PAAC18,@ASEF15_PAAC18,@ASEF11_PAAC19,@ASEF13_PAAC19,@ASEF11_PAAC20
            ,@ASEF11_PAAC21,@ASEF14_PAAC21,@ASEF15_PAAC21,@ASEF11_PAAC22,@ASEF14_PAAC22,@ASEF15_PAAC22,@ASEF11_PAAC23,@ASEF11_PAAC24
            ,@ASEF14_PAAC24,@ASEF15_PAAC24,@ASEF10_PAAC25,@ASEF11_PAAC25,@ASEF14_PAAC25,@ASEF10_PAAC26,@ASEF10_PAAC27,@ASEF11_PAAC27
            ,@ASEF14_PAAC27,@ASEF15_PAAC27,@ASEF11_PAAC29,@ASEF14_PAAC29,@ASEF15_PAAC29,@ASEF11_PAAC30,@ASEF14_PAAC30,@ASEF15_PAAC30
            ,@ASEF11_PAAC31,@ASEF14_PAAC31,@ASEF15_PAAC31,@ASEF11_PAAC32,@ASEF14_PAAC32,@ASEF15_PAAC32,@ASEF11_PAAC33,@ASEF14_PAAC33
            ,@ASEF15_PAAC33,@ASEF11_PAAC34,@ASEF11_PAAC35,@ASEF11_PAAC36,@ASEF11_PAAC37,@ASEF11_PAAC38,@ASEF11_PAAC39,@ASEF11_PAAC40
            ,@ASEF11_PAAC41,@ASEF11_PAAC42,@ASEF11_PAAC43,@ASEF11_PAAC44,@ASEF11_PAAC45,@ASEF12_PAAC45,@ASEF13_PAAC45,@ASEF11_PAAC46
            ,@ASEF12_PAAC46,@ASEF11_PAAC47,@ASEF10_PAAC48,@ASEF11_PAAC48,@ASEF10_PAAC49,@ASEF11_PAAC49,@ASEF10_PAAC50,@ASEF11_PAAC50
            ,@BSEF11_PBAC01,@BSEF11_PBAC02,@BSEF11_PBAC03,@BSEF11_PBAC04,@BSEF11_PBAC05,@BSEF11_PBAC06,@BSEF11_PBAC07,@BSEF11_PBAC08
            ,@BSEF11_PBAC09,@BSEF11_PBAC10,@BSEF11_PBAC11,@BSEF11_PBAC12,@BSEF11_PBAC14,@BSEF11_PBAC15,@BSEF11_PBAC16
            ,@BSEF11_PBAC17,@BSEF14_PBAC17,@BSEF11_PBAC18,@BSEF14_PBAC18,@BSEF11_PBAC19
            )
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, MSPCALARS.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, MSPCALARS.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "ASEF11_PAAC01", DbType.Single, MSPCALARS.ASEF11_PAAC01);
                        Db.AddInParameter(cmd, "ASEF14_PAAC01", DbType.Single, MSPCALARS.ASEF14_PAAC01);
                        Db.AddInParameter(cmd, "ASEF10_PAAC02", DbType.Single, MSPCALARS.ASEF10_PAAC02);
                        Db.AddInParameter(cmd, "ASEF11_PAAC02", DbType.Single, MSPCALARS.ASEF11_PAAC02);
                        Db.AddInParameter(cmd, "ASEF14_PAAC02", DbType.Single, MSPCALARS.ASEF14_PAAC02);
                        Db.AddInParameter(cmd, "ASEF15_PAAC02", DbType.Single, MSPCALARS.ASEF15_PAAC02);
                        Db.AddInParameter(cmd, "ASEF11_PAAC03", DbType.Single, MSPCALARS.ASEF11_PAAC03);
                        Db.AddInParameter(cmd, "ASEF14_PAAC03", DbType.Single, MSPCALARS.ASEF14_PAAC03);
                        Db.AddInParameter(cmd, "ASEF11_PAAC04", DbType.Single, MSPCALARS.ASEF11_PAAC04);
                        Db.AddInParameter(cmd, "ASEF12_PAAC04", DbType.Single, MSPCALARS.ASEF12_PAAC04);
                        Db.AddInParameter(cmd, "ASEF13_PAAC04", DbType.Single, MSPCALARS.ASEF13_PAAC04);
                        Db.AddInParameter(cmd, "ASEF11_PAAC05", DbType.Single, MSPCALARS.ASEF11_PAAC05);
                        Db.AddInParameter(cmd, "ASEF12_PAAC05", DbType.Single, MSPCALARS.ASEF12_PAAC05);
                        Db.AddInParameter(cmd, "ASEF11_PAAC06", DbType.Single, MSPCALARS.ASEF11_PAAC06);
                        Db.AddInParameter(cmd, "ASEF12_PAAC06", DbType.Single, MSPCALARS.ASEF12_PAAC06);
                        Db.AddInParameter(cmd, "ASEF11_PAAC07", DbType.Single, MSPCALARS.ASEF11_PAAC07);
                        Db.AddInParameter(cmd, "ASEF12_PAAC07", DbType.Single, MSPCALARS.ASEF12_PAAC07);
                        Db.AddInParameter(cmd, "ASEF13_PAAC08", DbType.Single, MSPCALARS.ASEF13_PAAC08);
                        Db.AddInParameter(cmd, "ASEF09_PAAC09", DbType.Single, MSPCALARS.ASEF09_PAAC09);
                        Db.AddInParameter(cmd, "ASEF11_PAAC09", DbType.Single, MSPCALARS.ASEF11_PAAC09);
                        Db.AddInParameter(cmd, "ASEF13_PAAC09", DbType.Single, MSPCALARS.ASEF13_PAAC09);
                        Db.AddInParameter(cmd, "ASEF09_PAAC10", DbType.Single, MSPCALARS.ASEF09_PAAC10);
                        Db.AddInParameter(cmd, "ASEF11_PAAC10", DbType.Single, MSPCALARS.ASEF11_PAAC10);
                        Db.AddInParameter(cmd, "ASEF13_PAAC10", DbType.Single, MSPCALARS.ASEF13_PAAC10);
                        Db.AddInParameter(cmd, "ASEF09_PAAC11", DbType.Single, MSPCALARS.ASEF09_PAAC11);
                        Db.AddInParameter(cmd, "ASEF11_PAAC11", DbType.Single, MSPCALARS.ASEF11_PAAC11);
                        Db.AddInParameter(cmd, "ASEF13_PAAC11", DbType.Single, MSPCALARS.ASEF13_PAAC11);
                        Db.AddInParameter(cmd, "ASEF09_PAAC12", DbType.Single, MSPCALARS.ASEF09_PAAC12);
                        Db.AddInParameter(cmd, "ASEF11_PAAC12", DbType.Single, MSPCALARS.ASEF11_PAAC12);
                        Db.AddInParameter(cmd, "ASEF13_PAAC12", DbType.Single, MSPCALARS.ASEF13_PAAC12);
                        Db.AddInParameter(cmd, "ASEF09_PAAC13", DbType.Single, MSPCALARS.ASEF09_PAAC13);
                        Db.AddInParameter(cmd, "ASEF11_PAAC13", DbType.Single, MSPCALARS.ASEF11_PAAC13);
                        Db.AddInParameter(cmd, "ASEF13_PAAC13", DbType.Single, MSPCALARS.ASEF13_PAAC13);
                        Db.AddInParameter(cmd, "ASEF11_PAAC14", DbType.Single, MSPCALARS.ASEF11_PAAC14);
                        Db.AddInParameter(cmd, "ASEF12_PAAC14", DbType.Single, MSPCALARS.ASEF12_PAAC14);
                        Db.AddInParameter(cmd, "ASEF14_PAAC14", DbType.Single, MSPCALARS.ASEF14_PAAC14);
                        Db.AddInParameter(cmd, "ASEF15_PAAC14", DbType.Single, MSPCALARS.ASEF15_PAAC14);
                        Db.AddInParameter(cmd, "ASEF11_PAAC15", DbType.Single, MSPCALARS.ASEF11_PAAC15);
                        Db.AddInParameter(cmd, "ASEF12_PAAC15", DbType.Single, MSPCALARS.ASEF12_PAAC15);
                        Db.AddInParameter(cmd, "ASEF11_PAAC16", DbType.Single, MSPCALARS.ASEF11_PAAC16);
                        Db.AddInParameter(cmd, "ASEF12_PAAC16", DbType.Single, MSPCALARS.ASEF12_PAAC16);
                        Db.AddInParameter(cmd, "ASEF13_PAAC16", DbType.Single, MSPCALARS.ASEF13_PAAC16);
                        //Db.AddInParameter(cmd, "ASEF16_PBAC16", DbType.Single, MSPCALARS.ASEF16_PBAC16);    //有資料來源, 資料定義不明, 故刪除
                        //Db.AddInParameter(cmd, "ASEF17_PBAC16", DbType.Single, MSPCALARS.ASEF17_PBAC16);    //有資料來源, 資料定義不明, 故刪除
                        Db.AddInParameter(cmd, "ASEF14_PAAC16", DbType.Single, MSPCALARS.ASEF14_PAAC16);
                        Db.AddInParameter(cmd, "ASEF15_PAAC16", DbType.Single, MSPCALARS.ASEF15_PAAC16);
                        Db.AddInParameter(cmd, "ASEF11_PAAC17", DbType.Single, MSPCALARS.ASEF11_PAAC17);
                        Db.AddInParameter(cmd, "ASEF12_PAAC17", DbType.Single, MSPCALARS.ASEF12_PAAC17);
                        Db.AddInParameter(cmd, "ASEF13_PAAC17", DbType.Single, MSPCALARS.ASEF13_PAAC17);
                        Db.AddInParameter(cmd, "ASEF11_PAAC18", DbType.Single, MSPCALARS.ASEF11_PAAC18);
                        Db.AddInParameter(cmd, "ASEF13_PAAC18", DbType.Single, MSPCALARS.ASEF13_PAAC18);
                        Db.AddInParameter(cmd, "ASEF14_PAAC18", DbType.Single, MSPCALARS.ASEF14_PAAC18);
                        Db.AddInParameter(cmd, "ASEF15_PAAC18", DbType.Single, MSPCALARS.ASEF15_PAAC18);
                        Db.AddInParameter(cmd, "ASEF11_PAAC19", DbType.Single, MSPCALARS.ASEF11_PAAC19);
                        Db.AddInParameter(cmd, "ASEF13_PAAC19", DbType.Single, MSPCALARS.ASEF13_PAAC19);
                        Db.AddInParameter(cmd, "ASEF11_PAAC20", DbType.Single, MSPCALARS.ASEF11_PAAC20);
                        Db.AddInParameter(cmd, "ASEF11_PAAC21", DbType.Single, MSPCALARS.ASEF11_PAAC21);
                        Db.AddInParameter(cmd, "ASEF14_PAAC21", DbType.Single, MSPCALARS.ASEF14_PAAC21);
                        Db.AddInParameter(cmd, "ASEF15_PAAC21", DbType.Single, MSPCALARS.ASEF15_PAAC21);
                        Db.AddInParameter(cmd, "ASEF11_PAAC22", DbType.Single, MSPCALARS.ASEF11_PAAC22);
                        Db.AddInParameter(cmd, "ASEF14_PAAC22", DbType.Single, MSPCALARS.ASEF14_PAAC22);
                        Db.AddInParameter(cmd, "ASEF15_PAAC22", DbType.Single, MSPCALARS.ASEF15_PAAC22);
                        Db.AddInParameter(cmd, "ASEF11_PAAC23", DbType.Single, MSPCALARS.ASEF11_PAAC23);
                        Db.AddInParameter(cmd, "ASEF11_PAAC24", DbType.Single, MSPCALARS.ASEF11_PAAC24);
                        Db.AddInParameter(cmd, "ASEF14_PAAC24", DbType.Single, MSPCALARS.ASEF14_PAAC24);
                        Db.AddInParameter(cmd, "ASEF15_PAAC24", DbType.Single, MSPCALARS.ASEF15_PAAC24);
                        Db.AddInParameter(cmd, "ASEF10_PAAC25", DbType.Single, MSPCALARS.ASEF10_PAAC25);
                        Db.AddInParameter(cmd, "ASEF11_PAAC25", DbType.Single, MSPCALARS.ASEF11_PAAC25);
                        Db.AddInParameter(cmd, "ASEF14_PAAC25", DbType.Single, MSPCALARS.ASEF14_PAAC25);
                        Db.AddInParameter(cmd, "ASEF10_PAAC26", DbType.Single, MSPCALARS.ASEF10_PAAC26);
                        Db.AddInParameter(cmd, "ASEF10_PAAC27", DbType.Single, MSPCALARS.ASEF10_PAAC27);
                        Db.AddInParameter(cmd, "ASEF11_PAAC27", DbType.Single, MSPCALARS.ASEF11_PAAC27);
                        Db.AddInParameter(cmd, "ASEF14_PAAC27", DbType.Single, MSPCALARS.ASEF14_PAAC27);
                        Db.AddInParameter(cmd, "ASEF15_PAAC27", DbType.Single, MSPCALARS.ASEF15_PAAC27);
                        Db.AddInParameter(cmd, "ASEF11_PAAC29", DbType.Single, MSPCALARS.ASEF11_PAAC29);
                        Db.AddInParameter(cmd, "ASEF14_PAAC29", DbType.Single, MSPCALARS.ASEF14_PAAC29);
                        Db.AddInParameter(cmd, "ASEF15_PAAC29", DbType.Single, MSPCALARS.ASEF15_PAAC29);
                        Db.AddInParameter(cmd, "ASEF11_PAAC30", DbType.Single, MSPCALARS.ASEF11_PAAC30);
                        Db.AddInParameter(cmd, "ASEF14_PAAC30", DbType.Single, MSPCALARS.ASEF14_PAAC30);
                        Db.AddInParameter(cmd, "ASEF15_PAAC30", DbType.Single, MSPCALARS.ASEF15_PAAC30);
                        Db.AddInParameter(cmd, "ASEF11_PAAC31", DbType.Single, MSPCALARS.ASEF11_PAAC31);
                        Db.AddInParameter(cmd, "ASEF14_PAAC31", DbType.Single, MSPCALARS.ASEF14_PAAC31);
                        Db.AddInParameter(cmd, "ASEF15_PAAC31", DbType.Single, MSPCALARS.ASEF15_PAAC31);
                        Db.AddInParameter(cmd, "ASEF11_PAAC32", DbType.Single, MSPCALARS.ASEF11_PAAC32);
                        Db.AddInParameter(cmd, "ASEF14_PAAC32", DbType.Single, MSPCALARS.ASEF14_PAAC32);
                        Db.AddInParameter(cmd, "ASEF15_PAAC32", DbType.Single, MSPCALARS.ASEF15_PAAC32);
                        Db.AddInParameter(cmd, "ASEF11_PAAC33", DbType.Single, MSPCALARS.ASEF11_PAAC33);
                        Db.AddInParameter(cmd, "ASEF14_PAAC33", DbType.Single, MSPCALARS.ASEF14_PAAC33);
                        Db.AddInParameter(cmd, "ASEF15_PAAC33", DbType.Single, MSPCALARS.ASEF15_PAAC33);
                        Db.AddInParameter(cmd, "ASEF11_PAAC34", DbType.Single, MSPCALARS.ASEF11_PAAC34);
                        Db.AddInParameter(cmd, "ASEF11_PAAC35", DbType.Single, MSPCALARS.ASEF11_PAAC35);
                        Db.AddInParameter(cmd, "ASEF11_PAAC36", DbType.Single, MSPCALARS.ASEF11_PAAC36);
                        Db.AddInParameter(cmd, "ASEF11_PAAC37", DbType.Single, MSPCALARS.ASEF11_PAAC37);
                        Db.AddInParameter(cmd, "ASEF11_PAAC38", DbType.Single, MSPCALARS.ASEF11_PAAC38);
                        Db.AddInParameter(cmd, "ASEF11_PAAC39", DbType.Single, MSPCALARS.ASEF11_PAAC39);
                        Db.AddInParameter(cmd, "ASEF11_PAAC40", DbType.Single, MSPCALARS.ASEF11_PAAC40);
                        Db.AddInParameter(cmd, "ASEF11_PAAC41", DbType.Single, MSPCALARS.ASEF11_PAAC41);
                        Db.AddInParameter(cmd, "ASEF11_PAAC42", DbType.Single, MSPCALARS.ASEF11_PAAC42);
                        Db.AddInParameter(cmd, "ASEF11_PAAC43", DbType.Single, MSPCALARS.ASEF11_PAAC43);
                        Db.AddInParameter(cmd, "ASEF11_PAAC44", DbType.Single, MSPCALARS.ASEF11_PAAC44);
                        Db.AddInParameter(cmd, "ASEF11_PAAC45", DbType.Single, MSPCALARS.ASEF11_PAAC45);
                        Db.AddInParameter(cmd, "ASEF12_PAAC45", DbType.Single, MSPCALARS.ASEF12_PAAC45);
                        Db.AddInParameter(cmd, "ASEF13_PAAC45", DbType.Single, MSPCALARS.ASEF13_PAAC45);
                        Db.AddInParameter(cmd, "ASEF11_PAAC46", DbType.Single, MSPCALARS.ASEF11_PAAC46);
                        Db.AddInParameter(cmd, "ASEF12_PAAC46", DbType.Single, MSPCALARS.ASEF12_PAAC46);
                        Db.AddInParameter(cmd, "ASEF11_PAAC47", DbType.Single, MSPCALARS.ASEF11_PAAC47);
                        Db.AddInParameter(cmd, "ASEF10_PAAC48", DbType.Single, MSPCALARS.ASEF10_PAAC48);
                        Db.AddInParameter(cmd, "ASEF11_PAAC48", DbType.Single, MSPCALARS.ASEF11_PAAC48);
                        Db.AddInParameter(cmd, "ASEF10_PAAC49", DbType.Single, MSPCALARS.ASEF10_PAAC49);
                        Db.AddInParameter(cmd, "ASEF11_PAAC49", DbType.Single, MSPCALARS.ASEF11_PAAC49);
                        Db.AddInParameter(cmd, "ASEF10_PAAC50", DbType.Single, MSPCALARS.ASEF10_PAAC50);
                        Db.AddInParameter(cmd, "ASEF11_PAAC50", DbType.Single, MSPCALARS.ASEF11_PAAC50);
                        Db.AddInParameter(cmd, "BSEF11_PBAC01", DbType.Single, MSPCALARS.BSEF11_PBAC01);
                        Db.AddInParameter(cmd, "BSEF11_PBAC02", DbType.Single, MSPCALARS.BSEF11_PBAC02);
                        Db.AddInParameter(cmd, "BSEF11_PBAC03", DbType.Single, MSPCALARS.BSEF11_PBAC03);
                        Db.AddInParameter(cmd, "BSEF11_PBAC04", DbType.Single, MSPCALARS.BSEF11_PBAC04);
                        Db.AddInParameter(cmd, "BSEF11_PBAC05", DbType.Single, MSPCALARS.BSEF11_PBAC05);
                        Db.AddInParameter(cmd, "BSEF11_PBAC06", DbType.Single, MSPCALARS.BSEF11_PBAC06);
                        Db.AddInParameter(cmd, "BSEF11_PBAC07", DbType.Single, MSPCALARS.BSEF11_PBAC07);
                        Db.AddInParameter(cmd, "BSEF11_PBAC08", DbType.Single, MSPCALARS.BSEF11_PBAC08);
                        Db.AddInParameter(cmd, "BSEF11_PBAC09", DbType.Single, MSPCALARS.BSEF11_PBAC09);
                        Db.AddInParameter(cmd, "BSEF11_PBAC10", DbType.Single, MSPCALARS.BSEF11_PBAC10);
                        Db.AddInParameter(cmd, "BSEF11_PBAC11", DbType.Single, MSPCALARS.BSEF11_PBAC11);
                        Db.AddInParameter(cmd, "BSEF11_PBAC12", DbType.Single, MSPCALARS.BSEF11_PBAC12);
                        //Db.AddInParameter(cmd, "BSEF11_PBAC13", DbType.Single, MSPCALARS.BSEF11_PBAC13);    //有資料來源, 沒資料定義, 故刪除
                        Db.AddInParameter(cmd, "BSEF11_PBAC14", DbType.Single, MSPCALARS.BSEF11_PBAC14);
                        Db.AddInParameter(cmd, "BSEF11_PBAC15", DbType.Single, MSPCALARS.BSEF11_PBAC15);
                        Db.AddInParameter(cmd, "BSEF11_PBAC16", DbType.Single, MSPCALARS.BSEF11_PBAC16);
                        Db.AddInParameter(cmd, "BSEF11_PBAC17", DbType.Single, MSPCALARS.BSEF11_PBAC17);
                        Db.AddInParameter(cmd, "BSEF14_PBAC17", DbType.Single, MSPCALARS.BSEF14_PBAC17);
                        Db.AddInParameter(cmd, "BSEF11_PBAC18", DbType.Single, MSPCALARS.BSEF11_PBAC18);
                        Db.AddInParameter(cmd, "BSEF14_PBAC18", DbType.Single, MSPCALARS.BSEF14_PBAC18);
                        Db.AddInParameter(cmd, "BSEF11_PBAC19", DbType.Single, MSPCALARS.BSEF11_PBAC19);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }

        public bool WriteBufferForMSPCAI(MSPCAI MSPCAI)
        {
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.Serializable }))
            {
                using (DbConnection conn = Db.CreateConnection())
                {
                    conn.Open();

                    string sql = @"
IF NOT EXISTS (SELECT 1 FROM MSPCAI WITH (UPDLOCK) WHERE AUTOID = @AUTOID)
    BEGIN
        INSERT INTO MSPCAI (AUTOID,DATETIME,ACTIVE
            ,ASEF16_PAAC01,ASEF16_PAAC02,ASEF17_PAAC02,ASEF16_PAAC03,ASEF16_PAAC04,ASEF17_PAAC04,ASEF16_PAAC06,ASEF17_PAAC06
            ,ASEF16_PAAC14,ASEF17_PAAC14,ASEF16_PAAC16,ASEF17_PAAC16,ASEF16_PAAC18,ASEF16_PAAC19,ASEF17_PAAC19,ASEF16_PAAC21
            ,ASEF17_PAAC21,ASEF16_PAAC22,ASEF17_PAAC22,ASEF16_PAAC24,ASEF17_PAAC24,ASEF16_PAAC25,ASEF16_PAAC27,ASEF17_PAAC27
            ,ASEF16_PAAC28,ASEF18_PAAC28,ASEF16_PAAC29,ASEF17_PAAC29,ASEF16_PAAC30,ASEF17_PAAC30,ASEF16_PAAC31,ASEF17_PAAC31
            ,ASEF16_PAAC32,ASEF17_PAAC32,ASEF16_PAAC33,ASEF17_PAAC33,ASEF16_PAAC45,ASEF17_PAAC45,ASEF16_PAAC46,ASEF17_PAAC46
            ,ASEF16_PAAC48,ASEF17_PAAC48,BSEF16_PBAC16,BSEF17_PBAC16,BSEF16_PBAC18,BSEF17_PBAC18
            )
        VALUES (@AUTOID,@DATETIME,@ACTIVE
            ,@ASEF16_PAAC01,@ASEF16_PAAC02,@ASEF17_PAAC02,@ASEF16_PAAC03,@ASEF16_PAAC04,@ASEF17_PAAC04,@ASEF16_PAAC06,@ASEF17_PAAC06
            ,@ASEF16_PAAC14,@ASEF17_PAAC14,@ASEF16_PAAC16,@ASEF17_PAAC16,@ASEF16_PAAC18,@ASEF16_PAAC19,@ASEF17_PAAC19,@ASEF16_PAAC21
            ,@ASEF17_PAAC21,@ASEF16_PAAC22,@ASEF17_PAAC22,@ASEF16_PAAC24,@ASEF17_PAAC24,@ASEF16_PAAC25,@ASEF16_PAAC27,@ASEF17_PAAC27
            ,@ASEF16_PAAC28,@ASEF18_PAAC28,@ASEF16_PAAC29,@ASEF17_PAAC29,@ASEF16_PAAC30,@ASEF17_PAAC30,@ASEF16_PAAC31,@ASEF17_PAAC31
            ,@ASEF16_PAAC32,@ASEF17_PAAC32,@ASEF16_PAAC33,@ASEF17_PAAC33,@ASEF16_PAAC45,@ASEF17_PAAC45,@ASEF16_PAAC46,@ASEF17_PAAC46
            ,@ASEF16_PAAC48,@ASEF17_PAAC48,@BSEF16_PBAC16,@BSEF17_PBAC16,@BSEF16_PBAC18,@BSEF17_PBAC18
            )
    END
";
                    using (DbCommand cmd = Db.GetSqlStringCommand(sql))
                    {
                        #region 參數
                        Db.AddInParameter(cmd, "AUTOID", DbType.Int32, MSPCAI.AUTOID);
                        Db.AddInParameter(cmd, "DATETIME", DbType.DateTime, MSPCAI.DATETIME);
                        Db.AddInParameter(cmd, "ACTIVE", DbType.String, "A");
                        Db.AddInParameter(cmd, "ASEF16_PAAC01", DbType.Single, MSPCAI.ASEF16_PAAC01);
                        Db.AddInParameter(cmd, "ASEF16_PAAC02", DbType.Single, MSPCAI.ASEF16_PAAC02);
                        Db.AddInParameter(cmd, "ASEF17_PAAC02", DbType.Single, MSPCAI.ASEF17_PAAC02);
                        Db.AddInParameter(cmd, "ASEF16_PAAC03", DbType.Single, MSPCAI.ASEF16_PAAC03);
                        Db.AddInParameter(cmd, "ASEF16_PAAC04", DbType.Single, MSPCAI.ASEF16_PAAC04);
                        Db.AddInParameter(cmd, "ASEF17_PAAC04", DbType.Single, MSPCAI.ASEF17_PAAC04);
                        Db.AddInParameter(cmd, "ASEF16_PAAC06", DbType.Single, MSPCAI.ASEF16_PAAC06);
                        Db.AddInParameter(cmd, "ASEF17_PAAC06", DbType.Single, MSPCAI.ASEF17_PAAC06);
                        Db.AddInParameter(cmd, "ASEF16_PAAC14", DbType.Single, MSPCAI.ASEF16_PAAC14);
                        Db.AddInParameter(cmd, "ASEF17_PAAC14", DbType.Single, MSPCAI.ASEF17_PAAC14);
                        Db.AddInParameter(cmd, "ASEF16_PAAC16", DbType.Single, MSPCAI.ASEF16_PAAC16);
                        Db.AddInParameter(cmd, "ASEF17_PAAC16", DbType.Single, MSPCAI.ASEF17_PAAC16);
                        Db.AddInParameter(cmd, "ASEF16_PAAC18", DbType.Single, MSPCAI.ASEF16_PAAC18);
                        Db.AddInParameter(cmd, "ASEF16_PAAC19", DbType.Single, MSPCAI.ASEF16_PAAC19);
                        Db.AddInParameter(cmd, "ASEF17_PAAC19", DbType.Single, MSPCAI.ASEF17_PAAC19);
                        Db.AddInParameter(cmd, "ASEF16_PAAC21", DbType.Single, MSPCAI.ASEF16_PAAC21);
                        Db.AddInParameter(cmd, "ASEF17_PAAC21", DbType.Single, MSPCAI.ASEF17_PAAC21);
                        Db.AddInParameter(cmd, "ASEF16_PAAC22", DbType.Single, MSPCAI.ASEF16_PAAC22);
                        Db.AddInParameter(cmd, "ASEF17_PAAC22", DbType.Single, MSPCAI.ASEF17_PAAC22);
                        Db.AddInParameter(cmd, "ASEF16_PAAC24", DbType.Single, MSPCAI.ASEF16_PAAC24);
                        Db.AddInParameter(cmd, "ASEF17_PAAC24", DbType.Single, MSPCAI.ASEF17_PAAC24);
                        Db.AddInParameter(cmd, "ASEF16_PAAC25", DbType.Single, MSPCAI.ASEF16_PAAC25);
                        Db.AddInParameter(cmd, "ASEF16_PAAC27", DbType.Single, MSPCAI.ASEF16_PAAC27);
                        Db.AddInParameter(cmd, "ASEF17_PAAC27", DbType.Single, MSPCAI.ASEF17_PAAC27);
                        Db.AddInParameter(cmd, "ASEF16_PAAC28", DbType.Single, MSPCAI.ASEF16_PAAC28);
                        Db.AddInParameter(cmd, "ASEF18_PAAC28", DbType.Single, MSPCAI.ASEF18_PAAC28);
                        Db.AddInParameter(cmd, "ASEF16_PAAC29", DbType.Single, MSPCAI.ASEF16_PAAC29);
                        Db.AddInParameter(cmd, "ASEF17_PAAC29", DbType.Single, MSPCAI.ASEF17_PAAC29);
                        Db.AddInParameter(cmd, "ASEF16_PAAC30", DbType.Single, MSPCAI.ASEF16_PAAC30);
                        Db.AddInParameter(cmd, "ASEF17_PAAC30", DbType.Single, MSPCAI.ASEF17_PAAC30);
                        Db.AddInParameter(cmd, "ASEF16_PAAC31", DbType.Single, MSPCAI.ASEF16_PAAC31);
                        Db.AddInParameter(cmd, "ASEF17_PAAC31", DbType.Single, MSPCAI.ASEF17_PAAC31);
                        Db.AddInParameter(cmd, "ASEF16_PAAC32", DbType.Single, MSPCAI.ASEF16_PAAC32);
                        Db.AddInParameter(cmd, "ASEF17_PAAC32", DbType.Single, MSPCAI.ASEF17_PAAC32);
                        Db.AddInParameter(cmd, "ASEF16_PAAC33", DbType.Single, MSPCAI.ASEF16_PAAC33);
                        Db.AddInParameter(cmd, "ASEF17_PAAC33", DbType.Single, MSPCAI.ASEF17_PAAC33);
                        Db.AddInParameter(cmd, "ASEF16_PAAC45", DbType.Single, MSPCAI.ASEF16_PAAC45);
                        Db.AddInParameter(cmd, "ASEF17_PAAC45", DbType.Single, MSPCAI.ASEF17_PAAC45);
                        Db.AddInParameter(cmd, "ASEF16_PAAC46", DbType.Single, MSPCAI.ASEF16_PAAC46);
                        Db.AddInParameter(cmd, "ASEF17_PAAC46", DbType.Single, MSPCAI.ASEF17_PAAC46);
                        Db.AddInParameter(cmd, "ASEF16_PAAC48", DbType.Single, MSPCAI.ASEF16_PAAC48);
                        Db.AddInParameter(cmd, "ASEF17_PAAC48", DbType.Single, MSPCAI.ASEF17_PAAC48);
                        Db.AddInParameter(cmd, "BSEF16_PBAC16", DbType.Single, MSPCAI.BSEF16_PBAC16);
                        Db.AddInParameter(cmd, "BSEF17_PBAC16", DbType.Single, MSPCAI.BSEF17_PBAC16);
                        Db.AddInParameter(cmd, "BSEF16_PBAC18", DbType.Single, MSPCAI.BSEF16_PBAC18);
                        Db.AddInParameter(cmd, "BSEF17_PBAC18", DbType.Single, MSPCAI.BSEF17_PBAC18);
                        #endregion
                        affected = Db.ExecuteNonQuery(cmd);
                    }
                }

                scop.Complete();
            }

            return affected > 0;
        }
    }
}

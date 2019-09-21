using System;
using TP_DSYNC.Models.DataAccess;
using TP_DSYNC.Models.DataDefine.B3;
using System.Data;
using System.Data.Common;
using System.Transactions;

namespace TP_DSYNC.Models.Implement
{
    public class AHU_BufferImplement : DatabaseAccess
    {
        public AHU_BufferImplement(string connectionStringName) : base(connectionStringName) { }

        public bool WriteBufferForAHU_004F(AHU_004F AHU_004F)
        {
            int affected = 0;
            try
            {
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
            }
            catch (Exception ex)
            {

                throw;
            }

            return affected > 0;
        }

        public bool WriteBufferForAHU_0B1F(AHU_0B1F AHU_0B1F)
        {
            int affected = 0;
            try
            {
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
            }
            catch (Exception ex)
            {

                throw;
            }

            return affected > 0;
        }

        public bool WriteBufferForAHU_00RF(AHU_00RF AHU_00RF)
        {
            int affected = 0;
            try
            {
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
            }
            catch (Exception ex)
            {

                throw;
            }

            return affected > 0;
        }

        public bool WriteBufferForAHU_014F(AHU_014F AHU_014F)
        {
            int affected = 0;
            try
            {
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
            }
            catch (Exception ex)
            {

                throw;
            }

            return affected > 0;
        }

        public bool WriteBufferForAHU_S03F(AHU_S03F AHU_S03F)
        {
            int affected = 0;
            try
            {
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
            }
            catch (Exception ex)
            {

                throw;
            }

            return affected > 0;
        }

        public bool WriteBufferForAHU_SB1F(AHU_SB1F AHU_SB1F)
        {
            int affected = 0;
            try
            {
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
            }
            catch (Exception ex)
            {

                throw;
            }

            return affected > 0;
        }

    }
}

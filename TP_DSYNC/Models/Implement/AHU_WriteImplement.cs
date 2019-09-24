using System;
using TP_DSYNC.Models.DataAccess;
using TP_DSYNC.Models.DataDefine.B3;
using System.Data;
using System.Data.Common;
using System.Transactions;

namespace TP_DSYNC.Models.Implement
{
    public class AHU_WriteImplement : B3BUFFER_DSCCR_Access
    {
        public AHU_WriteImplement(string connectionStringNameB3BUFFER, string connectionStringNameDSCCR) : base(connectionStringNameB3BUFFER, connectionStringNameDSCCR) { }

        public int WriteDataForAHU_004F(AHU_004F AHU_004F)
        {
            string sql;
            int affected = 0;
            try
            {
                using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
                {
                    using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                    {
                        string active = null;
                        connB3BUFFER.Open();
                        using (DbCommand cmd = connB3BUFFER.CreateCommand())
                        {
                            sql = @"
                SELECT ACTIVE FROM AHU_04F WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                            cmd.CommandText = sql;
                            DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_004F.AUTOID);
                            var obj = DbB3BUFFER.ExecuteScalar(cmd);
                            if (obj != null)
                            {
                                active = obj.ToString();
                            }

                            if (active == "A")
                            {
                                using (DbConnection connDSCCR = DbDSCCR.CreateConnection())
                                {
                                    connDSCCR.Open();
                                    using (DbCommand cmdDSCCR = connDSCCR.CreateCommand())
                                    {
                                        sql = @"
INSERT INTO AHU (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,AHU01,AHU02,AHU03,AHU04,AHU05,AHU06,AHU07,AHU08,AHU09,AHU10,AHU11)     
    VALUES (@SID,@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                                        cmdDSCCR.CommandText = sql;
                                        #region 參數
                                        DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU01", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU02", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU03", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU04", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU05", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU06", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU07", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU08", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU09", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU10", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU11", DbType.Single);

                                        DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 91);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", AHU_004F.AUTOID);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", AHU_004F.DATETIME);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "004F");

                                        #region 004F01
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_004F.AHU01_004F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_004F.AHU02_004F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_004F.AHU03_004F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_004F.AHU04_004F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_004F.AHU05_004F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_004F.AHU06_004F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_004F.AHU07_004F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_004F.AHU08_004F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_004F.AHU09_004F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_004F.AHU10_004F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_004F.AHU11_004F01);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 004F02
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "02");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_004F.AHU01_004F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_004F.AHU02_004F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_004F.AHU03_004F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_004F.AHU04_004F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_004F.AHU05_004F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_004F.AHU06_004F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_004F.AHU07_004F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_004F.AHU08_004F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_004F.AHU09_004F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_004F.AHU10_004F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_004F.AHU11_004F02);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 004F03
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "03");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_004F.AHU01_004F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_004F.AHU02_004F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_004F.AHU03_004F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_004F.AHU04_004F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_004F.AHU05_004F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_004F.AHU06_004F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_004F.AHU07_004F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_004F.AHU08_004F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_004F.AHU09_004F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_004F.AHU10_004F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_004F.AHU11_004F03);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 004F04
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "04");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_004F.AHU01_004F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_004F.AHU02_004F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_004F.AHU03_004F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_004F.AHU04_004F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_004F.AHU05_004F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_004F.AHU06_004F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_004F.AHU07_004F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_004F.AHU08_004F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_004F.AHU09_004F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_004F.AHU10_004F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_004F.AHU11_004F04);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #endregion

                                        affected = 0;
                                        sql = @"
UPDATE AHU_04F SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                        cmd.CommandText = sql;
                                        //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_004F.AUTOID);
                                        affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                        if (affected == 0)
                                        {
                                            //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + AHU_004F.AUTOID.ToString());
                                        }
                                    }
                                }
                            }


                        }
                    }
                    scop.Complete();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return affected;
        }

        public int WriteDataForAHU_0B1F(AHU_0B1F AHU_0B1F)
        {
            string sql;
            int affected = 0;
            try
            {
                using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
                {
                    using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                    {
                        string active = null;
                        connB3BUFFER.Open();
                        using (DbCommand cmd = connB3BUFFER.CreateCommand())
                        {
                            sql = @"
                SELECT ACTIVE FROM AHU_0B1 WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                            cmd.CommandText = sql;
                            DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_0B1F.AUTOID);
                            var obj = DbB3BUFFER.ExecuteScalar(cmd);
                            if (obj != null)
                            {
                                active = obj.ToString();
                            }

                            if (active == "A")
                            {
                                using (DbConnection connDSCCR = DbDSCCR.CreateConnection())
                                {
                                    connDSCCR.Open();
                                    using (DbCommand cmdDSCCR = connDSCCR.CreateCommand())
                                    {
                                        sql = @"
INSERT INTO AHU (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,AHU01,AHU02,AHU03,AHU04,AHU05,AHU06,AHU07,AHU08,AHU09,AHU10,AHU11)     
    VALUES (@SID,@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                                        cmdDSCCR.CommandText = sql;
                                        #region 參數
                                        DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU01", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU02", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU03", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU04", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU05", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU06", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU07", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU08", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU09", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU10", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU11", DbType.Single);

                                        DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 91);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", AHU_0B1F.AUTOID);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", AHU_0B1F.DATETIME);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "0B1F");

                                        #region 0B1F01
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_0B1F.AHU01_0B1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_0B1F.AHU02_0B1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_0B1F.AHU03_0B1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_0B1F.AHU04_0B1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_0B1F.AHU05_0B1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_0B1F.AHU06_0B1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_0B1F.AHU07_0B1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_0B1F.AHU08_0B1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_0B1F.AHU09_0B1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_0B1F.AHU10_0B1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_0B1F.AHU11_0B1F01);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 0B1F02
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "02");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_0B1F.AHU01_0B1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_0B1F.AHU02_0B1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_0B1F.AHU03_0B1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_0B1F.AHU04_0B1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_0B1F.AHU05_0B1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_0B1F.AHU06_0B1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_0B1F.AHU07_0B1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_0B1F.AHU08_0B1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_0B1F.AHU09_0B1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_0B1F.AHU10_0B1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_0B1F.AHU11_0B1F02);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 0B1F03
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "03");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_0B1F.AHU01_0B1F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_0B1F.AHU02_0B1F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_0B1F.AHU03_0B1F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_0B1F.AHU04_0B1F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_0B1F.AHU05_0B1F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_0B1F.AHU06_0B1F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_0B1F.AHU07_0B1F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_0B1F.AHU08_0B1F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_0B1F.AHU09_0B1F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_0B1F.AHU10_0B1F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_0B1F.AHU11_0B1F03);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 0B1F04
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "04");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_0B1F.AHU01_0B1F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_0B1F.AHU02_0B1F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_0B1F.AHU03_0B1F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_0B1F.AHU04_0B1F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_0B1F.AHU05_0B1F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_0B1F.AHU06_0B1F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_0B1F.AHU07_0B1F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_0B1F.AHU08_0B1F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_0B1F.AHU09_0B1F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_0B1F.AHU10_0B1F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_0B1F.AHU11_0B1F04);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 0B1F05
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "05");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_0B1F.AHU01_0B1F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_0B1F.AHU02_0B1F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_0B1F.AHU03_0B1F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_0B1F.AHU04_0B1F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_0B1F.AHU05_0B1F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_0B1F.AHU06_0B1F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_0B1F.AHU07_0B1F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_0B1F.AHU08_0B1F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_0B1F.AHU09_0B1F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_0B1F.AHU10_0B1F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_0B1F.AHU11_0B1F05);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 0B1F06
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "06");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_0B1F.AHU01_0B1F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_0B1F.AHU02_0B1F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_0B1F.AHU03_0B1F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_0B1F.AHU04_0B1F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_0B1F.AHU05_0B1F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_0B1F.AHU06_0B1F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_0B1F.AHU07_0B1F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_0B1F.AHU08_0B1F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_0B1F.AHU09_0B1F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_0B1F.AHU10_0B1F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_0B1F.AHU11_0B1F06);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 0B1F07
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "07");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_0B1F.AHU01_0B1F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_0B1F.AHU02_0B1F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_0B1F.AHU03_0B1F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_0B1F.AHU04_0B1F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_0B1F.AHU05_0B1F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_0B1F.AHU06_0B1F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_0B1F.AHU07_0B1F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_0B1F.AHU08_0B1F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_0B1F.AHU09_0B1F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_0B1F.AHU10_0B1F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_0B1F.AHU11_0B1F07);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 0B1F08
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "08");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_0B1F.AHU01_0B1F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_0B1F.AHU02_0B1F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_0B1F.AHU03_0B1F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_0B1F.AHU04_0B1F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_0B1F.AHU05_0B1F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_0B1F.AHU06_0B1F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_0B1F.AHU07_0B1F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_0B1F.AHU08_0B1F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_0B1F.AHU09_0B1F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_0B1F.AHU10_0B1F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_0B1F.AHU11_0B1F08);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #endregion

                                        affected = 0;
                                        sql = @"
UPDATE AHU_0B1 SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                        cmd.CommandText = sql;
                                        //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_0B1F.AUTOID);
                                        affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                        if (affected == 0)
                                        {
                                            //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + AHU_0B1F.AUTOID.ToString());
                                        }
                                    }
                                }
                            }


                        }
                    }
                    scop.Complete();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return affected;
        }

        public int WriteDataForAHU_00RF(AHU_00RF AHU_00RF)
        {
            string sql;
            int affected = 0;
            try
            {
                using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
                {
                    using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                    {
                        string active = null;
                        connB3BUFFER.Open();
                        using (DbCommand cmd = connB3BUFFER.CreateCommand())
                        {
                            sql = @"
                SELECT ACTIVE FROM AHU_0RF WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                            cmd.CommandText = sql;
                            DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_00RF.AUTOID);
                            var obj = DbB3BUFFER.ExecuteScalar(cmd);
                            if (obj != null)
                            {
                                active = obj.ToString();
                            }

                            if (active == "A")
                            {
                                using (DbConnection connDSCCR = DbDSCCR.CreateConnection())
                                {
                                    connDSCCR.Open();
                                    using (DbCommand cmdDSCCR = connDSCCR.CreateCommand())
                                    {
                                        sql = @"
INSERT INTO AHU (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,AHU01,AHU02,AHU03,AHU04,AHU05,AHU06,AHU07,AHU08,AHU09,AHU10,AHU11)     
    VALUES (@SID,@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                                        cmdDSCCR.CommandText = sql;
                                        #region 參數
                                        DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU01", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU02", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU03", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU04", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU05", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU06", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU07", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU08", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU09", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU10", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU11", DbType.Single);

                                        DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 91);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", AHU_00RF.AUTOID);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", AHU_00RF.DATETIME);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "00RF");

                                        #region 00RF01
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_00RF.AHU01_00RF01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_00RF.AHU02_00RF01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_00RF.AHU03_00RF01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_00RF.AHU04_00RF01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_00RF.AHU05_00RF01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_00RF.AHU06_00RF01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_00RF.AHU07_00RF01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_00RF.AHU08_00RF01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_00RF.AHU09_00RF01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_00RF.AHU10_00RF01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_00RF.AHU11_00RF01);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 00RF02
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "02");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_00RF.AHU01_00RF02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_00RF.AHU02_00RF02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_00RF.AHU03_00RF02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_00RF.AHU04_00RF02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_00RF.AHU05_00RF02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_00RF.AHU06_00RF02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_00RF.AHU07_00RF02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_00RF.AHU08_00RF02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_00RF.AHU09_00RF02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_00RF.AHU10_00RF02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_00RF.AHU11_00RF02);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 00RF03
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "03");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_00RF.AHU01_00RF03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_00RF.AHU02_00RF03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_00RF.AHU03_00RF03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_00RF.AHU04_00RF03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_00RF.AHU05_00RF03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_00RF.AHU06_00RF03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_00RF.AHU07_00RF03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_00RF.AHU08_00RF03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_00RF.AHU09_00RF03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_00RF.AHU10_00RF03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_00RF.AHU11_00RF03);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 00RF04
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "04");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_00RF.AHU01_00RF04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_00RF.AHU02_00RF04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_00RF.AHU03_00RF04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_00RF.AHU04_00RF04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_00RF.AHU05_00RF04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_00RF.AHU06_00RF04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_00RF.AHU07_00RF04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_00RF.AHU08_00RF04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_00RF.AHU09_00RF04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_00RF.AHU10_00RF04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_00RF.AHU11_00RF04);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 00RF05
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "05");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_00RF.AHU01_00RF05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_00RF.AHU02_00RF05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_00RF.AHU03_00RF05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_00RF.AHU04_00RF05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_00RF.AHU05_00RF05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_00RF.AHU06_00RF05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_00RF.AHU07_00RF05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_00RF.AHU08_00RF05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_00RF.AHU09_00RF05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_00RF.AHU10_00RF05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_00RF.AHU11_00RF05);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 00RF06
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "06");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_00RF.AHU01_00RF06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_00RF.AHU02_00RF06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_00RF.AHU03_00RF06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_00RF.AHU04_00RF06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_00RF.AHU05_00RF06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_00RF.AHU06_00RF06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_00RF.AHU07_00RF06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_00RF.AHU08_00RF06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_00RF.AHU09_00RF06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_00RF.AHU10_00RF06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_00RF.AHU11_00RF06);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 00RF07
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "07");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_00RF.AHU01_00RF07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_00RF.AHU02_00RF07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_00RF.AHU03_00RF07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_00RF.AHU04_00RF07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_00RF.AHU05_00RF07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_00RF.AHU06_00RF07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_00RF.AHU07_00RF07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_00RF.AHU08_00RF07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_00RF.AHU09_00RF07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_00RF.AHU10_00RF07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_00RF.AHU11_00RF07);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 00RF08
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "08");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_00RF.AHU01_00RF08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_00RF.AHU02_00RF08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_00RF.AHU03_00RF08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_00RF.AHU04_00RF08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_00RF.AHU05_00RF08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_00RF.AHU06_00RF08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_00RF.AHU07_00RF08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_00RF.AHU08_00RF08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_00RF.AHU09_00RF08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_00RF.AHU10_00RF08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_00RF.AHU11_00RF08);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 00RF09
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "09");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_00RF.AHU01_00RF09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_00RF.AHU02_00RF09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_00RF.AHU03_00RF09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_00RF.AHU04_00RF09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_00RF.AHU05_00RF09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_00RF.AHU06_00RF09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_00RF.AHU07_00RF09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_00RF.AHU08_00RF09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_00RF.AHU09_00RF09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_00RF.AHU10_00RF09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_00RF.AHU11_00RF09);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #endregion

                                        affected = 0;
                                        sql = @"
UPDATE AHU_0RF SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                        cmd.CommandText = sql;
                                        //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_00RF.AUTOID);
                                        affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                        if (affected == 0)
                                        {
                                            //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + AHU_00RF.AUTOID.ToString());
                                        }
                                    }
                                }
                            }


                        }
                    }
                    scop.Complete();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return affected;
        }

        public int WriteDataForAHU_014F(AHU_014F AHU_014F)
        {
            string sql;
            int affected = 0;
            try
            {
                using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
                {
                    using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                    {
                        string active = null;
                        connB3BUFFER.Open();
                        using (DbCommand cmd = connB3BUFFER.CreateCommand())
                        {
                            sql = @"
                SELECT ACTIVE FROM AHU_14F WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                            cmd.CommandText = sql;
                            DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_014F.AUTOID);
                            var obj = DbB3BUFFER.ExecuteScalar(cmd);
                            if (obj != null)
                            {
                                active = obj.ToString();
                            }

                            if (active == "A")
                            {
                                using (DbConnection connDSCCR = DbDSCCR.CreateConnection())
                                {
                                    connDSCCR.Open();
                                    using (DbCommand cmdDSCCR = connDSCCR.CreateCommand())
                                    {
                                        sql = @"
INSERT INTO AHU (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,AHU01,AHU02,AHU03,AHU04,AHU05,AHU06,AHU07,AHU08,AHU09,AHU10,AHU11)     
    VALUES (@SID,@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                                        cmdDSCCR.CommandText = sql;
                                        #region 參數
                                        DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU01", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU02", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU03", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU04", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU05", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU06", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU07", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU08", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU09", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU10", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU11", DbType.Single);

                                        DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 141);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", AHU_014F.AUTOID);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", AHU_014F.DATETIME);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "014F");

                                        #region 014F01
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F01);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F02
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "02");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F02);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F03
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "03");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F03);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F04
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "04");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F04);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F04);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F05
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "05");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F05);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F05);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F06
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "06");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F06);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F07
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "07");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F07);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F07);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F08
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "08");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F08);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F08);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F09
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "09");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F09);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F09);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F10
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "10");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F10);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F10);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F10);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F10);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F10);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F10);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F10);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F10);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F10);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F10);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F10);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F11
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "11");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F11);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F11);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F11);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F11);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F11);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F11);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F11);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F11);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F11);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F11);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F11);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F12
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "12");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F12);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F12);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F12);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F12);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F12);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F12);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F12);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F12);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F12);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F12);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F12);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F13
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "13");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F13);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F13);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F13);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F13);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F13);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F13);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F13);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F13);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F13);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F13);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F13);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F14
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "14");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F14);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F14);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F14);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F14);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F14);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F14);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F14);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F14);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F14);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F14);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F14);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F15
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "15");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F15);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F15);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F15);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F15);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F15);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F15);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F15);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F15);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F15);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F15);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F15);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 014F16
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "16");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_014F.AHU01_014F16);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_014F.AHU02_014F16);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_014F.AHU03_014F16);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_014F.AHU04_014F16);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_014F.AHU05_014F16);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_014F.AHU06_014F16);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_014F.AHU07_014F16);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_014F.AHU08_014F16);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_014F.AHU09_014F16);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_014F.AHU10_014F16);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_014F.AHU11_014F16);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #endregion

                                        affected = 0;
                                        sql = @"
UPDATE AHU_14F SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                        cmd.CommandText = sql;
                                        //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_014F.AUTOID);
                                        affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                        if (affected == 0)
                                        {
                                            //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + AHU_014F.AUTOID.ToString());
                                        }
                                    }
                                }
                            }

                
                        }
                    }
                    scop.Complete();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return affected;
        }

        public int WriteDataForAHU_S03F(AHU_S03F AHU_S03F)
        {
            string sql;
            int affected = 0;
            try
            {
                using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
                {
                    using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                    {
                        string active = null;
                        connB3BUFFER.Open();
                        using (DbCommand cmd = connB3BUFFER.CreateCommand())
                        {
                            sql = @"
                SELECT ACTIVE FROM AHU_S03 WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                            cmd.CommandText = sql;
                            DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_S03F.AUTOID);
                            var obj = DbB3BUFFER.ExecuteScalar(cmd);
                            if (obj != null)
                            {
                                active = obj.ToString();
                            }

                            if (active == "A")
                            {
                                using (DbConnection connDSCCR = DbDSCCR.CreateConnection())
                                {
                                    connDSCCR.Open();
                                    using (DbCommand cmdDSCCR = connDSCCR.CreateCommand())
                                    {
                                        sql = @"
INSERT INTO AHU (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,AHU01,AHU02,AHU03,AHU04,AHU05,AHU06,AHU07,AHU08,AHU09,AHU10,AHU11)     
    VALUES (@SID,@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                                        cmdDSCCR.CommandText = sql;
                                        #region 參數
                                        DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU01", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU02", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU03", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU04", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU05", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU06", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU07", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU08", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU09", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU10", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU11", DbType.Single);

                                        DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 1);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", AHU_S03F.AUTOID);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", AHU_S03F.DATETIME);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "S03F");

                                        #region S03F01
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_S03F.AHU01_S03F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_S03F.AHU02_S03F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_S03F.AHU03_S03F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_S03F.AHU04_S03F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_S03F.AHU05_S03F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_S03F.AHU06_S03F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_S03F.AHU07_S03F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_S03F.AHU08_S03F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_S03F.AHU09_S03F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_S03F.AHU10_S03F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_S03F.AHU11_S03F01);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #endregion
                                    }
                                }
                            }

                            affected = 0;
                            sql = @"
UPDATE AHU_S03 SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                            cmd.CommandText = sql;
                            //DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_S03F.AUTOID);
                            affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                            if (affected == 0)
                            {
                                //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + AHU_S03F.AUTOID.ToString());
                            }
                        }
                    }
                    scop.Complete();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return affected;
        }
            
        public int WriteDataForAHU_SB1F(AHU_SB1F AHU_SB1F)
        {
            string sql;
            int affected = 0;
            try
            {
                using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
                {
                    using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                    {
                        string active = null;
                        connB3BUFFER.Open();
                        using (DbCommand cmd = connB3BUFFER.CreateCommand())
                        {
                            sql = @"
                SELECT ACTIVE FROM AHU_SB1 WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                            cmd.CommandText = sql;
                            DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_SB1F.AUTOID);
                            var obj = DbB3BUFFER.ExecuteScalar(cmd);
                            if (obj != null)
                            {
                                active = obj.ToString();
                            }

                            if (active == "A")
                            {
                                using (DbConnection connDSCCR = DbDSCCR.CreateConnection())
                                {
                                    connDSCCR.Open();
                                    using (DbCommand cmdDSCCR = connDSCCR.CreateCommand())
                                    {
                                        sql = @"
INSERT INTO AHU (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,AHU01,AHU02,AHU03,AHU04,AHU05,AHU06,AHU07,AHU08,AHU09,AHU10,AHU11)     
    VALUES (@SID,@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                                        cmdDSCCR.CommandText = sql;
                                        #region 參數
                                        DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU01", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU02", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU03", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU04", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU05", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU06", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU07", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU08", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU09", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU10", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AHU11", DbType.Single);

                                        DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 91);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", AHU_SB1F.AUTOID);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", AHU_SB1F.DATETIME);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "SB1F");

                                        #region SB1F01
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_SB1F.AHU01_SB1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_SB1F.AHU02_SB1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_SB1F.AHU03_SB1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_SB1F.AHU04_SB1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_SB1F.AHU05_SB1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_SB1F.AHU06_SB1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_SB1F.AHU07_SB1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_SB1F.AHU08_SB1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_SB1F.AHU09_SB1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_SB1F.AHU10_SB1F01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_SB1F.AHU11_SB1F01);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region SB1F02
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "02");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU01", AHU_SB1F.AHU01_SB1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU02", AHU_SB1F.AHU02_SB1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU03", AHU_SB1F.AHU03_SB1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU04", AHU_SB1F.AHU04_SB1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU05", AHU_SB1F.AHU05_SB1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU06", AHU_SB1F.AHU06_SB1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU07", AHU_SB1F.AHU07_SB1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU08", AHU_SB1F.AHU08_SB1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU09", AHU_SB1F.AHU09_SB1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU10", AHU_SB1F.AHU10_SB1F02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AHU11", AHU_SB1F.AHU11_SB1F02);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #endregion

                                        affected = 0;
                                        sql = @"
UPDATE AHU_SB1 SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                        cmd.CommandText = sql;
                                        //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, AHU_SB1F.AUTOID);
                                        affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                        if (affected == 0)
                                        {
                                            //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + AHU_SB1F.AUTOID.ToString());
                                        }
                                    }
                                }
                            }


                        }
                    }
                    scop.Complete();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return affected;
        }

        public int WriteDataForChiller(Chiller Chiller)
        {
            string sql;
            int affected = 0;
            try
            {
                using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
                {
                    using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                    {
                        string active = null;
                        connB3BUFFER.Open();
                        using (DbCommand cmd = connB3BUFFER.CreateCommand())
                        {
                            sql = @"
                SELECT ACTIVE FROM Chiller WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                            cmd.CommandText = sql;
                            DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, Chiller.AUTOID);
                            var obj = DbB3BUFFER.ExecuteScalar(cmd);
                            if (obj != null)
                            {
                                active = obj.ToString();
                            }

                            if (active == "A")
                            {
                                using (DbConnection connDSCCR = DbDSCCR.CreateConnection())
                                {
                                    connDSCCR.Open();
                                    using (DbCommand cmdDSCCR = connDSCCR.CreateCommand())
                                    {
                                        sql = @"
INSERT INTO Chiller (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,Chiller01,Chiller02,Chiller03,Chiller04,Chiller05,Chiller06,Chiller07,Chiller08,Chiller09,Chiller10)
    VALUES (@SID,@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@Chiller01,@Chiller02,@Chiller03,@Chiller04,@Chiller05,@Chiller06,@Chiller07,@Chiller08,@Chiller09,@Chiller10)
";
                                        cmdDSCCR.CommandText = sql;
                                        #region 參數
                                        DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "Chiller01", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "Chiller02", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "Chiller03", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "Chiller04", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "Chiller05", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "Chiller06", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "Chiller07", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "Chiller08", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "Chiller09", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "Chiller10", DbType.Single);

                                        DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 71);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", Chiller.AUTOID);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", Chiller.DATETIME);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "XXXF");

                                        #region R1
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "R1");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller01", Chiller.Chiller01_R1);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller02", Chiller.Chiller02_R1);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller03", Chiller.Chiller03_R1);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller04", Chiller.Chiller04_R1);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller05", Chiller.Chiller05_R1);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller06", Chiller.Chiller06_R1);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller07", Chiller.Chiller07_R1);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller08", Chiller.Chiller08_R1);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller09", Chiller.Chiller09_R1);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller10", Chiller.Chiller10_R1);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region R2
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "R2");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller01", Chiller.Chiller01_R2);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller02", Chiller.Chiller02_R2);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller03", Chiller.Chiller03_R2);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller04", Chiller.Chiller04_R2);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller05", Chiller.Chiller05_R2);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller06", Chiller.Chiller06_R2);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller07", Chiller.Chiller07_R2);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller08", Chiller.Chiller08_R2);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller09", Chiller.Chiller09_R2);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller10", Chiller.Chiller10_R2);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region R3
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "R3");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller01", Chiller.Chiller01_R3);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller02", Chiller.Chiller02_R3);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller03", Chiller.Chiller03_R3);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller04", Chiller.Chiller04_R3);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller05", Chiller.Chiller05_R3);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller06", Chiller.Chiller06_R3);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller07", Chiller.Chiller07_R3);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller08", Chiller.Chiller08_R3);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller09", Chiller.Chiller09_R3);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller10", Chiller.Chiller10_R3);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region R6
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "R6");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller01", Chiller.Chiller01_R6);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller02", Chiller.Chiller02_R6);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller03", Chiller.Chiller03_R6);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller04", Chiller.Chiller04_R6);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller05", Chiller.Chiller05_R6);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller06", Chiller.Chiller06_R6);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller07", Chiller.Chiller07_R6);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller08", Chiller.Chiller08_R6);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller09", Chiller.Chiller09_R6);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "Chiller10", Chiller.Chiller10_R6);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #endregion

                                        affected = 0;
                                        sql = @"
UPDATE Chiller SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                        cmd.CommandText = sql;
                                        //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, ChillerF.AUTOID);
                                        affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                        if (affected == 0)
                                        {
                                            //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + ChillerF.AUTOID.ToString());
                                        }
                                    }
                                }
                            }


                        }
                    }
                    scop.Complete();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return affected;
        }

        public int WriteDataForCOP(COP COP)
        {
            string sql;
            int affected = 0;
            try
            {
                using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
                {
                    using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                    {
                        string active = null;
                        connB3BUFFER.Open();
                        using (DbCommand cmd = connB3BUFFER.CreateCommand())
                        {
                            sql = @"
                SELECT ACTIVE FROM COP WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                            cmd.CommandText = sql;
                            DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, COP.AUTOID);
                            var obj = DbB3BUFFER.ExecuteScalar(cmd);
                            if (obj != null)
                            {
                                active = obj.ToString();
                            }

                            if (active == "A")
                            {
                                using (DbConnection connDSCCR = DbDSCCR.CreateConnection())
                                {
                                    connDSCCR.Open();
                                    using (DbCommand cmdDSCCR = connDSCCR.CreateCommand())
                                    {
                                        sql = @"
INSERT INTO COP (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,COP01,COP02,COP03,COP04,COP05)
    VALUES (@SID,@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@COP01,@COP02,@COP03,@COP04,@COP05)
";
                                        cmdDSCCR.CommandText = sql;
                                        #region 參數
                                        DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "COP01", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "COP02", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "COP03", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "COP04", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "COP05", DbType.Single);

                                        DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 81);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", COP.AUTOID);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", COP.DATETIME);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "COPF");

                                        #region 001
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "001");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP01", COP.COP01_001);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP02", COP.COP02_001);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP03", COP.COP03_001);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP04", COP.COP04_001);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP05", COP.COP05_001);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 002
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "002");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP01", COP.COP01_002);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP02", COP.COP02_002);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP03", COP.COP03_002);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP04", COP.COP04_002);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP05", COP.COP05_002);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 003
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "003");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP01", COP.COP01_003);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP02", COP.COP02_003);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP03", COP.COP03_003);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP04", COP.COP04_003);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP05", COP.COP05_003);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 006
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "006");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP01", COP.COP01_006);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP02", COP.COP02_006);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP03", COP.COP03_006);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP04", COP.COP04_006);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP05", COP.COP05_006);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 12S
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "12S");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP01", COP.COP01_12S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP02", COP.COP02_12S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP03", COP.COP03_12S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP04", COP.COP04_12S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP05", COP.COP05_12S);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 03S
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "03S");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP01", COP.COP01_03S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP02", COP.COP02_03S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP03", COP.COP03_03S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP04", COP.COP04_03S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP05", COP.COP05_03S);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 06S
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "06S");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP01", COP.COP01_06S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP02", COP.COP02_06S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP03", COP.COP03_06S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP04", COP.COP04_06S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "COP05", COP.COP05_06S);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion

                                        #endregion

                                        affected = 0;
                                        sql = @"
UPDATE COP SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                        cmd.CommandText = sql;
                                        //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, COPF.AUTOID);
                                        affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                        if (affected == 0)
                                        {
                                            //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + COPF.AUTOID.ToString());
                                        }
                                    }
                                }
                            }


                        }
                    }
                    scop.Complete();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return affected;
        }

        public int WriteDataForCP(CP CP)
        {
            string sql;
            int affected = 0;
            try
            {
                using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
                {
                    using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                    {
                        string active = null;
                        connB3BUFFER.Open();
                        using (DbCommand cmd = connB3BUFFER.CreateCommand())
                        {
                            sql = @"
                SELECT ACTIVE FROM CP WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                            cmd.CommandText = sql;
                            DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, CP.AUTOID);
                            var obj = DbB3BUFFER.ExecuteScalar(cmd);
                            if (obj != null)
                            {
                                active = obj.ToString();
                            }

                            if (active == "A")
                            {
                                using (DbConnection connDSCCR = DbDSCCR.CreateConnection())
                                {
                                    connDSCCR.Open();
                                    using (DbCommand cmdDSCCR = connDSCCR.CreateCommand())
                                    {
                                        sql = @"
INSERT INTO CP (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,CP01,CP02,CP03,CP04,CP05,CP06,CP07)
    VALUES (@SID,@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@CP01,@CP02,@CP03,@CP04,@CP05,@CP06,@CP07)
";
                                        cmdDSCCR.CommandText = sql;
                                        #region 參數
                                        DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "CP01", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "CP02", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "CP03", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "CP04", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "CP05", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "CP06", DbType.Single);
                                        DbDSCCR.AddInParameter(cmdDSCCR, "CP07", DbType.Single);

                                        DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 61);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", CP.AUTOID);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", CP.DATETIME);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "CPF");

                                        #region 01
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP01", CP.CP01_01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP02", CP.CP02_01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP03", CP.CP03_01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP04", CP.CP04_01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP05", CP.CP05_01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP06", CP.CP06_01);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP07", CP.CP07_01);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 02
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "02");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP01", CP.CP01_02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP02", CP.CP02_02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP03", CP.CP03_02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP04", CP.CP04_02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP05", CP.CP05_02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP06", CP.CP06_02);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP07", CP.CP07_02);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 03
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "03");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP01", CP.CP01_03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP02", CP.CP02_03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP03", CP.CP03_03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP04", CP.CP04_03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP05", CP.CP05_03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP06", CP.CP06_03);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP07", CP.CP07_03);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 06
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "06");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP01", CP.CP01_06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP02", CP.CP02_06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP03", CP.CP03_06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP04", CP.CP04_06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP05", CP.CP05_06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP06", CP.CP06_06);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP07", CP.CP07_06);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #region 0S
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "0S");
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP01", CP.CP01_0S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP02", CP.CP02_0S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP03", CP.CP03_0S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP04", CP.CP04_0S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP05", CP.CP05_0S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP06", CP.CP06_0S);
                                        DbDSCCR.SetParameterValue(cmdDSCCR, "CP07", CP.CP07_0S);
                                        affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                        #endregion
                                        #endregion

                                        affected = 0;
                                        sql = @"
UPDATE CP SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                        cmd.CommandText = sql;
                                        //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, CPF.AUTOID);
                                        affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                        if (affected == 0)
                                        {
                                            //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + CPF.AUTOID.ToString());
                                        }
                                    }
                                }
                            }


                        }
                    }
                    scop.Complete();
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return affected;
        }
    }
}

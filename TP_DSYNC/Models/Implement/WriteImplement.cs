using System;
using TP_DSYNC.Models.DataAccess;
using TP_DSYNC.Models.DataDefine.B3;
using System.Data;
using System.Data.Common;
using System.Transactions;

namespace TP_DSYNC.Models.Implement
{
    public class WriteImplement : B3BUFFER_DSCCR_Access
    {
        public WriteImplement(string connectionStringNameB3BUFFER, string connectionStringNameDSCCR) : base(connectionStringNameB3BUFFER, connectionStringNameDSCCR) { }

        public int WriteDataForAHU_004F(AHU_004F AHU_004F)
        {
            string sql;
            int affected = 0;

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
    VALUES (NEXT VALUE FOR [AHU_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
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

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 91);
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

            return affected;
        }

        public int WriteDataForAHU_0B1F(AHU_0B1F AHU_0B1F)
        {
            string sql;
            int affected = 0;

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
    VALUES (NEXT VALUE FOR [AHU_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
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

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 91);
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

            return affected;
        }

        public int WriteDataForAHU_00RF(AHU_00RF AHU_00RF)
        {
            string sql;
            int affected = 0;

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
    VALUES (NEXT VALUE FOR [AHU_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
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

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 91);
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

            return affected;
        }

        public int WriteDataForAHU_014F(AHU_014F AHU_014F)
        {
            string sql;
            int affected = 0;

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
    VALUES (NEXT VALUE FOR [AHU_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
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

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 141);
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

            return affected;
        }

        public int WriteDataForAHU_S03F(AHU_S03F AHU_S03F)
        {
            string sql;
            int affected = 0;

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
    VALUES (NEXT VALUE FOR [AHU_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
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

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 1);
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

            return affected;
        }

        public int WriteDataForAHU_SB1F(AHU_SB1F AHU_SB1F)
        {
            string sql;
            int affected = 0;

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
    VALUES (NEXT VALUE FOR [AHU_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@AHU01,@AHU02,@AHU03,@AHU04,@AHU05,@AHU06,@AHU07,@AHU08,@AHU09,@AHU10,@AHU11)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
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

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 91);
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

            return affected;
        }

        public int WriteDataForChiller(Chiller Chiller)
        {
            string sql;
            int affected = 0;

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
    VALUES (NEXT VALUE FOR [Chiller_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@Chiller01,@Chiller02,@Chiller03,@Chiller04,@Chiller05,@Chiller06,@Chiller07,@Chiller08,@Chiller09,@Chiller10)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
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

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 71);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", Chiller.AUTOID);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", Chiller.DATETIME);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "XXXF");

                                    #region R1冰機
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
                                    #region R2冰機
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
                                    #region R3冰機
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
                                    #region R6=>R4冰機
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

            return affected;
        }

        public int WriteDataForCOP(COP COP)
        {
            string sql;
            int affected = 0;

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
    VALUES (NEXT VALUE FOR [COP_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@COP01,@COP02,@COP03,@COP04,@COP05)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "COP01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "COP02", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "COP03", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "COP04", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "COP05", DbType.Single);

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 81);
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

            return affected;
        }

        public int WriteDataForCP(CP CP)
        {
            string sql;
            int affected = 0;

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
    VALUES (NEXT VALUE FOR [CP_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@CP01,@CP02,@CP03,@CP04,@CP05,@CP06,@CP07)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
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

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 61);
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

            return affected;
        }

        public int WriteDataForZP(ZP ZP)
        {
            string sql;
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                {
                    string active = null;
                    connB3BUFFER.Open();
                    using (DbCommand cmd = connB3BUFFER.CreateCommand())
                    {
                        sql = @"
                SELECT ACTIVE FROM ZP WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                        cmd.CommandText = sql;
                        DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, ZP.AUTOID);
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
INSERT INTO ZP (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,ZP01,ZP02,ZP03,ZP04,ZP05,ZP06)
    VALUES (NEXT VALUE FOR [ZP_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@ZP01,@ZP02,@ZP03,@ZP04,@ZP05,@ZP06)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "ZP01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "ZP02", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "ZP03", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "ZP04", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "ZP05", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "ZP06", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "ZP07", DbType.Single);

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 61);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", ZP.AUTOID);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", ZP.DATETIME);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "ZPF");

                                    #region 00
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "00");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP01", ZP.ZP01_00);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP02", ZP.ZP02_00);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP03", ZP.ZP03_00);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP04", ZP.ZP04_00);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP05", ZP.ZP05_00);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP06", ZP.ZP06_00);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 01
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP01", ZP.ZP01_01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP02", ZP.ZP02_01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP03", ZP.ZP03_01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP04", ZP.ZP04_01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP05", ZP.ZP05_01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP06", ZP.ZP06_01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 02
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "02");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP01", ZP.ZP01_02);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP02", ZP.ZP02_02);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP03", ZP.ZP03_02);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP04", ZP.ZP04_02);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP05", ZP.ZP05_02);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "ZP06", ZP.ZP06_02);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #endregion

                                    affected = 0;
                                    sql = @"
UPDATE ZP SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                    cmd.CommandText = sql;
                                    //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, ZPF.AUTOID);
                                    affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                    if (affected == 0)
                                    {
                                        //throw new Exception("ACTIVE='A'->'S'失敗 AUTOID = " + ZPF.AUTOID.ToString());
                                    }
                                }
                            }
                        }


                    }
                }
                scop.Complete();
            }

            return affected;
        }

        public int WriteDataForCT(CT CT)
        {
            string sql;
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                {
                    string active = null;
                    connB3BUFFER.Open();
                    using (DbCommand cmd = connB3BUFFER.CreateCommand())
                    {
                        sql = @"
                SELECT ACTIVE FROM CT WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                        cmd.CommandText = sql;
                        DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, CT.AUTOID);
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
INSERT INTO CT (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,CT01,CT02,CT03,CT04,CT05,CT06,CT07)
    VALUES (NEXT VALUE FOR [CT_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@CT01,@CT02,@CT03,@CT04,@CT05,@CT06,@CT07)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "CT01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "CT02", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "CT03", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "CT04", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "CT05", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "CT06", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "CT07", DbType.Single);

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 61);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", CT.AUTOID);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", CT.DATETIME);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "CTF");

                                    #region 01
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT01", CT.CT01_01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT02", CT.CT02_01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT03", CT.CT03_01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT04", CT.CT04_01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT05", CT.CT05_01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT06", CT.CT06_01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT07", CT.CT07_01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 02
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "02");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT01", CT.CT01_02);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT02", CT.CT02_02);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT03", CT.CT03_02);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT04", CT.CT04_02);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT05", CT.CT05_02);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT06", CT.CT06_02);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT07", CT.CT07_02);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 03
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "03");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT01", CT.CT01_03);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT02", CT.CT02_03);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT03", CT.CT03_03);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT04", CT.CT04_03);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT05", CT.CT05_03);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT06", CT.CT06_03);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT07", CT.CT07_03);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 04
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "04");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT01", CT.CT01_04);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT02", CT.CT02_04);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT03", CT.CT03_04);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT04", CT.CT04_04);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT05", CT.CT05_04);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT06", CT.CT06_04);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT07", CT.CT07_04);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 05
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "05");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT01", CT.CT01_05);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT02", CT.CT02_05);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT03", CT.CT03_05);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT04", CT.CT04_05);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT05", CT.CT05_05);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT06", CT.CT06_05);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT07", CT.CT07_05);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 06
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "06");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT01", CT.CT01_06);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT02", CT.CT02_06);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT03", CT.CT03_06);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT04", CT.CT04_06);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT05", CT.CT05_06);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT06", CT.CT06_06);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "CT07", CT.CT07_06);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                
                                    #endregion

                                    affected = 0;
                                    sql = @"
UPDATE CT SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                    cmd.CommandText = sql;
                                    //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, CTF.AUTOID);
                                    affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                    if (affected == 0)
                                    {
                                        //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + CTF.AUTOID.ToString());
                                    }
                                }
                            }
                        }


                    }
                }
                scop.Complete();
            }

            return affected;
        }

        public int WriteDataForRRS_VFLH(RRS_VFLH RRS_VFLH)
        {
            string sql;
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                {
                    string active = null;
                    connB3BUFFER.Open();
                    using (DbCommand cmd = connB3BUFFER.CreateCommand())
                    {
                        sql = @"
                SELECT ACTIVE FROM RRS_VFLH WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                        cmd.CommandText = sql;
                        DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, RRS_VFLH.AUTOID);
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
INSERT INTO RRS_VFLH (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,RRS01_VFLH01,RRS02_VFLH01,RRS03_VFLH01,RRS04_VFLH01,RRS05_VFLH01,RRS06_VFLH01)
    VALUES (NEXT VALUE FOR [RRS_VFLH_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@RRS01_VFLH01,@RRS02_VFLH01,@RRS03_VFLH01,@RRS04_VFLH01,@RRS05_VFLH01,@RRS06_VFLH01)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS01_VFLH01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS02_VFLH01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS03_VFLH01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS04_VFLH01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS05_VFLH01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS06_VFLH01", DbType.Single);

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 71);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", RRS_VFLH.AUTOID);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", RRS_VFLH.DATETIME);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "XF");

                                    #region 01
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS01_VFLH01", RRS_VFLH.RRS01_VFLH01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS02_VFLH01", RRS_VFLH.RRS02_VFLH01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS03_VFLH01", RRS_VFLH.RRS03_VFLH01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS04_VFLH01", RRS_VFLH.RRS04_VFLH01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS05_VFLH01", RRS_VFLH.RRS05_VFLH01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS06_VFLH01", RRS_VFLH.RRS06_VFLH01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #endregion

                                    affected = 0;
                                    sql = @"
UPDATE RRS_VFLH SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                    cmd.CommandText = sql;
                                    //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, RRS_VFLHF.AUTOID);
                                    affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                    if (affected == 0)
                                    {
                                        //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + RRS_VFLHF.AUTOID.ToString());
                                    }
                                }
                            }
                        }


                    }
                }
                scop.Complete();
            }

            return affected;
        }

        public int WriteDataForRRS_PVOI(RRS_PVOI RRS_PVOI)
        {
            string sql;
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                {
                    string active = null;
                    connB3BUFFER.Open();
                    using (DbCommand cmd = connB3BUFFER.CreateCommand())
                    {
                        sql = @"
                SELECT ACTIVE FROM RRS_PVOI WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                        cmd.CommandText = sql;
                        DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, RRS_PVOI.AUTOID);
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
INSERT INTO RRS_PVOI (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,RRS01_PVOI01,RRS02_PVOI01,RRS03_PVOI01,RRS04_PVOI01,RRS05_PVOI01,RRS06_PVOI01,RRS07_PVOI01)
    VALUES (NEXT VALUE FOR [RRS_PVOI_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@RRS01_PVOI01,@RRS02_PVOI01,@RRS03_PVOI01,@RRS04_PVOI01,@RRS05_PVOI01,@RRS06_PVOI01,@RRS07_PVOI01)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS01_PVOI01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS02_PVOI01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS03_PVOI01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS04_PVOI01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS05_PVOI01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS06_PVOI01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS07_PVOI01", DbType.Single);

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 71);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", RRS_PVOI.AUTOID);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", RRS_PVOI.DATETIME);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "XF");

                                    #region 01
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS01_PVOI01",  RRS_PVOI.RRS01_PVOI01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS02_PVOI01",  RRS_PVOI.RRS02_PVOI01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS03_PVOI01",  RRS_PVOI.RRS03_PVOI01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS04_PVOI01",  RRS_PVOI.RRS04_PVOI01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS05_PVOI01",  RRS_PVOI.RRS05_PVOI01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS06_PVOI01",  RRS_PVOI.RRS06_PVOI01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS07_PVOI01",  RRS_PVOI.RRS07_PVOI01);

                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #endregion

                                    affected = 0;
                                    sql = @"
UPDATE RRS_PVOI SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                    cmd.CommandText = sql;
                                    //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, RRS_PVOIF.AUTOID);
                                    affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                    if (affected == 0)
                                    {
                                        //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + RRS_PVOIF.AUTOID.ToString());
                                    }
                                }
                            }
                        }


                    }
                }
                scop.Complete();
            }

            return affected;
        }

        public int WriteDataForRRS_PWLS(RRS_PWLS RRS_PWLS)
        {
            string sql;
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                {
                    string active = null;
                    connB3BUFFER.Open();
                    using (DbCommand cmd = connB3BUFFER.CreateCommand())
                    {
                        sql = @"
                SELECT ACTIVE FROM RRS_PWLS WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                        cmd.CommandText = sql;
                        DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, RRS_PWLS.AUTOID);
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
INSERT INTO RRS_PWLS (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,RRS01_PWLS01,RRS02_PWLS01,RRS03_PWLS01,RRS04_PWLS01,RRS05_PWLS01,RRS06_PWLS01,RRS07_PWLS01,RRS08_PWLS01,RRS09_PWLS01,RRS10_PWLS01,RRS11_PWLS01,RRS12_PWLS01,RRS13_PWLS01)
    VALUES (NEXT VALUE FOR [RRS_PWLS_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@RRS01_PWLS01,@RRS02_PWLS01,@RRS03_PWLS01,@RRS04_PWLS01,@RRS05_PWLS01,@RRS06_PWLS01,@RRS07_PWLS01,@RRS08_PWLS01,@RRS09_PWLS01,@RRS10_PWLS01,@RRS11_PWLS01,@RRS12_PWLS01,@RRS13_PWLS01)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS01_PWLS01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS02_PWLS01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS03_PWLS01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS04_PWLS01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS05_PWLS01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS06_PWLS01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS07_PWLS01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS08_PWLS01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS09_PWLS01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS10_PWLS01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS11_PWLS01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS12_PWLS01", DbType.Single);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "RRS13_PWLS01", DbType.Single);

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 71);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", RRS_PWLS.AUTOID);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", RRS_PWLS.DATETIME);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "XF");

                                    #region 01
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS01_PWLS01",  RRS_PWLS.RRS01_PWLS01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS02_PWLS01",  RRS_PWLS.RRS02_PWLS01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS03_PWLS01",  RRS_PWLS.RRS03_PWLS01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS04_PWLS01",  RRS_PWLS.RRS04_PWLS01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS05_PWLS01",  RRS_PWLS.RRS05_PWLS01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS06_PWLS01",  RRS_PWLS.RRS06_PWLS01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS07_PWLS01",  RRS_PWLS.RRS07_PWLS01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS08_PWLS01",  RRS_PWLS.RRS08_PWLS01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS09_PWLS01",  RRS_PWLS.RRS09_PWLS01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS10_PWLS01",  RRS_PWLS.RRS10_PWLS01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS11_PWLS01",  RRS_PWLS.RRS11_PWLS01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS12_PWLS01",  RRS_PWLS.RRS12_PWLS01);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "RRS13_PWLS01",  RRS_PWLS.RRS13_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #endregion

                                    affected = 0;
                                    sql = @"
UPDATE RRS_PWLS SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                    cmd.CommandText = sql;
                                    //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, RRS_PWLSF.AUTOID);
                                    affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                    if (affected == 0)
                                    {
                                        //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + RRS_PWLSF.AUTOID.ToString());
                                    }
                                }
                            }
                        }


                    }
                }
                scop.Complete();
            }

            return affected;
        }

        public int WriteDataForWSDS_PVOI(WSDS_PVOI WSDS_PVOI)
        {
            string sql;
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                {
                    string active = null;
                    connB3BUFFER.Open();
                    using (DbCommand cmd = connB3BUFFER.CreateCommand())
                    {
                        sql = @"
                SELECT ACTIVE FROM WSDS_PVOI WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                        cmd.CommandText = sql;
                        DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, WSDS_PVOI.AUTOID);
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
INSERT INTO WSDS_PVOI (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,WSDS_PVOI_STATUS)
    VALUES (NEXT VALUE FOR [WSDS_PVOI_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@WSDS_PVOI_STATUS)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "WSDS_PVOI_STATUS", DbType.Single);
                                  
                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 71);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", WSDS_PVOI.AUTOID);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", WSDS_PVOI.DATETIME);

                                    #region 主樓PH1(給水)	高層給水泵P1
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "PH1S");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS01_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓PH1(給水)	高層給水泵P2
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "PH1S");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "02");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS02_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓PH1(飲水)	高層飲用水泵P7
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "PH1D");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "03");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS03_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓PH1(飲水)	高層飲用水泵P8
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "PH1D");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "04");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS04_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓19F(給水)	中層給水泵P3
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "19FS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "05");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS05_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓19F(給水)	中層給水泵P4
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "19FS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "06");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS06_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓19F(飲水)	中層飲用水泵P9
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "19FD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "07");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS07_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓19F(飲水)	中層飲用水泵P10
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "19FD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "08");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS08_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓8F(給水)	    低層給水泵P5
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "08FS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "09");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS09_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓8F(給水)	    低層給水泵P6
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "08FS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "10");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS10_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓8F(飲水)	    低層飲用水泵P11
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "08FD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "11");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS11_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓8F(飲水)	    低層飲用水泵P12
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "08FD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "12");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS12_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B3F(B1車道雨廢水)	    廢水泵P15 (B3-12室)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B3FC");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "13");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS13_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B3F(B1車道雨廢水)	    廢水泵P16 (B3-12室)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B3FC");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "14");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS14_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B3F(糞便)	污水泵P13(B3-24室)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B3FX");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "15");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS15_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B3F(糞便)	污水泵P14(B3-24室)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B3FX");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "16");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS16_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(B1以下糞水)	排放泵#1(近B2-116車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "SB2X");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "17");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS17_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(B1以下糞水)	排放泵#2(近B2-116車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "SB2X");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "18");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS18_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(廚房污水)	    污水泵#1(近B2-122車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "SB2K");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "19");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS19_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(廚房污水)	    污水泵#2(近B2-122車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "SB2K");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "20");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS20_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(雨水儲存) 	廢水泵#2604(B2-81車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "SB2R");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "21");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS21_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(雨水儲存)	    廢水泵#2605(B2-81車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "SB2R");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "22");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS22_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(雨水離心排放)	    廢水泵#2606(B2-74車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "SB2E");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "23");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS23_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(雨水離心排放)	    廢水泵#2607(B2-74車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "SB2E");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "24");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS24_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(飲用及給水)	給水泵#1(B2-81旁房間)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "SB2Y");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "25");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS25_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(飲用及給水)	給水泵#2 (B2-81旁房間)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "SB2Y");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "26");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PVOI_STATUS", WSDS_PVOI.WSDS26_PVOI01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion

                                    #endregion

                                    affected = 0;
                                    sql = @"
UPDATE WSDS_PVOI SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                    cmd.CommandText = sql;
                                    //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, WSDS_PVOIF.AUTOID);
                                    affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                    if (affected == 0)
                                    {
                                        //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + WSDS_PVOIF.AUTOID.ToString());
                                    }
                                }
                            }
                        }


                    }
                }
                scop.Complete();
            }

            return affected;
        }

        public int WriteDataForWSDS_PWLS(WSDS_PWLS WSDS_PWLS)
        {
            string sql;
            int affected = 0;

            using (TransactionScope scop = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                using (DbConnection connB3BUFFER = DbB3BUFFER.CreateConnection())
                {
                    string active = null;
                    connB3BUFFER.Open();
                    using (DbCommand cmd = connB3BUFFER.CreateCommand())
                    {
                        sql = @"
                SELECT ACTIVE FROM WSDS_PWLS WITH(UPDLOCK,ROWLOCK) WHERE AUTOID=@AUTOID AND ACTIVE='A'
                ";
                        cmd.CommandText = sql;
                        DbB3BUFFER.AddInParameter(cmd, "AUTOID", DbType.Int32, WSDS_PWLS.AUTOID);
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
INSERT INTO WSDS_PWLS (SID,AUTOID,DATETIME,LOCATION,DEVICE_ID,WSDS_PWLS_STATUS)
    VALUES (NEXT VALUE FOR [WSDS_PWLS_SEQ],@AUTOID,@DATETIME,@LOCATION,@DEVICE_ID,@WSDS_PWLS_STATUS)
";
                                    cmdDSCCR.CommandText = sql;
                                    #region 參數
                                    //DbDSCCR.AddInParameter(cmdDSCCR, "SID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "AUTOID", DbType.Int32);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DATETIME", DbType.DateTime);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "LOCATION", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "DEVICE_ID", DbType.String);
                                    DbDSCCR.AddInParameter(cmdDSCCR, "WSDS_PWLS_STATUS", DbType.Single);

                                    //DbDSCCR.SetParameterValue(cmdDSCCR, "SID", 71);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "AUTOID", WSDS_PWLS.AUTOID);
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DATETIME", WSDS_PWLS.DATETIME);

                                    #region 主樓PH2東側(水塔補水箱)	CT7及CT10水塔補水箱水位檢知警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "PH2E");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "01");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS01_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓PH2西側(水塔補水箱)	CT9及CT15水塔補水箱水位檢知警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "PH2W");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "02");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS02_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓PH2(高層給水塔)	16-27樓高層給水高塔滿水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "PH2S");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "03");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS03_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓PH2(高層給水塔)	16-27樓高層給水高塔渴水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "PH2S");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "04");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS04_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓PH2(高層飲水塔)	16-27樓高層飲用水高塔滿水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "PH2D");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "05");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS05_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓PH2(高層飲水塔)	16-27樓高層飲用水高塔渴水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "PH2D");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "06");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS06_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓19F(中層給水塔)	5-15樓中層給水高塔滿水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "19FS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "07");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS07_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓19F(中層給水塔)	5-15樓中層給水高塔渴水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "19FS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "08");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS08_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓19F(中層飲水塔)	5-15樓中層飲用水高塔滿水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "19FD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "09");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS09_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓19F(中層飲水塔)	5-15樓中層飲用水高塔渴水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "19FD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "10");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS10_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓14樓前棟(冷卻水塔)	CT12冷卻水塔水位檢知警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "14FF");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "11");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS11_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓14樓後棟(冷卻水塔)	CT11冷卻水塔水位檢知警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "14FB");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "12");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS12_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓8F(低層給水塔)	B3-4樓低層給水高塔滿水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "8FLS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "13");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS13_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓8F(低層給水塔)	B3-4樓低層給水高塔渴水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "8FLS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "14");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS14_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓8F(低層飲水塔)	B3-4樓低層飲用水高塔滿水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "8FLD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "15");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS15_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓8F(低層飲水塔)	B3-4樓低層飲用水高塔渴水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "8FLD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "16");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS16_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(高層給水泵)	16-27樓高層給水泵P1過載警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1HS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "17");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS17_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(高層給水泵)	16-27樓高層給水泵P2過載警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1HS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "18");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS18_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(高層給水池)	16-27樓高層給水水池滿水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1HP");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "19");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS19_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(高層給水池)	16-27樓高層給水水池渴水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1HP");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "20");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS20_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(高層飲水泵)	16-27樓高層飲用水泵P7過載警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1HD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "21");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS21_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(高層飲水泵)	16-27樓高層飲用水泵P8過載警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1HD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "22");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS22_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(中層給水泵)	5-15樓中層給水泵P3過載警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1MS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "23");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS23_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(中層給水泵)	5-15樓中層給水泵P4過載警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1MS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "24");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS24_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(中層給水池)	5-15樓中層給水水池滿水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1MP");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "25");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS25_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(中層給水池)	5-15樓中層給水水池渴水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1MP");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "26");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS26_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(中層飲水泵)	5-15樓中層飲用水泵P9過載警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1MD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "27");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS27_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(中層飲水泵)	5-15樓中層飲用水泵P10過載警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1MD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "28");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS28_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(低層給水泵)	B3-4樓低層給水泵P5過載警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1LS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "29");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS29_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(低層給水泵)	B3-4樓低層給水泵P6過載警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1LS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "30");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS30_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(低層給水池)	B3-4樓低層給水水池滿水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1LP");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "31");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS31_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(低層給水池)	B3-4樓低層給水水池渴水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1LP");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "32");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS32_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(低層飲水泵)	B3-4樓低層飲用水泵P11過載警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1LD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "33");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS33_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(低層飲水泵)	B3-4樓低層飲用水泵P12過載警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1LD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "34");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS34_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(飲水池)	地下層飲用水池水位上限警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1DP");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "35");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS35_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(飲水池)	地下層飲用水池水位上限警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1DP");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "36");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS36_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(飲水槽)	B307飲用水槽高水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1DS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "37");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS37_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B307室(飲水槽)	B307飲用水槽低水位警報
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B1DS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "38");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS38_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B3F(B1車道雨廢水)	廢水泵P15過載警報 (B3-12室)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B3FC");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "39");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS39_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B3F(B1車道雨廢水)	廢水泵P16過載警報 (B3-12室)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B3FC");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "40");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS40_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B3F(B1車道雨廢水)	廢水池高液位警報(B3-12室)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B3FC");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "41");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS41_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B3F(糞便)	污水泵P13過載警報(B3-24室)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B3FX");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "42");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS42_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 主樓B3F(糞便)	污水泵P14過載警報(B3-24室)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B3FX");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "43");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS43_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(飲用及給水)	副樓給水泵#1過載警報(B2-81旁房間)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "44");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS44_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(飲用及給水)	副樓給水泵#2過載警報(B2-81旁房間)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FD");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "45");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS45_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(給水塔)	副樓給水水塔高水位警報(近B1電氣斑管道間)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "46");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS46_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(給水塔)	副樓給水水塔低水位警報(近B1電氣斑管道間)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FS");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "47");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS47_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(B1以下糞水)	副樓排放泵#1過載警報(近B2-116車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FX");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "48");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS48_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(B1以下糞水)	副樓排放泵#2過載警報(近B2-116車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FX");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "49");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS49_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(B1以下糞水)	副樓排放水池高液位警報(近B2-116車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FX");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "50");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS50_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(廚房污水)	副樓污水泵#1過載警報(近B2-122車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FK");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "51");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS51_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(廚房污水)	副樓污水泵#2過載警報(近B2-122車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FK");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "52");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS52_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(雨水儲存)	    副樓廢水泵#2604過載警報(B2-81車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FR");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "53");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS53_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(雨水儲存) 	副樓廢水泵#2605過載警報(B2-81車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FR");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "54");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS54_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(雨水儲存) 	副樓廢水池高液位警報(B2-81車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FR");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "55");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS55_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(雨水離心排放)	副樓廢水泵#2606過載警報(B2-74車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FE");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "56");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS56_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(雨水離心排放)	副樓廢水泵#2607過載警報(B2-74車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FE");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "57");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS57_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion
                                    #region 副樓B2F(雨水離心排放)	副樓廢水池高液位警報(B2-74車位)
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "LOCATION", "B2FE");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "DEVICE_ID", "58");
                                    DbDSCCR.SetParameterValue(cmdDSCCR, "WSDS_PWLS_STATUS", WSDS_PWLS.WSDS58_PWLS01);
                                    affected += DbDSCCR.ExecuteNonQuery(cmdDSCCR);
                                    #endregion

                                    #endregion

                                    affected = 0;
                                    sql = @"
UPDATE WSDS_PWLS SET ACTIVE='S' WHERE AUTOID=@AUTOID AND ACTIVE='A'
";
                                    cmd.CommandText = sql;
                                    //DbDSCCR.AddInParameter(cmd, "AUTOID", DbType.Int32, WSDS_PWLSF.AUTOID);
                                    affected = DbB3BUFFER.ExecuteNonQuery(cmd);
                                    if (affected == 0)
                                    {
                                        //throw new Exception("更新ACTIVE='A'->'S'失敗 AUTOID = " + WSDS_PWLSF.AUTOID.ToString());
                                    }
                                }
                            }
                        }


                    }
                }
                scop.Complete();
            }

            return affected;
        }
    }
}

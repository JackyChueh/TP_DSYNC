using System;
using System.Collections.Generic;
using System.Diagnostics;
using TP_DSYNC.Models.DataAccess;
using TP_DSYNC.Models.DataDefine.ALERT;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using TP_DSYNC.Models.Help;

namespace TP_DSYNC.Models.Implement
{
    public class AlertImplement
    {
        //public AlertImplement(string connectionStringName) : base(connectionStringName) { }

        public List<ALERT_CONFIG> ReadAlertConfig() //DayOfWeek dayOfWeek
        {
            List<ALERT_CONFIG> rows = new List<ALERT_CONFIG>();

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database Db = factory.Create("TP_ALERT");

            string sql = @"
SELECT SID,DATA_TYPE,LOCATION,DEVICE_ID,DATA_FIELD,MAX_VALUE,MIN_VALUE,CHECK_INTERVAL,ALERT_INTERVAL
    ,SUN,SUN_STIME,SUN_ETIME,MON,MON_STIME,MON_ETIME,TUE,TUE_STIME,TUE_ETIME,WED,WED_STIME,WED_ETIME,THU,THU_STIME
    ,THU_ETIME,FRI,FRI_STIME,FRI_ETIME,STA,STA_STIME,STA_ETIME,CHECK_DATE,ALERT_DATE,MAIL_TO,CHECK_HR_CALENDAR
	FROM ALERT_CONFIG
    WHERE MODE=@MODE 
";

            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                Db.AddInParameter(cmd, "MODE", DbType.String, "Y");

                //switch (dayOfWeek)
                //{
                //    case DayOfWeek.Sunday:
                //        break;
                //    case DayOfWeek.Monday:
                //        break;
                //    case DayOfWeek.Tuesday:
                //        break;
                //    case DayOfWeek.Wednesday:
                //        break;
                //    case DayOfWeek.Thursday:
                //        break;
                //    case DayOfWeek.Friday:
                //        break;
                //    case DayOfWeek.Saturday:
                //        break;
                //}

                //cmd.CommandText = sql;

                using (IDataReader reader = Db.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        ALERT_CONFIG ALERT_CONFIG = new ALERT_CONFIG();
                        ALERT_CONFIG.SID = (int)reader["SID"];
                        //ALERT_CONFIG.MODE = (Boolean)reader["MODE"];
                        ALERT_CONFIG.DATA_TYPE = reader["DATA_TYPE"] as string;
                        ALERT_CONFIG.LOCATION = reader["LOCATION"] as string;
                        ALERT_CONFIG.DEVICE_ID = reader["DEVICE_ID"] as string;
                        ALERT_CONFIG.DATA_FIELD = reader["DATA_FIELD"] as string;
                        ALERT_CONFIG.MAX_VALUE = (Single)reader["MAX_VALUE"];
                        ALERT_CONFIG.MIN_VALUE = (Single)reader["MIN_VALUE"];
                        ALERT_CONFIG.CHECK_INTERVAL = (int)reader["CHECK_INTERVAL"];
                        //ALERT_CONFIG.ALERT_INTERVAL = (int)reader["ALERT_INTERVAL"];
                        ALERT_CONFIG.SUN = (Boolean)reader["SUN"];
                        ALERT_CONFIG.SUN_STIME = reader["SUN_STIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.SUN_ETIME = reader["SUN_ETIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.MON = (Boolean)reader["MON"];
                        ALERT_CONFIG.MON_STIME = reader["MON_STIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.MON_ETIME = reader["MON_ETIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.TUE = (Boolean)reader["TUE"];
                        ALERT_CONFIG.TUE_STIME = reader["TUE_STIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.TUE_ETIME = reader["TUE_ETIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.WED = (Boolean)reader["WED"];
                        ALERT_CONFIG.WED_STIME = reader["WED_STIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.WED_ETIME = reader["WED_ETIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.THU = (Boolean)reader["THU"];
                        ALERT_CONFIG.THU_STIME = reader["THU_STIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.THU_ETIME = reader["THU_ETIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.FRI = (Boolean)reader["FRI"];
                        ALERT_CONFIG.FRI_STIME = reader["FRI_STIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.FRI_ETIME = reader["FRI_ETIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.STA = (Boolean)reader["STA"];
                        ALERT_CONFIG.STA_STIME = reader["STA_STIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.STA_ETIME = reader["STA_ETIME"] as TimeSpan? ?? null;
                        ALERT_CONFIG.CHECK_DATE = (DateTime)reader["CHECK_DATE"];
                        ALERT_CONFIG.ALERT_DATE = (DateTime)reader["ALERT_DATE"];
                        ALERT_CONFIG.MAIL_TO = reader["MAIL_TO"] as string;
                        ALERT_CONFIG.CHECK_HR_CALENDAR = (Boolean)reader["CHECK_HR_CALENDAR"];

                        rows.Add(ALERT_CONFIG);
                    }
                }

            }

            return rows;
        }

        public string GetDateType(DateTime Now)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database Db = factory.Create("TP_DSCCR");
            string dateType = null;
            string sql = "SELECT DATE_TYPE FROM [TP_ALERT].[dbo].[HR_CALENDAR] WHERE HR_DATE=@HR_DATE";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                Db.AddInParameter(cmd, "HR_DATE", DbType.DateTime);

                Db.SetParameterValue(cmd, "HR_DATE", new DateTime(Now.Year, Now.Month, Now.Day));
                cmd.CommandText = sql;
                using (IDataReader reader = Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        dateType = reader["DATE_TYPE"] as string;

                    }
                }

            }
            return dateType;
        }

        public Single? ReadFieldValue(ALERT_CONFIG c)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database Db = factory.Create("TP_DSCCR");

            Single? value = null;
            string sql = "SELECT TOP 1 {0} FROM {1} WHERE LOCATION=@LOCATION AND DEVICE_ID=@DEVICE_ID ORDER BY DATETIME DESC";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                sql = string.Format(sql, c.DATA_FIELD, c.DATA_TYPE);
                Db.AddInParameter(cmd, "LOCATION", DbType.String, c.LOCATION);
                Db.AddInParameter(cmd, "DEVICE_ID", DbType.String, c.DEVICE_ID);
                cmd.CommandText = sql;

                using (IDataReader reader = Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        value = reader[c.DATA_FIELD] as Single? ?? null;
                    }
                }

            }
            return value;
        }

        public void WriteAlertInfo(ALERT_CONFIG c, Single? value, DateTime Now)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database Db = factory.Create("TP_ALERT");

            using (DbConnection conn = Db.CreateConnection())
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    string sql = "UPDATE ALERT_LOG SET CHECK_DATE=@CHECK_DATE WHERE SID=@SID";
                    Db.AddInParameter(cmd, "CHECK_DATE", DbType.DateTime, Now);
                    Db.AddInParameter(cmd, "SID", DbType.Int32, c.SID);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }

                using (DbCommand cmd = Db.CreateConnection().CreateCommand())
                {
                    string sql = @"
SET @SID = NEXT VALUE FOR [ALERT_LOG_SEQ]
INSERT ALERT_LOG (
    SID,DATA_TYPE,LOCATION,DEVICE_ID,DATA_FIELD,MAX_VALUE,MIN_VALUE,ALERT_VALUE,CHECK_DATE
    )
VALUES (
    @SID,@DATA_TYPE,@LOCATION,@DEVICE_ID,@DATA_FIELD,@MAX_VALUE,@MIN_VALUE,@ALERT_VALUE,@CHECK_DATE
    );
                ";

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;

                    Db.AddInParameter(cmd, "DATA_TYPE", DbType.String, c.DATA_TYPE);
                    Db.AddInParameter(cmd, "LOCATION", DbType.String, c.LOCATION);
                    Db.AddInParameter(cmd, "DEVICE_ID", DbType.String, c.DEVICE_ID);
                    Db.AddInParameter(cmd, "DATA_FIELD", DbType.String, c.DATA_FIELD);
                    Db.AddInParameter(cmd, "MAX_VALUE", DbType.Single, c.MAX_VALUE);
                    Db.AddInParameter(cmd, "MIN_VALUE", DbType.Single, c.MIN_VALUE);
                    Db.AddInParameter(cmd, "ALERT_VALUE", DbType.Single, value);
                    Db.AddInParameter(cmd, "CHECK_DATE", DbType.Date, Now);
                    Db.AddOutParameter(cmd, "SID", DbType.Int32, 1);

                    int effect = Db.ExecuteNonQuery(cmd);
                }

            }
        }

        public void UpdateAlertDate(ALERT_CONFIG c, DateTime Now)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database Db = factory.Create("TP_ALERT");

            using (DbConnection conn = Db.CreateConnection())
            {
                conn.Open();
                using (DbCommand cmd = conn.CreateCommand())
                {
                    string sql = "UPDATE ALERT_CONFIG SET ALERT_DATE=@ALERT_DATE WHERE SID=@SID";
                    Db.AddInParameter(cmd, "ALERT_DATE", DbType.DateTime, Now);
                    Db.AddInParameter(cmd, "SID", DbType.Int32, c.SID);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SendAlertMessage(ALERT_CONFIG c, Single? value)
        {
            ALERT_LOG r = GetPhraseName(c, value);
            string title = "Title";
            string message = r.DATA_TYPE + " " + r.LOCATION + " " + r.DEVICE_ID + ", " + r.DATA_FIELD + "=" + r.ALERT_VALUE;
            //new MailSender().Google_Send(to, "Title", value.ToString());
            
            Logs.Write("MAIL ALERT", "{0} {1}", title, message);
        }

        public ALERT_LOG GetPhraseName(ALERT_CONFIG c, Single? value)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database Db = factory.Create("TP_SCC");

            ALERT_LOG r = new ALERT_LOG();

            string sql = @"
SELECT [dbo].[PHRASE_NAME]('DATA_TYPE',@DATA_TYPE,default) AS DATA_TYPE
	,[dbo].[PHRASE_NAME](@DATA_TYPE+'_LOCATION',@LOCATION,@DATA_TYPE) AS LOCATION
	,[dbo].[PHRASE_NAME](@DATA_TYPE+'_DEVICE_ID',@DEVICE_ID,@LOCATION) AS DEVICE_ID
	,[dbo].[PHRASE_NAME](@DATA_TYPE+'_DATA_FIELD',@DATA_FIELD,@DATA_TYPE) AS DATA_FIELD
    ,[dbo].[DATA_NAME] (@DATA_TYPE,@LOCATION,@DATA_FIELD,@MAX_VALUE) AS MAX_VALUE
    ,[dbo].[DATA_NAME] (@DATA_TYPE,@LOCATION,@DATA_FIELD,@MIN_VALUE) AS MIN_VALUE
    ,[dbo].[DATA_NAME] (@DATA_TYPE,@LOCATION,@DATA_FIELD,@ALERT_VALUE) AS ALERT_VALUE
";
            using (DbCommand cmd = Db.GetSqlStringCommand(sql))
            {
                Db.AddInParameter(cmd, "DATA_TYPE", DbType.String, c.DATA_TYPE);
                Db.AddInParameter(cmd, "LOCATION", DbType.String, c.LOCATION);
                Db.AddInParameter(cmd, "DEVICE_ID", DbType.String, c.DEVICE_ID);
                Db.AddInParameter(cmd, "DATA_FIELD", DbType.String, c.DATA_FIELD);
                Db.AddInParameter(cmd, "MAX_VALUE", DbType.Single, c.MAX_VALUE);
                Db.AddInParameter(cmd, "MIN_VALUE", DbType.Single, c.MIN_VALUE);
                Db.AddInParameter(cmd, "ALERT_VALUE", DbType.Single, value);
                cmd.CommandText = sql;

                using (IDataReader reader = Db.ExecuteReader(cmd))
                {
                    if (reader.Read())
                    {
                        //value = reader[c.DATA_FIELD] as Single? ?? null;
                        r.DATA_TYPE = reader["DATA_TYPE"] as string;
                        r.LOCATION = reader["LOCATION"] as string;
                        r.DEVICE_ID = reader["DEVICE_ID"] as string;
                        r.DATA_FIELD = reader["DATA_FIELD"] as string;
                        r.MAX_VALUE = reader["MAX_VALUE"] as string;
                        r.MIN_VALUE = reader["MIN_VALUE"] as string;
                        r.ALERT_VALUE = reader["ALERT_VALUE"] as string;
                    }
                    else
                    {
                        r.DATA_TYPE = c.DATA_TYPE.ToString();
                        r.LOCATION = c.LOCATION.ToString();
                        r.DEVICE_ID = c.DEVICE_ID.ToString();
                        r.DATA_FIELD = c.DATA_FIELD.ToString();
                        r.MAX_VALUE = c.MAX_VALUE.ToString();
                        r.MIN_VALUE = c.MIN_VALUE.ToString();
                        r.ALERT_VALUE = value.ToString();
                    }
                }
            }
            return r;
        }


        public bool CheckDayOfWeek(ALERT_CONFIG c, string DateType)
        {
            DayOfWeek dayOfWeek = DateTime.Today.DayOfWeek;
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = new TimeSpan(now.Hour, now.Minute, now.Second);
            #region 判斷日期與時間是否應該被執行
            bool yn = false;
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    if (c.SUN)  //星期日是否要進行檢查
                    {
                        yn = true;
                        if (c.CHECK_HR_CALENDAR && DateType == "H") //是否比對行事曆&&是否為放假日
                        {
                            yn = false;
                        }
                    }
                    else
                    {
                        yn = false;
                        if (c.CHECK_HR_CALENDAR && DateType == "W")//是否比對行事曆&&是否為工作日
                        {
                            yn = true;
                        }
                    }
                    if (yn)
                    {
                        //是否在必需檢查的時間起迄內
                        if (timeSpan.CompareTo(c.SUN_STIME) < 1 || timeSpan.CompareTo(c.SUN_ETIME) > -1)
                        {
                            yn = false;
                        }
                    }
                    break;
                case DayOfWeek.Monday:
                    if (c.MON)
                    {
                        yn = true;
                        if (c.CHECK_HR_CALENDAR && DateType == "H")
                        {
                            yn = false;
                        }
                    }
                    else
                    {
                        yn = false;
                        if (c.CHECK_HR_CALENDAR && DateType == "W")
                        {
                            yn = true;
                        }
                    }
                    if (yn)
                    {
                        if (timeSpan.CompareTo(c.MON_STIME) < 1 || timeSpan.CompareTo(c.MON_ETIME) > -1)
                        {
                            yn = false;
                        }
                    }
                    break;
                case DayOfWeek.Tuesday:
                    if (c.TUE)
                    {
                        yn = true;
                        if (c.CHECK_HR_CALENDAR && DateType == "H")
                        {
                            yn = false;
                        }
                    }
                    else
                    {
                        yn = false;
                        if (c.CHECK_HR_CALENDAR && DateType == "W")
                        {
                            yn = true;
                        }
                    }
                    if (yn)
                    {
                        if (timeSpan.CompareTo(c.TUE_STIME) < 1 || timeSpan.CompareTo(c.TUE_ETIME) > -1)
                        {
                            yn = false;
                        }
                    }
                    break;
                case DayOfWeek.Wednesday:
                    if (c.WED)
                    {
                        yn = true;
                        if (c.CHECK_HR_CALENDAR && DateType == "H")
                        {
                            yn = false;
                        }
                    }
                    else
                    {
                        yn = false;
                        if (c.CHECK_HR_CALENDAR && DateType == "W")
                        {
                            yn = true;
                        }
                    }
                    if (yn)
                    {
                        if (timeSpan.CompareTo(c.WED_STIME) < 1 || timeSpan.CompareTo(c.WED_ETIME) > -1)
                        {
                            yn = false;
                        }
                    }
                    break;
                case DayOfWeek.Thursday:
                    if (c.THU)
                    {
                        yn = true;
                        if (c.CHECK_HR_CALENDAR && DateType == "H")
                        {
                            yn = false;
                        }
                    }
                    else
                    {
                        yn = false;
                        if (c.CHECK_HR_CALENDAR && DateType == "W")
                        {
                            yn = true;
                        }
                    }
                    if (yn)
                    {
                        if (timeSpan.CompareTo(c.THU_STIME) < 1 || timeSpan.CompareTo(c.THU_ETIME) > -1)
                        {
                            yn = false;
                        }
                    }
                    break;
                case DayOfWeek.Friday:
                    if (c.FRI)
                    {
                        yn = true;
                        if (c.CHECK_HR_CALENDAR && DateType == "H")
                        {
                            yn = false;
                        }
                    }
                    else
                    {
                        yn = false;
                        if (c.CHECK_HR_CALENDAR && DateType == "W")
                        {
                            yn = true;
                        }
                    }
                    if (yn)
                    {
                        if (timeSpan.CompareTo(c.FRI_STIME) < 1 || timeSpan.CompareTo(c.FRI_ETIME) > -1)
                        {
                            yn = false;
                        }
                    }
                    break;
                case DayOfWeek.Saturday:
                    if (c.STA)
                    {
                        yn = true;
                        if (c.CHECK_HR_CALENDAR && DateType == "H")
                        {
                            yn = false;
                        }
                    }
                    else
                    {
                        yn = false;
                        if (c.CHECK_HR_CALENDAR && DateType == "W")
                        {
                            yn = true;
                        }
                    }
                    if (yn)
                    {
                        if (timeSpan.CompareTo(c.STA_STIME) < 1 || timeSpan.CompareTo(c.STA_ETIME) > -1)
                        {
                            yn = false;
                        }
                    }
                    break;
            }
            #endregion
            return yn;
        }

        //public void CheckConfig(List<ALERT_CONFIG> Config)
        //{
        //    DayOfWeek dayOfWeek = DateTime.Today.DayOfWeek;
        //    DateTime now = DateTime.Now;
        //    TimeSpan timeSpan = new TimeSpan(now.Hour, now.Minute, now.Second);
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    Database Db = factory.Create("TP_DSCCR");

        //    using (DbConnection conn = Db.CreateConnection())
        //    {
        //        string dateType = null;
        //        using (DbCommand cmd = conn.CreateCommand())
        //        {
        //            Db.AddInParameter(cmd, "HR_DATE", DbType.DateTime);
        //            string sql = "SELECT DATE_TYPE FROM [TP_ALERT].[dbo].[HR_CALENDAR] WHERE HR_DATE=@HR_DATE";
        //            Db.SetParameterValue(cmd, "HR_DATE", new DateTime(now.Year, now.Month, now.Day));
        //            cmd.CommandText = sql;
        //            using (IDataReader reader = Db.ExecuteReader(cmd))
        //            {
        //                if (reader.Read())
        //                {
        //                    dateType = reader["DATE_TYPE"] as string;

        //                }
        //            }
        //        }

        //        using (DbCommand cmd = conn.CreateCommand())
        //        {
        //            Db.AddInParameter(cmd, "LOCATION", DbType.String);
        //            Db.AddInParameter(cmd, "DEVICE_ID", DbType.String);

        //            foreach (ALERT_CONFIG c in Config)
        //            {
        //                #region 判斷日期與時間是否應該被執行
        //                bool yn;
        //                switch (dayOfWeek)
        //                {
        //                    case DayOfWeek.Sunday:
        //                        if (c.SUN)  //星期日是否要進行檢查
        //                        {
        //                            yn = true;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "H") //是否比對行事曆&&是否為放假日
        //                            {
        //                                yn = false;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            yn = false;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "W")//是否比對行事曆&&是否為工作日
        //                            {
        //                                yn = true;
        //                            }
        //                        }
        //                        if (yn)
        //                        {
        //                            //是否在必需檢查的時間起迄內
        //                            if (timeSpan.CompareTo(c.SUN_STIME) < 1 || timeSpan.CompareTo(c.SUN_ETIME) > -1)
        //                            {
        //                                continue;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            continue;
        //                        }
        //                        break;
        //                    case DayOfWeek.Monday:
        //                        if (c.MON)
        //                        {
        //                            yn = true;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "H")
        //                            {
        //                                yn = false;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            yn = false;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "W")
        //                            {
        //                                yn = true;
        //                            }
        //                        }
        //                        if (yn)
        //                        {
        //                            if (timeSpan.CompareTo(c.MON_STIME) < 1 || timeSpan.CompareTo(c.MON_ETIME) > -1)
        //                            {
        //                                continue;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            continue;
        //                        }
        //                        break;
        //                    case DayOfWeek.Tuesday:
        //                        if (c.TUE)
        //                        {
        //                            yn = true;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "H")
        //                            {
        //                                yn = false;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            yn = false;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "W")
        //                            {
        //                                yn = true;
        //                            }
        //                        }
        //                        if (yn)
        //                        {
        //                            if (timeSpan.CompareTo(c.TUE_STIME) < 1 || timeSpan.CompareTo(c.TUE_ETIME) > -1)
        //                            {
        //                                continue;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            continue;
        //                        }
        //                        break;
        //                    case DayOfWeek.Wednesday:
        //                        if (c.WED)
        //                        {
        //                            yn = true;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "H")
        //                            {
        //                                yn = false;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            yn = false;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "W")
        //                            {
        //                                yn = true;
        //                            }
        //                        }
        //                        if (yn)
        //                        {
        //                            if (timeSpan.CompareTo(c.WED_STIME) < 1 || timeSpan.CompareTo(c.WED_ETIME) > -1)
        //                            {
        //                                continue;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            continue;
        //                        }
        //                        break;
        //                    case DayOfWeek.Thursday:
        //                        if (c.THU)
        //                        {
        //                            yn = true;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "H")
        //                            {
        //                                yn = false;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            yn = false;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "W")
        //                            {
        //                                yn = true;
        //                            }
        //                        }
        //                        if (yn)
        //                        {
        //                            if (timeSpan.CompareTo(c.THU_STIME) < 1 || timeSpan.CompareTo(c.THU_ETIME) > -1)
        //                            {
        //                                continue;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            continue;
        //                        }
        //                        break;
        //                    case DayOfWeek.Friday:
        //                        if (c.FRI)
        //                        {
        //                            yn = true;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "H")
        //                            {
        //                                yn = false;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            yn = false;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "W")
        //                            {
        //                                yn = true;
        //                            }
        //                        }
        //                        if (yn)
        //                        {
        //                            if (timeSpan.CompareTo(c.FRI_STIME) < 1 || timeSpan.CompareTo(c.FRI_ETIME) > -1)
        //                            {
        //                                continue;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            continue;
        //                        }
        //                        break;
        //                    case DayOfWeek.Saturday:
        //                        if (c.STA)
        //                        {
        //                            yn = true;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "H")
        //                            {
        //                                yn = false;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            yn = false;
        //                            if (c.CHECK_HR_CALENDAR && dateType == "W")
        //                            {
        //                                yn = true;
        //                            }
        //                        }
        //                        if (yn)
        //                        {
        //                            if (timeSpan.CompareTo(c.STA_STIME) < 1 || timeSpan.CompareTo(c.STA_ETIME) > -1)
        //                            {
        //                                continue;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            continue;
        //                        }
        //                        break;
        //                }
        //                #endregion

        //                if (c.CHECK_DATE.AddMinutes(c.CHECK_INTERVAL) > now)
        //                {
        //                    continue;
        //                }

        //                string sql = "SELECT TOP 1 {0} FROM {1} WHERE LOCATION=@LOCATION AND DEVICE_ID=@DEVICE_ID ORDER BY DATETIME DESC";
        //                sql = string.Format(sql, c.DATA_FIELD, c.DATA_TYPE);
        //                Db.SetParameterValue(cmd, "LOCATION", c.LOCATION);
        //                Db.SetParameterValue(cmd, "DEVICE_ID", c.DEVICE_ID);
        //                cmd.CommandText = sql;

        //                Single? value = null;
        //                using (IDataReader reader = Db.ExecuteReader(cmd))
        //                {
        //                    if (reader.Read())
        //                    {
        //                        value = reader[c.DATA_FIELD] as Single? ?? null;
        //                    }
        //                }

        //                //Database Db2 = factory.Create("TP_DSCCR");
        //                //DbConnection conn2 = Db2.CreateConnection();
        //                if (value == null || value > c.MAX_VALUE || value < c.MIN_VALUE)
        //                {
        //                    using (DbCommand cmd2 = conn.CreateCommand())
        //                    {
        //                        sql = "UPDATE ALERT_CONFIG SET CHECK_DATE=@CHECK_DATE WHERE SID=@SID";
        //                        Db.AddInParameter(cmd2, "CHECK_DATE", DbType.DateTime, now);
        //                        Db.AddInParameter(cmd2, "SID", DbType.Int32, c.SID);
        //                        cmd2.CommandText = sql;
        //                        cmd2.ExecuteNonQuery();
        //                    }
        //                    //test(now, c.SID);
        //                    //string[] to = new string[] { "jackychueh@gmail.com" };
        //                    string[] to = c.MAIL_TO.Split(';');
        //                    if (to.Length > 0)
        //                    {
        //                        if (c.ALERT_DATE.AddMinutes(c.ALERT_INTERVAL) < now)
        //                        {
        //                            string title = "Title";
        //                            string message = c.DATA_TYPE + " " + c.LOCATION + " " + c.DEVICE_ID + ", " + c.DATA_FIELD + "=" + value.ToString();
        //                            //new MailSender().Google_Send(to, "Title", value.ToString());
        //                            Logs.Write("ALERT", "{0} {1}", title, message);

        //                            //using (DbCommand cmd2 = conn2.CreateCommand())
        //                            //{
        //                            //    sql = "UPDATE ALERT_CONFIG SET ALERT_DATE=@ALERT_DATE WHERE SID=@SID";
        //                            //    Db2.AddInParameter(cmd2, "CHECK_DATE", DbType.DateTime, now);
        //                            //    Db2.AddInParameter(cmd2, "SID", DbType.Int32, c.SID);
        //                            //    cmd2.CommandText = sql;
        //                            //    cmd2.ExecuteNonQuery();
        //                            //}
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //}
    
    }
}

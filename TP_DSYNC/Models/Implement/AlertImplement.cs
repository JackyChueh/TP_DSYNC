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

            using (DbConnection conn = Db.CreateConnection())
            {
                using (DbCommand cmd = conn.CreateCommand())
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

                    cmd.CommandText = sql;

                    using (IDataReader reader = Db.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            ALERT_CONFIG ALERT_CONFIG = new ALERT_CONFIG()
                            {
                                SID = (int)reader["SID"],
                                //MODE = (Boolean)reader["MODE"],
                                DATA_TYPE = reader["DATA_TYPE"] as string,
                                LOCATION = reader["LOCATION"] as string,
                                DEVICE_ID = reader["DEVICE_ID"] as string,
                                DATA_FIELD = reader["DATA_FIELD"] as string,
                                MAX_VALUE = (Single)reader["MAX_VALUE"],
                                MIN_VALUE = (Single)reader["MIN_VALUE"],
                                CHECK_INTERVAL = (int)reader["CHECK_INTERVAL"],
                                ALERT_INTERVAL = (int)reader["ALERT_INTERVAL"],
                                SUN = (Boolean)reader["SUN"],
                                SUN_STIME = (TimeSpan)reader["SUN_STIME"],
                                SUN_ETIME = (TimeSpan)reader["SUN_ETIME"],
                                MON = (Boolean)reader["MON"],
                                MON_STIME = (TimeSpan)reader["MON_STIME"],
                                MON_ETIME = (TimeSpan)reader["MON_ETIME"],
                                TUE = (Boolean)reader["TUE"],
                                TUE_STIME = (TimeSpan)reader["TUE_STIME"],
                                TUE_ETIME = (TimeSpan)reader["TUE_ETIME"],
                                WED = (Boolean)reader["WED"],
                                WED_STIME = (TimeSpan)reader["WED_STIME"],
                                WED_ETIME = (TimeSpan)reader["WED_ETIME"],
                                THU = (Boolean)reader["THU"],
                                THU_STIME = (TimeSpan)reader["THU_STIME"],
                                THU_ETIME = (TimeSpan)reader["THU_ETIME"],
                                FRI = (Boolean)reader["FRI"],
                                FRI_STIME = (TimeSpan)reader["FRI_STIME"],
                                FRI_ETIME = (TimeSpan)reader["FRI_ETIME"],
                                STA = (Boolean)reader["STA"],
                                STA_STIME = (TimeSpan)reader["STA_STIME"],
                                STA_ETIME = (TimeSpan)reader["STA_ETIME"],
                                CHECK_DATE = (DateTime)reader["CHECK_DATE"],
                                ALERT_DATE = (DateTime)reader["ALERT_DATE"],
                                MAIL_TO = reader["MAIL_TO"] as string,
                                CHECK_HR_CALENDAR = (Boolean)reader["CHECK_HR_CALENDAR"],
                            };

                            rows.Add(ALERT_CONFIG);
                        }
                    }
                }
            }

            return rows;
        }

        public void CheckConfig(List<ALERT_CONFIG> Config)
        {
            DayOfWeek dayOfWeek = DateTime.Today.DayOfWeek;
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = new TimeSpan(now.Hour, now.Minute, now.Second);
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database Db = factory.Create("TP_DSCCR");

            using (DbConnection conn = Db.CreateConnection())
            {
                string dateType = null;
                using (DbCommand cmd = conn.CreateCommand())
                {
                    Db.AddInParameter(cmd, "HR_DATE", DbType.DateTime);
                    string sql = "SELECT DATE_TYPE FROM [TP_ALERT].[dbo].[HR_CALENDAR] WHERE HR_DATE=@HR_DATE";
                    Db.SetParameterValue(cmd, "HR_DATE", new DateTime(now.Year, now.Month, now.Day));
                    cmd.CommandText = sql;
                    using (IDataReader reader = Db.ExecuteReader(cmd))
                    {
                        if (reader.Read())
                        {
                            dateType = reader["DATE_TYPE"] as string;

                        }
                    }
                }

                using (DbCommand cmd = conn.CreateCommand())
                {
                    Db.AddInParameter(cmd, "LOCATION", DbType.String);
                    Db.AddInParameter(cmd, "DEVICE_ID", DbType.String);

                    foreach (ALERT_CONFIG c in Config)
                    {
                        #region 判斷日期與時間是否應該被執行
                        bool yn;
                        switch (dayOfWeek)
                        {
                            case DayOfWeek.Sunday:
                                if (c.SUN)  //星期日是否要進行檢查
                                {
                                    yn = true;
                                    if (c.CHECK_HR_CALENDAR && dateType == "H") //是否比對行事曆&&是否為放假日
                                    {
                                        yn = false;
                                    }
                                }
                                else
                                {
                                    yn = false;
                                    if (c.CHECK_HR_CALENDAR && dateType == "W")//是否比對行事曆&&是否為工作日
                                    {
                                        yn = true;
                                    }
                                }
                                if (yn)
                                {
                                    //是否在必需檢查的時間起迄內
                                    if (timeSpan.CompareTo(c.SUN_STIME) < 1 || timeSpan.CompareTo(c.SUN_ETIME) > -1)
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                                break;
                            case DayOfWeek.Monday:
                                if (c.MON)
                                {
                                    yn = true;
                                    if (c.CHECK_HR_CALENDAR && dateType == "H")
                                    {
                                        yn = false;
                                    }
                                }
                                else
                                {
                                    yn = false;
                                    if (c.CHECK_HR_CALENDAR && dateType == "W")
                                    {
                                        yn = true;
                                    }
                                }
                                if (yn)
                                {
                                    if (timeSpan.CompareTo(c.MON_STIME) < 1 || timeSpan.CompareTo(c.MON_ETIME) > -1)
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                                break;
                            case DayOfWeek.Tuesday:
                                if (c.TUE)
                                {
                                    yn = true;
                                    if (c.CHECK_HR_CALENDAR && dateType == "H")
                                    {
                                        yn = false;
                                    }
                                }
                                else
                                {
                                    yn = false;
                                    if (c.CHECK_HR_CALENDAR && dateType == "W")
                                    {
                                        yn = true;
                                    }
                                }
                                if (yn)
                                {
                                    if (timeSpan.CompareTo(c.TUE_STIME) < 1 || timeSpan.CompareTo(c.TUE_ETIME) > -1)
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                                break;
                            case DayOfWeek.Wednesday:
                                if (c.WED)
                                {
                                    yn = true;
                                    if (c.CHECK_HR_CALENDAR && dateType == "H")
                                    {
                                        yn = false;
                                    }
                                }
                                else
                                {
                                    yn = false;
                                    if (c.CHECK_HR_CALENDAR && dateType == "W")
                                    {
                                        yn = true;
                                    }
                                }
                                if (yn)
                                {
                                    if (timeSpan.CompareTo(c.WED_STIME) < 1 || timeSpan.CompareTo(c.WED_ETIME) > -1)
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                                break;
                            case DayOfWeek.Thursday:
                                if (c.THU)
                                {
                                    yn = true;
                                    if (c.CHECK_HR_CALENDAR && dateType == "H")
                                    {
                                        yn = false;
                                    }
                                }
                                else
                                {
                                    yn = false;
                                    if (c.CHECK_HR_CALENDAR && dateType == "W")
                                    {
                                        yn = true;
                                    }
                                }
                                if (yn)
                                {
                                    if (timeSpan.CompareTo(c.THU_STIME) < 1 || timeSpan.CompareTo(c.THU_ETIME) > -1)
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                                break;
                            case DayOfWeek.Friday:
                                if (c.FRI)
                                {
                                    yn = true;
                                    if (c.CHECK_HR_CALENDAR && dateType == "H")
                                    {
                                        yn = false;
                                    }
                                }
                                else
                                {
                                    yn = false;
                                    if (c.CHECK_HR_CALENDAR && dateType == "W")
                                    {
                                        yn = true;
                                    }
                                }
                                if (yn)
                                {
                                    if (timeSpan.CompareTo(c.FRI_STIME) < 1 || timeSpan.CompareTo(c.FRI_ETIME) > -1)
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                                break;
                            case DayOfWeek.Saturday:
                                if (c.STA)
                                {
                                    yn = true;
                                    if (c.CHECK_HR_CALENDAR && dateType == "H")
                                    {
                                        yn = false;
                                    }
                                }
                                else
                                {
                                    yn = false;
                                    if (c.CHECK_HR_CALENDAR && dateType == "W")
                                    {
                                        yn = true;
                                    }
                                }
                                if (yn)
                                {
                                    if (timeSpan.CompareTo(c.STA_STIME) < 1 || timeSpan.CompareTo(c.STA_ETIME) > -1)
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                                break;
                        }
                        #endregion

                        if (c.CHECK_DATE.AddMinutes(c.CHECK_INTERVAL) > now)
                        {
                            continue;
                        }

                        string sql = "SELECT TOP 1 {0} FROM {1} WHERE LOCATION=@LOCATION AND DEVICE_ID=@DEVICE_ID ORDER BY DATETIME DESC";
                        sql = string.Format(sql, c.DATA_FIELD, c.DATA_TYPE);
                        Db.SetParameterValue(cmd, "LOCATION", c.LOCATION);
                        Db.SetParameterValue(cmd, "DEVICE_ID", c.DEVICE_ID);
                        cmd.CommandText = sql;

                        Single? value = null;
                        using (IDataReader reader = Db.ExecuteReader(cmd))
                        {
                            if (reader.Read())
                            {
                                value = reader[c.DATA_FIELD] as Single? ?? null;
                            }
                        }

                        //Database Db2 = factory.Create("TP_DSCCR");
                        //DbConnection conn2 = Db2.CreateConnection();
                        if (value == null || value > c.MAX_VALUE || value < c.MIN_VALUE)
                        {
                            using (DbCommand cmd2 = conn.CreateCommand())
                            {
                                sql = "UPDATE ALERT_CONFIG SET CHECK_DATE=@CHECK_DATE WHERE SID=@SID";
                                Db.AddInParameter(cmd2, "CHECK_DATE", DbType.DateTime, now);
                                Db.AddInParameter(cmd2, "SID", DbType.Int32, c.SID);
                                cmd2.CommandText = sql;
                                cmd2.ExecuteNonQuery();
                            }
                            //test(now, c.SID);
                            //string[] to = new string[] { "jackychueh@gmail.com" };
                            string[] to = c.MAIL_TO.Split(';');
                            if (to.Length > 0)
                            {
                                if (c.ALERT_DATE.AddMinutes(c.ALERT_INTERVAL) < now)
                                {
                                    string title = "Title";
                                    string message = c.DATA_TYPE + " " + c.LOCATION + " " + c.DEVICE_ID + ", " + c.DATA_FIELD + "=" + value.ToString();
                                    //new MailSender().Google_Send(to, "Title", value.ToString());
                                    Logs.Write("ALERT", "{0} {1}", title, message);

                                    //using (DbCommand cmd2 = conn2.CreateCommand())
                                    //{
                                    //    sql = "UPDATE ALERT_CONFIG SET ALERT_DATE=@ALERT_DATE WHERE SID=@SID";
                                    //    Db2.AddInParameter(cmd2, "CHECK_DATE", DbType.DateTime, now);
                                    //    Db2.AddInParameter(cmd2, "SID", DbType.Int32, c.SID);
                                    //    cmd2.CommandText = sql;
                                    //    cmd2.ExecuteNonQuery();
                                    //}
                                }
                            }
                        }
                    }
                }
            }

        }

        public void test(DateTime now, int SID)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database Db2 = factory.Create("TP_ALERT");
            DbConnection conn2 = Db2.CreateConnection();
            using (DbCommand cmd2 = conn2.CreateCommand())
            {
                string sql = "UPDATE ALERT_CONFIG SET CHECK_DATE=@CHECK_DATE WHERE SID=@SID";
                Db2.AddInParameter(cmd2, "CHECK_DATE", DbType.DateTime, now);
                Db2.AddInParameter(cmd2, "SID", DbType.Int32, SID);
                cmd2.CommandText = sql;
                cmd2.ExecuteNonQuery();
            }
        }
    }
}

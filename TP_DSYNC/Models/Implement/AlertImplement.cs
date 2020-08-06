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
    ,THU_ETIME,FRI,FRI_STIME,FRI_ETIME,STA,STA_STIME,STA_ETIME,CHECK_DATE,ALERT_DATE,MAIL_TO
	FROM ALERT_CONFIG
    WHERE MODE=@MODE 
";

            using (DbConnection conn = Db.CreateConnection())
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    Db.AddInParameter(cmd, "MODE", DbType.Boolean, true);

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
                                //MODE = (Boolean)reader["MODE"],
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
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database Db = factory.Create("TP_DSCCR");

            using (DbConnection conn = Db.CreateConnection())
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    Db.AddInParameter(cmd, "LOCATION", DbType.String);
                    Db.AddInParameter(cmd, "DEVICE_ID", DbType.String);

                    foreach (ALERT_CONFIG c in Config)
                    {
                        string sql = "SELECT TOP 1 {0} FROM {1} WHERE LOCATION=@LOCATION AND DEVICE_ID=@DEVICE_ID ORDER BY DATETIME DESC";
                        sql = string.Format(sql, c.DATA_FIELD, c.DATA_TYPE);
                        Db.SetParameterValue(cmd, "LOCATION", c.LOCATION);
                        Db.SetParameterValue(cmd, "DEVICE_ID", c.DEVICE_ID);

                        cmd.CommandText = sql;

                        using (IDataReader reader = Db.ExecuteReader(cmd))
                        {
                            while (reader.Read())
                            {
                                Single value = (Single)reader[c.DATA_FIELD];
                                if (value > c.MAX_VALUE || value < c.MIN_VALUE)
                                { 
                                    new MailSender().Google_Send()
                                }
                                //rows.Add(ALERT_CONFIG);
                            }
                        }
                    }
                }
            }


        }
        
    }
}
